using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlServerCe;

namespace Expenses
{
    public partial class MainExpense : Form
    {
        public MainExpense()
        {
            InitializeComponent();
        }
        private void MainExpense_Load(object sender, EventArgs e)
        {
            // 1. check if database exists
            // 2. disable functions if it does not exist
            if (!Form1_Helper.CheckDatabaseExists())
            {
                View.Enabled = false;
                Import.Enabled = false;
                Manual.Enabled = false;
                Edit.Enabled = false;
                Clear.Enabled = false;
            }
            else Setup.Enabled = false;
        }
        private Helper Form1_Helper = new Helper();

        private void View_Click(object sender, EventArgs e)
        {
            ViewExpense form = new ViewExpense(); form.Show();
            // 1. display current month's categories and values and %
            // 2. display buttons to move/swipe left/right 1 month
            // 3. click on category to view that category in detail
            // 4. click on month title to view that month in full
            // 5. click on year title to view summary for the year
        }
        private void Import_Click(object sender, EventArgs e)
        {
            // 2. import both CC activity files (file select dialog)
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader openFile = new StreamReader(openFileDialog1.OpenFile());
                string check = "", cat = "";
                string[] line; item x = new item();
                try
                {
                    // check to see if it is understandable
                    check = openFile.ReadLine();
                    if (check != "Type,Trans Date,Post Date,Description,Amount")
                    { MessageBox.Show("Not a Chase activity file!"); return; }
                }
                catch (IOException f) { MessageBox.Show("File cannot be read!"); return; }
                catch (OutOfMemoryException f) { MessageBox.Show("File too large to read!"); return; }
                // obtain max GUID to add on to for new items
                x.id = Form1_Helper.getGUID();
                while (!openFile.EndOfStream)
                {
                    check = openFile.ReadLine();
                    line = check.Split(',');
                    if (line[0] == "Sale") // deal with payments later maybe
                    {
                        // pick one of line[1] & line[2] to serve as date
                        x.dt = DateTime.Parse(line[1]);
                        x.desc = line[3];
                        x.cost = double.Parse(line[4]);
                        // add a duplicate checker (date/desc/amt) ignore if match
                        if (!Form1_Helper.IsDuplicate(x))
                        {
                            // increment the ID from obtained maximum, or increment from previous
                            Form1_Helper.IncrementID(ref x.id);
                            // before prompting for categorization check if prior
                            // categorization relationship already established
                            cat = Form1_Helper.IsCategorized(x.desc);
                            if (cat == "poop")
                            {
                                // 3. prompt for categorization of each line item
                                if (Form1_Helper.CatBox(x.desc, x.cost, ref x.cat) == DialogResult.OK)
                                {
                                    // 4. assemble into internal database
                                    if (!Form1_Helper.writeItem(x))
                                    { MessageBox.Show("Writing to database failed!"); return; }
                                    // should probably make this cleaner
                                }
                                else { MessageBox.Show("Skipped adding this item to database."); }
                            }
                            else
                            {
                                x.cat = cat; cat = "";
                                if (!Form1_Helper.writeItem(x))
                                { MessageBox.Show("Writing to database failed!"); return; }
                            }
                        }
                    }
                }
            }
        }
        private void Manual_Click(object sender, EventArgs e)
        {
            // 1. dialog box with all fields: date, description, amount, category
            AddExpense form = new AddExpense();
            item x = new item();
            if (form.ShowDialog() == DialogResult.OK)
            {
                x.id = Form1_Helper.getGUID();
                Form1_Helper.IncrementID(ref x.id);
                x.dt = form.timestamp;
                x.cost = -form.amount;
                x.desc = form.description;
                x.cat = form.category;
            }
            else { MessageBox.Show("Manual add cancelled!"); return; }
            // 2. assemble into internal database
            Form1_Helper.writeItem(x);
        }
        private void Setup_Click(object sender, EventArgs e)
        {
            // create SDF file and sub-tables
            if (Form1_Helper.CreateSDF())
            {
                MessageBox.Show("Okay, time to make a budget! Ready? Good!");
                SetupCategory form = new SetupCategory(); form.Show();

                //MessageBox.Show("You are completely setup! Add expenses manually or import Chase activity files from the main menu.");
                Edit.Enabled = true;
                Clear.Enabled = true;
                Setup.Enabled = false;
                View.Enabled = true;
                Import.Enabled = true;
                Manual.Enabled = true;
            }
            else MessageBox.Show("New database setup failed. Please try again.");
            // 1. create categories with monthly targets
            // 2. display final setup, click on anything to edit it
            // 3. and re-enable functions
        }
        private void Edit_Click(object sender, EventArgs e)
        {
            SetupCategory form = new SetupCategory(); form.Show();
        }
        private void Clear_Click(object sender, EventArgs e)
        {
            Form form = new Form(); form.Text = "Clear Databases";
            CheckBox clearCategories = new CheckBox();
            clearCategories.Text = "Clear All Categories, Expenses, and Relations";
            clearCategories.Checked = false;
            clearCategories.SetBounds(9, 6, 272, 24);

            CheckBox clearLineItems = new CheckBox();
            clearLineItems.Text = "Clear Line Item Expenses Only";
            clearLineItems.Checked = false;
            clearLineItems.SetBounds(9, 30, 272, 24);

            CheckBox clearRelations = new CheckBox();
            clearRelations.Text = "Clear Saved Relations Only";
            clearRelations.Checked = false;
            clearRelations.SetBounds(9, 54, 272, 24);

            Button OK = new Button(); OK.Text = "OK";
            OK.SetBounds(9, 78, 75, 23);
            OK.DialogResult = DialogResult.OK;
            Button Cancel = new Button(); Cancel.Text = "Cancel";
            Cancel.SetBounds(100, 78, 75, 23);
            Cancel.DialogResult = DialogResult.Cancel;

            form.ClientSize = new Size(296, 107);
            form.Controls.AddRange(new Control[] { clearCategories, clearLineItems, clearRelations, OK, Cancel });
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = OK;
            form.CancelButton = Cancel;

            if (form.ShowDialog() == DialogResult.OK)
            {
                if (clearCategories.Checked)
                {
                    File.Delete("Expenses.sdf");
                    Setup.Enabled = true; Edit.Enabled = false; Clear.Enabled = false;
                    View.Enabled = false; Import.Enabled = false; Manual.Enabled = false;
                }
                else if (clearLineItems.Checked)
                {
                    if (clearRelations.Checked) Form1_Helper.ClearRelations();
                    Form1_Helper.ClearLineItems();
                }
                else if (clearRelations.Checked) Form1_Helper.ClearRelations();
                else MessageBox.Show("No action taken.");
            }
            else MessageBox.Show("No action taken.");
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            return;
        }
    }
}
