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
    public partial class SetupCategory : Form
    {
        public SetupCategory()
        {
            InitializeComponent();
            UpdateBudgetTable();
        }
        private int numRows = 0;
        private List<Tuple<string,double>> rowData = new List<Tuple<string,double>>();
        /* need some better way of referring to data already in rows */

        private void UpdateBudgetTable()
        {
            SqlCeConnection cs = new SqlCeConnection(@"Data Source = Expenses.sdf");
            cs.Open();
            SqlCeCommand cmd = new SqlCeCommand("SELECT * FROM Categories", cs);
            SqlCeDataReader r = cmd.ExecuteReader();
            numRows = 0;
            rowData.Clear();
            BudgetTable.Controls.Clear();
            while (r.Read())
            {
                Label x = new Label(), y = new Label();
                x.Text = r["Category"].ToString(); y.Text = (double.Parse(r["Limit"].ToString())).ToString();
                x.AutoSize = true; y.AutoSize = true;
                x.MouseClick += new MouseEventHandler(Row_Click);
                y.MouseClick += new MouseEventHandler(Row_Click);
                x.Name = numRows.ToString() + ",0";
                y.Name = numRows.ToString() + ",1";
                BudgetTable.Controls.Add(x, 0, numRows);
                BudgetTable.Controls.Add(y, 1, numRows);
                rowData.Add(new Tuple<string,double>(x.Text,double.Parse(y.Text)));
                numRows++;
            }
            cs.Close();
        }

        private void Row_Click(object sender, MouseEventArgs e)
        {
            int row;
            // 1. get row based on label or table event
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
            // 2. Display an edit form for cat, $, update/delete/cancel buttons
            string oldCat = rowData[row].Item1, newCat = oldCat;
            double oldLimit = rowData[row].Item2, newLimit = oldLimit;

            DialogResult rval = EditCat(false, ref newCat, ref newLimit);
            SqlCeConnection cs = new SqlCeConnection(@"Data Source = Expenses.sdf");
            if (rval == DialogResult.Cancel) return;
            else if (rval == DialogResult.No)
            {
                cs.Open();
                SqlCeCommand cmd = new SqlCeCommand("DELETE FROM Categories WHERE (Category = @Category AND Limit = @Limit)", cs);
                cmd.Parameters.AddWithValue("@Category", newCat);
                cmd.Parameters.AddWithValue("@Limit", newLimit);
                try { cmd.ExecuteNonQuery(); }
                catch (Exception f) { MessageBox.Show(f.ToString()); return; }
                cs.Close();
            }
            // 3. Check input then add to Database
            else // DialogResult.Yes
            {
                cs.Open();
                SqlCeCommand updateLimit = new SqlCeCommand("UPDATE Categories SET Limit = @Limit WHERE Category = @Category", cs);
                updateLimit.Parameters.AddWithValue("@Category", oldCat);
                updateLimit.Parameters.AddWithValue("@Limit", newLimit);
                
                SqlCeCommand updateCat = new SqlCeCommand("UPDATE Categories SET Category = @Category WHERE Limit = @Limit", cs);
                updateCat.Parameters.AddWithValue("@Category", newCat);
                updateCat.Parameters.AddWithValue("@Limit", newLimit);

                try { updateLimit.ExecuteNonQuery(); updateCat.ExecuteNonQuery(); }
                catch (Exception f) { MessageBox.Show(f.ToString()); return; }
                cs.Close();
            }
            // 4. Run UpdateBudget Table
            UpdateBudgetTable();
        }
        private void Add_Click(object sender, EventArgs e)
        {
            // 1. Display an add form
            // 2. Capture category name and limit
            // 3. Check for valid input
            string cat = ""; double limit = 0;
            DialogResult rval = EditCat(true, ref cat, ref limit);
            if (rval != DialogResult.Yes) return;
            // 4. Add to Database
            SqlCeConnection cs = new SqlCeConnection(@"Data Source = Expenses.sdf");
            cs.Open();
            SqlCeCommand cmd = new SqlCeCommand("INSERT INTO Categories (Category, Limit) VALUES (@Category, @Limit)", cs);
            cmd.Parameters.AddWithValue("@Limit", limit);
            cmd.Parameters.AddWithValue("@Category", cat);
            cmd.ExecuteNonQuery();
            cs.Close();
            // 5. Run UpdateBudgetTable
            UpdateBudgetTable();
        }

        private DialogResult EditCat(bool isNew, ref string c, ref double D)
        {
            Form form = new Form();

            Button Accept = new Button();
            Accept.Text = "Accept";
            Accept.DialogResult = DialogResult.Yes;
            Accept.SetBounds(20, 78, 75, 23);
            Button Delete = new Button();
            Delete.Text = "Delete";
            Delete.DialogResult = DialogResult.No;
            Delete.SetBounds(110, 78, 75, 23);
            Button Cancel = new Button();
            Cancel.Text = "Cancel";
            Cancel.DialogResult = DialogResult.Cancel;
            Cancel.SetBounds(200, 78, 75, 23);

            Label catLabel = new Label();
            catLabel.Text = "Category";
            catLabel.SetBounds(20, 20, 120, 13);
            Label limitLabel = new Label();
            limitLabel.Text = "Limit";
            limitLabel.SetBounds(155, 20, 120, 13);
            TextBox catBox = new TextBox();
            catBox.SetBounds(20, 40, 120, 20);
            catBox.Text = c;
            TextBox limitBox = new TextBox();
            limitBox.SetBounds(155, 40, 120, 20);
            limitBox.Text = D.ToString();

            if (isNew)
            {
                form.Text = "Add New Category";
                Delete.Visible = false;
                Delete.Enabled = false;
            }
            else form.Text = "Edit Category";

            form.ClientSize = new Size(296, 107);
            form.Controls.AddRange(new Control[] { catLabel, limitLabel, catBox, limitBox, Accept, Delete, Cancel });
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;

            DialogResult rval = form.ShowDialog();

            if (catBox.Text == "" || limitBox.Text == "")
            {
                MessageBox.Show("Can't leave fields blank!");
                c = ""; D = 0;
                return DialogResult.Cancel;
            }
            else if (!double.TryParse(limitBox.Text, out D))
            {
                MessageBox.Show("Invalid dollar amount entry!");
                c = "";
                return DialogResult.Cancel;
            }
            else { c = catBox.Text; return rval; }
        }
    }
}