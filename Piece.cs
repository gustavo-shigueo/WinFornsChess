namespace Chess;

public static class Piece {
  public const int None = 0;
  public const int King = 1;
  public const int Pawn = 2;
  public const int Knight = 3;
  public const int Bishop = 4;
  public const int Rook = 5;
  public const int Queen = 6;

  public const int White = 8;
  public const int Black = 16;

  public static bool IsWhite(int piece) => piece >> 3 == 1;

  public static bool IsSlidingPiece(int piece) => Type(piece) is Rook or Bishop or Queen;

  public static bool IsFriendly(int piece) => piece is not None && IsWhite(piece) == Board.WhiteToMove;

  public static int Type(int piece) => piece & 7;

  public static int At(int square) => Board.Square[square];
}
