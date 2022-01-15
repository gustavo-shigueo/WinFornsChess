namespace Chess;

public static class Sprite {
  private readonly static int _spriteWidth = 333;
  private readonly static int _spriteHeight = 334;

  private static readonly string _spritePath = Path.GetFullPath(@"Assets\Pieces.png");
  private static readonly Image _spriteSheet = Image.FromFile(_spritePath);
  private static readonly Bitmap _buffer = new(_spriteSheet);
  public static Rectangle SpriteDestRect { get; } = new(0, 0, 75, 75);

  private static readonly Dictionary<int, int> _widthOffset = new() { 
    [1] = 0,
    [2] = 5,
    [3] = 3,
    [4] = 2,
    [5] = 4,
    [6] = 1,
  };

  private static Rectangle GetSpriteSrcRect(int piece) {
    if (piece is Piece.None) return new(0, 0, 1, 1);

    int offset = _widthOffset[Piece.Type(piece)];
    int srcY = Piece.IsWhite(piece) ? 0 : _spriteHeight;
    int srcX = offset * _spriteWidth;

    return new(srcX, srcY, _spriteWidth, _spriteHeight);
  }

  public static Image GetSprite(int piece) {
    var image = _buffer.Clone(GetSpriteSrcRect(piece), _buffer.PixelFormat);
    return image;
  }

  public static void GetSpriteAsBackground(Control c, int piece) {
    c.Paint += (sender, e) => {
      var image = new Bitmap(_spritePath);

      var destinationRect = new Rectangle(0, 0, 75, 75);
      var sourceRect = piece is not Piece.None ? GetSpriteSrcRect(piece) : new Rectangle(0, 0, 0, 0);

      e.Graphics.DrawImage(image, destinationRect, sourceRect, GraphicsUnit.Pixel);
    };
  }
}
