using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechTopiaM2
{
    public partial class Main : Form
    {
        //helper function
        private LogIn log;
        private static void incrementDecrement(TextBox txt, bool isAdd)
        {
            int quantity = Convert.ToInt32(txt.Text.ToString());
            if (isAdd)
            {
                if (quantity == 0 || quantity > 0)
                {
                    quantity++;
                    txt.Text = Convert.ToString(quantity);
                }
            }
            else
            {
                if (quantity > 1)
                {
                    quantity--;
                    txt.Text = Convert.ToString(quantity);
                }
            }
        }

        public Main()
        {
            InitializeComponent();
            displayLogin();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsTables.Meals' table. You can move, or remove it, as needed.


        }

        public void displayForm(Form contentForm)
        {
            this.displayPanel.Controls.Clear();
            contentForm.TopLevel = false; //set form to be dependent
            contentForm.FormBorderStyle = FormBorderStyle.None;
            contentForm.Dock = DockStyle.Fill;
            this.displayPanel.Controls.Add(contentForm);
            contentForm.Show();
        }
        public void displayLogin()
        {
            disableAll();
            LogIn login = new LogIn(this); // pass this form reference to login form
            log = login;
            displayForm(login);
        }
        public void disableAll()
        {
            this.menuStrip1.Enabled = false;
            this.menuStrip1.Visible = false;
            this.displayPanel.Controls.Clear();
        }
        public void enableAll()
        {
            this.menuStrip1.Enabled = true;
            this.menuStrip1.Visible = true;
            this.displayPanel.Controls.Clear();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            log.clere();
           displayLogin();
        }

        private void mondayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            displayForm(new Monday(mealsDataset, mealsTableAdapter,productsTableAdapter,dailyOrderTableAdapter,daily_Order_ItemsTableAdapter));
        }

        private void tuesdayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            displayForm(new Tuesday(mealsDataset,mealsTableAdapter,productsTableAdapter,dailyOrderTableAdapter,daily_Order_ItemsTableAdapter));
        }

        private void wednesdayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            displayForm(new Wednesday(mealsDataset, mealsTableAdapter, productsTableAdapter, dailyOrderTableAdapter,daily_Order_ItemsTableAdapter));
        }

        private void thursdayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            displayForm(new Thursday(mealsDataset,mealsTableAdapter,productsTableAdapter, dailyOrderTableAdapter, daily_Order_ItemsTableAdapter));
        }

        private void fridayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            displayForm(new Friday(mealsDataset,mealsTableAdapter,productsTableAdapter,dailyOrderTableAdapter,daily_Order_ItemsTableAdapter));
        }

        private void weekendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            displayForm(new Weekend(mealsDataset,mealsTableAdapter,productsTableAdapter,dailyOrderTableAdapter,daily_Order_ItemsTableAdapter));
        }
                                                                             
        private void inventoryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            displayForm(new Inventory_Report());
        }

        private void salesSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            displayForm(new Sales_Summary());
        }

        private void managementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //displayForm(new Management());
        }


        private void studentsSubscriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            displayForm(new Student_Monthly_Meal_Subscription(subscriptionDataset,subscribedStudentTableAdapter));
        }

        private void workersSubscriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            displayForm(new Wokers_Monthly_Meal_Subscription(subscriptionDataset,subscribedWorkersTableAdapter));
        }


        //static methods
        public static void addMealToCart(DataGridView cart, dsTables ds, dsTablesTableAdapters.MealsTableAdapter mealsAd, int mealID, TextBox txtQuantity,TextBox subtotaltxt)
        {
            mealsAd.FillByMealID(ds.Meals, mealID);

            DataRow row = ds.Cart.NewCartRow();
            int quantity = Convert.ToInt32(txtQuantity.Text);
            decimal price = Convert.ToDecimal(ds.Meals.Rows[0][2]);


            row[0] = ds.Meals.Rows[0][1]; //not a product
            row[1] = null;
            row[2] = mealID;
            row[3] = quantity;
            row[4] = price;
            row[5] = quantity * price;

            ds.Meals.Rows.Clear();
            ds.Cart.Rows.Add(row);
            cart.DataSource = ds.Cart;
            subtotaltxt.Text = GetTotal(ds).ToString();
        }

        public static void removeMealFromCart(int mealID, DataGridView cart, dsTables ds)
        {
            var rows = ds.Cart.Rows;
            for (int i = 0; i < rows.Count; i++)
            {
                if (rows[i][2].ToString() != "")
                {
                    if (Convert.ToInt32(rows[i][2]) == mealID)
                    {
                        ds.Cart.Rows.Remove(rows[i]);
                    }
                }
            }
            cart.DataSource = ds.Cart;
        }
        public static DataGridViewRow getRowByMealID(int id, DataGridView cart)
        {
            DataGridViewRow row = null;
            for (int i = 0; i < cart.Rows.Count; i++)
            {
                row = cart.Rows[i];
                if (row != null && row.Cells[2].Value.ToString() != "")
                {
                    if (Convert.ToInt32(row.Cells[2].Value) == id)
                    {
                        return row;
                    }
                }
            }
            return row;
        }

        //buttons method
        public static void IncreaseQuantity(TextBox txtQuantity, int mealID, DataGridView cart, bool increase)
        {
            DataGridViewRow row = null; //this item row in cart
            if (increase)
            {
                incrementDecrement(txtQuantity, true);
            }
            else
            {
                incrementDecrement(txtQuantity, false);
            }
            int qty = Convert.ToInt32(txtQuantity.Text);
            row = getRowByMealID(mealID, cart);
            decimal price = Convert.ToDecimal(row.Cells[4].Value);
            row.Cells[3].Value = qty;
            row.Cells[5].Value = qty * price;
        }

        public static void checkBoxChecked(bool isChecked, Button addButton, Button removeButton, TextBox txtQuantity)
        {
            if (isChecked)
            {
                addButton.Enabled = true;
                removeButton.Enabled = true;
                txtQuantity.Text = "1";
                
            }
            else
            {
                removeButton.Enabled = false;
                addButton.Enabled = false;
                txtQuantity.Text = "0";
            }
        }
        //get selected row from datagridview
        public static DataGridViewRow getSelectedRow(DataGridView productDgv)
        {
            DataGridViewRow selectedRow = productDgv.CurrentRow;
            return selectedRow;
        }
        //add product to Cart
        public static void addProductToCart(DataGridView cart,  dsTables ds, TextBox txtQuantity,DataGridViewRow row, TextBox subtotaltxt)
        {
            DataRow cartRow = ds.Cart.NewCartRow();
            dsTablesTableAdapters.ProductsTableAdapter pd = new dsTablesTableAdapters.ProductsTableAdapter();
            int productID = Convert.ToInt32(row.Cells[0].Value);
            
            bool match = false;
            if (validateQuantity(txtQuantity))
            {
                int quantity = Convert.ToInt32(txtQuantity.Text);
                decimal price = Convert.ToDecimal(row.Cells[3].Value);
                cartRow[0] = row.Cells[1].Value; //not a product
                cartRow[1] = productID;
                cartRow[2] = null;
                cartRow[3] = quantity;
                cartRow[4] = price;
                cartRow[5] = quantity * price;

                foreach(var existingRow in ds.Cart)
                { 
                    if (existingRow.productID == cartRow[1].ToString())
                    {
                        //there is a matching BookID
                        match = true;
                        //quantity++;
                        existingRow.quantity = ((Convert.ToInt32(existingRow.quantity) + quantity));
                        existingRow.subTotal = existingRow.itemPrice * existingRow.quantity;
                        break;
                    }
                }
                if (!match)
                {
                    //ds.Products.Rows.Clear();
                    ds.Cart.Rows.Add(cartRow);
                   
                }

                subtotaltxt.Text = GetTotal(ds).ToString();
            }
        }
        private static bool validateQuantity(TextBox quantity)
        {
            int qty = 0;
            bool isvalid = false;
            if (int.TryParse(quantity.Text,out qty))
            {
                isvalid = true;
                if (qty <= 0)
                {
                    MessageBox.Show(null,"Please enter a valid quantity value!","Invalid Quantity Value");
                    isvalid = false;
                }
            }
            else
            {
                MessageBox.Show(null, "Please enter a valid quantity value!", "Invalid Quantity Value");
                isvalid = false;
            }
            return isvalid;
        }
        public static decimal GetTotal(dsTables ds)
        {
            decimal sum = 0;
            foreach (var existingRow in ds.Cart)
            {
                sum += existingRow.subTotal;
            }
            return sum;
        }
        // remove and uncheck the corresponding checkBox
        public static void removeAndUncheck(Dictionary<int, CheckBox> checkBoxMap,int mealID)
        {
            checkBoxMap[mealID].Checked = false;
        }
        public static void uncheckAll(Dictionary<int, CheckBox> checkBoxMap)
        {
            for(int i = 0; i < checkBoxMap.Count; i++)
            {
                foreach(var checkBox in checkBoxMap)
                {
                    int key = checkBox.Key;
                    checkBoxMap[key].Checked = false;
                }
            }
        }
        //placing order
        public static void placeOrder(dsTablesTableAdapters.DailyOrderTableAdapter ordersAdapter, dsTablesTableAdapters.Daily_Order_ItemsTableAdapter orderItemAdapter,dsTables ds,TextBox total,Dictionary<int,CheckBox> checkBoxMap)
        {

            bool isMeal = false;
            int orderNo = (int)ordersAdapter.InsertNewOrder(DateTime.Now.ToString(), 1, Convert.ToDecimal(total.Text));
            String itemName = "";
            int itemID = 0;
            int quantity = 0;
            decimal itemPrice = 0;
            decimal subtotal = 0;

            //  var currentRow = ds.Cart.Rows;
            foreach (var existingRow in ds.Cart)
            {
                if (existingRow.productID != null)
                {
                    isMeal = false;
                    itemID = Convert.ToInt32(existingRow.productID.ToString());
                }
                else
                {
                    isMeal = true;
                    itemID = Convert.ToInt32(existingRow.mealID.ToString());
                }
                itemName = existingRow.Name;
                quantity = Convert.ToInt32(existingRow.quantity.ToString());
                itemPrice = Convert.ToDecimal(existingRow.itemPrice.ToString());
                subtotal = Convert.ToDecimal(existingRow.subTotal.ToString());
                if (isMeal)
                {
                    orderItemAdapter.Insert(itemName,orderNo, null, itemID, quantity, itemPrice, subtotal);
                }
                else
                {
                    orderItemAdapter.Insert(itemName,orderNo, itemID, null, quantity, itemPrice, subtotal);
                }
            }

            MessageBox.Show("New Order Added: " + orderNo.ToString());
            ds.Cart.Rows.Clear();
            Main.uncheckAll(checkBoxMap);
        }

        
        private void studentSubscriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            displayForm(new Worker_Subscription(subscriptionDataset, subscribedStudentTableAdapter, subscribedWorkersTableAdapter));
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            displayForm(new Inventory_Report());
        }

        private void credentialsManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            displayForm(new Change_Password());
        }

        private void staffManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            displayForm(new Manage_Staff());
        }
    }

}