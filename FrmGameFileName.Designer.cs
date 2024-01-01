namespace O_Neillo
{
    partial class FrmGameFileName
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
            this.lblSaveGame = new System.Windows.Forms.Label();
            this.txtEnteredFileName = new System.Windows.Forms.TextBox();
            this.btnSaveGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSaveGame
            // 
            this.lblSaveGame.AutoSize = true;
            this.lblSaveGame.Location = new System.Drawing.Point(12, 57);
            this.lblSaveGame.Name = "lblSaveGame";
            this.lblSaveGame.Size = new System.Drawing.Size(202, 32);
            this.lblSaveGame.TabIndex = 0;
            this.lblSaveGame.Text = "Save game as:";
            // 
            // txtEnteredFileName
            // 
            this.txtEnteredFileName.Location = new System.Drawing.Point(235, 57);
            this.txtEnteredFileName.Name = "txtEnteredFileName";
            this.txtEnteredFileName.Size = new System.Drawing.Size(316, 38);
            this.txtEnteredFileName.TabIndex = 1;
            // 
            // btnSaveGame
            // 
            this.btnSaveGame.Location = new System.Drawing.Point(365, 285);
            this.btnSaveGame.Name = "btnSaveGame";
            this.btnSaveGame.Size = new System.Drawing.Size(186, 50);
            this.btnSaveGame.TabIndex = 2;
            this.btnSaveGame.Text = "save game";
            this.btnSaveGame.UseVisualStyleBackColor = true;
            this.btnSaveGame.Click += new System.EventHandler(this.btnSaveGame_Click);
            // 
            // FrmGameFileName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 378);
            this.Controls.Add(this.btnSaveGame);
            this.Controls.Add(this.txtEnteredFileName);
            this.Controls.Add(this.lblSaveGame);
            this.Name = "FrmGameFileName";
            this.Text = "Save Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSaveGame;
        private System.Windows.Forms.TextBox txtEnteredFileName;
        private System.Windows.Forms.Button btnSaveGame;
    }
}