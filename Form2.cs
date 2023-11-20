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
        public frmAbout()
        {
            InitializeComponent();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            pbxAbout.Image = Image.FromFile(@"images\aboutPagePhoto.PNG");
        }

        private void btnCloseAbout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
