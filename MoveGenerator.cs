namespace Chess;

public static class MoveGenerator {
  public static readonly int[] directionOffsets = { 8, -8, -1, 1, 7, -7, 9, -9 };
  public static readonly int[] knightJumpOffsets = { 17, 10, -6, -15, -17, -10, 6, 15 };
  public static readonly int[][] distanceToEdge;

  static MoveGenerator() {
    distanceToEdge = new int[64][];
    for (var squareIndex = 0; squareIndex < 64; squareIndex++) {
      var rank = squareIndex / 8;
      var file = squareIndex - rank * 8;

      var north = 7 - rank;
      var south = rank;
      var west = file;
      var east = 7 - file;

      distanceToEdge[squareIndex] = new int[8];
      distanceToEdge[squareIndex][0] = north;
      distanceToEdge[squareIndex][1] = south;
      distanceToEdge[squareIndex][2] = west;
      distanceToEdge[squareIndex][3] = east;
      distanceToEdge[squareIndex][4] = Math.Min(north, west);
      distanceToEdge[squareIndex][5] = Math.Min(south, east);
      distanceToEdge[squareIndex][6] = Math.Min(north, east);
      distanceToEdge[squareIndex][7] = Math.Min(south, west);
    }
  }

  public static List<Move> GetAvailableMoves(int startSquare, int? piece = null, bool stop = false) {
    if (piece is null) {
      piece = Piece.At(startSquare);
      if (Piece.IsWhite((int) piece) != Board.WhiteToMove) return new();
    }
 
    if (Piece.IsSlidingPiece((int) piece)) return GenerateSlidingMoves((int) piece, startSquare, stop);

    return Piece.Type((int) piece) switch {
      Piece.Pawn => GeneratePawnMoves(startSquare, piece is null ? Board.WhiteToMove : Piece.IsWhite((int) piece), stop),
      Piece.King => GenerateKingMoves(startSquare, (int) piece, stop),
      Piece.Knight => GenerateKnightMoves(startSquare, (int) piece, stop),
      _ => new(),
    };
  }

  public static List<Move> GetAllAvailableMoves(bool isWhite) {
    var moves = new List<Move>();

    for (var i = 0; i < 64; i++) {
      var piece = Piece.At(i);
      if (piece is Piece.None || Piece.IsWhite(piece) != isWhite) continue;

      moves.AddRange(GetAvailableMoves(i, piece));
    }

    return moves;
  }

  private static List<Move> GenerateKnightMoves(int startSquare, int piece, bool stop) {
    var moves = new List<Move>();

    for (var i = 0; i < 8; i++) {
      if (KnightTooCloseToEdge(startSquare, i)) continue;

      var direction = knightJumpOffsets[i];
      var targetSquare = startSquare + direction;
      var targetSquarePiece = Piece.At(targetSquare);

      if (targetSquarePiece is not Piece.None && Piece.IsWhite(piece) == Piece.IsWhite(targetSquarePiece)) continue;

      var move = new Move(startSquare, targetSquare);
      if (stop || TestIfLegal(move)) moves.Add(move);
    }

    return moves;
  }

  private static bool KnightTooCloseToEdge(int startSquare, int i) {
    return
      i is 0 or 7 && distanceToEdge[startSquare][0] < 2 ||
      i is 3 or 4 && distanceToEdge[startSquare][1] < 2 ||
      i is 5 or 6 && distanceToEdge[startSquare][2] < 2 ||
      i is 1 or 2 && distanceToEdge[startSquare][3] < 2 ||

      i is 1 or 6 && distanceToEdge[startSquare][0] < 1 ||
      i is 2 or 5 && distanceToEdge[startSquare][1] < 1 ||
      i is 4 or 7 && distanceToEdge[startSquare][2] < 1 ||
      i is 0 or 3 && distanceToEdge[startSquare][3] < 1;
  }

  private static List<Move> GeneratePawnMoves(int startSquare, bool isWhite, bool stop) {
    if (isWhite && startSquare > 55 || !isWhite && startSquare < 8) return new();
    var moves = new List<Move>();
    var direction = isWhite ? 1 : -1;
    var initialRank = isWhite ? 1 : 6;
    var currentRank = Board.GetRankFromIndex(startSquare);

    if (Piece.At(startSquare + 8 * direction) is Piece.None) {
      var targetSquare = startSquare + 8 * direction;
      var move1 = new Move(startSquare, targetSquare, targetSquare is > 55 or < 8 ? Move.Flag.Promotion : Move.Flag.None);
      if (stop || TestIfLegal(move1)) moves.Add(move1);

      if (currentRank == initialRank && Piece.At(startSquare + 16 * direction) is Piece.None) {
        var move2 = new Move(startSquare, startSquare + 16 * direction, Move.Flag.PawnTwoForward);
        if (stop || TestIfLegal(move2)) moves.Add(move2);
      }
    }


    var possibleCaptures = new[] { 7 * direction, 9 * direction };
    foreach (var possibleCapture in possibleCaptures) {
      if (PawnTooCloseToEdge(startSquare, possibleCapture)) continue;

      var possibleCaptureIndex = startSquare + possibleCapture;
      var possibleCapturePiece = Piece.At(possibleCaptureIndex);

      if (Piece.At(possibleCaptureIndex) is Piece.None) {
        if (Board.EnPassantSquare is -1 || Board.EnPassantSquare != possibleCaptureIndex) continue;
        var move = new Move(startSquare, possibleCaptureIndex, Move.Flag.EnPassant);
        if (stop || TestIfLegal(move)) moves.Add(move);
      } else if (Piece.IsWhite(possibleCapturePiece) != isWhite) { 
        var move = new Move(startSquare, possibleCaptureIndex, possibleCaptureIndex is > 55 or < 8 ? Move.Flag.Promotion : Move.Flag.None);
        if (stop || TestIfLegal(move)) moves.Add(move);
      }
    }

    return moves;
  }

  private static bool PawnTooCloseToEdge(int startSquare, int targetSquare) {
    var distancesToCampare = new Dictionary<int, int> {
      [7] = 4,
      [9] = 6,
      [-7] = 5,
      [-9] = 7,
    };

    foreach (var (capture, index) in distancesToCampare) {
      if (targetSquare == capture && distanceToEdge[startSquare][index] is 0) return true;
    }

    return false;
  }
  private static List<Move> GenerateKingMoves(int startSquare, int piece, bool stop) {
    var moves = new List<Move>();

    for (var directionIndex = 0; directionIndex < 8; directionIndex++) {
      var direction = directionOffsets[directionIndex];

      if (distanceToEdge[startSquare][directionIndex] < 1) continue;

      var targetSquare = startSquare + direction;
      var targetSquarePiece = Piece.At(targetSquare);
 
      if (targetSquarePiece is not Piece.None && Piece.IsWhite(piece) == Piece.IsWhite(targetSquarePiece)) continue;

      var move = new Move(startSquare, targetSquare);
      if (stop || TestIfLegal(move)) moves.Add(move);
    }

    var checkCastle = new Dictionary<string, (int[] places, bool available)> {
      ["QueenSide"] = Board.WhiteToMove ? (new[] { 1, 2, 3 }, Board.WhiteCastleQueenSide) : (new[] { 57, 58, 59 }, Board.BlackCastleQueenSide),
      ["KingSide"] = Board.WhiteToMove ? (new[] { 5, 6 }, Board.WhiteCastleKingSide) : (new[] { 61, 62 }, Board.BlackCastleKingSide)
    };

    var castlingPossible = new Dictionary<string, (bool possible, int target)>() {
      ["QueenSide"] = (checkCastle["QueenSide"].places.All(v => Piece.At(v) is Piece.None) && checkCastle["QueenSide"].available, Board.WhiteToMove ? 2 : 58),
      ["KingSide"] = (checkCastle["KingSide"].places.All(v => Piece.At(v) is Piece.None) && checkCastle["KingSide"].available, Board.WhiteToMove ? 6 : 62),
    };

    foreach (var (name, (possible, target)) in castlingPossible) {
      if (possible) {
        var move = new Move(startSquare, target, Move.Flag.Castling);
        if (stop || TestIfLegal(move)) moves.Add(move);
      }
    }

    return moves;
  }

  private static List<Move> GenerateSlidingMoves(int piece, int startSquare, bool stop) => Piece.Type(piece) switch {
    Piece.Rook => GenerateSlidingMoves(startSquare, 0, 4, Piece.IsWhite(piece), stop),
    Piece.Queen => GenerateSlidingMoves(startSquare, 0, 8, Piece.IsWhite(piece), stop),
    Piece.Bishop => GenerateSlidingMoves(startSquare, 4, 8, Piece.IsWhite(piece), stop),
    _ => new List<Move>(),
  };
  

  private static List<Move> GenerateSlidingMoves(int startSquare, int firstDirIndex, int lastDirIndex, bool isWhite, bool stop) {
    var moves = new List<Move>();

    for (var directionIndex = firstDirIndex; directionIndex < lastDirIndex; directionIndex++) {
      var direction = directionOffsets[directionIndex];

      for (var n = 0; n < distanceToEdge[startSquare][directionIndex]; n++) {
        var targetSquare = startSquare + direction * (n + 1);
        var targetSquarePiece = Piece.At(targetSquare);

        if (targetSquarePiece is not Piece.None && Piece.IsWhite(targetSquarePiece) == isWhite) break;

        var move = new Move(startSquare, targetSquare);

        if (stop || TestIfLegal(move)) moves.Add(move);

        var isCapture = targetSquarePiece is not Piece.None;

        if (isCapture) break;
      }
    }

    return moves;
  }

  private static bool TestIfLegal(Move move) {
    Board.MakeTestMove(move);

    var valid = !Board.LookForCheck(Board.WhiteToMove);

    Board.UndoTestMove();

    var castleIndices = new[] { 0, 3, 5, 7, 56, 59, 61, 63 };
    foreach (var index in castleIndices) BoardUI.Tiles[index].DrawPiece();

    return valid;
  }
}
