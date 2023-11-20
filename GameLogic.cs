using O_Neillo.GameboardGUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace O_Neillo
{
    public partial class GameLogic:FrmGame
    {
        //everything will need to go in a while loop which keeps checking if the game is over (while !GameOver)
        //set GameOver as boolean variable
        //each pass should look at where P1 placed the token, examine all adjacent squares
        //for each adjacent suqare, check if it is the opposing colour
        //if it is not, disregard those as potential moves
        //if it is, continue to look in the same direction for opposing colour tile, same colour tile, empty tile or boundary
        //create a list to store the value of each square investigated on a path in the same direction once it's been identified as a valid path
        //if a boundary is reached, it is not a valid move
        //if opposing colour is reached, keep looking
        //if same colour is reached, it is a valid move
        //if an empty space is reached, it is not a valid move
        //wherever a valid move has been identified, place a 10 square 
        //where there is a 10 square, allow them to click there
        //if the user clicks on a square which does not have a 10, show a messagebox with an error saying they can't place here
        /*public void CheckValidity()
        {
            int clickedRowIndex = board.GetCurrentRowIndex(sender);
            int clickedColIndex = board.GetCurrentColumnIndex(sender);
            MessageBox.Show("Checking validity");
        }*/

        public void CheckForValidMove()
        {
            MessageBox.Show("Checking for valid move");
        }
        public void TurnTokens()
        {
            MessageBox.Show("Turning Tokens");
        }
        public void isGameOver()
        {
            MessageBox.Show("Game is over");
        }
    }

}
