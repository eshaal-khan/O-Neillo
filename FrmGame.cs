using O_Neillo.GameboardGUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Speech.Synthesis;

namespace O_Neillo
{
    public partial class FrmGame : Form
    {
        //instantiates board & sets starting values for each tile of the board
        GameboardImageArray board;
        int[,] boardData = { { 10, 10, 10, 10, 10, 10, 10, 10 }, { 10, 10, 10, 10, 10, 10, 10, 10 },{ 10, 10, 10, 10, 10, 10, 10, 10 },
            {10,10,10,1,0,10,10,10},{ 10, 10, 10, 0, 1, 10, 10, 10 },{ 10, 10, 10, 10, 10, 10, 10, 10 },
            { 10, 10, 10, 10, 10, 10, 10, 10 },{ 10, 10, 10, 10, 10, 10, 10, 10 } };
        //sets up variables which will store player names
        string player1Name;
        string player2Name;
        int currentPlayer = 0;
        public string fileName { get; set; } //used to get name under which user wants to save name
        private void FrmGame_Load(object sender, EventArgs e) //loads images & sets player1 as starting player
        {
            pbxWhiteIcon.Image = Image.FromFile(@"images\pbxWhite.PNG");
            pbxBlackIcon.Image = Image.FromFile(@"images\pbxBlack.PNG");
            lblPlayer2Turn.Hide();
            btnStartGame.Show();
        }
        private void btnStartGame_Click(object sender, EventArgs e) //sets player names & makes textboxes read-only
        {
            if (string.IsNullOrEmpty(txtPlayer1.Text))
            {
                txtPlayer1.Text = "Player #1";
            }
            if (string.IsNullOrEmpty(txtPlayer2.Text))
            {
                txtPlayer2.Text = "Player #2";
            }
            player1Name = txtPlayer1.Text;
            player2Name = txtPlayer2.Text;
            txtPlayer1.ReadOnly = true;
            txtPlayer2.ReadOnly = true;
            btnStartGame.Hide();
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) //opens about page
        {
            frmAbout aboutPage = new frmAbout();
            aboutPage.ShowDialog();
        }
        private void informationPanelToolStripMenuItem_Click(object sender, EventArgs e) //hiding & showing info panel depending on state to checkbox
        {
            if (informationPanelToolStripMenuItem.Checked == true)
            {
                informationPanelToolStripMenuItem.Checked = false;
                lblPlayer1Turn.Hide();
                lblPlayer2Turn.Hide();
                lblP1Tokens.Hide();
                lblP2Tokens.Hide();
                txtPlayer1.Hide();
                txtPlayer2.Hide();
                pbxBlackIcon.Hide();
                pbxWhiteIcon.Hide();
                pbxPanel.Hide();
            }
            else
            {
                informationPanelToolStripMenuItem.Checked = true;
                lblPlayer1Turn.Show();
                lblPlayer2Turn.Show();
                lblP1Tokens.Show();
                lblP2Tokens.Show();
                txtPlayer1.Show();
                txtPlayer2.Show();
                pbxBlackIcon.Show();
                pbxWhiteIcon.Show();
                pbxPanel.Show();
            }
        }
        private void speakToolStripMenuItem_Click(object sender, EventArgs e) //Speech.Synthesis code will go here
        {
            if (speakToolStripMenuItem.Checked == true)
            {
                speakToolStripMenuItem.Checked = false;
            }
            else
            {
                speakToolStripMenuItem.Checked = true;
                var synthesizer = new SpeechSynthesizer();
                synthesizer.Speak("Speech is now on, after every move the name of the player who has just completed their turn, followed by " +
                    "the row and column number of the space where they have placed will be read out");
            }
        }
        public FrmGame() //sets inital display & view of all elements -> labels, board, textboxes, speech & panel options, drop down file names
        {
            InitializeComponent();
            string pathToJsonFiles = Directory.GetCurrentDirectory();
            string[] files = Directory.GetFiles(pathToJsonFiles, "*.json");
            foreach (string file in files) 
            {
                string nameToShow;
                nameToShow = file.Substring(65);
                char[] charsToTrim = { '.', 'j', 's', 'o', 'n' };
                nameToShow = nameToShow.TrimEnd(charsToTrim);
                
                saveGameToolStripMenuItem.DropDownItems.Add(nameToShow);
                restoreGameToolStripMenuItem.DropDownItems.Add(nameToShow);
            }
            txtPlayer1.Text = "Player #1";
            txtPlayer2.Text = "Player #2";
            lblP1Tokens.Text = "2";
            lblP2Tokens.Text = "2";
            txtPlayer1.ReadOnly = false;
            txtPlayer2.ReadOnly = false;
            lblPlayer1Turn.Show();
            lblPlayer2Turn.Hide();
            Point topLeftConnerFromFormSides = new Point(75, 75);
            Point bottomRightConnerFromFormSides = new Point(75, 75);
            string pathToImages = Directory.GetCurrentDirectory() + @"\images\";
            try
            {
                //creates board
                board = new GameboardImageArray(this, boardData, bottomRightConnerFromFormSides, bottomRightConnerFromFormSides, 5, pathToImages);
                //creates new tile clicked event every time a tile is clicked
                board.TileClicked += new GameboardImageArray.TileClickedEventDelegate(BoardTileClicked);
                //updates board display based on changes made due to tile being clicked, uses boardData 2D array
                board.UpdateBoardGui(boardData);
            }
            catch (Exception exception) //will run when the size for board set isn't compatible
            {
                DialogResult result = MessageBox.Show(exception.ToString(), "Game board size problem", MessageBoxButtons.OK);
                this.Close();
            }
        }

        public void BoardTileClicked(object sender, EventArgs e) //when tile is clicked
        {
            int clickedRowIndex = board.GetCurrentRowIndex(sender);
            int clickedColIndex = board.GetCurrentColumnIndex(sender);
            CheckValidityAndMakeMove(clickedRowIndex, clickedColIndex, currentPlayer);
            SwapTurn();
        }
        public void CheckValidityAndMakeMove(int row, int col, int currentPlayer) //will change the state of the board if the tile clicked is a valid move
        {
            bool validMove;
            int opposingPlayer;
            if (currentPlayer == 0)
            {
                opposingPlayer = 1;
            }
            else
            {
                opposingPlayer = 0;
            }
            int clickedSquareValue = boardData[row, col]; //gets the colour of the starting point tile         
            //stores the address of each of the places that need to be investigated
            int[,] adjacentSpacesToCheck = { { row, col - 1 }, { row, col + 1 },
            { row + 1, col }, { row - 1, col },
            { row - 1, col - 1 }, { row + 1, col + 1 },
            { row + 1, col - 1 }, { row - 1, col + 1 } };
            if (clickedSquareValue == 1 || clickedSquareValue == 0) //if they click on a square which contains a coloured token -> can't place a token on top of another token
            {
                validMove = false;
            }
            else
            {
                for (int i = 0; i < 8; i++) //num. of times it repeats = num. of items in spacesToCheck
                {
                    if (adjacentSpacesToCheck[i, 0] >= 0 && adjacentSpacesToCheck[i, 0] <= 7 && adjacentSpacesToCheck[i, 1] >= 0 && adjacentSpacesToCheck[i, 1] <= 7)
                    {
                        int[,] newSquare = new int[1, 2];
                        if (boardData[adjacentSpacesToCheck[i, 0], adjacentSpacesToCheck[i, 1]] == 10 || boardData[adjacentSpacesToCheck[i, 0], adjacentSpacesToCheck[i, 1]] == 11)
                        {
                            validMove = false;
                        }
                        else if (boardData[adjacentSpacesToCheck[i, 0], adjacentSpacesToCheck[i, 1]] == currentPlayer)
                        {
                            validMove = false;
                        }
                        else //if square after empty one is of opposing colour
                        {
                            int[,] direction = new int[1, 2]; //stores direction in which opposing colour was found
                            direction[0, 0] = adjacentSpacesToCheck[i, 0] - row;
                            direction[0, 1] = adjacentSpacesToCheck[i, 1] - col;
                            List<int[,]> spacesWithOpposingColour = new List<int[,]>();
                            while (adjacentSpacesToCheck[i, 0] >= 0 && adjacentSpacesToCheck[i, 0] <= 7 && adjacentSpacesToCheck[i, 1] >= 0 && adjacentSpacesToCheck[i, 1] <= 7) //boundary of board
                            {
                                if (boardData[adjacentSpacesToCheck[i, 0], adjacentSpacesToCheck[i, 1]] == 10) //if they encounter an empty square in that direction aside from the initial adjacent one
                                {
                                    validMove = false;
                                    break;
                                }
                                else if (boardData[adjacentSpacesToCheck[i, 0], adjacentSpacesToCheck[i, 1]] == opposingPlayer)
                                {
                                    validMove = true;
                                    int[,] temp = new int[1, 2];
                                    temp = new int[,] { { adjacentSpacesToCheck[i, 0], adjacentSpacesToCheck[i, 1] } };
                                    spacesWithOpposingColour.Add(temp);
                                    adjacentSpacesToCheck[i, 0] = adjacentSpacesToCheck[i, 0] + direction[0, 0];
                                    adjacentSpacesToCheck[i, 1] = adjacentSpacesToCheck[i, 1] + direction[0, 1];
                                }
                                else if (boardData[adjacentSpacesToCheck[i, 0], adjacentSpacesToCheck[i, 1]] == currentPlayer)
                                {
                                    validMove = true;
                                    string playerNameToSpeak;
                                    if (speakToolStripMenuItem.Checked == true)
                                    {
                                        if (currentPlayer == 0)
                                        {
                                            playerNameToSpeak = player1Name;
                                        }
                                        else
                                        {
                                            playerNameToSpeak = player2Name;
                                        }
                                        var synthesizer = new SpeechSynthesizer();
                                        synthesizer.Speak($"{playerNameToSpeak} has placed at space {row + 1},{col + 1}");
                                    }
                                    FlipTokens(spacesWithOpposingColour, row, col, currentPlayer);
                                    UpdateLabels();
                                    MoveLabel(currentPlayer);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        public void FlipTokens(List<int[,]> spaces, int row, int col, int currentPlayer) //changes values of tiles according to whose turn it is
        {
            foreach (int[,] square in spaces)
            {
                boardData[square[0, 0], square[0, 1]] = currentPlayer;
                boardData[row, col] = currentPlayer;
                board.UpdateBoardGui(boardData);
            }
        }

        public void UpdateLabels() //loops through whole board & updates counter values in labels
        {
            int white = 0;
            int black = 0;
            for (int i = 0; i <= 7; i++)
            {
                for (int j = 0; j <= 7; j++)
                {
                    if (boardData[i, j] == 0)
                    {
                        black = black + 1;
                    }
                    else if (boardData[i, j] == 1)
                    {
                        white = white + 1;
                    }
                }

            }
            lblP1Tokens.Text = Convert.ToString(black);
            lblP2Tokens.Text = Convert.ToString(white);
        }

        public void SwapTurn()
        {
            if (currentPlayer == 0)
            {
                currentPlayer = 1;
            }
            else
            {
                currentPlayer = 0;
            }
        }

        public void MoveLabel(int currentPlayer) //hides & shows respective values to indicate whose turn it is
        {
            if (currentPlayer == 0)
            {
                lblPlayer1Turn.Hide();
                lblPlayer2Turn.Show();
            }
            else
            {
                lblPlayer2Turn.Hide();
                lblPlayer1Turn.Show();
            }
        }

        public void BoardState() //gets current state of whole board
        {
            for (int i = 0; i <= 7; i++)
            {
                for (int j = 0; j <= 7; j++)
                {
                    boardData[i, j] = (boardData[i, j]);
                }
            }
        }
        private void saveGameToolStripMenuItem_Click(object sender, EventArgs e) //when player selects save option
        {
            if (restoreGameToolStripMenuItem.DropDownItems.Count<5) 
            {
                if (txtPlayer1.Text == "Player #1")
                {
                    player1Name = "Player #1";
                }
                if (txtPlayer2.Text == "Player #2")
                {
                    player2Name = "Player #2";
                }
                using (var enterFileNameForm = new FrmGameFileName())
                {
                    enterFileNameForm.Owner = this;
                    enterFileNameForm.ShowDialog();
                    string sentData = fileName;
                }
                SaveGame gameData = new SaveGame(player1Name, player2Name, Convert.ToInt32(lblP1Tokens.Text), Convert.ToInt32(lblP2Tokens.Text), currentPlayer,speakToolStripMenuItem.Checked, informationPanelToolStripMenuItem.Checked, boardData, fileName);
                gameData.writeData(gameData);
                MessageBox.Show("File successfully saved!");
                char[] charsToTrim = { '.', 'j', 's', 'o', 'n' };
                string nameToShow = fileName.TrimEnd(charsToTrim);
                restoreGameToolStripMenuItem.DropDownItems.Add(nameToShow);
                saveGameToolStripMenuItem.DropDownItems.Add(nameToShow);
            }
            else
            {
                MessageBox.Show("There are already 5 game states saved, please select one from the restore game sub-menu to overwrite");
            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e) //when player selects new game option
        {
            DialogResult result= MessageBox.Show("Are you sure you would like to start a new game? Any unsaved progress will be lost so ensure " +
                "you have saved this game if you would like to return to it, if so click yes to start new game","Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                FrmGame NewGame = new FrmGame();
                NewGame.ShowDialog();
                this.Close();
            }
        }

        private void exitGameToolStripMenuItem_Click(object sender, EventArgs e) //when player selects exit game option
        {
            DialogResult result = MessageBox.Show("Are you sure you would like to exit? Any unsaved progress will be lost so ensure " +
                "you have saved this game if you would like to return to it, if so click yes to exit.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void restoreGameToolStripMenuItem_Click(object sender, EventArgs e) //when player selects restore game option & theres no game states saved
        {
            if (restoreGameToolStripMenuItem.DropDownItems.Count == 0)
            {
                MessageBox.Show("There are no game states which can be restored, please save a game to enable this option");
            }
        }

        private void restoreGameToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e) //when player selects a game state from restore game sub-menu
        {
            this.Hide();
            FrmGame NewGame = new FrmGame();
            string fileName = e.ClickedItem.Text;
            string pathToFile = Directory.GetCurrentDirectory() + @"\" + fileName + ".json";
            string jsonString = File.ReadAllText(pathToFile);
            SaveGame deserializedGame = JsonConvert.DeserializeObject<SaveGame>(jsonString);
            NewGame.txtPlayer1.Text = deserializedGame.p1Name;
            NewGame.txtPlayer2.Text = deserializedGame.p2Name;
            NewGame.lblP1Tokens.Text = Convert.ToString(deserializedGame.p1TokenNum);
            NewGame.lblP2Tokens.Text = Convert.ToString(deserializedGame.p2TokenNum);
            NewGame.speakToolStripMenuItem.Checked = deserializedGame.speechTicked;
            NewGame.informationPanelToolStripMenuItem.Checked = deserializedGame.infoPanelTicked;
            if (deserializedGame.nextPlayerNum == 0)
            {
                NewGame.lblPlayer1Turn.Show();
                NewGame.lblPlayer2Turn.Hide();
            }
            else
            {
                NewGame.lblPlayer1Turn.Hide();
                NewGame.lblPlayer2Turn.Show();
            }
            NewGame.boardData = deserializedGame.boardState;
            NewGame.txtPlayer1.ReadOnly = true;
            NewGame.txtPlayer2.ReadOnly = true;
            NewGame.btnStartGame.Hide();
            NewGame.board.UpdateBoardGui(boardData);
            NewGame.ShowDialog();
            this.Close();
        }

        private void saveGameToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e) //when player selects game state from save game sub-menu
        {
            DialogResult result = MessageBox.Show("By selecting this option, you are overwriting the data of the selected file, the file name will remain the same. Please select yes to confirm this, select no to go back", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string fileName;
                fileName = Convert.ToString(e.ClickedItem.Text);
                string pathToFile = Directory.GetCurrentDirectory() + @"\" + fileName + ".json";
                File.Delete(pathToFile);
                int nextPlayer;
                if (currentPlayer == 0)
                {
                    nextPlayer = 1;
                }
                else
                {
                    nextPlayer = 0;
                }
                if (txtPlayer1.Text=="Player #1")
                {
                    player1Name = "Player #1";
                }
                if (txtPlayer2.Text=="Player #2")
                {
                    player2Name = "Player #2";
                }
                SaveGame gameData = new SaveGame(player1Name, player2Name, Convert.ToInt32(lblP1Tokens.Text), Convert.ToInt32(lblP2Tokens.Text), nextPlayer, speakToolStripMenuItem.Checked, informationPanelToolStripMenuItem.Checked, boardData, fileName+".json");
                gameData.writeData(gameData);
                MessageBox.Show("File successfully overwritten!");
            }
            
        }
    }
}
