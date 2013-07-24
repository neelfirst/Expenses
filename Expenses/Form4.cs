using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.Globalization;
using System.IO;

namespace Expenses
{
    public partial class ViewCategory : Form
    {
        public ViewCategory(string C, int M, int Y)
        {
            InitializeComponent();
            InitializeCategoryTable(C, M, Y);
        }
        // 0 - unsorted, 1/2 - up/down date, 3/4 - up/down desc, 5/6 - up/down $
        public int sortState = 0;
        public int numRows;
        public List<Tuple<DateTime, string, double>> rows = new List<Tuple<DateTime, string, double>>();

        public void InitializeCategoryTable(string C, int Month, int Year)
        {
            // if month == 0, then display the annual budget
            DateTime start, stop; numRows = 0;
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
            SqlCeCommand cmd2 = new SqlCeCommand("SELECT * FROM LineItems WHERE ((Date BETWEEN @Start AND @Stop) AND (Category = @Category))", cs2);
            cmd2.Parameters.AddWithValue("@Start", start);
            cmd2.Parameters.AddWithValue("@Stop", stop);
            cmd2.Parameters.AddWithValue("@Category", C);
            SqlCeDataReader r = cmd2.ExecuteReader();
            while (r.Read())
            {
                numRows++; double x = double.Parse(r["Amount"].ToString()); x *= -1;
                rows.Add(new Tuple<DateTime, string, double>(((DateTime)(r["Date"])), r["Description"].ToString(), x));
            }
            cs2.Close();

            for (int i = 0; i < numRows; i++)
            {
                // initialize labels
                Label x = new Label(), y = new Label(), z = new Label();
                x.AutoSize = true; y.AutoSize = true; z.AutoSize = true;
                x.MouseClick += new MouseEventHandler(Row_Click);
                y.MouseClick += new MouseEventHandler(Row_Click);
                z.MouseClick += new MouseEventHandler(Row_Click);
                x.Name = i.ToString() + ",0";
                y.Name = i.ToString() + ",1";
                z.Name = i.ToString() + ",2";
                categoryTable.Controls.Add(x, 0, i);
                categoryTable.Controls.Add(y, 1, i);
                categoryTable.Controls.Add(z, 2, i);

                // update labels in table with dates, descriptions, amounts
                x.Text = rows[i].Item1.ToString("MM/dd"); y.Text = rows[i].Item2; z.Text = rows[i].Item3.ToString("C");
            }
            string m;
            if (Month == 0) m = "Year";
            else m = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Month);
            Title.Text = C + " for " + m + " " + Year.ToString();
        }

        private void Row_Click(object sender, MouseEventArgs e)
        {
            int col;
            // get column based on label or table event
            switch (sender.GetType().ToString())
            {
                case "System.Windows.Forms.Label":
                    if (((Label)sender).Name[1] != ',') col = (int)((Label)sender).Name[3] - 48;
                    else col = (int)((Label)sender).Name[2] - 48;
                    break;
                case "System.Windows.Forms.TableLayoutPanel":
                    col = 5 * e.X / categoryTable.Size.Width;
                    if (col == 0) { }
                    else if (col == 4) { col = 2; }
                    else col = 1;
                    break;
                default: return;
            }
            // sort by which column was clicked and previous sort state
            switch (col)
            {
                case 0:
                    if (sortState == 1) { sortState = 2; rows.Sort((x,y) => y.Item1.CompareTo(x.Item1)); }
                    else { sortState = 1; rows.Sort((x,y) => x.Item1.CompareTo(y.Item1)); }
                    break;
                case 1:
                    if (sortState == 3) { sortState = 4; rows.Sort((x,y) => y.Item2.CompareTo(x.Item2)); }
                    else { sortState = 3; rows.Sort((x,y) => x.Item2.CompareTo(y.Item2)); }
                    break;
                case 2:
                    if (sortState == 5) { sortState = 6; rows.Sort((x,y) => y.Item3.CompareTo(x.Item3)); }
                    else { sortState = 5; rows.Sort((x,y) => x.Item3.CompareTo(y.Item3)); }
                    break;
                default: return;
            }
            for (int i = 0; i < numRows; i++)
            {
                Label x = (Label)(categoryTable.Controls.Find(i.ToString() + ",0", true)[0]);
                Label y = (Label)(categoryTable.Controls.Find(i.ToString() + ",1", true)[0]);
                Label z = (Label)(categoryTable.Controls.Find(i.ToString() + ",2", true)[0]);
                x.Text = rows[i].Item1.ToString("MM/dd");
                y.Text = rows[i].Item2.ToString();
                z.Text = rows[i].Item3.ToString("C");
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (SaveFile.ShowDialog() == DialogResult.OK)
            {
                StreamWriter CSV = new StreamWriter(SaveFile.FileName);
                Label temp = new Label(); string line;
                // header information
                CSV.WriteLine(Title.Text);
                CSV.WriteLine("Date,Description,Amount");
                for (int i = 0; i < numRows; i++)
                {
                    line = "";
                    for (int j = 0; j <= 2; j++)
                    {
                        if (j != 0) line += ",";
                        temp = (Label)categoryTable.Controls.Find(i.ToString() + "," + j.ToString(), true)[0];
                        if (temp == null) { MessageBox.Show("error"); return; }
                        line += temp.Text;
                    }
                    CSV.WriteLine(line);
                }
                CSV.Close();
            }
        }
        private void SaveFile_FileOk(object sender, CancelEventArgs e)
        {
            return;
        }
    }
}
