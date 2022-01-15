namespace Chess;

public partial class BoardUI : Form {
  public static Tile[] Tiles { get; private set; } = new Tile[64];

  private static readonly int[] ButtonIcons = new[] { Piece.Knight, Piece.Bishop, Piece.Rook, Piece.Queen };
  public static Button[] PromoteBlackButtons { get; private set; } = new Button[4];

  public static Button[] PromoteWhiteButtons { get; private set; } = new Button[4];
  public static GameElements Data { get; set; } = new();

  public BoardUI() {
    InitializeComponent();
    BuildBoard();
    SetupButtons();
    SetupLabelBindings();
  }

  private void BuildBoard() {
    Board.Square = new int[64];
    FenReader.ReadFenString();

    for (int rank = 0; rank < 8; rank++) {
      for (int file = 0; file < 8; file++) CreateTile(file, 7 - rank);
    }
  }

  private void CreateTile(int file, int rank) {
    var tile = new Tile(file, rank);

    Tiles[tile.Index] = tile;
    MainPanel.Controls.Add(tile);
  }

  private void SetupButtons() {
    PromoteBlackButtons = new[] {
      PromoteToKnightBlackBtn,
      PromoteToBishopBlackBtn,
      PromoteToRookBlackBtn,
      PromoteToQueenBlackBtn,
    };

    PromoteWhiteButtons = new[] {
      PromoteToKnightWhiteBtn,
      PromoteToBishopWhiteBtn,
      PromoteToRookWhiteBtn,
      PromoteToQueenWhiteBtn,
    };

    for (var i = 0; i < 4; i++) {
      var buttons = new[] { PromoteBlackButtons[i], PromoteWhiteButtons[i] };
      var pieceType = ButtonIcons[i];

      foreach (var button in buttons) {
        int pieceColor = button.Name[^8..^3] is "White" ? Piece.White : Piece.Black;
        button.Click += Board.HandlePromotionClick;
        Sprite.GetSpriteAsBackground(button, pieceColor | pieceType);
      }
    }

    RestartBtn.DataBindings.Add(new("Visible", Data, nameof(Data.GameIsOver)));
  }

  private void SetupLabelBindings() {
    GameResultLabel.DataBindings.Add(new("Text", Data, nameof(Data.GameText)));
    BlackTimerLabel.DataBindings.Add(new("Text", Data, nameof(Data.BlackTimer)));
    WhiteTimerLabel.DataBindings.Add(new("Text", Data, nameof(Data.WhiteTimer)));
  }
  private void GameTimer_Tick(object sender, EventArgs e) {
    if (!Board.TimerIsRunning) return;

    Board.DecrementTimer();

    if (Board.BlackTimer is 0 || Board.WhiteTimer is 0) {
      Data.GameText = $"Timeout! {(Board.WhiteTimer is 0 ? "Black" : "White")} wins";
      GameTimer.Stop();
      Board.TimerIsRunning = false;
    }
  }

  private void RestartBtn_Click(object sender, EventArgs e) {
    for (var i = 0; i < 64; i++) {
      Tiles[i]?.Dispose();
      Tiles = new Tile[64];
    }

    MainPanel.Controls.Clear();
    BuildBoard();

    for (var i = 0; i < 64; i++) Tiles[i].DrawPiece();

    Data.GameText = "White to move";
    Data.GameIsOver = false;

    Board.WhiteTimer = Board.BlackTimer = Board.START_TIMER;
    Board.WhiteToMove = Board.WhiteCastleQueenSide = Board.WhiteCastleKingSide = true;
    Board.TimerIsRunning = Board.BlackCastleQueenSide = Board.BlackCastleKingSide = true;
    Board.EnPassantSquare = -1;
  }

  public static void PaintTileInCheck() {
    var checkLocationEnemy = Array.IndexOf(Board.Square, Piece.King | Board.ColorToMove);
    Tiles[checkLocationEnemy]?.DrawPiece();
  }
}
