namespace DisplayFreeSpace
{
    partial class WelcomeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sideMenu1 = new DisplayFreeSpace.SideMenu();
            this.collect1 = new DisplayFreeSpace.Collect();
            this.viewData1 = new DisplayFreeSpace.ViewData();
            this.SuspendLayout();
            // 
            // sideMenu1
            // 
            this.sideMenu1.Dock = System.Windows.Forms.DockStyle.Left;
            this.sideMenu1.Location = new System.Drawing.Point(0, 0);
            this.sideMenu1.Name = "sideMenu1";
            this.sideMenu1.Size = new System.Drawing.Size(134, 616);
            this.sideMenu1.TabIndex = 13;
            this.sideMenu1.ButtonClicked += new System.EventHandler<string>(this.sideMenu1_ButtonClicked);
            // 
            // collect1
            // 
            this.collect1.Location = new System.Drawing.Point(140, 0);
            this.collect1.Name = "collect1";
            this.collect1.Size = new System.Drawing.Size(752, 413);
            this.collect1.TabIndex = 14;
            this.collect1.Load += new System.EventHandler(this.collect1_Load);
            // 
            // viewData1
            // 
            this.viewData1.Location = new System.Drawing.Point(140, 0);
            this.viewData1.Name = "viewData1";
            this.viewData1.Size = new System.Drawing.Size(752, 413);
            this.viewData1.TabIndex = 15;
            // 
            // WelcomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(891, 616);
            this.Controls.Add(this.sideMenu1);
            this.Controls.Add(this.collect1);
            this.Controls.Add(this.viewData1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WelcomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SQL Server Database Free Space Viewer";
            this.ResumeLayout(false);

        }

        #endregion
        private SideMenu sideMenu1;
        private Collect collect1;
        private ViewData viewData1;
    }
}