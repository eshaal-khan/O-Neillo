using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace O_Neillo
{
    namespace GameboardGUI
    {
        public class GameboardImageArray : UserControl
        {
            /// <summary>
            /// Delegate class which is used to represent the event run when the player clicks a tile
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            public delegate void TileClickedEventDelegate(object sender, EventArgs e);

            /// <summary>
            /// Instantiation of the TileClickedEventDelegate class
            /// </summary>
            public event TileClickedEventDelegate TileClicked;


            //attributes for a GameBoardImageArray object
            private int _topY, _topX, _boardRows, _boardCols, _tileMargin, _tileWidth, _tileHeight;
            private PictureBox[,] _boardTiles;
            private Form _containingForm;
            private string _tileImagesPath;

            /// <summary>
            /// Method <c>GameboardImageArray</c> constructor for GameboardImageArray class
            /// Generates array of images from an int array sent in
            /// </summary>
            /// <param name="parentForm"> form object on which the gameboard tiles will be displayed.</param>
            /// <param name="gameBoardStateArray">int array of game state data</param>
            /// <param name="topY">position of the top left corner of the game board relative to the parentForm's top border</param>
            /// <param name="topX">position of the top left corner of the game board relative to the parentForm's left border</param>
            /// <param name="bottomY">position of the bottom right corner of the game board relative to the parentForm's bottom border</param>
            /// <param name="bottomX">position of the bottom right corner of the game board relative to the parentForm's right border</param>
            /// <param name="tileMargin">gap between each image, e.g., Top, Left, Right and Bottom </param>
            /// <param name="tileImagePath">directory path to the images</param>
            public GameboardImageArray(Form parentForm, int[,] gameBoardStateArray, Point topLeftCorner,
                Point bottomRightCorner, int tileMargin, string tileImagePath)
            {
                _containingForm = parentForm;
                _boardRows = gameBoardStateArray.GetLength(0);
                _boardCols = gameBoardStateArray.GetLength(1);
                int boardHeight = parentForm.ClientSize.Height - ((topLeftCorner.Y + bottomRightCorner.Y) + (tileMargin * _boardCols - 1));
                int boardWidth = parentForm.ClientSize.Width - ((topLeftCorner.X + bottomRightCorner.X) + (tileMargin * _boardRows - 1));
                _topY = topLeftCorner.Y;
                _topX = topLeftCorner.X;
                this._tileMargin = tileMargin;
                _tileImagesPath = tileImagePath;

                _tileWidth = ComputeTileWidth(boardWidth);
                _tileHeight = ComputeTileHeight(boardHeight);
                if ((_tileWidth < 5) || (_tileHeight < 5))
                {
                    string exceptionMessage = "The Images requested will be to small." +
                        "\rPlease increase the window size or reduce the number of elements required!";
                    throw new GameboardImageArraySizeException(exceptionMessage);
                }
                else
                {
                    _boardTiles = new PictureBox[_boardRows, _boardCols];

                    RenderGameStateToGui(parentForm, gameBoardStateArray);
                }
            }
            /// <summary>
            /// Method <c>UpdateBoardGui</c> updates the gameboard display based on the 2D array data (gameStateArray) parameter passed in
            /// </summary>
            /// <param name="gameStateArray"> array containing the current game state.</param>
            public void UpdateBoardGui(int[,] gameStateArray)
            {
                for (int r = 0; r < _boardRows; r++)
                {
                    for (int c = 0; c < _boardCols; c++)
                    {
                        _boardTiles[r, c].ImageLocation = _tileImagesPath + gameStateArray[r, c].ToString() + ".PNG";
                    }
                }
            }
            /// <summary>
            /// Method <c>GetCurrentColumnIndex</c> returns index of the column of the clicked on tile
            /// </summary>
            /// <param name="sender">the object selected within the grid array</param>
            /// <returns>index of the column where the object is stored in the array</returns>
            public int GetCurrentColumnIndex(object sender)
            {
                for (int r = 0; r < _boardRows; r++)
                {
                    for (int c = 0; c < _boardCols; c++)
                    {
                        if (sender == _boardTiles[r, c])
                        {
                            return c;
                        }
                    }
                }
                return -1;
            }
            /// <summary>
            /// Method <c>GetCurrentRowIndex</c> returns the index of the row of the clicked on tile
            /// </summary>
            /// <param name="sender"> the object selected within the grid array</param>
            /// <returns>index of the row where the object is stored in the array</returns>
            public int GetCurrentRowIndex(object sender)
            {
                for (int r = 0; r < _boardRows; r++)
                {
                    for (int c = 0; c < _boardCols; c++)
                    {
                        if (sender == _boardTiles[r, c])
                        {
                            return r;
                        }
                    }
                }
                return -1;
            }
            /// <summary>
            /// Method <c>RenderGameStateToGui</c> displays game state on the GUI
            /// </summary>
            /// <param name="parentForm"></param>
            /// <param name="gameStateArray"></param>
            private void RenderGameStateToGui(Form parentForm, int[,] gameStateArray)
            {
                for (int r = 0; r < _boardRows; r++)
                {
                    for (int c = 0; c < _boardCols; c++)
                    {
                        int l = _topX;
                        if (c > 0)
                            l = l + (_tileWidth * c) + (_tileMargin * c);
                        int t = _topY;
                        if (r > 0)
                            t = t + (_tileHeight * r) + (_tileMargin * r);
                        _boardTiles[r, c] = new PictureBox();
                        _boardTiles[r, c].SizeMode = PictureBoxSizeMode.StretchImage;
                        _boardTiles[r, c].Location = new Point(l, t);
                        _boardTiles[r, c].Size = new Size(_tileWidth, _tileHeight);
                        _boardTiles[r, c].ImageLocation = _tileImagesPath + gameStateArray[r, c].ToString() + ".PNG";
                        _boardTiles[r, c].Click += new EventHandler(TileClickListener);
                        _containingForm.Controls.Add(_boardTiles[r, c]);
                    }
                }
            }
            /// <summary>
            /// Method <c>TileClickListener</c> listens to the click event on each tile 
            /// and raises the event that will be handled by the parent form
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void TileClickListener(object sender, EventArgs e)
            {
                if (this != null)
                    TileClicked(sender, e);
            }

            /// <summary>
            /// Method <c>ComputeTileHeight</c> calculates height of each tile, using the boardHeight and number of columns
            /// </summary>
            /// <param name="boardHeight"></param>
            /// <returns> height of each tile </returns>
            private int ComputeTileHeight(int boardHeight)
            {
                int tileHeight = boardHeight / _boardCols;
                return tileHeight;
            }
            /// <summary>
            /// Method <c>ComputeTileWidth</c> calcualtes width of each tile, using the boardWidth and number of rows
            /// </summary>
            /// <param name="boardWidth"></param>
            /// <returns> width of each tile </returns>
            private int ComputeTileWidth(int boardWidth)
            {
                int tileWidth = boardWidth / _boardRows;
                return tileWidth;
            }
        }

        /// <summary>
        /// Class <c>GameboardImageArraySizeException : Exception</c> inheritign from the System.Exception class, manages exception handling in the program
        /// </summary>
        public class GameboardImageArraySizeException : Exception
        {
            public GameboardImageArraySizeException() : base() { }
            public GameboardImageArraySizeException(string message) : base(message) { }
            public GameboardImageArraySizeException(string message, Exception inner) : base(message, inner) { }

        }
    }
}
