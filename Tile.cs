namespace Chess;

public partial class Tile : UserControl {
  private static readonly Color darkTileColor = Color.FromArgb(255, 166, 110, 90);
  private static readonly Color lightTileColor = Color.FromArgb(255, 238, 209, 104);
  private static readonly Color highlightTileColor = Color.FromArgb(255, 104, 209, 104);
  private static List<Move> validMoves = new();

  public int File { get; }
  public int Rank { get; }
  public int Index { get; }

  private const int tileSize = 75;
  private static Tile? startTile;

  public Tile(int file, int rank) {
    InitializeComponent();

    File = file;
    Rank = rank;

    Index = Board.ConvertFileAndRankToIndex(File, Rank);
    Size = new(tileSize, tileSize);
  }

  protected override void OnPaint(PaintEventArgs pe) {
    base.OnPaint(pe);
  }

  public void DrawPiece() {
    var piece = Piece.At(Index);
    var type = Piece.Type(piece);
    var check = type is Piece.King && Board.LookForCheck(Piece.IsWhite(piece), Index);
    var color = check ? Color.Red : GetTileColor();

    if (type is not Piece.King) BoardUI.PaintTileInCheck();

    ColorTile(Index, color);

    if (Piece.At(Index) == Piece.None) {
      PieceImage.Image = null;
      return;
    }

    var img = Sprite.GetSprite(Piece.At(Index));
    PieceImage.Image = img;
  }

  private Color GetTileColor() => (File + Rank) % 2 != 0 ? darkTileColor : lightTileColor;

  private void Tile_Load(object sender, EventArgs e) {
    PieceImage.Click += Tile_Clicked;
    DrawPiece();
  }

  private static void ColorTile(int index, Color color) {
    var tile = BoardUI.Tiles[index];
    tile.BackColor = tile.PieceImage.BackColor = color;
  }

  private void Tile_Clicked(object? sender, EventArgs e) {
    if (!Board.TimerIsRunning) return;

    if (startTile is null) {
      var piece = Piece.At(Index);
      startTile = piece != Piece.None && Piece.IsWhite(piece) == Board.WhiteToMove ? this : null;

      if (startTile is null) return;

      validMoves = MoveGenerator.GetAvailableMoves(startTile.Index, Piece.At(startTile.Index));

      if (validMoves.Count is 0) {
        startTile = null;
        return;
      }

      foreach (var validMove in validMoves) ColorTile(validMove.TargetSquare, highlightTileColor);

      return;
    }

    var moveToTest = new Move(startTile.Index, Index);
    var moveIsValid = validMoves.Any(m => m.IsSameMove(moveToTest));
    var move = validMoves.FirstOrDefault(m => m.IsSameMove(moveToTest));

    foreach (var validMove in validMoves) {
      var index = validMove.TargetSquare;
      ColorTile(index, BoardUI.Tiles[index].GetTileColor());
    }

    startTile = null;
    validMoves.Clear();

    if (!moveIsValid) return;

    var movedPiece = Piece.At(move.StartSquare);
    var targetPiece = Piece.At(move.TargetSquare);
    if (Piece.Type(movedPiece) is Piece.Pawn || targetPiece is not Piece.None) Board.HalfMoveClock = 0;

    Board.MakeMove(move);

    BoardUI.PaintTileInCheck();

    Board.VerifyInsuficientMaterial();

    if (MoveGenerator.GetAllAvailableMoves(Board.WhiteToMove).Count > 0) { 
      BoardUI.PaintTileInCheck();
      return;
    }

    Board.EndGame(Board.LookForCheck(Board.WhiteToMove) ? "Checkmate!" : "Stalemate!");
  }
}
