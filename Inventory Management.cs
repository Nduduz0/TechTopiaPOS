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
    public partial class Inventory_Report : Form
    {
        int ProductID = 0;
        public Inventory_Report()
        {
            InitializeComponent();
            groupBox2.Enabled = false;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Inventory_Report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsTables.Products' table. You can move, or remove it, as needed.
            this.taProducts.Fill(this.dsTables.Products);
            // TODO: This line of code loads data into the 'dsTables.Products' table. You can move, or remove it, as needed.
            this.taProducts.Fill(this.dsTables.Products);
            // TODO: This line of code loads data into the 'dsTables.Products' table. You can move, or remove it, as needed.
            this.taProducts.Fill(this.dsTables.Products);

        }

        private void txtInvSerach_TextChanged(object sender, EventArgs e)
        {
            taProducts.FillByProductName(dsTables.Products, txtInvSearch.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            /*if (validAddBoxes())
            {
                taProducts.InsertQueryNewProduct(txtproduct_name.Text, txtCategory.Text, Convert.ToDecimal(textPRICE.Text), Convert.ToInt32(textQuantity.Text));
                taProducts.Fill(dsTables.Products);
                MessageBox.Show("Product named" +  txtproduct_name.Text + "has been added");
                txtproduct_name.Clear();
                txtCategory.Clear();
                textPRICE.Clear();
                textQuantity.Clear();
            }
            else
            {
                MessageBox.Show("Please Fill In All The Required Fields");
            }  */
            List<string> errors = new List<string>();

            // Check if product name is empty
            if (string.IsNullOrWhiteSpace(txtproduct_name.Text))
            {
                errors.Add("Product name is required.");
            }

            // Check if category is empty
            if (string.IsNullOrWhiteSpace(txtCategory.Text))
            {
                errors.Add("Category is required.");
            }

            // Check if price is a valid decimal
            if (!decimal.TryParse(textPRICE.Text, out decimal price) || price < 0)
            {
                errors.Add("Price must be a valid non-negative number.");
            }

            // Check if quantity is a valid integer
            if (!int.TryParse(textQuantity.Text, out int quantity) || quantity < 0)
            {
                errors.Add("Quantity must be a valid non-negative whole number.");
            }

            // If there are any validation errors, show them
            if (errors.Count > 0)
            {
                MessageBox.Show("Please fix the following errors:\n- " + string.Join("\n- ", errors), "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Insert new product
                taProducts.InsertQueryNewProduct(txtproduct_name.Text, txtCategory.Text, price, quantity);
                taProducts.Fill(dsTables.Products);

                MessageBox.Show("Product named \"" + txtproduct_name.Text + "\" has been added.");

                // Clear fields
                txtproduct_name.Clear();
                //txtCategory.Clear();
                textPRICE.Clear();
                textQuantity.Clear();
            }
        }

        private void dgvInventory_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
            if (e.RowIndex >= 0)
            {
                groupBox2.Enabled = true;
                DataGridViewRow row = dgvInventory.Rows[e.RowIndex];
                ProductID = Convert.ToInt32(row.Cells[0].Value.ToString());
                label6.Text = "Update " + row.Cells[1].Value.ToString();
                txtprice.Text = row.Cells[3].Value.ToString();
                txtQuantity_On_Hand.Text = row.Cells[4].Value.ToString();
                label7.Text = row.Cells[0].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (validBoxes())
            {
                taProducts.UpdateProduct(Convert.ToDecimal(txtprice.Text),Convert.ToInt32(dgvInventory.CurrentRow.Cells[4].Value) + Convert.ToInt32(txtQuantity_On_Hand.Text), ProductID);
                taProducts.Fill(this.dsTables.Products);
                MessageBox.Show("Product named: " + label6.Text + " Updated Successfully");
                groupBox2.Enabled = false;
                txtprice.Clear();
                txtQuantity_On_Hand.Clear();
            }
            else
            {
                MessageBox.Show("Please fill in the required fields");
            }
        }
        private bool validBoxes()
        {
            bool valid = false;
            if(txtprice.Text !="" && txtQuantity_On_Hand.Text != "")
            {
                valid = true;
            }
            return valid;
        }
        private bool validAddBoxes()
        {
            bool valid = false;
            if(txtproduct_name.Text != "" && txtCategory.Text !="" && textPRICE.Text !="" && textQuantity.Text != ""){
                valid = true;   
            }
            return valid;
        }

        private void dgvInventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (validBoxes())
            {
                string delete = "deleted";

                taProducts.UpdatetoDLT(delete, ProductID, Convert.ToInt32(label7.Text));
                taProducts.Fill(this.dsTables.Products);
                MessageBox.Show("Product named: " + label6.Text + " have been deleted");
                groupBox2.Enabled = false;
                txtprice.Clear();
                txtQuantity_On_Hand.Clear();
            }
            else
            {
                MessageBox.Show("Please fill in the required fields");
            }
        }
    }
}
    

