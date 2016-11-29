using System;
using System.Drawing;
using System.Windows.Forms;

namespace DisplayFreeSpace
{
    public partial class SideMenu : UserControl
    {
        private Color ButtonSelected = Color.FromArgb(161, 189, 227);
        private Color MouseOverButton = Color.FromArgb(218, 218, 218);
        private Color MouseOverSelectedButton = Color.FromArgb(122, 163, 219);

        public event EventHandler<string> ButtonClicked;

        public SideMenu()
        {
            InitializeComponent();
            panel1.BackColor = Color.FromArgb(242, 242, 242);

            // Select this control
            this.lblCollect.Tag = "SELECTED";
            this.lblCollect.BackColor = ButtonSelected;
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            var lbl = sender as Label;
            if (lbl == null) return;

            if ((string)lbl.Tag == "SELECTED")
            {
                lbl.BackColor = MouseOverSelectedButton;
            }
            else
                lbl.BackColor = MouseOverButton;
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            var lbl = sender as Label;
            if (lbl == null) return;

            if ((string)lbl.Tag == "SELECTED")
            {
                lbl.BackColor = ButtonSelected;
            }
            else
                lbl.BackColor = panel1.BackColor;
        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            var lbl = sender as Label;
            if (lbl == null) return;

            // De-select the other controls
            foreach (var ctl in this.panel1.Controls)
            {
                var l = ctl as Label;
                if (l != null)
                {
                    l.Tag = "";
                    l.BackColor = this.panel1.BackColor;
                }
            }

            // Select this control
            lbl.Tag = "SELECTED";
            lbl.BackColor = ButtonSelected;

            // Tell the world
            ButtonClicked?.Invoke(lbl, lbl.Name);
        }
    }
}
