namespace SpaceRaceGame
{
    partial class GameScreen
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gameLoopTimer = new System.Windows.Forms.Timer(this.components);
            this.victoryLabel = new System.Windows.Forms.Label();
            this.endButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gameLoopTimer
            // 
            this.gameLoopTimer.Interval = 20;
            this.gameLoopTimer.Tick += new System.EventHandler(this.gameLoopTimer_Tick);
            // 
            // victoryLabel
            // 
            this.victoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.victoryLabel.ForeColor = System.Drawing.Color.White;
            this.victoryLabel.Location = new System.Drawing.Point(126, 38);
            this.victoryLabel.Name = "victoryLabel";
            this.victoryLabel.Size = new System.Drawing.Size(416, 47);
            this.victoryLabel.TabIndex = 0;
            this.victoryLabel.Text = "eagfgrg";
            this.victoryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.victoryLabel.Visible = false;
            // 
            // endButton
            // 
            this.endButton.Enabled = false;
            this.endButton.Location = new System.Drawing.Point(291, 351);
            this.endButton.Name = "endButton";
            this.endButton.Size = new System.Drawing.Size(100, 45);
            this.endButton.TabIndex = 1;
            this.endButton.Text = "Back to Main Menu";
            this.endButton.UseVisualStyleBackColor = true;
            this.endButton.Visible = false;
            this.endButton.Click += new System.EventHandler(this.endButton_Click);
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.endButton);
            this.Controls.Add(this.victoryLabel);
            this.DoubleBuffered = true;
            this.Name = "GameScreen";
            this.Size = new System.Drawing.Size(688, 489);
            this.Load += new System.EventHandler(this.GameScreen_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameScreen_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameScreen_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.GameScreen_PreviewKeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameLoopTimer;
        private System.Windows.Forms.Label victoryLabel;
        private System.Windows.Forms.Button endButton;
    }
}
