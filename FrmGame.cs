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
        //set initial values for each board tile, instantiate player-related variables
        GameboardImageArray board;
        int[,] boardData = { { 10, 10, 10, 10, 10, 10, 10, 10 }, { 10, 10, 10, 10, 10, 10, 10, 10 },{ 10, 10, 10, 10, 10, 10, 10, 10 },
            {10,10,10,1,0,10,10,10},{ 10, 10, 10, 0, 1, 10, 10, 10 },{ 10, 10, 10, 10, 10, 10, 10, 10 },
            { 10, 10, 10, 10, 10, 10, 10, 10 },{ 10, 10, 10, 10, 10, 10, 10, 10 } };
        string player1Name;
        string player2Name;
        int currentPlayer = 0;

        //public attribute used later for attaining file name from FrmGameFileName when saving a game state
        public string fileName { get; set; }

        /// <summary>
        /// Method <c>FrmGame_Load</c> loads and sets the components needed for the start of the game 
        /// (images for the picture boxes, shows the start game button, indicate that player#1 is starting)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmGame_Load(object sender, EventArgs e)
        {
            pbxWhiteIcon.Image = Image.FromFile(@"images\pbxWhite.PNG");
            pbxBlackIcon.Image = Image.FromFile(@"images\pbxBlack.PNG");
            lblPlayer2Turn.Hide();
            btnStartGame.Show();
        }
        /// <summary>
        /// Method <c>btnStartGame_Click</c> stores the entered player names into their respective variables (Player #1 and Player #2 if they are left blank),
        /// makes the textboxes read-only and hides the button to indicate the game starting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartGame_Click(object sender, EventArgs e)
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
        /// <summary>
        /// Method <c>aboutToolStripMenuItem_Click</c> opens the about page (frmAbout) when that option is selected from the sub menu of 'Help' on the menu strip
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout aboutPage = new frmAbout();
            aboutPage.ShowDialog();
        }
        /// <summary>
        /// Method<c>informationPanelToolStripMenuItem_Click</c> hides and shows the information panel components depending on the state of the checkbox
        /// (checked = show all the components, unchecked= hide all the components)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void informationPanelToolStripMenuItem_Click(object sender, EventArgs e)
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
        /// <summary>
        /// Method <c>speakToolStripMenuItem_Click</c> turns the speech function on and off depending on state of the checkbox.
        /// If it is checked, it will read a message indicating it is on
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void speakToolStripMenuItem_Click(object sender, EventArgs e)
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
        /// <summary>
        /// Method <c>FrmGame</c> opens the main game form, which includes several things. It retrieves the names of the currently stored game states to display
        /// on the save game sub-menu (for overwriting) and restore game sub-menu, it also sets the initial values for components including the textboxes,
        /// labels used to count the amount of coloured tokens and showing/hiding the correct labels to indicate that Player 1 starts.
        /// It will ensure both textboxes are intially not read-only, and also creates a new GameBoardImageArray object to show the board, and sets up the
        /// TileClicked event. It also includes some exception handling to manage errors with the size.
        /// </summary>
        public FrmGame() //set inital display & view of all components -> labels, board, textboxes, speech & panel options, drop down file names
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
                board = new GameboardImageArray(this, boardData, bottomRightConnerFromFormSides, bottomRightConnerFromFormSides, 5, pathToImages);
                board.TileClicked += new GameboardImageArray.TileClickedEventDelegate(BoardTileClicked);
                board.UpdateBoardGui(boardData);
            }
            catch (Exception exception)
            {
                DialogResult result = MessageBox.Show(exception.ToString(), "Game board size problem", MessageBoxButtons.OK);
                this.Close();
            }
        }

        /// <summary>
        /// Method <c>BoardTileClicked</c> gets the row and column index of the clicked tile using the GetCurrentRowIndex and GetCurrentColumnInex methods
        /// for GameBoardImageArray objects, these are passed through along with the current player to CheckValidityAndMakeMove. After this is run, the method
        /// runs SwapTurn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BoardTileClicked(object sender, EventArgs e) //when tile is clicked
        {
            int clickedRowIndex = board.GetCurrentRowIndex(sender);
            int clickedColIndex = board.GetCurrentColumnIndex(sender);
            CheckValidityAndMakeMove(clickedRowIndex, clickedColIndex, currentPlayer);
            SwapTurn();
        }
        /// <summary>
        /// Method <c>CheckValidityAndMakeMove</c> uses the row and column values, plus the current player to check if the clicked square is a valid move
        /// and if so, it identifies and commits the changes which need to be made to the board. The following comments describe key structures/steps in the method chronologically
        /// The adjacentSpacesToCheck array stores the co-ordinates of all tiles adjacent to the one clicked. 
        /// If the square clicked is a black or white tile, the move cannot be made. 
        /// If the square clicked has an adjacent empty space or if it has a square of the current player's, the move cannot be made in the direction of the adjacent space checked
        /// A list of 2D arrays is then used to store the co-ordinates of all the tiles visited in the valid directions identified. The program continues to
        /// visit tiles in a direction, until an empty tile or end of the board is reached (both cases = not a valid move)
        /// OR until a tile of the current player's tile colour is reached AFTER a consecutive line of opponent tiles (co-ordinates stored in spacesWithOpposingColour list of 2D arrays)
        /// , in which case the move is valid.
        /// When the move is valid, if the speak checkbox is ticked, it will read out the player and where they have placed. Then regardless of if speech is
        /// active or not, a list of 2D arrays (spacesWithOpposingColour), the current player and row and column of the initial square clicked are passed
        /// into FlipTokens. Once this has been run,UpdateLabels and MoveLabel methods are executed, passing the current player in MoveLabel
        /// </summary>
        /// <param name="row">passed from BoardTileClicked</param>  
        /// <param name="col">passed from BoardTileClicked</param>
        /// <param name="currentPlayer">passed from BoardTileClicked</param>
        public void CheckValidityAndMakeMove(int row, int col, int currentPlayer)
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
            int clickedSquareValue = boardData[row, col];
            int[,] adjacentSpacesToCheck = { { row, col - 1 }, { row, col + 1 },
            { row + 1, col }, { row - 1, col },
            { row - 1, col - 1 }, { row + 1, col + 1 },
            { row + 1, col - 1 }, { row - 1, col + 1 } };
            if (clickedSquareValue == 1 || clickedSquareValue == 0)
            {
                validMove = false;
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    if (adjacentSpacesToCheck[i, 0] >= 0 && adjacentSpacesToCheck[i, 0] <= 7 && adjacentSpacesToCheck[i, 1] >= 0 && adjacentSpacesToCheck[i, 1] <= 7)
                    {
                        int[,] newSquare = new int[1, 2];
                        if (boardData[adjacentSpacesToCheck[i, 0], adjacentSpacesToCheck[i, 1]] == 10)
                        {
                            validMove = false;
                        }
                        else if (boardData[adjacentSpacesToCheck[i, 0], adjacentSpacesToCheck[i, 1]] == currentPlayer)
                        {
                            validMove = false;
                        }
                        else
                        {
                            int[,] direction = new int[1, 2];
                            direction[0, 0] = adjacentSpacesToCheck[i, 0] - row;
                            direction[0, 1] = adjacentSpacesToCheck[i, 1] - col;
                            List<int[,]> spacesWithOpposingColour = new List<int[,]>();
                            while (adjacentSpacesToCheck[i, 0] >= 0 && adjacentSpacesToCheck[i, 0] <= 7 && adjacentSpacesToCheck[i, 1] >= 0 && adjacentSpacesToCheck[i, 1] <= 7)
                            {
                                if (boardData[adjacentSpacesToCheck[i, 0], adjacentSpacesToCheck[i, 1]] == 10)
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
        /// <summary>
        /// Method <c>FlipTokens</c> receives a list of spaces, the initially clicked tile co-ordinares and the current player.
        /// It changes the value of the spaces to the colour of the current player's token, completing the player's move and showing it on the GUI
        /// </summary>
        /// <param name="spaces">passed from CheckValidityAndMakeMove (spacesWithOpposingColour)</param>
        /// <param name="row">passed from CheckValidityAndMakeMove</param>
        /// <param name="col">passed from CheckValidityAndMakeMove</param> passed from CheckValidityAndMakeMove
        /// <param name="currentPlayer">passed from CheckValidityAndMakeMove</param>
        public void FlipTokens(List<int[,]> spaces, int row, int col, int currentPlayer)
        {
            foreach (int[,] square in spaces)
            {
                boardData[square[0, 0], square[0, 1]] = currentPlayer;
                boardData[row, col] = currentPlayer;
                board.UpdateBoardGui(boardData);
            }
        }
        /// <summary>
        /// Method <c>UpdateLabels</c> uses nested selection to loop through every tile on the board and check the value of each one.
        /// If the tile is black, the counter for the black tokens is incremented, the same applies to if the tile is white.
        /// After visiting all the tiles, the counter variable values are displayed via their respective labels.
        /// Called when a move has been made as part of swapping the turn
        /// </summary>
        public void UpdateLabels()
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

        /// <summary>
        /// Method <c>SwapTurn</c> inverts the currentPlayer value to swap which player's turn it is
        /// </summary>
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

        /// <summary>
        /// Method <c>MoveLabel</c> uses the received currentPlayer value to hide and show the respective labels to indicate which player's turn it is
        /// Called when a move has been made as part of swapping the turn
        /// </summary>
        /// <param name="currentPlayer">passed from CheckValidityAndMakeMove</param>
        public void MoveLabel(int currentPlayer)
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
        /// <summary>
        /// Method <c>saveGameToolStripMenuItem_Click</c> runs when the user wants to save the current game state.
        /// If there are already 5 game states saved, the user is notified that they can only rewrite one and not create a new saved state.
        /// Otherwise, FrmGameFileName is opened, where the user enters the name under which to save the game state (current date and time if empty).
        /// This is returned to this form (FrmGame) and the data which needs to be saved is compiled into a new SaveGame object and written to a json file
        /// using the writeData method is SaveGame.cs
        /// The new game name is added to the restore game and save game sub-menus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveGameToolStripMenuItem_Click(object sender, EventArgs e)
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
                try
                {
                    SaveGame gameData = new SaveGame(player1Name, player2Name, Convert.ToInt32(lblP1Tokens.Text), Convert.ToInt32(lblP2Tokens.Text), currentPlayer, speakToolStripMenuItem.Checked, informationPanelToolStripMenuItem.Checked, boardData, fileName);
                    gameData.writeData(gameData);
                    MessageBox.Show("File successfully saved!");
                    char[] charsToTrim = { '.', 'j', 's', 'o', 'n' };
                    string nameToShow = fileName.TrimEnd(charsToTrim);
                    restoreGameToolStripMenuItem.DropDownItems.Add(nameToShow);
                    saveGameToolStripMenuItem.DropDownItems.Add(nameToShow);
                }
                catch (Exception exception)
                {
                    DialogResult result = MessageBox.Show(exception.ToString(), "Error in saving game state", MessageBoxButtons.OK);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("There are already 5 game states saved, please select one from the restore game sub-menu to overwrite");
            }
        }

        /// <summary>
        /// Method <c>newGameToolStripMenuItem_Click</c> runs when the user selects the 'New Game' option on the menu strip. It asks the user to confirm.
        /// Once they confirm, it will close the current game form, and open a new one with the starting settings and components
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result= MessageBox.Show("Are you sure you would like to start a new game? Any unsaved progress will be lost so ensure " +
                "you have saved this game if you would like to return to it, if so click yes to start new game","Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    this.Hide();
                    FrmGame NewGame = new FrmGame();
                    NewGame.ShowDialog();
                    this.Close();
                }
                catch (Exception exception)
                {
                    DialogResult result2 = MessageBox.Show(exception.ToString(), "Error in creating a new game", MessageBoxButtons.OK);
                    this.Close();
                }
            }
        }

       /// <summary>
       /// Method <c>exitGameToolStripMenuItem_Click</c> runs when the user selects the 'Exit Game' option on the menu strip. It asks the user to confirm.
       /// Once they confirm, the game form is closed
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void exitGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you would like to exit? Any unsaved progress will be lost so ensure " +
                "you have saved this game if you would like to return to it, if so click yes to exit.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Method <c>restoreGameToolStripMenuItem_Click</c> runs when the user selects 'Restore Game' from the menu strip. If there are no game states saved,
        /// it notifies the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void restoreGameToolStripMenuItem_Click(object sender, EventArgs e) //when player selects restore game option & theres no game states saved
        {
            if (restoreGameToolStripMenuItem.DropDownItems.Count == 0)
            {
                MessageBox.Show("There are no game states which can be restored, please save a game to enable this option");
            }
        }

        /// <summary>
        /// Method <c>restoreGameToolStripMenuItem_DropDownItemClicked</c> when the user selects a saved game to restore
        /// The game data is retrieved and deserialized into a new SaveGame object, from which the data is read into components on the new form for the restored game
        /// Once the data is read into the components and the components are correctly set, the current form is closed and a new instance of FrmGame
        /// with the restored game data is shown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void restoreGameToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
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
            catch (Exception exception)
            {

                DialogResult result = MessageBox.Show(exception.ToString(), "Error in restoring game", MessageBoxButtons.OK);
                this.Close();
            }
            
        }

        /// <summary>
        /// Method <c>saveGameToolStripMenuItem_DropDownItemClicked</c> when the user selects the name of a saved game state to overwrite.
        /// The user is asked to confirm, then the overwriting works by deleting the selected game state and creating a new one with the same name
        /// It creates a new SaveGame object and game state with the same name as the one deleted and notifies user when completed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveGameToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show("By selecting this option, you are overwriting the data of the selected file, the file name will remain the same. Please select yes to confirm this, select no to go back", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
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
                    if (txtPlayer1.Text == "Player #1")
                    {
                        player1Name = "Player #1";
                    }
                    if (txtPlayer2.Text == "Player #2")
                    {
                        player2Name = "Player #2";
                    }
                    SaveGame gameData = new SaveGame(player1Name, player2Name, Convert.ToInt32(lblP1Tokens.Text), Convert.ToInt32(lblP2Tokens.Text), nextPlayer, speakToolStripMenuItem.Checked, informationPanelToolStripMenuItem.Checked, boardData, fileName + ".json");
                    gameData.writeData(gameData);
                    MessageBox.Show("File successfully overwritten!");
                }
                catch (Exception exception)
                {

                    DialogResult result2 = MessageBox.Show(exception.ToString(), "Error in overwriting", MessageBoxButtons.OK);
                    this.Close();
                }
            }
            
        }
    }
}
