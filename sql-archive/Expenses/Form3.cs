using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace Expenses
{
    public partial class ViewExpense : Form
    {
        public ViewExpense()
        {
            InitializeComponent();
            InitializeMonthYear();
            InitializeBudgetTable();
        }

        private int numRows = 0, Month = 0, Year = 0;
        private string[] categories;
        private double[] limits;

        public void InitializeMonthYear()
        {
            DateTime now = DateTime.Now;
            Month = now.Month; Year = now.Year;
            int setMonth = now.Month;
            string setYear = now.Year.ToString();
            displayMonth.SelectedIndex = setMonth;
            foreach (object y in displayYear.Items)
                if (setYear == y.ToString()) { displayYear.SelectedItem = y; break; }
        }
        public void InitializeBudgetTable()
        {
            this.budgetTable.MouseClick += new MouseEventHandler(Row_Click);

            // get number of necessary rows
            SqlCeConnection cs = new SqlCeConnection(@"Data Source = Expenses.sdf");
            cs.Open();
            SqlCeCommand cmd = new SqlCeCommand("SELECT COUNT(Category) FROM Categories", cs);
            numRows = (int)cmd.ExecuteScalar();
            cs.Close();

            // initialize labels in table format for display
            for (int i = 0; i < numRows; i++)
            {
                Label x = new Label(), y = new Label(), z = new Label();
                x.AutoSize = true; y.AutoSize = true; z.AutoSize = true;
                x.MouseClick += new MouseEventHandler(Row_Click);
                y.MouseClick += new MouseEventHandler(Row_Click);
                z.MouseClick += new MouseEventHandler(Row_Click);
                x.Name = i.ToString() + ",0";
                y.Name = i.ToString() + ",1";
                z.Name = i.ToString() + ",2";
                budgetTable.Controls.Add(x, 0, i);
                budgetTable.Controls.Add(y, 1, i);
                budgetTable.Controls.Add(z, 2, i);
            }

            // get categories and limits from database
            int row = 0;
            categories = new string[numRows]; limits = new double[numRows];

            SqlCeConnection cs2 = new SqlCeConnection(@"Data Source = Expenses.sdf");
            cs2.Open();
            SqlCeCommand cmd2 = new SqlCeCommand("SELECT * FROM Categories", cs2);
            SqlCeDataReader r = cmd2.ExecuteReader();
            while (r.Read())
            {
                categories[row] = r["Category"].ToString();
                limits[row] = double.Parse(r["Limit"].ToString());
                row++;
            }
            cs2.Close();
            // general update display function
            UpdateBudgetTable();
        }
        public void UpdateBudgetTable()
        {
            // if month == 0, then display the annual budget
            DateTime start, stop;
            if (Month == 0)
            {
                start = new DateTime(Year, 1, 1);
                stop = new DateTime(Year, 12, 31);
            }
            else
            {
                start = new DateTime(Year, Month, 1);
                stop = new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month));
            }

            // get all line items for the month (between start/stop of one month)
            SqlCeConnection cs2 = new SqlCeConnection(@"Data Source = Expenses.sdf");
            cs2.Open();
            SqlCeCommand cmd2 = new SqlCeCommand("SELECT * FROM LineItems WHERE Date BETWEEN @Start AND @Stop", cs2);
            cmd2.Parameters.AddWithValue("@Start", start);
            cmd2.Parameters.AddWithValue("@Stop", stop);
            SqlCeDataReader read = cmd2.ExecuteReader();

            // sum up line items for each category
            double[] sums = new double[numRows];
            while (read.Read())
            {
                for (int i = 0; i < numRows; i++)
                {
                    if (categories[i] == read["Category"].ToString())
                    { sums[i] -= double.Parse(read["Amount"].ToString()); break; }
                }
            }
            cs2.Close();

            // update labels in table with categories, limits, and percentages
            foreach (Label L in budgetTable.Controls)
            {
                string[] rc = L.Name.Split(',');
                int r = int.Parse(rc[0]), c = int.Parse(rc[1]);
                if (r < numRows)
                {
                    switch (c)
                    {
                        case 0:
                            L.Text = categories[r];
                            break;
                        case 1:
                            L.Text = "$" + sums[r].ToString("F0");
                            break;
                        case 2:
                            L.Text = (100 * sums[r] / limits[r]).ToString("F0") + "%";
                            break;
                        default: break;
                    }
                }
            }
        }

        private void displayMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            Month = displayMonth.SelectedIndex;
            UpdateBudgetTable();
        }
        private void displayYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            Year = int.Parse(displayYear.SelectedItem.ToString());
            UpdateBudgetTable();
        }
        private void displaySwitch_Click(object sender, EventArgs e)
        {
            if (Month == 0) Month = DateTime.Now.Month;
            else Month = 0;
            displayMonth.SelectedIndex = Month;
            UpdateBudgetTable();
        }

        private void Row_Click(object sender, MouseEventArgs e)
        {
            int row;
            // get row based on label or table event
            switch (sender.GetType().ToString())
            {
                case "System.Windows.Forms.Label":
                    row = (int)((Label)sender).Name[0] - 48;
                    if (((Label)sender).Name[1] != ',')
                    {
                        row *= 10;
                        row += (int)((Label)sender).Name[1] - 48;
                    }
                    break;
                case "System.Windows.Forms.TableLayoutPanel":
                    row = e.Y / 27; // fine tune this
                    if (row >= numRows) return; // handle out of bounds clicks
                    break;
                default: return;
            }
            // convert row to category
            // generate new form with category display & save button & sort functions
            ViewCategory form = new ViewCategory(categories[row], Month, Year); form.Show();
        }
    }
}
