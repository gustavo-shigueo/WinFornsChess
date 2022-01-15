namespace Chess;

partial class BoardUI {
  /// <summary>
  ///  Required designer variable.
  /// </summary>
  private System.ComponentModel.IContainer components = null;

  /// <summary>
  ///  Clean up any resources being used.
  /// </summary>
  /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
  protected override void Dispose(bool disposing) {
    if (disposing && (components != null)) {
      components.Dispose();
    }
    base.Dispose(disposing);
  }

  #region Windows Form Designer generated code

  /// <summary>
  ///  Required method for Designer support - do not modify
  ///  the contents of this method with the code editor.
  /// </summary>
  private void InitializeComponent() {
      this.components = new System.ComponentModel.Container();
      this.MainPanel = new System.Windows.Forms.FlowLayoutPanel();
      this.PromoteToKnightBlackBtn = new System.Windows.Forms.Button();
      this.PromoteToBishopBlackBtn = new System.Windows.Forms.Button();
      this.PromoteToRookBlackBtn = new System.Windows.Forms.Button();
      this.WhiteTimerLabel = new System.Windows.Forms.Label();
      this.GameResultLabel = new System.Windows.Forms.Label();
      this.SidePanel = new System.Windows.Forms.TableLayoutPanel();
      this.PromoteToRookWhiteBtn = new System.Windows.Forms.Button();
      this.PromoteToQueenBlackBtn = new System.Windows.Forms.Button();
      this.PromoteToKnightWhiteBtn = new System.Windows.Forms.Button();
      this.PromoteToBishopWhiteBtn = new System.Windows.Forms.Button();
      this.PromoteToQueenWhiteBtn = new System.Windows.Forms.Button();
      this.BlackTimerLabel = new System.Windows.Forms.Label();
      this.RestartBtn = new System.Windows.Forms.Button();
      this.GameTimer = new System.Windows.Forms.Timer(this.components);
      this.SidePanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // MainPanel
      // 
      this.MainPanel.Dock = System.Windows.Forms.DockStyle.Left;
      this.MainPanel.Location = new System.Drawing.Point(0, 0);
      this.MainPanel.Margin = new System.Windows.Forms.Padding(0);
      this.MainPanel.Name = "MainPanel";
      this.MainPanel.Size = new System.Drawing.Size(600, 600);
      this.MainPanel.TabIndex = 0;
      // 
      // PromoteToKnightBlackBtn
      // 
      this.PromoteToKnightBlackBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.PromoteToKnightBlackBtn.BackColor = System.Drawing.Color.White;
      this.PromoteToKnightBlackBtn.Enabled = false;
      this.PromoteToKnightBlackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.PromoteToKnightBlackBtn.Location = new System.Drawing.Point(7, 17);
      this.PromoteToKnightBlackBtn.Name = "PromoteToKnightBlackBtn";
      this.PromoteToKnightBlackBtn.Size = new System.Drawing.Size(75, 75);
      this.PromoteToKnightBlackBtn.TabIndex = 0;
      this.PromoteToKnightBlackBtn.UseVisualStyleBackColor = false;
      // 
      // PromoteToBishopBlackBtn
      // 
      this.PromoteToBishopBlackBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.PromoteToBishopBlackBtn.BackColor = System.Drawing.Color.White;
      this.PromoteToBishopBlackBtn.Enabled = false;
      this.PromoteToBishopBlackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.PromoteToBishopBlackBtn.Location = new System.Drawing.Point(96, 17);
      this.PromoteToBishopBlackBtn.Name = "PromoteToBishopBlackBtn";
      this.PromoteToBishopBlackBtn.Size = new System.Drawing.Size(75, 75);
      this.PromoteToBishopBlackBtn.TabIndex = 1;
      this.PromoteToBishopBlackBtn.UseVisualStyleBackColor = false;
      // 
      // PromoteToRookBlackBtn
      // 
      this.PromoteToRookBlackBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.PromoteToRookBlackBtn.BackColor = System.Drawing.Color.White;
      this.PromoteToRookBlackBtn.Enabled = false;
      this.PromoteToRookBlackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.PromoteToRookBlackBtn.Location = new System.Drawing.Point(185, 17);
      this.PromoteToRookBlackBtn.Name = "PromoteToRookBlackBtn";
      this.PromoteToRookBlackBtn.Size = new System.Drawing.Size(75, 75);
      this.PromoteToRookBlackBtn.TabIndex = 2;
      this.PromoteToRookBlackBtn.UseVisualStyleBackColor = false;
      // 
      // WhiteTimerLabel
      // 
      this.WhiteTimerLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.SidePanel.SetColumnSpan(this.WhiteTimerLabel, 4);
      this.WhiteTimerLabel.Font = new System.Drawing.Font("Arial", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.WhiteTimerLabel.Location = new System.Drawing.Point(38, 438);
      this.WhiteTimerLabel.Name = "WhiteTimerLabel";
      this.WhiteTimerLabel.Size = new System.Drawing.Size(281, 49);
      this.WhiteTimerLabel.TabIndex = 1;
      this.WhiteTimerLabel.Text = "05:00";
      this.WhiteTimerLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // GameResultLabel
      // 
      this.GameResultLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.SidePanel.SetColumnSpan(this.GameResultLabel, 4);
      this.GameResultLabel.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.GameResultLabel.Location = new System.Drawing.Point(5, 233);
      this.GameResultLabel.Name = "GameResultLabel";
      this.GameResultLabel.Size = new System.Drawing.Size(347, 81);
      this.GameResultLabel.TabIndex = 0;
      this.GameResultLabel.Text = "-";
      this.GameResultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // SidePanel
      // 
      this.SidePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.SidePanel.BackColor = System.Drawing.SystemColors.ControlLight;
      this.SidePanel.ColumnCount = 4;
      this.SidePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.SidePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.SidePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.SidePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.SidePanel.Controls.Add(this.PromoteToRookWhiteBtn, 2, 5);
      this.SidePanel.Controls.Add(this.PromoteToQueenBlackBtn, 3, 0);
      this.SidePanel.Controls.Add(this.PromoteToKnightWhiteBtn, 0, 5);
      this.SidePanel.Controls.Add(this.PromoteToBishopWhiteBtn, 1, 5);
      this.SidePanel.Controls.Add(this.PromoteToQueenWhiteBtn, 3, 5);
      this.SidePanel.Controls.Add(this.PromoteToRookBlackBtn, 2, 0);
      this.SidePanel.Controls.Add(this.PromoteToBishopBlackBtn, 1, 0);
      this.SidePanel.Controls.Add(this.PromoteToKnightBlackBtn, 0, 0);
      this.SidePanel.Controls.Add(this.WhiteTimerLabel, 0, 4);
      this.SidePanel.Controls.Add(this.GameResultLabel, 0, 2);
      this.SidePanel.Controls.Add(this.BlackTimerLabel, 0, 1);
      this.SidePanel.Controls.Add(this.RestartBtn, 1, 3);
      this.SidePanel.Dock = System.Windows.Forms.DockStyle.Right;
      this.SidePanel.Location = new System.Drawing.Point(603, 0);
      this.SidePanel.Name = "SidePanel";
      this.SidePanel.RowCount = 6;
      this.SidePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.00001F));
      this.SidePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.SidePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.SidePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
      this.SidePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.SidePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.SidePanel.Size = new System.Drawing.Size(357, 600);
      this.SidePanel.TabIndex = 1;
      // 
      // PromoteToRookWhiteBtn
      // 
      this.PromoteToRookWhiteBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.PromoteToRookWhiteBtn.BackColor = System.Drawing.Color.White;
      this.PromoteToRookWhiteBtn.Enabled = false;
      this.PromoteToRookWhiteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.PromoteToRookWhiteBtn.Location = new System.Drawing.Point(185, 506);
      this.PromoteToRookWhiteBtn.Name = "PromoteToRookWhiteBtn";
      this.PromoteToRookWhiteBtn.Size = new System.Drawing.Size(75, 75);
      this.PromoteToRookWhiteBtn.TabIndex = 8;
      this.PromoteToRookWhiteBtn.UseVisualStyleBackColor = false;
      // 
      // PromoteToQueenBlackBtn
      // 
      this.PromoteToQueenBlackBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.PromoteToQueenBlackBtn.BackColor = System.Drawing.Color.White;
      this.PromoteToQueenBlackBtn.Enabled = false;
      this.PromoteToQueenBlackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.PromoteToQueenBlackBtn.Location = new System.Drawing.Point(274, 17);
      this.PromoteToQueenBlackBtn.Name = "PromoteToQueenBlackBtn";
      this.PromoteToQueenBlackBtn.Size = new System.Drawing.Size(75, 75);
      this.PromoteToQueenBlackBtn.TabIndex = 7;
      this.PromoteToQueenBlackBtn.UseVisualStyleBackColor = false;
      // 
      // PromoteToKnightWhiteBtn
      // 
      this.PromoteToKnightWhiteBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.PromoteToKnightWhiteBtn.BackColor = System.Drawing.Color.White;
      this.PromoteToKnightWhiteBtn.Enabled = false;
      this.PromoteToKnightWhiteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.PromoteToKnightWhiteBtn.Location = new System.Drawing.Point(7, 506);
      this.PromoteToKnightWhiteBtn.Name = "PromoteToKnightWhiteBtn";
      this.PromoteToKnightWhiteBtn.Size = new System.Drawing.Size(75, 75);
      this.PromoteToKnightWhiteBtn.TabIndex = 6;
      this.PromoteToKnightWhiteBtn.UseVisualStyleBackColor = false;
      // 
      // PromoteToBishopWhiteBtn
      // 
      this.PromoteToBishopWhiteBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.PromoteToBishopWhiteBtn.BackColor = System.Drawing.Color.White;
      this.PromoteToBishopWhiteBtn.Enabled = false;
      this.PromoteToBishopWhiteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.PromoteToBishopWhiteBtn.Location = new System.Drawing.Point(96, 506);
      this.PromoteToBishopWhiteBtn.Name = "PromoteToBishopWhiteBtn";
      this.PromoteToBishopWhiteBtn.Size = new System.Drawing.Size(75, 75);
      this.PromoteToBishopWhiteBtn.TabIndex = 5;
      this.PromoteToBishopWhiteBtn.UseVisualStyleBackColor = false;
      // 
      // PromoteToQueenWhiteBtn
      // 
      this.PromoteToQueenWhiteBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.PromoteToQueenWhiteBtn.BackColor = System.Drawing.Color.White;
      this.PromoteToQueenWhiteBtn.Enabled = false;
      this.PromoteToQueenWhiteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.PromoteToQueenWhiteBtn.Location = new System.Drawing.Point(274, 506);
      this.PromoteToQueenWhiteBtn.Name = "PromoteToQueenWhiteBtn";
      this.PromoteToQueenWhiteBtn.Size = new System.Drawing.Size(75, 75);
      this.PromoteToQueenWhiteBtn.TabIndex = 4;
      this.PromoteToQueenWhiteBtn.UseVisualStyleBackColor = false;
      // 
      // BlackTimerLabel
      // 
      this.BlackTimerLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.SidePanel.SetColumnSpan(this.BlackTimerLabel, 4);
      this.BlackTimerLabel.Font = new System.Drawing.Font("Arial", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.BlackTimerLabel.Location = new System.Drawing.Point(38, 110);
      this.BlackTimerLabel.Name = "BlackTimerLabel";
      this.BlackTimerLabel.Size = new System.Drawing.Size(281, 42);
      this.BlackTimerLabel.TabIndex = 3;
      this.BlackTimerLabel.Text = "05:00";
      this.BlackTimerLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
      // 
      // RestartBtn
      // 
      this.RestartBtn.BackColor = System.Drawing.Color.White;
      this.SidePanel.SetColumnSpan(this.RestartBtn, 2);
      this.RestartBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.RestartBtn.Location = new System.Drawing.Point(92, 331);
      this.RestartBtn.Name = "RestartBtn";
      this.RestartBtn.Size = new System.Drawing.Size(172, 36);
      this.RestartBtn.TabIndex = 9;
      this.RestartBtn.Text = "Restart Game";
      this.RestartBtn.UseVisualStyleBackColor = false;
      this.RestartBtn.Click += new System.EventHandler(this.RestartBtn_Click);
      // 
      // GameTimer
      // 
      this.GameTimer.Enabled = true;
      this.GameTimer.Interval = 1000;
      this.GameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
      // 
      // BoardUI
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(960, 600);
      this.Controls.Add(this.SidePanel);
      this.Controls.Add(this.MainPanel);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
      this.Margin = new System.Windows.Forms.Padding(5);
      this.MaximizeBox = false;
      this.Name = "BoardUI";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Chess";
      this.SidePanel.ResumeLayout(false);
      this.ResumeLayout(false);

  }

  #endregion

  private FlowLayoutPanel MainPanel;
  private Label GameResultLabel;
  private Button PromoteToKnightBlackBtn;
  private Label WhiteTimerLabel;
  private Button PromoteToBishopBlackBtn;
  private Button PromoteToRookBlackBtn;
  private TableLayoutPanel SidePanel;
  private Label BlackTimerLabel;
  private Button PromoteToKnightWhiteBtn;
  private Button PromoteToBishopWhiteBtn;
  private Button PromoteToQueenWhiteBtn;
  private Button PromoteToQueenBlackBtn;
  private Button PromoteToRookWhiteBtn;
  private System.Windows.Forms.Timer GameTimer;
  private Button RestartBtn;
}
