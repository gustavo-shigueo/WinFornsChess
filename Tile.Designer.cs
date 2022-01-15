namespace Chess;

partial class Tile {
  /// <summary>
  /// Variável de designer necessária.
  /// </summary>
  private System.ComponentModel.IContainer components = null;

  /// <summary>
  /// Limpar os recursos que estão sendo usados.
  /// </summary>
  /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
  protected override void Dispose(bool disposing) {
    if (disposing && (components != null)) {
      components.Dispose();
    }
    base.Dispose(disposing);
  }

  #region Código gerado pelo Designer de Componentes

  /// <summary>
  /// Método necessário para suporte ao Designer - não modifique 
  /// o conteúdo deste método com o editor de código.
  /// </summary>
  private void InitializeComponent() {
      this.PieceImage = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.PieceImage)).BeginInit();
      this.SuspendLayout();
      // 
      // PieceImage
      // 
      this.PieceImage.Dock = System.Windows.Forms.DockStyle.Fill;
      this.PieceImage.ErrorImage = null;
      this.PieceImage.ImageLocation = "";
      this.PieceImage.InitialImage = null;
      this.PieceImage.Location = new System.Drawing.Point(0, 0);
      this.PieceImage.Margin = new System.Windows.Forms.Padding(0);
      this.PieceImage.MaximumSize = new System.Drawing.Size(75, 75);
      this.PieceImage.MinimumSize = new System.Drawing.Size(75, 75);
      this.PieceImage.Name = "PieceImage";
      this.PieceImage.Size = new System.Drawing.Size(75, 75);
      this.PieceImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.PieceImage.TabIndex = 0;
      this.PieceImage.TabStop = false;
      // 
      // Tile
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.PieceImage);
      this.Margin = new System.Windows.Forms.Padding(0);
      this.Name = "Tile";
      this.Size = new System.Drawing.Size(75, 75);
      this.Load += new System.EventHandler(this.Tile_Load);
      ((System.ComponentModel.ISupportInitialize)(this.PieceImage)).EndInit();
      this.ResumeLayout(false);
  }

  #endregion

  private PictureBox PieceImage;
}
