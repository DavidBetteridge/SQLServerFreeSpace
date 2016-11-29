namespace DisplayFreeSpace
{
    partial class SideMenu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCollect = new System.Windows.Forms.Label();
            this.lblView = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCollect
            // 
            this.lblCollect.BackColor = System.Drawing.Color.LightGray;
            this.lblCollect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCollect.Location = new System.Drawing.Point(1, 2);
            this.lblCollect.Name = "lblCollect";
            this.lblCollect.Size = new System.Drawing.Size(209, 38);
            this.lblCollect.TabIndex = 24;
            this.lblCollect.Text = "Collect Data";
            this.lblCollect.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCollect.Click += new System.EventHandler(this.Button_Clicked);
            this.lblCollect.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.lblCollect.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // lblView
            // 
            this.lblView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblView.Location = new System.Drawing.Point(1, 40);
            this.lblView.Name = "lblView";
            this.lblView.Size = new System.Drawing.Size(209, 38);
            this.lblView.TabIndex = 22;
            this.lblView.Text = "View Data";
            this.lblView.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblView.Click += new System.EventHandler(this.Button_Clicked);
            this.lblView.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.lblView.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.lblCollect);
            this.panel1.Controls.Add(this.lblView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(212, 573);
            this.panel1.TabIndex = 24;
            // 
            // SideMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "SideMenu";
            this.Size = new System.Drawing.Size(213, 573);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCollect;
        private System.Windows.Forms.Label lblView;
        private System.Windows.Forms.Panel panel1;
    }
}
