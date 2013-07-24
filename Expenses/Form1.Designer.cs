namespace Expenses
{
    partial class MainExpense
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
            this.View = new System.Windows.Forms.Button();
            this.Import = new System.Windows.Forms.Button();
            this.Manual = new System.Windows.Forms.Button();
            this.Setup = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Edit = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // View
            // 
            this.View.Location = new System.Drawing.Point(13, 12);
            this.View.Name = "View";
            this.View.Size = new System.Drawing.Size(95, 23);
            this.View.TabIndex = 0;
            this.View.Text = "View";
            this.View.UseVisualStyleBackColor = true;
            this.View.Click += new System.EventHandler(this.View_Click);
            // 
            // Import
            // 
            this.Import.Location = new System.Drawing.Point(13, 42);
            this.Import.Name = "Import";
            this.Import.Size = new System.Drawing.Size(95, 23);
            this.Import.TabIndex = 1;
            this.Import.Text = "Import";
            this.Import.UseVisualStyleBackColor = true;
            this.Import.Click += new System.EventHandler(this.Import_Click);
            // 
            // Manual
            // 
            this.Manual.Location = new System.Drawing.Point(13, 72);
            this.Manual.Name = "Manual";
            this.Manual.Size = new System.Drawing.Size(95, 23);
            this.Manual.TabIndex = 2;
            this.Manual.Text = "Manual";
            this.Manual.UseVisualStyleBackColor = true;
            this.Manual.Click += new System.EventHandler(this.Manual_Click);
            // 
            // Setup
            // 
            this.Setup.Location = new System.Drawing.Point(13, 102);
            this.Setup.Name = "Setup";
            this.Setup.Size = new System.Drawing.Size(95, 23);
            this.Setup.TabIndex = 3;
            this.Setup.Text = "New";
            this.Setup.UseVisualStyleBackColor = true;
            this.Setup.Click += new System.EventHandler(this.Setup_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // Edit
            // 
            this.Edit.Location = new System.Drawing.Point(13, 132);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(95, 23);
            this.Edit.TabIndex = 4;
            this.Edit.Text = "Edit";
            this.Edit.UseVisualStyleBackColor = true;
            this.Edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(13, 162);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(95, 23);
            this.Clear.TabIndex = 5;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // MainExpense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(122, 193);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.Edit);
            this.Controls.Add(this.Setup);
            this.Controls.Add(this.Manual);
            this.Controls.Add(this.Import);
            this.Controls.Add(this.View);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainExpense";
            this.Text = "Expenses";
            this.Load += new System.EventHandler(this.MainExpense_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button View;
        private System.Windows.Forms.Button Import;
        private System.Windows.Forms.Button Manual;
        private System.Windows.Forms.Button Setup;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button Edit;
        private System.Windows.Forms.Button Clear;
    }
}

