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
    public partial class frmAbout : Form
    {
        /// <summary>
        /// Method <c>frmAbout</c> opens the about page when the aboout option is selected from the sub-menu of help on the menu strip
        /// </summary>
        public frmAbout()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Method <c>frmAbout_Load</c> retrieves and shows the necessary png in the picture box on frmAbout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAbout_Load(object sender, EventArgs e)
        {
            pbxAbout.Image = Image.FromFile(@"images\aboutPagePhoto.PNG");
        }
        /// <summary>
        /// Method <c>btnCloseAbout_Click</c> closes frmAbout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnCloseAbout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
