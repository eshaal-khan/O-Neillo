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
        public FrmGameFileName()
        {
            InitializeComponent();
        }

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
