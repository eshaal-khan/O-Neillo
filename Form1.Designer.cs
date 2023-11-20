namespace O_Neillo
{
    partial class FrmGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGame));
            this.lblMessage = new System.Windows.Forms.Label();
            this.msMenu = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informationPanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speakToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbxPanel = new System.Windows.Forms.PictureBox();
            this.txtPlayer1 = new System.Windows.Forms.TextBox();
            this.txtPlayer2 = new System.Windows.Forms.TextBox();
            this.lblPlayer1Turn = new System.Windows.Forms.Label();
            this.pbxWhiteIcon = new System.Windows.Forms.PictureBox();
            this.pbxBlackIcon = new System.Windows.Forms.PictureBox();
            this.lblP2Tokens = new System.Windows.Forms.Label();
            this.lblP1Tokens = new System.Windows.Forms.Label();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.lblPlayer2Turn = new System.Windows.Forms.Label();
            this.msMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxWhiteIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBlackIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(11, 67);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(92, 32);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "label1";
            // 
            // msMenu
            // 
            this.msMenu.BackColor = System.Drawing.Color.LightBlue;
            this.msMenu.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.msMenu.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.msMenu.Location = new System.Drawing.Point(0, 0);
            this.msMenu.Name = "msMenu";
            this.msMenu.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.msMenu.Size = new System.Drawing.Size(987, 49);
            this.msMenu.TabIndex = 1;
            this.msMenu.Text = "msMenu";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.saveGameToolStripMenuItem,
            this.exitGameToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(120, 45);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(331, 54);
            this.newGameToolStripMenuItem.Text = "New Game";
            // 
            // saveGameToolStripMenuItem
            // 
            this.saveGameToolStripMenuItem.Name = "saveGameToolStripMenuItem";
            this.saveGameToolStripMenuItem.Size = new System.Drawing.Size(331, 54);
            this.saveGameToolStripMenuItem.Text = "Save Game";
            // 
            // exitGameToolStripMenuItem
            // 
            this.exitGameToolStripMenuItem.Name = "exitGameToolStripMenuItem";
            this.exitGameToolStripMenuItem.Size = new System.Drawing.Size(331, 54);
            this.exitGameToolStripMenuItem.Text = "Exit Game";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informationPanelToolStripMenuItem,
            this.speakToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(149, 45);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // informationPanelToolStripMenuItem
            // 
            this.informationPanelToolStripMenuItem.Checked = true;
            this.informationPanelToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.informationPanelToolStripMenuItem.Name = "informationPanelToolStripMenuItem";
            this.informationPanelToolStripMenuItem.Size = new System.Drawing.Size(418, 54);
            this.informationPanelToolStripMenuItem.Text = "Information Panel";
            this.informationPanelToolStripMenuItem.Click += new System.EventHandler(this.informationPanelToolStripMenuItem_Click);
            // 
            // speakToolStripMenuItem
            // 
            this.speakToolStripMenuItem.Name = "speakToolStripMenuItem";
            this.speakToolStripMenuItem.Size = new System.Drawing.Size(418, 54);
            this.speakToolStripMenuItem.Text = "Speak";
            this.speakToolStripMenuItem.Click += new System.EventHandler(this.speakToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(104, 45);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(266, 54);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // pbxPanel
            // 
            this.pbxPanel.BackColor = System.Drawing.Color.PowderBlue;
            this.pbxPanel.Location = new System.Drawing.Point(0, 682);
            this.pbxPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbxPanel.Name = "pbxPanel";
            this.pbxPanel.Size = new System.Drawing.Size(984, 169);
            this.pbxPanel.TabIndex = 2;
            this.pbxPanel.TabStop = false;
            // 
            // txtPlayer1
            // 
            this.txtPlayer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlayer1.Location = new System.Drawing.Point(24, 747);
            this.txtPlayer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPlayer1.Name = "txtPlayer1";
            this.txtPlayer1.Size = new System.Drawing.Size(201, 53);
            this.txtPlayer1.TabIndex = 3;
            this.txtPlayer1.Text = "Player #1";
            // 
            // txtPlayer2
            // 
            this.txtPlayer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlayer2.Location = new System.Drawing.Point(522, 747);
            this.txtPlayer2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPlayer2.Name = "txtPlayer2";
            this.txtPlayer2.Size = new System.Drawing.Size(207, 53);
            this.txtPlayer2.TabIndex = 4;
            this.txtPlayer2.Text = "Player #2";
            // 
            // lblPlayer1Turn
            // 
            this.lblPlayer1Turn.AutoSize = true;
            this.lblPlayer1Turn.BackColor = System.Drawing.Color.MistyRose;
            this.lblPlayer1Turn.Font = new System.Drawing.Font("Consolas", 14.1F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer1Turn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPlayer1Turn.Location = new System.Drawing.Point(7, 690);
            this.lblPlayer1Turn.Name = "lblPlayer1Turn";
            this.lblPlayer1Turn.Size = new System.Drawing.Size(258, 55);
            this.lblPlayer1Turn.TabIndex = 5;
            this.lblPlayer1Turn.Text = "Your turn";
            // 
            // pbxWhiteIcon
            // 
            this.pbxWhiteIcon.Location = new System.Drawing.Point(765, 747);
            this.pbxWhiteIcon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbxWhiteIcon.Name = "pbxWhiteIcon";
            this.pbxWhiteIcon.Size = new System.Drawing.Size(80, 62);
            this.pbxWhiteIcon.TabIndex = 6;
            this.pbxWhiteIcon.TabStop = false;
            // 
            // pbxBlackIcon
            // 
            this.pbxBlackIcon.Location = new System.Drawing.Point(282, 747);
            this.pbxBlackIcon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbxBlackIcon.Name = "pbxBlackIcon";
            this.pbxBlackIcon.Size = new System.Drawing.Size(80, 62);
            this.pbxBlackIcon.TabIndex = 7;
            this.pbxBlackIcon.TabStop = false;
            // 
            // lblP2Tokens
            // 
            this.lblP2Tokens.AutoSize = true;
            this.lblP2Tokens.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblP2Tokens.Location = new System.Drawing.Point(880, 761);
            this.lblP2Tokens.Name = "lblP2Tokens";
            this.lblP2Tokens.Size = new System.Drawing.Size(43, 46);
            this.lblP2Tokens.TabIndex = 8;
            this.lblP2Tokens.Text = "2";
            // 
            // lblP1Tokens
            // 
            this.lblP1Tokens.AutoSize = true;
            this.lblP1Tokens.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblP1Tokens.Location = new System.Drawing.Point(405, 761);
            this.lblP1Tokens.Name = "lblP1Tokens";
            this.lblP1Tokens.Size = new System.Drawing.Size(43, 46);
            this.lblP1Tokens.TabIndex = 9;
            this.lblP1Tokens.Text = "2";
            // 
            // btnStartGame
            // 
            this.btnStartGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartGame.Location = new System.Drawing.Point(651, 67);
            this.btnStartGame.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(323, 81);
            this.btnStartGame.TabIndex = 10;
            this.btnStartGame.Text = "START GAME";
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // lblPlayer2Turn
            // 
            this.lblPlayer2Turn.AutoSize = true;
            this.lblPlayer2Turn.BackColor = System.Drawing.Color.MistyRose;
            this.lblPlayer2Turn.Font = new System.Drawing.Font("Consolas", 14.1F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer2Turn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPlayer2Turn.Location = new System.Drawing.Point(498, 690);
            this.lblPlayer2Turn.Name = "lblPlayer2Turn";
            this.lblPlayer2Turn.Size = new System.Drawing.Size(258, 55);
            this.lblPlayer2Turn.TabIndex = 11;
            this.lblPlayer2Turn.Text = "Your turn";
            // 
            // FrmGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 861);
            this.Controls.Add(this.lblPlayer2Turn);
            this.Controls.Add(this.btnStartGame);
            this.Controls.Add(this.lblP1Tokens);
            this.Controls.Add(this.lblP2Tokens);
            this.Controls.Add(this.pbxBlackIcon);
            this.Controls.Add(this.pbxWhiteIcon);
            this.Controls.Add(this.lblPlayer1Turn);
            this.Controls.Add(this.txtPlayer2);
            this.Controls.Add(this.txtPlayer1);
            this.Controls.Add(this.pbxPanel);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.msMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMenu;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGame";
            this.Text = "O\'Neillo Game";
            this.Load += new System.EventHandler(this.FrmGame_Load);
            this.msMenu.ResumeLayout(false);
            this.msMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxWhiteIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBlackIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.MenuStrip msMenu;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informationPanelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speakToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbxPanel;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TextBox txtPlayer1;
        private System.Windows.Forms.TextBox txtPlayer2;
        private System.Windows.Forms.Label lblPlayer1Turn;
        private System.Windows.Forms.PictureBox pbxWhiteIcon;
        private System.Windows.Forms.PictureBox pbxBlackIcon;
        private System.Windows.Forms.Label lblP2Tokens;
        private System.Windows.Forms.Label lblP1Tokens;
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.Label lblPlayer2Turn;
    }
}

