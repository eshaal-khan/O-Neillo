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
        bool GameOver = false;

        private void FrmGame_Load(object sender, EventArgs e) //runs when form is opened
        {
            //loads token photos onto GUI next to player names
            pbxWhiteIcon.Image = Image.FromFile(@"images\pbxWhite.PNG");
            pbxBlackIcon.Image = Image.FromFile(@"images\pbxBlack.PNG");
            lblPlayer2Turn.Hide();
        }
        private void btnStartGame_Click(object sender, EventArgs e) //runs when button is clicked
        {
            //checks that both textboxes contain text, otherwise they are filled with Player + respective number
            if (string.IsNullOrEmpty(txtPlayer1.Text))
            {
                txtPlayer1.Text = "Player #1";
            }
            if (string.IsNullOrEmpty(txtPlayer2.Text))
            {
                txtPlayer2.Text = "Player #2";
            }
            //stores contents of textboxes into variables
            player1Name = txtPlayer1.Text;
            player2Name = txtPlayer2.Text;
            //sets both textboxes to read-only when game starts -> names can't be changes then
            txtPlayer1.ReadOnly = true;
            txtPlayer2.ReadOnly = true;
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) //runs when about option on Help is clicked
        {
            //opens new form containing info about the game
            frmAbout aboutPage = new frmAbout(); 
            aboutPage.ShowDialog();
        }
        private void informationPanelToolStripMenuItem_Click(object sender, EventArgs e) //runs when information panel option on Settings is clicked
        {
            if (informationPanelToolStripMenuItem.Checked==true)
            {
                informationPanelToolStripMenuItem.Checked = false;
                lblPlayer1Turn.Hide();
                lblPlayer2Turn.Hide();
                lblMessage.Hide();
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
                lblMessage.Show();
                lblP1Tokens.Show();
                lblP2Tokens.Show();
                txtPlayer1.Show();
                txtPlayer2.Show();
                pbxBlackIcon.Show();
                pbxWhiteIcon.Show();
                pbxPanel.Show();
            }
        }
        private void speakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (speakToolStripMenuItem.Checked==true)
            {
                speakToolStripMenuItem.Checked = false;
            }
            else
            {
                speakToolStripMenuItem.Checked = true;
            }
        }
        public FrmGame()
        {
            //runs when program is run 
            //sets size of board & gets directory to images folder containing PNGs needed
            InitializeComponent();
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
            catch (Exception exception) //will run when the size for board set isn't compatible -> prevents program crashing
            {
                DialogResult result = MessageBox.Show(exception.ToString(), "Game board size problem", MessageBoxButtons.OK);
                this.Close();
            }
        }

        public void BoardTileClicked(object sender, EventArgs e) //when tile is clicked
        {
            int currentPlayer = 0;
            //gets index value of row & column of tile that's been clicked on
            int clickedRowIndex = board.GetCurrentRowIndex(sender);
            int clickedColIndex = board.GetCurrentColumnIndex(sender);
            while (GameOver==false)
            {
                CheckValidity(clickedRowIndex, clickedColIndex,currentPlayer);
                currentPlayer=ChangeTurn(0);
                CheckValidity(clickedRowIndex, clickedColIndex, currentPlayer);
                currentPlayer=ChangeTurn(1);
                break;
            }
        }
        public void CheckValidity(int row, int col, int currentPlayer)
        {
            bool validMove;
            //int currentPlayer; //stores PNG code of current player 0=black, 1=white
            //currentPlayer = 0;
            int opposingPlayer;
            //opposingPlayer = 1;
            if (currentPlayer==0)
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
                //MessageBox.Show(Convert.ToString(clickedRowIndex) + Convert.ToString(clickedColIndex));
                //MessageBox.Show(Convert.ToString(originalSquareColour));
            }
            else
            {
                for (int i = 0; i < 8; i++) //num. of times it repeats = num. of items in spacesToCheck
                {
                    //MessageBox.Show($"Testing position {i} of 7");
                    if (adjacentSpacesToCheck[i, 0] >= 0 && adjacentSpacesToCheck[i, 0] <= 7 && adjacentSpacesToCheck[i, 1] >= 0 && adjacentSpacesToCheck[i, 1] <= 7)
                    {
                        int[,] newSquare = new int[1, 2];
                        //MessageBox.Show($"Looking at cell [{spacesToCheck[i, 0]}, {spacesToCheck[i, 1]}] based from [{row}, {col}]");
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
                                //MessageBox.Show($"Looking at cell [{spacesToCheck[i, 0]}, {spacesToCheck[i, 1]}] based from [{row}, {col}]");
                                if (boardData[adjacentSpacesToCheck[i, 0], adjacentSpacesToCheck[i, 1]] == 10) //if they encounter an empty square in that direction aside from the initial adjacent one
                                {
                                    validMove = false;
                                    break;
                                }
                                else if (boardData[adjacentSpacesToCheck[i, 0], adjacentSpacesToCheck[i, 1]] == opposingPlayer)
                                {
                                    validMove = true;
                                    int[,]temp=new int[1, 2];
                                    temp = new int[,] { { adjacentSpacesToCheck[i, 0], adjacentSpacesToCheck[i, 1] } };
                                    //MessageBox.Show($"Looking at cell [{spacesToCheck[i, 0]}, {spacesToCheck[i, 1]}] based from [{row}, {col}]");
                                    //MessageBox.Show($"The value of temp is [{temp[0,0]}, {temp[0, 1]}]");
                                    spacesWithOpposingColour.Add(temp);
                                    adjacentSpacesToCheck[i, 0] = adjacentSpacesToCheck[i, 0] + direction[0, 0];
                                    adjacentSpacesToCheck[i, 1] = adjacentSpacesToCheck[i, 1] + direction[0, 1];
                                }
                                else if (boardData[adjacentSpacesToCheck[i, 0], adjacentSpacesToCheck[i, 1]] == currentPlayer)
                                {
                                    FlipTokens(spacesWithOpposingColour, row, col,currentPlayer);
                                    UpdateLabels();
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        public void FlipTokens(List<int[,]> spaces, int row, int col, int currentPlayer)
        {
            foreach (int[,] square in spaces)
            {
                //MessageBox.Show(Convert.ToString(boardData[square[0, 0], square[0, 1]]));
                //MessageBox.Show(Convert.ToString(square[0, 0]) + Convert.ToString(square[0, 1]));
                boardData[square[0, 0], square[0, 1]] = currentPlayer;
                boardData[row, col] = currentPlayer;
                board.UpdateBoardGui(boardData);
            }
        }

        /*public void FindMoves()
        {
            for (int i = 0; i <= 7; i++)
            {
                for (int j = 0; j <= 7; j++)
                {
                    CheckValidity(i,j);
                }
            }
        }*/

        public void UpdateLabels()
        {
            int white=0;
            int black=0;
            for (int i = 0; i <= 7; i++)
            {
                for (int j = 0; j <= 7; j++)
                {
                    if (boardData[i, j]==0)
                    {
                        black = black + 1;
                    }
                    else if (boardData[i,j]==1)
                    {
                        white = white + 1;
                    }
                }

            }
            lblP1Tokens.Text = Convert.ToString(black);
            lblP2Tokens.Text = Convert.ToString(white);
        }

        public int ChangeTurn(int currentPlayer)
        {
            if (currentPlayer == 0)
            {
                currentPlayer = 1;
                lblPlayer2Turn.Hide();
                lblPlayer1Turn.Show();
            }
            else
            {
                currentPlayer = 0;
                lblPlayer1Turn.Hide();
                lblPlayer2Turn.Show();
            }
            return currentPlayer;
        }
        public bool GameOverChecker(bool GameOver)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {

                    //no squares contain 10
                    //no valid moves for player1
                    //no valid moves for player2
                }
            }
            GameOver = true;
            return GameOver;
            //bool GameOver
            //nested for loop running through whole board
            //if none of the squares contain 10 -> GameOver=true
            //if after running findMoves for player1
             //nested for loop running through whole board
             //none of the squares contain 11
             //AND if after running findMoves for player2
               //none of the squares contain 11
               //GameOver=true
            //display winner (winner is player whose label contains the highest number)
        }
    }
}
