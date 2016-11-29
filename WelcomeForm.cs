using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisplayFreeSpace
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
        }

        private void sideMenu1_ButtonClicked(object sender, string e)
        {
            switch (e.ToUpper())
            {
                case "LBLCOLLECT":
                    collect1.Visible = true;
                    viewData1.Visible = false;
                    break;
                case "LBLVIEW":
                    collect1.Visible = false;
                    viewData1.Visible = true;
                    break;
                default:
                    break;
            }
        }

        private void collect1_Load(object sender, EventArgs e)
        {

        }
    }
}
