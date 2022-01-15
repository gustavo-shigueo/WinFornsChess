namespace Chess;

public static class FenReader {
  private static readonly Dictionary<char, int> symbolToPiece = new() { 
    ['k'] = Piece.King,
    ['p'] = Piece.Pawn,
    ['r'] = Piece.Rook,
    ['q'] = Piece.Queen,
    ['n'] = Piece.Knight,
    ['b'] = Piece.Bishop,
  };

  public const string startFen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";

  public static void ReadFenString(string fen = startFen) {
    var sections = fen.Split(' ');

    var file = 0;
    var rank = 7;

    foreach (var symbol in sections[0]) {
      if (symbol == '/') {
        file = 0;
        rank--;
        continue;
      }

      if (char.IsDigit(symbol)) {
        file += (int) char.GetNumericValue(symbol);
        continue;
      }

      var color = char.IsUpper(symbol) ? Piece.White : Piece.Black;
      var type = symbolToPiece[char.ToLower(symbol)];
      Board.Square[Board.ConvertFileAndRankToIndex(file, rank)] = color | type;
      file++;
    }

    Board.WhiteToMove = sections[1] == "w";

    var castlingAllowed = sections.Length > 2 ? sections[2] : "KQkq";
    Board.WhiteCastleKingSide = castlingAllowed.Contains('K');
    Board.WhiteCastleQueenSide = castlingAllowed.Contains('Q');
    Board.BlackCastleKingSide = castlingAllowed.Contains('k');
    Board.BlackCastleQueenSide = castlingAllowed.Contains('q');

    if (sections.Length > 3) {
      var enPassantSquareName = sections[3];

      if (Board.SquareNames.Contains(enPassantSquareName)) {
        Board.EnPassantSquare = Array.IndexOf(Board.SquareNames, enPassantSquareName);
      }
    }

    if (sections.Length > 4) {
      _ = int.TryParse(sections[4], out int halfMoveClock);
      Board.HalfMoveClock = halfMoveClock;
    }
  }
}
