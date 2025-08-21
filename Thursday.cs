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
    public partial class Thursday : Form
    {
        private dsTables ds;
        private dsTablesTableAdapters.MealsTableAdapter mealsAdapter;
        private dsTablesTableAdapters.ProductsTableAdapter productsAdapter;
        private dsTablesTableAdapters.DailyOrderTableAdapter ordersAdapter;
        private dsTablesTableAdapters.Daily_Order_ItemsTableAdapter orderItemAdapter;
        private Dictionary<int, CheckBox> checkBoxMap;// contains checkboxes and associated their meal ID
        public Thursday(dsTables dataset, dsTablesTableAdapters.MealsTableAdapter mealsTableAdapter, dsTablesTableAdapters.ProductsTableAdapter productsTableAdapter,
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

            checkBoxMap.Add(3, BeefUphuthuCheckBox);
            checkBoxMap.Add(4, BeefRiceCheckBox);
            checkBoxMap.Add(8, NhlokoUphuthuCheckBox);
            checkBoxMap.Add(9, NhlokoUjeqeCheckBox);
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
        enum ThursdayMeals
        {
            BeefAndUphuthu = 3,
            BeefAndRice = 4,
            NhlokoAndUphuthu = 8,
            NhlokoAndUjeqe = 9,
            BerryWaffle = 17,
            Granolacup = 16,
            Bagel = 18,
            BeefBurger = 23,
            MiniTriffle = 22,
            ChocolateBrownie = 24,
            MalvaPudding = 21,
            WorsRoll = 20
        }

        //Inhloko and Uphuthuh
        private void NhlokoUphuthuCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (NhlokoUphuthuCheckBox.Checked)
            {
                Main.checkBoxChecked(true, NhlokoUphuthuAdd, NhlokoUphuthuRemove, txtNhlokoUphuthu);
                Main.addMealToCart(CartData, ds, mealsAdapter, (int)ThursdayMeals.NhlokoAndUphuthu, txtNhlokoUphuthu,subtotaltxt);
            }
            else
            {
                Main.checkBoxChecked(false, NhlokoUphuthuAdd, NhlokoUphuthuRemove, txtNhlokoUphuthu);
                Main.removeMealFromCart((int)ThursdayMeals.NhlokoAndUphuthu, CartData, ds);
            }
        }

        private void NhlokoUphuthuRemove_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(txtNhlokoUphuthu, (int)ThursdayMeals.NhlokoAndUphuthu, CartData, false);
        }

        private void NhlokoUphuthuAdd_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(txtNhlokoUphuthu, (int)ThursdayMeals.NhlokoAndUphuthu, CartData, true);
        }

        //Inhloko and Ujeqe
        private void NhlokoUjeqeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (NhlokoUjeqeCheckBox.Checked)
            {
                Main.checkBoxChecked(true, NhlokoUjeqeAdd, NhlokoUjeqeRemove, txtNhlokoUjeqe);
                Main.addMealToCart(CartData, ds, mealsAdapter, (int)ThursdayMeals.NhlokoAndUjeqe, txtNhlokoUjeqe, subtotaltxt);
            }
            else
            {
                Main.checkBoxChecked(false, NhlokoUjeqeAdd, NhlokoUjeqeRemove, txtNhlokoUjeqe);
                Main.removeMealFromCart((int)ThursdayMeals.NhlokoAndUjeqe, CartData, ds);
            }
        }

        private void NhlokoUjeqeRemove_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(txtNhlokoUjeqe, (int)ThursdayMeals.NhlokoAndUjeqe, CartData,false);
        }

        private void NhlokoUjeqeAdd_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(txtNhlokoUjeqe, (int)ThursdayMeals.NhlokoAndUjeqe, CartData, true);
        }

        //Beef and Uphuthu
        private void BeefUphuthuCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (BeefUphuthuCheckBox.Checked)
            {
                Main.checkBoxChecked(true, BeefUphuthuAdd, BeefUphuthuRemove, txtBeefUphuthu);
                Main.addMealToCart(CartData, ds, mealsAdapter, (int)ThursdayMeals.BeefAndUphuthu, txtBeefUphuthu, subtotaltxt);
            }
            else
            {
                Main.checkBoxChecked(false, BeefUphuthuAdd, BeefUphuthuRemove, txtBeefUphuthu);
                Main.removeMealFromCart((int)ThursdayMeals.BeefAndUphuthu, CartData, ds);
            }
        }

        private void BeefUphuthuRemove_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(txtBeefUphuthu, (int)ThursdayMeals.BeefAndUphuthu, CartData, false);
        }

        private void BeefUphuthuAdd_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(txtBeefUphuthu, (int)ThursdayMeals.BeefAndUphuthu, CartData, true);
        }

        //Beef and Rice
        private void BeefRiceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (BeefRiceCheckBox.Checked)
            {
                Main.checkBoxChecked(true, BeefRiceAdd,BeefRiceRemove, txtBeefRice);
                Main.addMealToCart(CartData, ds, mealsAdapter, (int)ThursdayMeals.BeefAndRice, txtBeefRice, subtotaltxt);
            }
            else
            {
                Main.checkBoxChecked(false, BeefRiceAdd, BeefRiceRemove, txtBeefRice);
                Main.removeMealFromCart((int)ThursdayMeals.BeefAndRice, CartData, ds);
            }
        }

        private void BeefRiceRemove_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(txtBeefRice, (int)ThursdayMeals.BeefAndRice, CartData, false);
        }

        private void BeefRiceAdd_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(txtBeefRice, (int)ThursdayMeals.BeefAndRice, CartData, true);
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                Main.checkBoxChecked(true, button1, button2, textBox1);
                Main.addMealToCart(CartData, ds, mealsAdapter, (int)ThursdayMeals.BerryWaffle, textBox1, subtotaltxt);
            }
            else
            {
                Main.checkBoxChecked(false, button1, button2, textBox1);
                Main.removeMealFromCart((int)ThursdayMeals.BerryWaffle, CartData, ds);
                subtotaltxt.Text = Main.GetTotal(ds).ToString();
            }
        }



        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                Main.checkBoxChecked(true, button3, button4, textBox2);
                Main.addMealToCart(CartData, ds, mealsAdapter, (int)ThursdayMeals.Granolacup, textBox2, subtotaltxt);
            }
            else
            {
                Main.checkBoxChecked(false, button3, button4, textBox2);
                Main.removeMealFromCart((int)ThursdayMeals.Granolacup, CartData, ds);
                subtotaltxt.Text = Main.GetTotal(ds).ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox2, (int)ThursdayMeals.Granolacup, CartData, false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox2, (int)ThursdayMeals.Granolacup, CartData, true);
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
            {
                Main.checkBoxChecked(true, button5, button6, textBox3);
                Main.addMealToCart(CartData, ds, mealsAdapter, (int)ThursdayMeals.Bagel, textBox3, subtotaltxt);
            }
            else
            {
                Main.checkBoxChecked(false, button5, button6, textBox3);
                Main.removeMealFromCart((int)ThursdayMeals.Bagel, CartData, ds);
                subtotaltxt.Text = Main.GetTotal(ds).ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox3, (int)ThursdayMeals.Bagel, CartData, false);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox3, (int)ThursdayMeals.Bagel, CartData, true);
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked)
            {
                Main.checkBoxChecked(true, button13, button14, textBox7);
                Main.addMealToCart(CartData, ds, mealsAdapter, (int)ThursdayMeals.BeefBurger, textBox7, subtotaltxt);
            }
            else
            {
                Main.checkBoxChecked(false, button13, button14, textBox7);
                Main.removeMealFromCart((int)ThursdayMeals.BeefBurger, CartData, ds);
                subtotaltxt.Text = Main.GetTotal(ds).ToString();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox7, (int)ThursdayMeals.BeefBurger, CartData, false);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox7, (int)ThursdayMeals.BeefBurger, CartData, true);
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked)
            {
                Main.checkBoxChecked(true, button7, button8, textBox4);
                Main.addMealToCart(CartData, ds, mealsAdapter, (int)ThursdayMeals.MiniTriffle, textBox4, subtotaltxt);
            }
            else
            {
                Main.checkBoxChecked(false, button7, button8, textBox4);
                Main.removeMealFromCart((int)ThursdayMeals.MiniTriffle, CartData, ds);
                subtotaltxt.Text = Main.GetTotal(ds).ToString();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox4, (int)ThursdayMeals.MiniTriffle, CartData, false);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox4, (int)ThursdayMeals.MiniTriffle, CartData, true);
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked)
            {
                Main.checkBoxChecked(true, button9, button10, textBox5);
                Main.addMealToCart(CartData, ds, mealsAdapter, (int)ThursdayMeals.ChocolateBrownie, textBox5, subtotaltxt);
            }
            else
            {
                Main.checkBoxChecked(false, button9, button10, textBox5);
                Main.removeMealFromCart((int)ThursdayMeals.ChocolateBrownie, CartData, ds);
                subtotaltxt.Text = Main.GetTotal(ds).ToString();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox5, (int)ThursdayMeals.ChocolateBrownie, CartData, false);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox5, (int)ThursdayMeals.ChocolateBrownie, CartData, true);
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked)
            {
                Main.checkBoxChecked(true, button11, button12, textBox6);
                Main.addMealToCart(CartData, ds, mealsAdapter, (int)ThursdayMeals.MalvaPudding, textBox6, subtotaltxt);
            }
            else
            {
                Main.checkBoxChecked(false, button11, button12, textBox6);
                Main.removeMealFromCart((int)ThursdayMeals.MalvaPudding, CartData, ds);
                subtotaltxt.Text = Main.GetTotal(ds).ToString();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox6, (int)ThursdayMeals.MalvaPudding, CartData, false);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox6, (int)ThursdayMeals.MalvaPudding, CartData, true);
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox12.Checked)
            {
                Main.checkBoxChecked(true, button15, button16, textBox8);
                Main.addMealToCart(CartData, ds, mealsAdapter, (int)ThursdayMeals.WorsRoll, textBox8, subtotaltxt);
            }
            else
            {
                Main.checkBoxChecked(false, button15, button16, textBox8);
                Main.removeMealFromCart((int)ThursdayMeals.WorsRoll, CartData, ds);
                subtotaltxt.Text = Main.GetTotal(ds).ToString();
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox8, (int)ThursdayMeals.WorsRoll, CartData, false);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox8, (int)ThursdayMeals.WorsRoll, CartData, true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox1, (int)ThursdayMeals.BerryWaffle, CartData, false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox1, (int)ThursdayMeals.BerryWaffle, CartData, false);
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            productsAdapter.FillByProductName(ds.Products, searchBox.Text);
        }

        private void addToCart_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = Main.getSelectedRow(productsDgv);
            Main.addProductToCart(CartData, ds, txtQuantity, selectedRow, subtotaltxt);
        }

        private void btnRemove1_Click(object sender, EventArgs e)
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

        private void btnCancel1_Click(object sender, EventArgs e)
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

        private void btnPayment3_Click(object sender, EventArgs e)
        {
            Main.placeOrder(ordersAdapter, orderItemAdapter, ds, subtotaltxt, checkBoxMap);
        }
    }
}
