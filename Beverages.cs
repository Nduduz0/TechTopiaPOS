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
    public partial class Beverages : Form
    {
        private DataGridView CartData;
        private dsTables dsTable;

        enum BeverageID
        {
            Sprite = 2,
            Coke =4,
            Water = 5,
            Energade = 6,
            Powerade = 7

        }
        public Beverages(DataGridView dgv,dsTables ds)
        {
            this.CartData = dgv;
            this.dsTable = ds;
            InitializeComponent();
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        /*
         private void checkBox1_CheckedChanged(object sender, EventArgs e)
         {
             if (cokeCheckBox.Checked)
             {
                 cokeMinus.Enabled = true;
                 cokePlus.Enabled = true;
                 txtCoke.Text = "1";
                 addProductToCart((int)BeverageID.Coke, txtCoke);
             }
             else
             {
                 cokeMinus.Enabled = false;
                 cokePlus.Enabled = false;
                 txtCoke.Text = "0";
                 removeProductFromCart((int)BeverageID.Coke);
             }
         }

         private void cokeMinus_Click(object sender, EventArgs e)
         {
             DataGridViewRow row = null;
             HelperObject.incrementDecrement(cokeMinus, txtCoke, false);
             int qty = Convert.ToInt32(txtCoke.Text);
             row = getRowByProductID((int)BeverageID.Coke);
             decimal price = Convert.ToDecimal(row.Cells[4].Value);
             row.Cells[3].Value = qty;
             row.Cells[5].Value = qty * price;
         }

         private void cokePlus_Click(object sender, EventArgs e)
         {
             DataGridViewRow row = null;
             HelperObject.incrementDecrement(cokePlus, txtCoke, true);
             int qty = Convert.ToInt32(txtCoke.Text);
             row = getRowByProductID((int)BeverageID.Coke);
             decimal price = Convert.ToDecimal(row.Cells[4].Value);
             row.Cells[3].Value = qty;
             row.Cells[5].Value = qty * price;
         }
         private void addProductToCart(int productID, TextBox txtQuantiy)
         {

             productsTableAdapter.FillByProductID(dsTable.Products, productID);

             DataRow row = dsTable.Cart.NewCartRow();
             int quantity = Convert.ToInt32(txtQuantiy.Text);
             decimal price = Convert.ToDecimal(dsTable.Products.Rows[0][3]);//select correct row

             row[0] = dsTable.Products.Rows[0][1]; 
             row[1] =productID;
             row[2] = null;//not a meal
             row[3] = quantity;
             row[4] = price;
             row[5] = quantity * price;

             dsTable.Products.Rows.Clear();
             dsTable.Cart.Rows.Add(row);
             CartData.DataSource = dsTable.Cart;
         }

         //remove meal from cart
         private void removeProductFromCart(int productID)
         {
             var rows = dsTable.Cart.Rows;
             for (int i = 0; i < rows.Count; i++)
             {
                 if (rows[i][1].ToString() != "")//rows[i][0] for products and rows[i][1] for meals
                 {
                     if (Convert.ToInt32(rows[i][1]) == productID)
                     {
                         dsTable.Cart.Rows.Remove(rows[i]);
                     }
                 }
             }
             CartData.DataSource = dsTable.Cart;
         }
         private DataGridViewRow getRowByProductID(int id)
         {
             DataGridViewRow row = null;
             for (int i = 0; i < CartData.Rows.Count; i++)
             {
                 row = CartData.Rows[i];
                 if (row!=null && row.Cells[1].Value.ToString()!="")
                 {
                     if(Convert.ToInt32(row.Cells[1].Value) == id)
                     {
                         return row;
                     }
                 }
             }
             return row;
         }
        */

    }
}

