namespace Chess;

public readonly struct Move {
  public readonly struct Flag {
    public const int None = 0;
    public const int EnPassant = 1;
    public const int Castling = 2;
    public const int Promotion = 3;
    public const int PawnTwoForward = 4;
  }

  private readonly ushort moveValue;
  private const ushort startSquareMask = 0b000_000000_111111;
  private const ushort targetSquareMask = 0b000_111111_000000;
  private const ushort flagMask = 0b111_000000_000000;

  public Move(ushort _moveValue) {
    moveValue = _moveValue;
  }

  public Move(int startSquare, int targetSquare) {
    if (startSquare == targetSquare) {
      moveValue = (ushort) InvalidMove;
      return;
    }

    moveValue = (ushort) (startSquare | targetSquare << 6);
  }

  public Move(int startSquare, int targetSquare, int flag) {
    if (startSquare == targetSquare) {
      moveValue = (ushort) InvalidMove;
      return;
    }

    moveValue = (ushort) (startSquare | targetSquare << 6 | flag << 12);
  }

  public ushort Value {
    get => moveValue;
  }

  public int StartSquare {
    get => moveValue & startSquareMask;
  }

  public int TargetSquare {
    get => (moveValue & targetSquareMask) >> 6;
  }

  public int MoveFlag {
    get => (moveValue & flagMask) >> 12;
  }

  public bool IsPromotion {
    get => MoveFlag is Flag.Promotion;
  }

  public static int InvalidMove {
    get => 0;
  }

  public bool IsCapture {
    get => Piece.At(TargetSquare) is not Piece.None;
  }

  public bool IsSameMove(Move other) {
    return StartSquare == other.StartSquare && TargetSquare == other.TargetSquare;
  }

  public static bool operator ==(Move move1, Move move2) => move1.Value == move2.Value;

  public static bool operator !=(Move move1, Move move2) => move1.Value != move2.Value;

  public override bool Equals(object? otherMove) {
    return otherMove is not null && otherMove is Move o && o.Value == Value;
  }

  public override int GetHashCode() => base.GetHashCode();
}
