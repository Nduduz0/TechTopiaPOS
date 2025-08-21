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
    public partial class Tuesday : Form
    {
        private dsTables ds;
        private dsTablesTableAdapters.MealsTableAdapter mealsAdapter;
        private dsTablesTableAdapters.ProductsTableAdapter productsAdapter;
        private dsTablesTableAdapters.DailyOrderTableAdapter ordersAdapter;
        private dsTablesTableAdapters.Daily_Order_ItemsTableAdapter orderItemAdapter;

        private Dictionary<int, CheckBox> checkBoxMap;// contains checkboxes and associated their meal ID
        public Tuesday(dsTables dataset, dsTablesTableAdapters.MealsTableAdapter mealsTableAdapter, dsTablesTableAdapters.ProductsTableAdapter productsTableAdapter, 
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

            //adding all checkboxes and their meal ID's
            checkBoxMap.Add(5, ChickenUphuthuCheckBox);
            checkBoxMap.Add(6, ChickenRiceCheckBox);
            checkBoxMap.Add(17, checkBox5);
            checkBoxMap.Add(16, checkBox6);
            checkBoxMap.Add(18, checkBox7);
            checkBoxMap.Add(23, checkBox8);
            checkBoxMap.Add(22, checkBox9);
            checkBoxMap.Add(24, checkBox10);
            checkBoxMap.Add(21, checkBox11);
            checkBoxMap.Add(20, checkBox12);

        }
        //Meals ID
        enum TuesdayMeals
        {
            ChickenAndUphuthu = 5,
            ChickenAndRice = 6,
            BerryWaffle = 17,
            Granolacup = 16,
            Bagel = 18,
            BeefBurger = 23,
            MiniTriffle = 22,
            ChocolateBrownie = 24,
            MalvaPudding = 21,
            WorsRoll = 20
        }

        //Chicken and Uphuthu
        private void ChickenUphuthuCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ChickenUphuthuCheckBox.Checked)
            {
                Main.checkBoxChecked(true, ChickenUphuthuAdd, ChickenUphuthuRemove, txtChickenUphuthu);
                Main.addMealToCart(CartData, ds, mealsAdapter, (int)TuesdayMeals.ChickenAndUphuthu, txtChickenUphuthu, subtotaltxt);
            }
            else
            {
                Main.checkBoxChecked(false, ChickenUphuthuAdd, ChickenUphuthuRemove, txtChickenUphuthu);
                Main.removeMealFromCart((int)TuesdayMeals.ChickenAndUphuthu,   CartData, ds);
            }
        }

        private void ChickenUphuthuRemove_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(txtChickenUphuthu, (int)TuesdayMeals.ChickenAndUphuthu, CartData, false);
            subtotaltxt.Text = Main.GetTotal(ds).ToString();
        }

        private void ChickenUphuthuAdd_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(txtChickenUphuthu, (int)TuesdayMeals.ChickenAndUphuthu, CartData, true);
            subtotaltxt.Text = Main.GetTotal(ds).ToString();
        }

        //chicken and rice
        private void ChickenRiceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ChickenRiceCheckBox.Checked)
            {
                Main.checkBoxChecked(true, ChickenRiceAdd, ChickenRiceRemove, txtChickenRice);
                Main.addMealToCart(CartData, ds, mealsAdapter, (int)TuesdayMeals.ChickenAndRice, txtChickenRice, subtotaltxt);
            }
            else
            {
                Main.checkBoxChecked(false, ChickenRiceAdd, ChickenRiceRemove, txtChickenRice);
                Main.removeMealFromCart((int)TuesdayMeals.ChickenAndRice, CartData, ds);
            }
        }

        private void ChickenRiceRemove_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(txtChickenRice, (int)TuesdayMeals.ChickenAndRice, CartData, false);
            subtotaltxt.Text = Main.GetTotal(ds).ToString();
        }

        private void ChickenRiceAdd_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(txtChickenRice, (int)TuesdayMeals.ChickenAndRice, CartData, true);
            subtotaltxt.Text = Main.GetTotal(ds).ToString();
        }

        private void btnRemove1_Click_1(object sender, EventArgs e)
        {
            if (ds.Cart.Rows.Count > 0)
            {
                if (CartData.CurrentRow.Cells[2].Value.ToString().Length != 0)
                {
                    var id = CartData.CurrentRow.Cells[2].Value;
                    Main.removeAndUncheck(checkBoxMap, Convert.ToInt32(id));
                }
                else
                {
                    ds.Cart.Rows.RemoveAt(CartData.CurrentRow.Index);
                }
                subtotaltxt.Text = Main.GetTotal(ds).ToString();//recalculate subtotal after removing either meal or product
            }
            else
            {
                MessageBox.Show("No item selected");
            }
        }

        private void addToCart_Click_1(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = Main.getSelectedRow(productsDgv);
            Main.addProductToCart(CartData, ds, txtQuantity, selectedRow, subtotaltxt);
        }

        private void btnCancel1_Click_1(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(null, "Cancel order", "Confirmation", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                ds.Cart.Rows.Clear();
                subtotaltxt.Clear();
                Main.uncheckAll(checkBoxMap);
            }
            else
            {
                //Do nothing
            }
        }

        private void searchBox_TextChanged_1(object sender, EventArgs e)
        {
            productsAdapter.FillByProductName(ds.Products, searchBox.Text);
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                Main.checkBoxChecked(true, button1, button2, textBox1);
                Main.addMealToCart(CartData, ds, mealsAdapter, (int)TuesdayMeals.BerryWaffle, textBox1, subtotaltxt);
            }
            else
            {
                Main.checkBoxChecked(false, button1, button2, textBox1);
                Main.removeMealFromCart((int)TuesdayMeals.BerryWaffle, CartData, ds);
                subtotaltxt.Text = Main.GetTotal(ds).ToString();
            }
        }

        

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                Main.checkBoxChecked(true, button3, button4, textBox2);
                Main.addMealToCart(CartData, ds, mealsAdapter, (int)TuesdayMeals.Granolacup, textBox2, subtotaltxt);
            }
            else
            {
                Main.checkBoxChecked(false, button3, button4, textBox2);
                Main.removeMealFromCart((int)TuesdayMeals.Granolacup, CartData, ds);
                subtotaltxt.Text = Main.GetTotal(ds).ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox2, (int)TuesdayMeals.Granolacup, CartData, false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox2, (int)TuesdayMeals.Granolacup, CartData, true);
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
            {
                Main.checkBoxChecked(true, button5, button6, textBox3);
                Main.addMealToCart(CartData, ds, mealsAdapter, (int)TuesdayMeals.Bagel, textBox3, subtotaltxt);
            }
            else
            {
                Main.checkBoxChecked(false, button5, button6, textBox3);
                Main.removeMealFromCart((int)TuesdayMeals.Bagel, CartData, ds);
                subtotaltxt.Text = Main.GetTotal(ds).ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox3, (int)TuesdayMeals.Bagel, CartData, false);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox3, (int)TuesdayMeals.Bagel, CartData, true);
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked)
            {
                Main.checkBoxChecked(true, button13, button14, textBox7);
                Main.addMealToCart(CartData, ds, mealsAdapter, (int)TuesdayMeals.BeefBurger, textBox7, subtotaltxt);
            }
            else
            {
                Main.checkBoxChecked(false, button13, button14, textBox7);
                Main.removeMealFromCart((int)TuesdayMeals.BeefBurger, CartData, ds);
                subtotaltxt.Text = Main.GetTotal(ds).ToString();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox7, (int)TuesdayMeals.BeefBurger, CartData, false);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox7, (int)TuesdayMeals.BeefBurger, CartData, true);
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked)
            {
                Main.checkBoxChecked(true, button7, button8, textBox4);
                Main.addMealToCart(CartData, ds, mealsAdapter, (int)TuesdayMeals.MiniTriffle, textBox4, subtotaltxt);
            }
            else
            {
                Main.checkBoxChecked(false, button7, button8, textBox4);
                Main.removeMealFromCart((int)TuesdayMeals.MiniTriffle, CartData, ds);
                subtotaltxt.Text = Main.GetTotal(ds).ToString();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox4, (int)TuesdayMeals.MiniTriffle, CartData, false);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox4, (int)TuesdayMeals.MiniTriffle, CartData, true);
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked)
            {
                Main.checkBoxChecked(true, button9, button10, textBox5);
                Main.addMealToCart(CartData, ds, mealsAdapter, (int)TuesdayMeals.ChocolateBrownie, textBox5, subtotaltxt);
            }
            else
            {
                Main.checkBoxChecked(false, button9, button10, textBox5);
                Main.removeMealFromCart((int)TuesdayMeals.ChocolateBrownie, CartData, ds);
                subtotaltxt.Text = Main.GetTotal(ds).ToString();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox5, (int)TuesdayMeals.ChocolateBrownie, CartData, false);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox5, (int)TuesdayMeals.ChocolateBrownie, CartData, true);
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked)
            {
                Main.checkBoxChecked(true, button11, button12, textBox6);
                Main.addMealToCart(CartData, ds, mealsAdapter, (int)TuesdayMeals.MalvaPudding, textBox6, subtotaltxt);
            }
            else
            {
                Main.checkBoxChecked(false, button11, button12, textBox6);
                Main.removeMealFromCart((int)TuesdayMeals.MalvaPudding, CartData, ds);
                subtotaltxt.Text = Main.GetTotal(ds).ToString();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox6, (int)TuesdayMeals.MalvaPudding, CartData, false);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox6, (int)TuesdayMeals.MalvaPudding, CartData, true);
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox12.Checked)
            {
                Main.checkBoxChecked(true, button15, button16, textBox8);
                Main.addMealToCart(CartData, ds, mealsAdapter, (int)TuesdayMeals.WorsRoll, textBox8, subtotaltxt);
            }
            else
            {
                Main.checkBoxChecked(false, button15, button16, textBox8);
                Main.removeMealFromCart((int)TuesdayMeals.WorsRoll, CartData, ds);
                subtotaltxt.Text = Main.GetTotal(ds).ToString();
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox8, (int)TuesdayMeals.WorsRoll, CartData, false);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox8, (int)TuesdayMeals.WorsRoll, CartData, true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox1, (int)TuesdayMeals.BerryWaffle, CartData, false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox1, (int)TuesdayMeals.BerryWaffle, CartData, false);
        }

        private void btnPayment3_Click(object sender, EventArgs e)
        {
            Main.placeOrder(ordersAdapter, orderItemAdapter, ds, subtotaltxt, checkBoxMap);
        }
    }
    
}
