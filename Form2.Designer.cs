namespace O_Neillo
{
    partial class frmAbout
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.pbxAbout = new System.Windows.Forms.PictureBox();
            this.lblONeillo = new System.Windows.Forms.Label();
            this.lsbAboutGame = new System.Windows.Forms.ListBox();
            this.btnCloseAbout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAbout)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxAbout
            // 
            this.pbxAbout.Location = new System.Drawing.Point(12, 120);
            this.pbxAbout.Name = "pbxAbout";
            this.pbxAbout.Size = new System.Drawing.Size(743, 573);
            this.pbxAbout.TabIndex = 1;
            this.pbxAbout.TabStop = false;
            // 
            // lblONeillo
            // 
            this.lblONeillo.AutoSize = true;
            this.lblONeillo.Font = new System.Drawing.Font("Lucida Handwriting", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblONeillo.Location = new System.Drawing.Point(12, 24);
            this.lblONeillo.Name = "lblONeillo";
            this.lblONeillo.Size = new System.Drawing.Size(666, 78);
            this.lblONeillo.TabIndex = 2;
            this.lblONeillo.Text = "The O\'Neillo Game";
            // 
            // lsbAboutGame
            // 
            this.lsbAboutGame.FormattingEnabled = true;
            this.lsbAboutGame.ItemHeight = 31;
            this.lsbAboutGame.Items.AddRange(new object[] {
            "The O\'Neillo game was developed as part of a Programming ",
            "Fundamentals assignment at Sheffield Hallam University.",
            "The provided GameBoardImageArray.cs has been used",
            "and edited to fit the requirements of the game and ",
            "assignment. The game logic has been written independently."});
            this.lsbAboutGame.Location = new System.Drawing.Point(761, 120);
            this.lsbAboutGame.Name = "lsbAboutGame";
            this.lsbAboutGame.Size = new System.Drawing.Size(782, 531);
            this.lsbAboutGame.TabIndex = 4;
            // 
            // btnCloseAbout
            // 
            this.btnCloseAbout.Location = new System.Drawing.Point(633, 715);
            this.btnCloseAbout.Name = "btnCloseAbout";
            this.btnCloseAbout.Size = new System.Drawing.Size(242, 100);
            this.btnCloseAbout.TabIndex = 5;
            this.btnCloseAbout.Text = "OK";
            this.btnCloseAbout.UseVisualStyleBackColor = true;
            this.btnCloseAbout.Click += new System.EventHandler(this.btnCloseAbout_Click);
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1627, 877);
            this.Controls.Add(this.btnCloseAbout);
            this.Controls.Add(this.lsbAboutGame);
            this.Controls.Add(this.lblONeillo);
            this.Controls.Add(this.pbxAbout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAbout";
            this.Text = "About";
            this.Load += new System.EventHandler(this.frmAbout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxAbout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxAbout;
        private System.Windows.Forms.Label lblONeillo;
        private System.Windows.Forms.ListBox lsbAboutGame;
        private System.Windows.Forms.Button btnCloseAbout;
    }
}