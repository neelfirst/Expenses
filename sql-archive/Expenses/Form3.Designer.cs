namespace Expenses
{
    partial class ViewExpense
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
            this.displayMonth = new System.Windows.Forms.ComboBox();
            this.displayYear = new System.Windows.Forms.ComboBox();
            this.budgetTable = new System.Windows.Forms.TableLayoutPanel();
            this.displaySwitch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // displayMonth
            // 
            this.displayMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.displayMonth.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayMonth.FormattingEnabled = true;
            this.displayMonth.Items.AddRange(new object[] {
            " ",
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.displayMonth.Location = new System.Drawing.Point(13, 13);
            this.displayMonth.Name = "displayMonth";
            this.displayMonth.Size = new System.Drawing.Size(146, 45);
            this.displayMonth.TabIndex = 0;
            this.displayMonth.SelectedIndexChanged += new System.EventHandler(this.displayMonth_SelectedIndexChanged);
            // 
            // displayYear
            // 
            this.displayYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.displayYear.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayYear.FormattingEnabled = true;
            this.displayYear.Items.AddRange(new object[] {
            "2000",
            "2001",
            "2002",
            "2003",
            "2004",
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030",
            "2031",
            "2032",
            "2033",
            "2034",
            "2035",
            "2036",
            "2037",
            "2038",
            "2039",
            "2040",
            "2041",
            "2042",
            "2043",
            "2044",
            "2045",
            "2046",
            "2047",
            "2048",
            "2049",
            "2050"});
            this.displayYear.Location = new System.Drawing.Point(165, 13);
            this.displayYear.Name = "displayYear";
            this.displayYear.Size = new System.Drawing.Size(87, 45);
            this.displayYear.TabIndex = 1;
            this.displayYear.SelectedIndexChanged += new System.EventHandler(this.displayYear_SelectedIndexChanged);
            // 
            // budgetTable
            // 
            this.budgetTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.budgetTable.ColumnCount = 3;
            this.budgetTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.budgetTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.budgetTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.budgetTable.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.budgetTable.Location = new System.Drawing.Point(13, 64);
            this.budgetTable.Name = "budgetTable";
            this.budgetTable.RowCount = 3;
            this.budgetTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.budgetTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.budgetTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.budgetTable.Size = new System.Drawing.Size(319, 526);
            this.budgetTable.TabIndex = 2;
            // 
            // displaySwitch
            // 
            this.displaySwitch.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displaySwitch.Location = new System.Drawing.Point(258, 13);
            this.displaySwitch.Name = "displaySwitch";
            this.displaySwitch.Size = new System.Drawing.Size(75, 45);
            this.displaySwitch.TabIndex = 3;
            this.displaySwitch.Text = "M/Y";
            this.displaySwitch.UseVisualStyleBackColor = true;
            this.displaySwitch.Click += new System.EventHandler(this.displaySwitch_Click);
            // 
            // ViewExpense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(344, 602);
            this.Controls.Add(this.displaySwitch);
            this.Controls.Add(this.budgetTable);
            this.Controls.Add(this.displayYear);
            this.Controls.Add(this.displayMonth);
            this.Name = "ViewExpense";
            this.Text = "Expense Viewer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox displayMonth;
        private System.Windows.Forms.ComboBox displayYear;
        private System.Windows.Forms.TableLayoutPanel budgetTable;
        private System.Windows.Forms.Button displaySwitch;
    }
}