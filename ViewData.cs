using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DisplayFreeSpace
{
    public partial class ViewData : UserControl
    {
        public ViewData()
        {
            InitializeComponent();

            this.txtStorageFile1.Text = @"c:\temp\allocations.bin";
            this.txtStorageFile2.Text = @"c:\temp\now.bin";
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtStorageFile1.Text))
            {
                MessageBox.Show("Please enter the location of the storage file", "View Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtStorageFile1.Focus();
                return;
            }

            if (!File.Exists(this.txtStorageFile1.Text))
            {
                MessageBox.Show("The first storage file does not exist.", "View Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtStorageFile1.Focus();
                return;
            }

            if (!string.IsNullOrWhiteSpace(this.txtStorageFile2.Text) && !File.Exists(this.txtStorageFile2.Text))
            {
                MessageBox.Show("The second storage file does not exist.", "View Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtStorageFile2.Focus();
                return;
            }

            var frm = new MainForm(this.txtStorageFile1.Text, this.txtStorageFile2.Text);
            frm.ShowDialog();
        }
    }
}
