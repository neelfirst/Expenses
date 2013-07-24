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
    public partial class AddExpense : Form
    {
        public AddExpense()
        {
            InitializeComponent();
            InitializeComboBox();
        }
        public DateTime timestamp;
        public string description, category;
        public double amount;

        private void InitializeComboBox()
        {
            SqlCeConnection cs = new SqlCeConnection(@"Data Source = Expenses.sdf");
            cs.Open();
            SqlCeDataReader r = null;
            SqlCeCommand cmd = new SqlCeCommand("SELECT * FROM Categories", cs);
            r = cmd.ExecuteReader();
            while (r.Read()) comboBox1.Items.Add(r["Category"]);
            cs.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            timestamp = dateTimePicker1.Value;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            description = textBox1.Text;
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private void OK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            category = comboBox1.Text;
/*            int i = comboBox1.SelectedIndex;
            SqlCeConnection cs = new SqlCeConnection(@"Data Source = |DataDirectory|\LineItems.sdf");
            cs.Open();
            SqlCeDataReader r = null;
            SqlCeCommand cmd = new SqlCeCommand("SELECT * FROM Categories", cs);
            r = cmd.ExecuteReader();
            for (int j = 0; j <= i; j++)
            {
                r.Read();
            }
            category = r["Category"].ToString();*/
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!double.TryParse(textBox2.Text, out amount))
            { MessageBox.Show("Invalid cost, please enter proper dollars and cents."); }
        }
    }
}
