namespace Chess;

public static class Board {
  public const int START_TIMER = 300;
  public static int[] Square { get; set; } = new int[64];
  public static int[] SquareCopy { get; set; } = new int[64];
  public static bool WhiteToMove { get; set; } = true;
  public static int ColorToMove { get => WhiteToMove ? Piece.White : Piece.Black; }
  public static bool WhiteCastleKingSide { get; set; } = true;
  public static bool WhiteCastleQueenSide { get; set; } = true;
  public static bool BlackCastleKingSide { get; set; } = true;
  public static bool BlackCastleQueenSide { get; set; } = true;
  public static string[] SquareNames { get; } = new string[64];
  public static int EnPassantSquare { get; set; } = -1;
  public static int HalfMoveClock { get; set; }
  public static int WhiteTimer { get; set; } = START_TIMER;
  public static int BlackTimer { get; set; } = START_TIMER;
  public static int PromotionSquare { get; set; } = -1;
  public static bool TimerIsRunning { get; set; } = true;

  static Board() {
    const string files = "abcdefgh";

    for (var rank = 0; rank < 8; rank++) {
      for (var file = 0; file < 8; file++) SquareNames[ConvertFileAndRankToIndex(rank, file)] = $"{files[file]}{rank + 1}";
    }
  }

  public static int GetRankFromIndex(int index) => index >> 3;

  public static int ConvertFileAndRankToIndex(int file, int rank) => file + rank * 8;

  private static string GetTimeString(int time) => TimeSpan.FromSeconds(time).ToString(@"mm\:ss");
  public static void DecrementTimer() {
    if (!TimerIsRunning) return;

    if (WhiteToMove) WhiteTimer--;
    else BlackTimer--;

    (BoardUI.Data.WhiteTimer, BoardUI.Data.BlackTimer) = (GetTimeString(WhiteTimer), GetTimeString(BlackTimer));
  }

  public static void MakeMove(Move move) {
    if (move.Value == Move.InvalidMove) return;

    var friendlyKingStartLocation = Array.IndexOf(Square, Piece.King | (WhiteToMove ? Piece.White : Piece.Black));
    BoardUI.Tiles[friendlyKingStartLocation].DrawPiece();

    if (move.TargetSquare is 0) WhiteCastleQueenSide = false;
    if (move.TargetSquare is 7) WhiteCastleKingSide = false;
    if (move.TargetSquare is 56) BlackCastleQueenSide = false;
    if (move.TargetSquare is 63) BlackCastleKingSide = false;

    HandleFlaggedMove(move);

    if (move.MoveFlag is Move.Flag.Castling) {
      if (WhiteToMove) WhiteCastleQueenSide = WhiteCastleKingSide = false;
      else BlackCastleQueenSide = BlackCastleKingSide = false;
    }

    if (Piece.Type(Piece.At(move.StartSquare)) is Piece.Rook or Piece.King) DisableCastling(move);

    Square[move.TargetSquare] = Piece.At(move.StartSquare);
    Square[move.StartSquare] = Piece.None;

    BoardUI.Tiles[move.StartSquare].DrawPiece();
    BoardUI.Tiles[move.TargetSquare].DrawPiece();
 
    if (!WhiteToMove) HalfMoveClock++;

    WhiteToMove = !WhiteToMove;
    if (move.MoveFlag is not Move.Flag.Promotion) BoardUI.Data.GameText = $"{(WhiteToMove ? "White" : "Black")} to move";

    if (HalfMoveClock is 100) {
      TimerIsRunning = false;
      BoardUI.Data.GameText = "Draw";
    }
  }

  public static void MakeTestMove(Move move) {
    SquareCopy = (int[]) Square.Clone();

    var enPassantTemp = EnPassantSquare;
    if (move.MoveFlag is not Move.Flag.Promotion) HandleFlaggedMove(move);
    EnPassantSquare = enPassantTemp;

    Square[move.TargetSquare] = Piece.At(move.StartSquare);
    Square[move.StartSquare] = Piece.None;
  }

  public static void UndoTestMove() {
    Square = (int[]) SquareCopy.Clone();

    if (EnPassantSquare is -1) return;
    BoardUI.Tiles[EnPassantSquare + 8].DrawPiece();
    BoardUI.Tiles[EnPassantSquare - 8].DrawPiece();
  }

  public static bool LookForCheck(bool isWhite, int kingLocation = -1) {
    var friendlyColor = isWhite ? Piece.White : Piece.Black;
    var enemyColor = !isWhite ? Piece.White : Piece.Black;

    kingLocation = kingLocation == -1 ? Array.IndexOf(Square, Piece.King | friendlyColor) : kingLocation;

    for (var pieceType = Piece.King; pieceType <= Piece.Queen; pieceType++) {
      if (Square.Any(p => p == (pieceType | enemyColor)) && TestResponses(kingLocation, pieceType, friendlyColor, enemyColor)) return true;
    }

    return false;
  }

  private static bool TestResponses(int kingLocation, int type, int friendlyColor, int enemyColor) {
    var responses = MoveGenerator.GetAvailableMoves(kingLocation, type | friendlyColor, true);
    var length = responses.Count;
    for (var i = 0; i < length; i++) {
      if (Piece.At(responses[i].TargetSquare) == (type | enemyColor)) return true;
    }

    return false;
  }

  private static void DisableCastling(Move move) {
    var piece = Piece.At(move.StartSquare);

    if (Piece.Type(piece) is Piece.Rook) {
      if (WhiteToMove) {
        if (WhiteCastleQueenSide && move.StartSquare is 0) WhiteCastleQueenSide = false;
        if (WhiteCastleKingSide && move.StartSquare is 7) WhiteCastleKingSide = false;
      } else {
        if (BlackCastleQueenSide && move.StartSquare is 56) BlackCastleKingSide = false;
        if (BlackCastleKingSide && move.StartSquare is 63) BlackCastleQueenSide = false;
      }
    } else if (Piece.Type(piece) is Piece.King) {
      if (WhiteToMove) WhiteCastleQueenSide = WhiteCastleKingSide = false;
      else BlackCastleQueenSide = BlackCastleKingSide = false;
    }
  }

  private static void HandleFlaggedMove(Move move) {
    if (move.MoveFlag is Move.Flag.EnPassant) HandleEnPassant(move);
    if (move.MoveFlag is Move.Flag.Promotion) HandlePromotion(move);
    if (move.MoveFlag is Move.Flag.Castling) HandleCastling(move);

    if (move.MoveFlag is Move.Flag.PawnTwoForward) HandlePawnTwoForwardFlag(move);
    else EnPassantSquare = -1;
  }

  private static void HandleCastling(Move move) {
    (int initialSquare, int finalSquare) = move.TargetSquare is 2 ? (0, 3) : (7, 5);
    if (!WhiteToMove) (initialSquare, finalSquare) = move.TargetSquare is 58 ? (56, 59) : (63, 61);

    Square[finalSquare] = Square[initialSquare];
    Square[initialSquare] = Piece.None;

    BoardUI.Tiles[initialSquare].DrawPiece();
    BoardUI.Tiles[finalSquare].DrawPiece();
  }

  private static void HandlePromotion(Move move) {
    TimerIsRunning = false;

    BoardUI.Data.GameText = ($"Promotion for {(WhiteToMove ? "White" : "Black")}");

    PromotePieceAt(move.TargetSquare);
  }

  private static void PromotePieceAt(int square) {
    var buttons = WhiteToMove ? BoardUI.PromoteWhiteButtons : BoardUI.PromoteBlackButtons;
    PromotionSquare = square;
    foreach (var button in buttons) button.Enabled = true;
  }

  public static void HandlePromotionClick(object? sender, EventArgs e) {
    if (PromotionSquare is -1) return;

    var buttons = !WhiteToMove ? BoardUI.PromoteWhiteButtons : BoardUI.PromoteBlackButtons;
    var name = ((Button) sender!).Name[9..^8];
    var pieceColor = !WhiteToMove ? Piece.White : Piece.Black;

    Square[PromotionSquare] = name switch {
      "Knight" => pieceColor | Piece.Knight,
      "Bishop" => pieceColor | Piece.Bishop,
      "Rook" => pieceColor | Piece.Rook,
      "Queen" => pieceColor | Piece.Queen,
      _ => Piece.None,
    };

    BoardUI.Tiles[PromotionSquare].DrawPiece();

    TimerIsRunning = true;
    PromotionSquare = -1;

    foreach (var button in buttons) button.Enabled = false;

    BoardUI.Data.GameText = $"{(WhiteToMove ? "White" : "Black")} to move";

    var checkLocationEnemy = Array.IndexOf(Square, Piece.King | (WhiteToMove ? Piece.White : Piece.Black));
    BoardUI.Tiles[checkLocationEnemy].DrawPiece();

    if (MoveGenerator.GetAllAvailableMoves(WhiteToMove).Count is 0) {
      BoardUI.Data.GameText = "Checkmate";
      TimerIsRunning = false;
    }
  }

  private static void HandleEnPassant(Move move) {
    var direction = Math.Sign(move.TargetSquare - move.StartSquare);
    var index = move.TargetSquare - direction * 8;

    Square[index] = Piece.None;
    BoardUI.Tiles[index].DrawPiece();
  }

  private static void HandlePawnTwoForwardFlag(Move move) {
    var direction = Math.Sign(move.TargetSquare - move.StartSquare);
    EnPassantSquare = move.StartSquare + direction * 8;
  }

  public static void EndGame(string message) {
    BoardUI.Data.GameText = message;
    BoardUI.Data.GameIsOver = true;
    TimerIsRunning = false;
  }

  public static void VerifyInsuficientMaterial() {
    var remainingPieces = Square.Where(p => p is not Piece.None).ToArray();
    if (remainingPieces.Length is 2) {
      EndGame("Draw");
      return;
    } else if (remainingPieces.Length is 3) {
      var remainingWhite = remainingPieces.Where(p => Piece.IsWhite(p) && Piece.Type(p) is not Piece.King).ToArray();
      var remainingBlack = remainingPieces.Where(p => !Piece.IsWhite(p) && Piece.Type(p) is not Piece.King).ToArray();

      var pieceToCheck = remainingWhite.Length is 1 ? remainingWhite[0] : remainingBlack[0];
      if (Piece.Type(pieceToCheck) is Piece.Knight or Piece.Bishop) {
        EndGame("Draw");
        return;
      }
    }
  }  
}
