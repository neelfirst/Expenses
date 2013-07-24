using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.IO;

namespace Expenses
{
    public class Helper
    {
        public string getGUID()
        {
            string max = "00000000-0000-0000-0000-000000000000";
            SqlCeConnection getGuid = new SqlCeConnection(@"Data Source = Expenses.sdf");
            getGuid.Open();
            SqlCeCommand getCmd = new SqlCeCommand("select max(convert(NVARCHAR,ID)) as ID from LineItems", getGuid);
            SqlCeDataReader r = null;
            r = getCmd.ExecuteReader();
            while (r.Read()) { max = r["ID"].ToString(); }
            getGuid.Close();
            if (max == "") { max = "00000000-0000-0000-0000-000000000000"; }
            return max;
        }
        public bool writeItem (item x)
        {
            try
            {
                SqlCeConnection cs = new SqlCeConnection(@"Data Source = Expenses.sdf");
                cs.Open();
                SqlCeCommand cmd = new SqlCeCommand("INSERT INTO LineItems VALUES (@Date, @Description, @Amount, @Category, @ID)", cs);
                cmd.Parameters.AddWithValue("@ID", x.id);
                cmd.Parameters.AddWithValue("@Date", x.dt);
                cmd.Parameters.AddWithValue("@Description", x.desc);
                cmd.Parameters.AddWithValue("@Amount", x.cost);
                cmd.Parameters.AddWithValue("@Category", x.cat);
                cmd.ExecuteNonQuery();
                cs.Close();
            }
            catch { return false; }
            return true;
        }
        public void IncrementID(ref string ID)
        {
            string[] chunks = ID.Split('-');
            long c0 = long.Parse(chunks[0]);
            long c1 = long.Parse(chunks[1]);
            long c2 = long.Parse(chunks[2]);
            long c3 = long.Parse(chunks[3]);
            long c4 = long.Parse(chunks[4]);
            if (c4 != 999999999999) { c4++; }
            else
            {
                c4 = 0;
                if (c3 != 9999) { c3++; }
                else
                {
                    c3 = 0;
                    if (c2 != 9999) { c2++; }
                    else
                    {
                        c2 = 0;
                        if (c1 != 9999) { c1++; }
                        else
                        {
                            c1 = 0;
                            if (c0 != 99999999) { c0++; }
                            else c0 = 0;
                        }
                    }
                }
            }
            ID = c0.ToString("D8") + "-" + c1.ToString("D4") + "-" + c2.ToString("D4") + "-" + c3.ToString("D4") + "-" + c4.ToString("D12");
        }
        public bool IsDuplicate(item x)
        {
            bool success;
            // need to write a dupe checker
            try
            {
                SqlCeConnection cs = new SqlCeConnection(@"Data Source = Expenses.sdf");
                cs.Open();
                SqlCeCommand cmd = new SqlCeCommand("SELECT ID FROM LineItems WHERE (Date = @Date AND Description = @Description AND Amount = @Amount)", cs);
                cmd.Parameters.AddWithValue("@Date", x.dt);
                cmd.Parameters.AddWithValue("@Description", x.desc);
                cmd.Parameters.AddWithValue("@Amount", x.cost);
                SqlCeDataReader r = cmd.ExecuteReader();
                if (r.Read()) success = true;
                else success = false;
                cs.Close();
            }
            catch { MessageBox.Show("Database access error!"); return true; }
            return success;
        }
        public string IsCategorized(string description)
        {
            string rval = "";
            SqlCeConnection cs = new SqlCeConnection(@"Data Source = Expenses.sdf");
            cs.Open();
            SqlCeCommand cmd = new SqlCeCommand("SELECT * FROM CategorizedItems WHERE (Description = @Description)", cs);
            cmd.Parameters.AddWithValue("@Description", description);
            SqlCeDataReader r = cmd.ExecuteReader();
            if (r.Read()) rval = r["Category"].ToString();
            else rval = "poop";
            cs.Close();
            return rval;
        }
        public DialogResult CatBox(string promptText, double cost, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            Label amount = new Label();
            ComboBox comboBox = new ComboBox();
            Button buttonOk = new Button();
            CheckBox checkBox = new CheckBox();
            form.Text = "Specify a Category:";
            label.Text = promptText;
            amount.Text = cost.ToString("C");
            checkBox.Text = "Remember this relationship?";
            buttonOk.Text = "OK";
            buttonOk.DialogResult = DialogResult.OK;
            label.SetBounds(9, 20, 272, 13);
            amount.SetBounds(273, 20, 100, 13);
            comboBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(309, 72, 75, 23);
            checkBox.SetBounds(12, 72, 275, 24); // ???
            label.AutoSize = true;
            comboBox.Anchor = comboBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            checkBox.Anchor = checkBox.Anchor | AnchorStyles.Right;
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, amount, checkBox, comboBox, buttonOk });
            form.ClientSize = new Size(Math.Max(300, amount.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;

            SqlCeConnection cs = new SqlCeConnection(@"Data Source = Expenses.sdf");
            cs.Open();
            SqlCeDataReader r = null;
            SqlCeCommand getCats = new SqlCeCommand("SELECT * FROM Categories", cs);
            r = getCats.ExecuteReader();
            while (r.Read()) comboBox.Items.Add(r["Category"]);
            cs.Close();
            DialogResult dialogResult = form.ShowDialog();
            value = comboBox.Text;
            // remember relationship if option to do so is checked
            if (checkBox.Checked)
            {
                SqlCeConnection cs2 = new SqlCeConnection(@"Data Source = Expenses.sdf");
                cs2.Open();
                SqlCeCommand setCat = new SqlCeCommand("INSERT INTO CategorizedItems VALUES (@Description, @Category)", cs2);
                setCat.Parameters.AddWithValue("@Description", promptText);
                setCat.Parameters.AddWithValue("@Category", value);
                setCat.ExecuteNonQuery();
                cs2.Close();
            }
            return dialogResult;
        }
        public bool CheckDatabaseExists() // if SDF exists, then tables exist
        {
            bool result = false;
            try
            {
                using (SqlCeConnection tmpConn = new SqlCeConnection(@"Data Source = Expenses.sdf"))
                {
                    tmpConn.Open();
                    tmpConn.Close();
                }
                result = true;
            } 
            catch (Exception ex) { result = false; }
            return result;
        }
        public bool CreateSDF()
        {
            // creating SDF file
            string FileName = "Expenses.sdf";
            if (File.Exists(FileName)) File.Delete(FileName);
            string connectionString = "DataSource=\"Expenses.sdf\"";
            SqlCeEngine en = new SqlCeEngine(connectionString);
            try { en.CreateDatabase(); }
            catch (Exception e) { MessageBox.Show(e.ToString()); return false; }

            SqlCeConnection cs = new SqlCeConnection(connectionString); cs.Open();

            // creating (empty) Categories table
            SqlCeCommand makeCats = new SqlCeCommand("CREATE TABLE Categories (Category nvarchar(50), Limit money)", cs);
            try { makeCats.ExecuteNonQuery(); }
            catch (Exception e) { MessageBox.Show("1"+e.ToString()); return false; }

            // creating (empty) LineItems table
            SqlCeCommand makeItems = new SqlCeCommand("CREATE TABLE LineItems (Date datetime, Description nvarchar(50), Amount money, Category nvarchar(50), ID uniqueidentifier PRIMARY KEY)", cs);
            try { makeItems.ExecuteNonQuery(); }
            catch (Exception e) { MessageBox.Show("2"+e.ToString()); return false; }

            // creating (empty) CategorizedItems table
            SqlCeCommand makeRelations = new SqlCeCommand("CREATE TABLE CategorizedItems (Description nvarchar(50), Category nvarchar(50))", cs);
            try { makeRelations.ExecuteNonQuery(); }
            catch (Exception e) { MessageBox.Show("3"+e.ToString()); return false; }

            cs.Close();
            return true;
        }
        public bool ClearRelations()
        {
            SqlCeConnection cs = new SqlCeConnection(@"Data Source = Expenses.sdf");
            cs.Open();
            SqlCeCommand cmd = new SqlCeCommand("DELETE FROM CategorizedItems", cs);
            try { cmd.ExecuteNonQuery(); cs.Close(); }
            catch { return false; }
            return true;
        }
        public bool ClearLineItems()
        {
            SqlCeConnection cs = new SqlCeConnection(@"Data Source = Expenses.sdf");
            cs.Open();
            SqlCeCommand cmd = new SqlCeCommand("DELETE FROM LineItems", cs);
            try { cmd.ExecuteNonQuery(); cs.Close(); }
            catch { return false; }
            return true;
        }
    }
    public class item
    {
        public DateTime dt; public double cost;
        public string desc, cat, id;
    }
}
