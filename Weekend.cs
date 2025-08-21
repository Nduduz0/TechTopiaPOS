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
    public partial class Weekend : Form
    {
        private dsTables ds;
        private dsTablesTableAdapters.MealsTableAdapter mealsAdapter;
        private dsTablesTableAdapters.ProductsTableAdapter productsAdapter;
        private dsTablesTableAdapters.DailyOrderTableAdapter ordersAdapter;
        private dsTablesTableAdapters.Daily_Order_ItemsTableAdapter orderItemAdapter;
        private Dictionary<int, CheckBox> checkBoxMap;
        public Weekend(dsTables dataset, dsTablesTableAdapters.MealsTableAdapter mealsTableAdapter, dsTablesTableAdapters.ProductsTableAdapter productsTableAdapter,
            dsTablesTableAdapters.DailyOrderTableAdapter ordersAdapter, dsTablesTableAdapters.Daily_Order_ItemsTableAdapter orderItemAdapter)
        {
            InitializeComponent();
            checkBoxMap = new Dictionary<int, CheckBox>();

            this.ds = dataset;
            this.mealsAdapter = mealsTableAdapter;
            this.productsAdapter = productsTableAdapter;
            this.ordersAdapter = ordersAdapter;
            this.orderItemAdapter = orderItemAdapter;

            ds.Cart.Rows.Clear();
            ds.Products.Rows.Clear();

            CartData.DataSource = ds.Cart;
            productsDgv.DataSource = ds.Products;
            productsAdapter.Fill(ds.Products);

            checkBoxMap.Add(12, BurgerCheckBox);
            checkBoxMap.Add(13, SandwichCheckBox);
            checkBoxMap.Add(14, GwinyaCheckBox);
            checkBoxMap.Add(15, YababaCheckBox);
            checkBoxMap.Add(17, checkBox5);
            checkBoxMap.Add(16, checkBox6);
            checkBoxMap.Add(18, checkBox7);
            checkBoxMap.Add(23, checkBox8);
            checkBoxMap.Add(22, checkBox9);
            checkBoxMap.Add(24, checkBox10);
            checkBoxMap.Add(21, checkBox11);
            checkBoxMap.Add(20, checkBox12);
        }
        //meals ID
        enum WeekendMeals{
            WeekendBurger = 12,
            ClassicSandwich = 13,
            GwinyaCombo = 14,
            YababaCombo = 15,
            BerryWaffle = 17,
            Granolacup = 16,
            Bagel = 18,
            BeefBurger = 23,
            MiniTriffle = 22,
            ChocolateBrownie = 24,
            MalvaPudding = 21,
            WorsRoll = 20
        }

        private void BurgerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (BurgerCheckBox.Checked)
            {
                Main.checkBoxChecked(true, BurgerAdd, BurgerRemove, txtBurger);
                Main.addMealToCart(CartData, ds, mealsAdapter, (int)WeekendMeals.WeekendBurger,txtBurger, subtotaltxt);
            }
            else
            {
                Main.checkBoxChecked(false, BurgerAdd, BurgerRemove, txtBurger);
                Main.removeMealFromCart((int)WeekendMeals.WeekendBurger, CartData, ds);
            }
        }

        private void BurgerRemove_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(txtBurger, (int)WeekendMeals.WeekendBurger, CartData, false);
        }

        private void BurgerAdd_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(txtBurger, (int)WeekendMeals.WeekendBurger, CartData, true);
        }

        private void SandwichCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(SandwichCheckBox.Checked)
            {
                Main.checkBoxChecked(true, SandWichAdd, SandwichRemove, txtSandwich);
                Main.addMealToCart(CartData, ds, mealsAdapter, (int)WeekendMeals.ClassicSandwich, txtSandwich, subtotaltxt);
            }
            else
            {
                Main.checkBoxChecked(false,SandWichAdd, SandwichRemove, txtSandwich);
                Main.removeMealFromCart((int)WeekendMeals.ClassicSandwich, CartData, ds);
            }
        }

        private void SandwichRemove_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(txtSandwich, (int)WeekendMeals.ClassicSandwich, CartData, false);
        }

        private void SandWichAdd_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(txtSandwich, (int)WeekendMeals.ClassicSandwich, CartData, true);
        }

        private void GwinyaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (GwinyaCheckBox.Checked)
            {
                Main.checkBoxChecked(true, GwinyaAdd, GwinyaRemove, txtGwinya);
                Main.addMealToCart(CartData, ds, mealsAdapter, (int)WeekendMeals.GwinyaCombo, txtGwinya, subtotaltxt);
            }
            else
            {
                Main.checkBoxChecked(false, GwinyaAdd, GwinyaRemove, txtGwinya);
                Main.removeMealFromCart((int)WeekendMeals.GwinyaCombo, CartData, ds);
            }
        }

        private void GwinyaRemove_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(txtGwinya, (int)WeekendMeals.GwinyaCombo, CartData, false);
        }

        private void GwinyaAdd_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(txtGwinya, (int)WeekendMeals.GwinyaCombo, CartData, true);
        }

        private void YababaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (YababaCheckBox.Checked)
            {
                Main.checkBoxChecked(true, YababaAdd,YababaRemove, txtYababa);
                Main.addMealToCart(CartData, ds, mealsAdapter, (int)WeekendMeals.YababaCombo, txtYababa, subtotaltxt);
            }
            else
            {
                Main.checkBoxChecked(false, YababaAdd, YababaRemove, txtYababa);
                Main.removeMealFromCart((int)WeekendMeals.YababaCombo, CartData, ds);
            }
        }

        private void YababaRemove_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(txtYababa, (int)WeekendMeals.YababaCombo, CartData, false);
        }

        private void YababaAdd_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(txtYababa, (int)WeekendMeals.YababaCombo, CartData, true);
        }
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                Main.checkBoxChecked(true, button1, button2, textBox1);
                Main.addMealToCart(CartData, ds, mealsAdapter, (int)WeekendMeals.BerryWaffle, textBox1, subtotaltxt);
            }
            else
            {
                Main.checkBoxChecked(false, button1, button2, textBox1);
                Main.removeMealFromCart((int)WeekendMeals.BerryWaffle, CartData, ds);
                subtotaltxt.Text = Main.GetTotal(ds).ToString();
            }
        }



        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                Main.checkBoxChecked(true, button3, button4, textBox2);
                Main.addMealToCart(CartData, ds, mealsAdapter, (int)WeekendMeals.Granolacup, textBox2, subtotaltxt);
            }
            else
            {
                Main.checkBoxChecked(false, button3, button4, textBox2);
                Main.removeMealFromCart((int)WeekendMeals.Granolacup, CartData, ds);
                subtotaltxt.Text = Main.GetTotal(ds).ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox2, (int)WeekendMeals.Granolacup, CartData, false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox2, (int)WeekendMeals.Granolacup, CartData, true);
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
            {
                Main.checkBoxChecked(true, button5, button6, textBox3);
                Main.addMealToCart(CartData, ds, mealsAdapter, (int)WeekendMeals.Bagel, textBox3, subtotaltxt);
            }
            else
            {
                Main.checkBoxChecked(false, button5, button6, textBox3);
                Main.removeMealFromCart((int)WeekendMeals.Bagel, CartData, ds);
                subtotaltxt.Text = Main.GetTotal(ds).ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox3, (int)WeekendMeals.Bagel, CartData, false);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox3, (int)WeekendMeals.Bagel, CartData, true);
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked)
            {
                Main.checkBoxChecked(true, button13, button14, textBox7);
                Main.addMealToCart(CartData, ds, mealsAdapter, (int)WeekendMeals.BeefBurger, textBox7, subtotaltxt);
            }
            else
            {
                Main.checkBoxChecked(false, button13, button14, textBox7);
                Main.removeMealFromCart((int)WeekendMeals.BeefBurger, CartData, ds);
                subtotaltxt.Text = Main.GetTotal(ds).ToString();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox7, (int)WeekendMeals.BeefBurger, CartData, false);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox7, (int)WeekendMeals.BeefBurger, CartData, true);
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked)
            {
                Main.checkBoxChecked(true, button7, button8, textBox4);
                Main.addMealToCart(CartData, ds, mealsAdapter, (int)WeekendMeals.MiniTriffle, textBox4, subtotaltxt);
            }
            else
            {
                Main.checkBoxChecked(false, button7, button8, textBox4);
                Main.removeMealFromCart((int)WeekendMeals.MiniTriffle, CartData, ds);
                subtotaltxt.Text = Main.GetTotal(ds).ToString();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox4, (int)WeekendMeals.MiniTriffle, CartData, false);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox4, (int)WeekendMeals.MiniTriffle, CartData, true);
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked)
            {
                Main.checkBoxChecked(true, button9, button10, textBox5);
                Main.addMealToCart(CartData, ds, mealsAdapter, (int)WeekendMeals.ChocolateBrownie, textBox5, subtotaltxt);
            }
            else
            {
                Main.checkBoxChecked(false, button9, button10, textBox5);
                Main.removeMealFromCart((int)WeekendMeals.ChocolateBrownie, CartData, ds);
                subtotaltxt.Text = Main.GetTotal(ds).ToString();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox5, (int)WeekendMeals.ChocolateBrownie, CartData, false);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox5, (int)WeekendMeals.ChocolateBrownie, CartData, true);
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked)
            {
                Main.checkBoxChecked(true, button11, button12, textBox6);
                Main.addMealToCart(CartData, ds, mealsAdapter, (int)WeekendMeals.MalvaPudding, textBox6, subtotaltxt);
            }
            else
            {
                Main.checkBoxChecked(false, button11, button12, textBox6);
                Main.removeMealFromCart((int)WeekendMeals.MalvaPudding, CartData, ds);
                subtotaltxt.Text = Main.GetTotal(ds).ToString();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox6, (int)WeekendMeals.MalvaPudding, CartData, false);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox6, (int)WeekendMeals.MalvaPudding, CartData, true);
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox12.Checked)
            {
                Main.checkBoxChecked(true, button15, button16, textBox8);
                Main.addMealToCart(CartData, ds, mealsAdapter, (int)WeekendMeals.WorsRoll, textBox8, subtotaltxt);
            }
            else
            {
                Main.checkBoxChecked(false, button15, button16, textBox8);
                Main.removeMealFromCart((int)WeekendMeals.WorsRoll, CartData, ds);
                subtotaltxt.Text = Main.GetTotal(ds).ToString();
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox8, (int)WeekendMeals.WorsRoll, CartData, false);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox8, (int)WeekendMeals.WorsRoll, CartData, true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox1, (int)WeekendMeals.BerryWaffle, CartData, false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main.IncreaseQuantity(textBox1, (int)WeekendMeals.BerryWaffle, CartData, true);
        }

        private void btnPayment3_Click(object sender, EventArgs e)
        {
            Main.placeOrder(ordersAdapter, orderItemAdapter, ds, subtotaltxt, checkBoxMap);
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

        private void addToCart_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = Main.getSelectedRow(productsDgv);
            Main.addProductToCart(CartData, ds, txtQuantity, selectedRow, subtotaltxt);
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            productsAdapter.FillByProductName(ds.Products, searchBox.Text);
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
