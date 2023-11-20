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
            public delegate void TileClickedEventDelegate(object sender, EventArgs e);

            public event TileClickedEventDelegate TileClicked;


            private int _topY, _topX, _boardRows, _boardCols, _tileMargin, _tileWidth, _tileHeight;
            private PictureBox[,] _boardTiles;
            private Form _containingForm;
            private string _tileImagesPath;

            public GameboardImageArray(Form parentForm, int[,] gameBoardStateArray, Point topLeftCorner,
                Point bottomRightCorner, int tileMargin, string tileImagePath)
            {
                _containingForm = parentForm;
                _boardRows = gameBoardStateArray.GetLength(0);
                _boardCols = gameBoardStateArray.GetLength(1);

                // Calculate the available Height for the game board, based on the size of the parent form and provided board parameters
                int boardHeight = parentForm.ClientSize.Height - ((topLeftCorner.Y + bottomRightCorner.Y) + (tileMargin * _boardCols - 1));
                // Calculate the available Width for the game board, based on the size of the parent form and provided board parameters
                int boardWidth = parentForm.ClientSize.Width - ((topLeftCorner.X + bottomRightCorner.X) + (tileMargin * _boardRows - 1));
                _topY = topLeftCorner.Y;
                _topX = topLeftCorner.X;
                this._tileMargin = tileMargin;
                _tileImagesPath = tileImagePath;

                _tileWidth = ComputeTileWidth(boardWidth);
                _tileHeight = ComputeTileHeight(boardHeight);

                // Check if the game board GUI is large enough. Throw a GameBoardImageArraySizeException if the board is too small
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
            ~GameboardImageArray()
            {
                for (int r = 0; r < _boardRows; r++)
                {
                    for (int c = 0; c < _boardCols; c++)
                    {
                        _containingForm.Controls.Remove(_boardTiles[r, c]);
                        _boardTiles[r, c].Dispose();
                    }
                }
            }
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

            public PictureBox GetTile(int row, int col)
            {
                return _boardTiles[row, col];
            }
            public bool SetTile(int row, int col, string imageName)
            {
                _boardTiles[row, col].ImageLocation = _tileImagesPath + imageName + ".PNG";
                return true;
            }
            /*public void ToRedOrBlueBoard(string tileColor = "Blue")
            {
                switch (tileColor[0].ToString().ToLower())
                {
                    case "r":
                        tileColor = "Red";
                        break;
                    case "b":
                        tileColor = "Blue";
                        break;
                    default:
                        tileColor = "Blue";
                        break;
                }
                for (int r = 0; r < _boardRows; r++)
                {
                    for (int c = 0; c < _boardCols; c++)
                    {
                        _boardTiles[r, c].ImageLocation = _tileImagesPath + tileColor + ".PNG";
                    }
                }

            }*/
            public bool ShowElement(int[,] updateArray, int row, int c)
            {
                // Checks to see if requested element is within the boundaries
                if ((row < _boardRows) && (c < _boardCols))
                {
                    _boardTiles[row, c].ImageLocation = _tileImagesPath + updateArray[row, c].ToString() + ".PNG";
                    return true;
                }

                return false;
            }
            public void UpdateLocation()
            {
                int Available_Height = _containingForm.ClientSize.Height - ((Top + Bottom) + (_tileMargin * _boardCols - 1));
                int Available_Width = _containingForm.ClientSize.Width - ((Left + Right) + (_tileMargin * _boardRows - 1));
                _topY = Top;
                _topX = Left;

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
                        _boardTiles[r, c].Location = new Point(l, t);
                        _boardTiles[r, c].Size = new Size(_tileWidth, _tileHeight);
                    }
                }
            }
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
            private void TileClickListener(object sender, EventArgs e)
            {
                if (this != null)
                    TileClicked(sender, e);
            }

            private int ComputeTileHeight(int boardHeight)
            {
                int tileHeight = boardHeight / _boardCols;
                return tileHeight;
            }

            private int ComputeTileWidth(int boardWidth)
            {
                int tileWidth = boardWidth / _boardRows;
                return tileWidth;
            }
        }

        public class GameboardImageArraySizeException : Exception
        {
            public GameboardImageArraySizeException() : base() { }
            public GameboardImageArraySizeException(string message) : base(message) { }
            public GameboardImageArraySizeException(string message, Exception inner) : base(message, inner) { }

        }
    }
}
