namespace DisplayFreeSpace
{
    partial class Collect
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
            this.txtStorageFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDatabaseServerName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDatabaseName = new System.Windows.Forms.TextBox();
            this.lblDatabaseName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtStorageFile
            // 
            this.txtStorageFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStorageFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStorageFile.Location = new System.Drawing.Point(22, 221);
            this.txtStorageFile.Name = "txtStorageFile";
            this.txtStorageFile.Size = new System.Drawing.Size(669, 22);
            this.txtStorageFile.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Storage File";
            // 
            // txtDatabaseServerName
            // 
            this.txtDatabaseServerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDatabaseServerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDatabaseServerName.Location = new System.Drawing.Point(22, 159);
            this.txtDatabaseServerName.Name = "txtDatabaseServerName";
            this.txtDatabaseServerName.Size = new System.Drawing.Size(669, 22);
            this.txtDatabaseServerName.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Database Server Name:";
            // 
            // txtDatabaseName
            // 
            this.txtDatabaseName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDatabaseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDatabaseName.Location = new System.Drawing.Point(22, 91);
            this.txtDatabaseName.Name = "txtDatabaseName";
            this.txtDatabaseName.Size = new System.Drawing.Size(669, 22);
            this.txtDatabaseName.TabIndex = 9;
            // 
            // lblDatabaseName
            // 
            this.lblDatabaseName.AutoSize = true;
            this.lblDatabaseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatabaseName.Location = new System.Drawing.Point(19, 68);
            this.lblDatabaseName.Name = "lblDatabaseName";
            this.lblDatabaseName.Size = new System.Drawing.Size(111, 16);
            this.lblDatabaseName.TabIndex = 8;
            this.lblDatabaseName.Text = "Database Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(351, 25);
            this.label1.TabIndex = 14;
            this.label1.Text = "Collect information from a database";
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.Location = new System.Drawing.Point(25, 274);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(105, 16);
            this.lblProgress.TabIndex = 15;
            this.lblProgress.Text = "Progress Here...";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.Location = new System.Drawing.Point(553, 350);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(138, 42);
            this.cmdCancel.TabIndex = 16;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOK.Location = new System.Drawing.Point(396, 350);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(138, 42);
            this.cmdOK.TabIndex = 17;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // Collect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtStorageFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDatabaseServerName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDatabaseName);
            this.Controls.Add(this.lblDatabaseName);
            this.Name = "Collect";
            this.Size = new System.Drawing.Size(705, 552);
            this.Load += new System.EventHandler(this.Collect_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtStorageFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDatabaseServerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDatabaseName;
        private System.Windows.Forms.Label lblDatabaseName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
    }
}
