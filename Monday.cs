using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Font = iTextSharp.text.Font;

namespace TechTopiaM2
{
    public partial class Monday : Form
    {
        private dsTables ds;
        private dsTablesTableAdapters.MealsTableAdapter mealsAdapter;
        private dsTablesTableAdapters.ProductsTableAdapter productsAdapter;
        private dsTablesTableAdapters.DailyOrderTableAdapter ordersAdapter;
        private dsTablesTableAdapters.Daily_Order_ItemsTableAdapter orderItemAdapter;


        private Dictionary<int, CheckBox> checkBoxMap;// contains checkboxes and associated their meal ID

        public Monday(dsTables dataset, dsTablesTableAdapters.MealsTableAdapter mealsTableAdapter, dsTablesTableAdapters.ProductsTableAdapter productsTableAdapter,
            dsTablesTableAdapters.DailyOrderTableAdapter ordersAdapter, dsTablesTableAdapters.Daily_Order_ItemsTableAdapter orderItemAdapter)
        {
            InitializeComponent();
            //initializing shared objects i.e dataset and table adapters
            this.ds = dataset;
            this.mealsAdapter = mealsTableAdapter;
            this.productsAdapter = productsTableAdapter;
            this.ordersAdapter = ordersAdapter;
            this.orderItemAdapter = orderItemAdapter;

            checkBoxMap = new Dictionary<int, CheckBox>();//initializing checkBoxMap

            ds.Cart.Rows.Clear();
            ds.Products.Rows.Clear();

            CartData.DataSource = ds.Cart;
            productsDgv.DataSource = ds.Products;
            productsAdapter.Fill(ds.Products);

            DataView view = new DataView(ds.Products);
            view.RowFilter = "[Archive] IS NULL OR [Archive] = ''";
            productsDgv.DataSource = view;


            //adding all checkboxes and their meal ID's
            checkBoxMap.Add(1, checkBox1);
            checkBoxMap.Add(2, checkBox2);
            checkBoxMap.Add(3, checkBox3);
            checkBoxMap.Add(4, checkBox4);
            checkBoxMap.Add(17, checkBox5);
            checkBoxMap.Add(16, checkBox6);
            checkBoxMap.Add(18, checkBox7);
            checkBoxMap.Add(23, checkBox8);
            checkBoxMap.Add(22, checkBox9);
            checkBoxMap.Add(24, checkBox10);
            checkBoxMap.Add(21, checkBox11);
            checkBoxMap.Add(20, checkBox12);

            productsDgv.Columns[0].Visible = false;
            productsDgv.Columns[2].Visible = false;
            productsDgv.Columns[5].Visible = false;
            CartData.Columns[1].Visible = false;
            CartData.Columns[2].Visible = false;

            btnNoprint.Visible = false;
            BtnYesPrint.Visible = false;
            //txtOrderinfo.Clear();
            txtOrderinfo.Visible = false;
            label2.Visible = false;




            checkBox13.CheckedChanged += CheckBox_CheckedChanged;
            checkBox14.CheckedChanged += CheckBox_CheckedChanged;
            checkBox15.CheckedChanged += CheckBox_CheckedChanged;
            checkBox16.CheckedChanged += CheckBox_CheckedChanged;
            checkBox17.CheckedChanged += CheckBox_CheckedChanged;
            checkBox18.CheckedChanged += CheckBox_CheckedChanged;

            CartData.SelectionChanged += CartData_SelectionChanged;


        }

        //Monday Meals ID
        enum MondayMeals
        {
            MgxhabhisoAndUphuthu = 1,
            MgxhabhisoAndJeqe = 2,
            BeefAndUphuthu = 3,
            BeefAndRice = 4,
            BerryWaffle = 17,
            Granolacup = 16,
            Bagel = 18,
            BeefBurger = 23,
            MiniTriffle = 22,
            ChocolateBrownie = 24,
            MalvaPudding = 21,
            WorsRoll = 20
        }

        //Mgxhabhiso and Uphuthu
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                Main.checkBoxChecked(true, MgUpIncrement, MgUpDecrement, txtMgUp);
                Main.addMealToCart(CartData, ds, mealsAdapter, (int)MondayMeals.MgxhabhisoAndUphuthu, txtMgUp, subtotaltxt);

            }
            else
            {
                Main.checkBoxChecked(false, MgUpIncrement, MgUpDecrement, txtMgUp);
                Main.removeMealFromCart((int)MondayMeals.MgxhabhisoAndUphuthu, CartData, ds);
                subtotaltxt.Text = Main.GetTotal(ds).ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(txtMgUp, (int)MondayMeals.MgxhabhisoAndUphuthu, CartData, true);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(txtMgUp, (int)MondayMeals.MgxhabhisoAndUphuthu, CartData, false);
        }

        //Mgxhabhiso and Ujeqe
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                Main.checkBoxChecked(true, MgUjIncrement, MgUjDecrement, txtMgUj);
                Main.addMealToCart(CartData, ds, mealsAdapter, (int)MondayMeals.MgxhabhisoAndJeqe, txtMgUj, subtotaltxt);

            }
            else
            {
                Main.checkBoxChecked(false, MgUjIncrement, MgUjDecrement, txtMgUj);
                Main.removeMealFromCart((int)MondayMeals.MgxhabhisoAndJeqe, CartData, ds);
                subtotaltxt.Text = Main.GetTotal(ds).ToString();
            }
        }
        private void MgUjDecrement_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(txtMgUj, (int)MondayMeals.MgxhabhisoAndJeqe, CartData, false);
            subtotaltxt.Text = Main.GetTotal(ds).ToString();
        }
        private void MgUjIncrement_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(txtMgUj, (int)MondayMeals.MgxhabhisoAndJeqe, CartData, true);
            subtotaltxt.Text = Main.GetTotal(ds).ToString();
        }

        //Beef and Uphuthu
        private void BeefUphuthuCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                Main.checkBoxChecked(true, BfUphuthuAdd, BfUphuthuRemove, txtBeefUphuthu);
                Main.addMealToCart(CartData, ds, mealsAdapter, (int)MondayMeals.BeefAndUphuthu, txtBeefUphuthu, subtotaltxt);
            }
            else
            {
                Main.checkBoxChecked(false, BfUphuthuAdd, BfUphuthuRemove, txtBeefUphuthu);
                Main.removeMealFromCart((int)MondayMeals.BeefAndUphuthu, CartData, ds);
                subtotaltxt.Text = Main.GetTotal(ds).ToString();
            }
        }

        private void BfUphuthuRemove_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(txtBeefUphuthu, (int)MondayMeals.BeefAndUphuthu, CartData, false);
        }

        private void BfUphuthuAdd_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(txtBeefUphuthu, (int)MondayMeals.BeefAndUphuthu, CartData, true);
        }

        //Beef and Rice
        private void BeefRiceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                Main.checkBoxChecked(true, BfRiceAdd, BfRiceRemove, txtBeefRice);
                Main.addMealToCart(CartData, ds, mealsAdapter, (int)MondayMeals.BeefAndRice, txtBeefRice, subtotaltxt);
            }
            else
            {
                Main.checkBoxChecked(false, BfRiceAdd, BfRiceRemove, txtBeefRice);
                Main.removeMealFromCart((int)MondayMeals.BeefAndRice, CartData, ds);
                subtotaltxt.Text = Main.GetTotal(ds).ToString();
            }
        }

        private void BfRiceRemove_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(txtBeefRice, (int)MondayMeals.BeefAndRice, CartData, false);
        }

        private void BfRiceAdd_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(txtBeefRice, (int)MondayMeals.BeefAndRice, CartData, true);
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            productsAdapter.FillByProductName(ds.Products, searchBox.Text);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = Main.getSelectedRow(productsDgv);
            if (selectedRow != null)
            {
                if (string.IsNullOrWhiteSpace(txtQuantity.Text) || !int.TryParse(txtQuantity.Text, out int SoldQTY))
                {
                    MessageBox.Show("Please enter a valid quantity.");
                    return;
                }
                //Main.addProductToCart(CartData, ds, txtQuantity, selectedRow, subtotaltxt);
                int QOH = Convert.ToInt32(selectedRow.Cells[4].Value);
                // int SoldQTY = Convert.ToInt32(txtQuantity.Text);

                if (QOH >= SoldQTY && SoldQTY > 0)
                {

                    Main.addProductToCart(CartData, ds, txtQuantity, selectedRow, subtotaltxt);


                    selectedRow.Cells[4].Value = QOH - SoldQTY;


                    int productId = Convert.ToInt32(selectedRow.Cells[0].Value);
                    DataRow[] rows = ds.Products.Select("productID= " + productId);
                    if (rows.Length > 0)
                    {
                        rows[0]["Quantity_On_Hand"] = QOH - SoldQTY;
                        productsAdapter.Update(ds.Products);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid quantity - either not enough stock or quantity is zero");
                }
            }
        }

        private void btnRemove1_Click(object sender, EventArgs e)
        {
            if (CartData.CurrentRow != null)
            {
                // Check if it's a product (has productID)
                if (CartData.CurrentRow.Cells[1].Value != null && CartData.CurrentRow.Cells[1].Value.ToString() != "")
                {
                    int productId = Convert.ToInt32(CartData.CurrentRow.Cells[1].Value);
                    int quantityToRestore = Convert.ToInt32(CartData.CurrentRow.Cells[3].Value);

                    // Find the product in the products grid
                    foreach (DataGridViewRow row in productsDgv.Rows)
                    {
                        if (row.Cells[0].Value != null && Convert.ToInt32(row.Cells[0].Value) == productId)
                        {
                            // Update grid quantity
                            int currentQty = Convert.ToInt32(row.Cells[4].Value);
                            row.Cells[4].Value = currentQty + quantityToRestore;

                            // Update database
                            DataRow[] rows = ds.Products.Select("productID = " + productId);
                            if (rows.Length > 0)
                            {
                                rows[0]["Quantity_On_Hand"] = currentQty + quantityToRestore;
                                productsAdapter.Update(ds.Products);
                            }
                            break;
                        }
                    }
                }
                else if (CartData.CurrentRow.Cells[2].Value != null && CartData.CurrentRow.Cells[2].Value.ToString() != "")
                {
                    // It's a meal - just uncheck the checkbox
                    var id = CartData.CurrentRow.Cells[2].Value;
                    Main.removeAndUncheck(checkBoxMap, Convert.ToInt32(id));
                }

                // Remove from cart
                ds.Cart.Rows.RemoveAt(CartData.CurrentRow.Index);
                subtotaltxt.Text = Main.GetTotal(ds).ToString();
            }
            else
            {
                MessageBox.Show("No item selected");
            }
        }

        private void btnPayment3_Click(object sender, EventArgs e)
        {
            if (ds.Cart.Rows.Count > 0)
            {
                // First update all product quantities in database permanently
                foreach (var cartRow in ds.Cart)
                {
                    if (cartRow.productID != null)
                    {
                        int productId = Convert.ToInt32(cartRow.productID);
                        int newqty = Convert.ToInt32(productsDgv.CurrentRow.Cells[4].Value);
                        int ptableproductID = Convert.ToInt32(productsDgv.CurrentRow.Cells[0].Value);
                        productsAdapter.UpdateQueryQOH(newqty, ptableproductID, productId);
                        ds.Products.Rows.Clear();
                        productsAdapter.Fill(ds.Products);

                    }
                }

                double payAmt;
                double subtotal;

                if (double.TryParse(txtPayAmt.Text, out payAmt) && double.TryParse(subtotaltxt.Text, out subtotal))
                {
                    txtPayAmt.Text = payAmt.ToString("F2");
                    if (payAmt >= subtotal)
                    {
                        double change = payAmt - subtotal;
                        txtChange.Text = change.ToString("F2");

                        // Set up the fonts
                        System.Drawing.Font mainFont = new System.Drawing.Font("Consolas", 10);
                        System.Drawing.Font saladFont = new System.Drawing.Font("Consolas", 8);

                        const int col1Width = 25;
                        const int col2Width = 10;
                        const int col3Width = 15;

                        StringBuilder orderInfo = new StringBuilder();

                        // Header
                        orderInfo.AppendLine($"{"Name".PadRight(col1Width)}{"Quantity".PadRight(col2Width)}{"Price".PadLeft(col3Width)}");
                        orderInfo.AppendLine(new string('=', col1Width + col2Width + col3Width));

                        // Process each row
                        foreach (DataGridViewRow row in CartData.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                string productName = row.Cells[0].Value?.ToString() ?? "";
                                string saladInfo = row.Cells[6].Value?.ToString();
                                string quantity = row.Cells[3].Value?.ToString() ?? "";
                                string price = row.Cells[4].Value?.ToString() ?? "";

                                // Main product line
                                orderInfo.AppendLine($"{productName.PadRight(col1Width)}{quantity.PadRight(col2Width)}{price.PadLeft(col3Width)}");

                                // Add salad info if available (smaller font)
                                if (!string.IsNullOrWhiteSpace(saladInfo))
                                {
                                    // Indent the salad info to align with product name
                                    string indentedSalad = $"   ({saladInfo})";
                                    orderInfo.AppendLine(indentedSalad.PadRight(col1Width + col2Width + col3Width));
                                }
                            }
                        }

                        // Add summary
                        orderInfo.AppendLine(new string('=', col1Width + col2Width + col3Width));
                        orderInfo.AppendLine($"{"Total:".PadRight(col1Width + col2Width)}{subtotaltxt.Text.PadLeft(col3Width)}");
                        orderInfo.AppendLine($"{"Amount Paid:".PadRight(col1Width + col2Width)}{txtPayAmt.Text.PadLeft(col3Width)}");
                        orderInfo.AppendLine($"{"Change:".PadRight(col1Width + col2Width)}{txtChange.Text.PadLeft(col3Width)}");

                        // Set the final text
                        txtOrderinfo.Font = mainFont;
                        txtOrderinfo.Text = orderInfo.ToString();

                        // Then place the order
                        Main.placeOrder(ordersAdapter, orderItemAdapter, ds, subtotaltxt, checkBoxMap);
                        subtotaltxt.Clear();
                        txtPayAmt.Clear();

                        btnNoprint.Visible = true;
                        BtnYesPrint.Visible = true;
                        txtOrderinfo.Visible = true;
                        label2.Visible = true;
                        subtotalLabel.Visible = false;
                        // txtOrderinfo.Clear();
                        CartData.Visible = false;
                        subtotaltxt.Visible = false;
                        btnCancel1.Visible = false;
                        btnPayment3.Visible = false;
                        btnRemove1.Visible = false;
                        txtPayAmt.Visible = false;
                        lbPay.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Payment amount is less than the total due.");
                    }

                }
                else
                {
                    MessageBox.Show("Please enter valid numbers in both fields.");
                }


            }
            else
            {
                MessageBox.Show("Cart is empty - nothing to order");
            }
            //Main.placeOrder(ordersAdapter, orderItemAdapter, ds, subtotaltxt, checkBoxMap);
        }

        private void btnCancel1_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Cancel order?", "Confirmation", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                // Restore all product quantities
                foreach (var cartRow in ds.Cart)
                {
                    if (cartRow.productID != null)
                    {
                        int productId = Convert.ToInt32(cartRow.productID);
                        int quantityToRestore = Convert.ToInt32(cartRow.quantity);

                        // Find product in grid
                        foreach (DataGridViewRow row in productsDgv.Rows)
                        {
                            if (row.Cells[0].Value != null && Convert.ToInt32(row.Cells[0].Value) == productId)
                            {
                                // Update grid quantity
                                int currentQty = Convert.ToInt32(row.Cells[4].Value);
                                row.Cells[4].Value = currentQty + quantityToRestore;

                                // Update database
                                DataRow[] rows = ds.Products.Select("productID = " + productId);
                                if (rows.Length > 0)
                                {
                                    rows[0]["Quantity_On_Hand"] = currentQty + quantityToRestore;
                                    productsAdapter.Update(ds.Products);
                                }
                                break;
                            }
                        }
                    }
                }

                // Clear cart and uncheck all
                ds.Cart.Rows.Clear();
                subtotaltxt.Clear();
                Main.uncheckAll(checkBoxMap);
            }

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                Main.checkBoxChecked(true, button1, button2, textBox1);
                Main.addMealToCart(CartData, ds, mealsAdapter, (int)MondayMeals.BerryWaffle, textBox1, subtotaltxt);
            }
            else
            {
                Main.checkBoxChecked(false, button1, button2, textBox1);
                Main.removeMealFromCart((int)MondayMeals.BerryWaffle, CartData, ds);
                subtotaltxt.Text = Main.GetTotal(ds).ToString();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox1, (int)MondayMeals.BerryWaffle, CartData, false);
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox1, (int)MondayMeals.BerryWaffle, CartData, true);
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                Main.checkBoxChecked(true, button3, button4, textBox2);
                Main.addMealToCart(CartData, ds, mealsAdapter, (int)MondayMeals.Granolacup, textBox2, subtotaltxt);
            }
            else
            {
                Main.checkBoxChecked(false, button3, button4, textBox2);
                Main.removeMealFromCart((int)MondayMeals.Granolacup, CartData, ds);
                subtotaltxt.Text = Main.GetTotal(ds).ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox2, (int)MondayMeals.Granolacup, CartData, false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox2, (int)MondayMeals.Granolacup, CartData, true);
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
            {
                Main.checkBoxChecked(true, button5, button6, textBox3);
                Main.addMealToCart(CartData, ds, mealsAdapter, (int)MondayMeals.Bagel, textBox3, subtotaltxt);
            }
            else
            {
                Main.checkBoxChecked(false, button5, button6, textBox3);
                Main.removeMealFromCart((int)MondayMeals.Bagel, CartData, ds);
                subtotaltxt.Text = Main.GetTotal(ds).ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox3, (int)MondayMeals.Bagel, CartData, false);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox3, (int)MondayMeals.Bagel, CartData, true);
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked)
            {
                Main.checkBoxChecked(true, button13, button14, textBox7);
                Main.addMealToCart(CartData, ds, mealsAdapter, (int)MondayMeals.BeefBurger, textBox7, subtotaltxt);
            }
            else
            {
                Main.checkBoxChecked(false, button13, button14, textBox7);
                Main.removeMealFromCart((int)MondayMeals.BeefBurger, CartData, ds);
                subtotaltxt.Text = Main.GetTotal(ds).ToString();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox7, (int)MondayMeals.BeefBurger, CartData, false);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox7, (int)MondayMeals.BeefBurger, CartData, true);
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked)
            {
                Main.checkBoxChecked(true, button7, button8, textBox4);
                Main.addMealToCart(CartData, ds, mealsAdapter, (int)MondayMeals.MiniTriffle, textBox4, subtotaltxt);
            }
            else
            {
                Main.checkBoxChecked(false, button7, button8, textBox4);
                Main.removeMealFromCart((int)MondayMeals.MiniTriffle, CartData, ds);
                subtotaltxt.Text = Main.GetTotal(ds).ToString();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox4, (int)MondayMeals.MiniTriffle, CartData, false);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox4, (int)MondayMeals.MiniTriffle, CartData, true);
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked)
            {
                Main.checkBoxChecked(true, button9, button10, textBox5);
                Main.addMealToCart(CartData, ds, mealsAdapter, (int)MondayMeals.ChocolateBrownie, textBox5, subtotaltxt);
            }
            else
            {
                Main.checkBoxChecked(false, button9, button10, textBox5);
                Main.removeMealFromCart((int)MondayMeals.ChocolateBrownie, CartData, ds);
                subtotaltxt.Text = Main.GetTotal(ds).ToString();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox5, (int)MondayMeals.ChocolateBrownie, CartData, false);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox5, (int)MondayMeals.ChocolateBrownie, CartData, true);
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked)
            {
                Main.checkBoxChecked(true, button11, button12, textBox6);
                Main.addMealToCart(CartData, ds, mealsAdapter, (int)MondayMeals.MalvaPudding, textBox6, subtotaltxt);
            }
            else
            {
                Main.checkBoxChecked(false, button11, button12, textBox6);
                Main.removeMealFromCart((int)MondayMeals.MalvaPudding, CartData, ds);
                subtotaltxt.Text = Main.GetTotal(ds).ToString();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox6, (int)MondayMeals.MalvaPudding, CartData, false);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox6, (int)MondayMeals.MalvaPudding, CartData, true);
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox12.Checked)
            {
                Main.checkBoxChecked(true, button15, button16, textBox8);
                Main.addMealToCart(CartData, ds, mealsAdapter, (int)MondayMeals.WorsRoll, textBox8, subtotaltxt);
            }
            else
            {
                Main.checkBoxChecked(false, button15, button16, textBox8);
                Main.removeMealFromCart((int)MondayMeals.WorsRoll, CartData, ds);
                subtotaltxt.Text = Main.GetTotal(ds).ToString();
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox8, (int)MondayMeals.WorsRoll, CartData, false);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox8, (int)MondayMeals.WorsRoll, CartData, true);
        }


        private void CartData_SelectionChanged(object sender, EventArgs e)
        {
            SuspendCheckboxEvents();

            try
            {
                ResetAllCheckboxes();
                groupBox2.Enabled = false;

                if (CartData.CurrentRow != null && !CartData.CurrentRow.IsNewRow)
                {
                    groupBox2.Enabled = CartData.CurrentRow?.Cells[2].Value != null &&
                    new[] { "1", "2", "3", "4" }.Contains(CartData.CurrentRow.Cells[2].Value.ToString());
                    LoadSavedSaladSelections();
                }
            }
            finally
            {
                ResumeCheckboxEvents();
                UpdateCheckboxStates(); // Refresh enabled states
            }
        }

        private void SuspendCheckboxEvents()
        {
            checkBox13.CheckedChanged -= CheckBox_CheckedChanged;
            checkBox14.CheckedChanged -= CheckBox_CheckedChanged;
            checkBox15.CheckedChanged -= CheckBox_CheckedChanged;
            checkBox16.CheckedChanged -= CheckBox_CheckedChanged;
            checkBox17.CheckedChanged -= CheckBox_CheckedChanged;
            checkBox18.CheckedChanged -= CheckBox_CheckedChanged;
        }

        private void ResumeCheckboxEvents()
        {
            checkBox13.CheckedChanged += CheckBox_CheckedChanged;
            checkBox14.CheckedChanged += CheckBox_CheckedChanged;
            checkBox15.CheckedChanged += CheckBox_CheckedChanged;
            checkBox16.CheckedChanged += CheckBox_CheckedChanged;
            checkBox17.CheckedChanged += CheckBox_CheckedChanged;
            checkBox18.CheckedChanged += CheckBox_CheckedChanged;
        }

        private void ResetAllCheckboxes()
        {
            var checkboxes = new[] { checkBox13, checkBox14, checkBox15, checkBox16, checkBox17, checkBox18 };
            foreach (var cb in checkboxes)
            {
                cb.Checked = false;
                cb.Enabled = true;
            }
        }

        private void LoadSavedSaladSelections()
        {
            var savedValue = CartData.CurrentRow.Cells[6].Value?.ToString();
            if (string.IsNullOrWhiteSpace(savedValue)) return;

            var saladMap = new Dictionary<string, CheckBox>
    {
        {"Shatini", checkBox13},
        {"ColeSaw", checkBox14},
        {"Green Salad", checkBox15},
        {"Beetroot", checkBox16},
        {"Beans Salad", checkBox17},
        {"Butternut", checkBox18}
    };

            foreach (var salad in savedValue.Split(',').Select(s => s.Trim()))
            {
                if (saladMap.TryGetValue(salad, out var checkbox))
                {
                    checkbox.Checked = true;
                }
            }
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCheckboxStates();
            SaveCurrentSaladSelection();
        }

        private void UpdateCheckboxStates()
        {
            var checkboxes = new[] { checkBox13, checkBox14, checkBox15, checkBox16, checkBox17, checkBox18 };
            int checkedCount = checkboxes.Count(cb => cb.Checked);

            foreach (var cb in checkboxes)
            {
                cb.Enabled = checkedCount < 3 || cb.Checked;
            }
        }

        private void SaveCurrentSaladSelection()
        {
            if (CartData.CurrentRow == null || CartData.CurrentRow.IsNewRow) return;

            var selectedSalads = new List<string>();
            if (checkBox13.Checked) selectedSalads.Add("Shatini");
            if (checkBox14.Checked) selectedSalads.Add("ColeSaw");
            if (checkBox15.Checked) selectedSalads.Add("Green Salad");
            if (checkBox16.Checked) selectedSalads.Add("Beetroot");
            if (checkBox17.Checked) selectedSalads.Add("Beans Salad");
            if (checkBox18.Checked) selectedSalads.Add("Butternut");


            if (selectedSalads.Count > 0)
            {
                CartData.CurrentRow.Cells[6].Value = string.Join(", ", selectedSalads);
            }
            else
            {
                CartData.CurrentRow.Cells[6].Value = null;
            }
        }



        private void PrintToPdf()
        {
            try
            {
                // Create save file dialog
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "PDF files (*.pdf)|*.pdf";
                    saveDialog.Title = "Save Receipt as PDF";
                    saveDialog.FileName = "OrderReceipt_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Create PDF document
                        using (Document document = new Document(PageSize.A4, 25, 25, 30, 30))
                        {
                            using (PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(saveDialog.FileName, FileMode.Create)))
                            {
                                document.Open();

                                // Set up fonts
                                BaseFont baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                                iTextSharp.text.Font titleFont = new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.BOLD);
                                Font normalFont = new Font(baseFont, 10);
                                Font smallFont = new Font(baseFont, 8);

                                // Add title
                                Paragraph title = new Paragraph("ORDER RECEIPT", titleFont);
                                title.Alignment = Element.ALIGN_CENTER;
                                title.SpacingAfter = 20f;
                                document.Add(title);

                                // Add date/time
                                Paragraph date = new Paragraph("Date: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), normalFont);
                                date.Alignment = Element.ALIGN_CENTER;
                                date.SpacingAfter = 20f;
                                document.Add(date);

                                // Process each line from the order info
                                string[] lines = txtOrderinfo.Text.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

                                foreach (string line in lines)
                                {
                                    if (string.IsNullOrWhiteSpace(line))
                                        continue;

                                    if (line.Contains("==="))
                                    {
                                        // Add a line separator
                                        document.Add(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.5f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -1)));
                                        document.Add(new Paragraph(" "));
                                    }
                                    else if (line.TrimStart().StartsWith("("))
                                    {
                                        // Salad info - smaller and indented
                                        Paragraph saladPara = new Paragraph(line.Trim(), smallFont);
                                        saladPara.IndentationLeft = 20f;
                                        document.Add(saladPara);
                                    }
                                    else
                                    {
                                        // Regular text
                                        document.Add(new Paragraph(line, normalFont));
                                    }
                                }

                                document.Close();
                            }
                        }

                        MessageBox.Show("PDF saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnYesPrint_Click_1(object sender, EventArgs e)
        {
            PrintToPdf();


            btnNoprint.Visible = false;
            BtnYesPrint.Visible = false;
            txtOrderinfo.Visible = false;
            label2.Visible = false;
            subtotalLabel.Visible = true;
            txtOrderinfo.Clear();
            CartData.Visible = true;
            subtotaltxt.Visible = true;
            btnCancel1.Visible = true;
            btnPayment3.Visible = true;
            btnRemove1.Visible = true;
            btnRemove1.Visible = true;
            txtPayAmt.Visible = true;
            lbPay.Visible = true;

        }

        private void btnNoprint_Click_1(object sender, EventArgs e)
        {

            btnNoprint.Visible = false;
            BtnYesPrint.Visible = false;
            txtOrderinfo.Visible = false;
            label2.Visible = false;
            subtotalLabel.Visible = true;
            txtOrderinfo.Clear();
            CartData.Visible = true;
            subtotaltxt.Visible = true;
            btnCancel1.Visible = true;
            btnPayment3.Visible = true;
            btnRemove1.Visible = true;
            txtPayAmt.Visible = true;
            lbPay.Visible = true;
        }
    }
}

