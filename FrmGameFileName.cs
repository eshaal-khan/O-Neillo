using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace O_Neillo
{
    public partial class FrmGameFileName : Form
    {
        /// <summary>
        /// Method <c>FrmGameFileName</c> opens the form for the user to enter what name they would like to save the current state under 
        /// </summary>
        public FrmGameFileName()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Method <c>btnSaveGame_Click</c> returns the entered file name to FrmGame. If nothing is entered, the current date and time is returned
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveGame_Click(object sender, EventArgs e)
        {
            string enteredFileName = txtEnteredFileName.Text;
            if (string.IsNullOrEmpty(txtEnteredFileName.Text))
            {
                enteredFileName= DateTime.Now.ToString(" HH-mm on dd-MM-yyyy");
            }
            else
            {
                enteredFileName = txtEnteredFileName.Text;
            }
            ((FrmGame)Owner).fileName = enteredFileName+".json";
            Close();
        }
    }
}
