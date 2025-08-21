using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechTopiaM2
{
    public partial class Manage_Staff : Form
    {
        public DateTime startdate { get; set; }
       
        public Manage_Staff()
        {
            InitializeComponent();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            taEMPLOYEE.FillBySurname(dsTables1.Employee, txtSearch.Text);
        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
          
            {
                DateTime startdate = dateTimePicker1.Value;
                List<string> errors = new List<string>();

                string role = txtrole.SelectedItem?.ToString(); // Use ComboBox selected item

                // Validate required text fields
                if (string.IsNullOrWhiteSpace(txtfirstname.Text))
                    errors.Add("First name is required.");

                if (string.IsNullOrWhiteSpace(txtlastname.Text))
                    errors.Add("Last name is required.");

                if (string.IsNullOrWhiteSpace(txtIDno.Text) || !IsValidID(txtIDno.Text))
                    errors.Add("Valid ID number is required.");

                if (string.IsNullOrWhiteSpace(role))
                    errors.Add("Role is required.");

                if (string.IsNullOrWhiteSpace(txtemail.Text) || !IsValidEmail(txtemail.Text))
                    errors.Add("Valid email is required.");

                if (string.IsNullOrWhiteSpace(txtcontactno.Text) || !IsValidPhoneNumber(txtcontactno.Text))
                    errors.Add("Valid contact number is required.");

                if (string.IsNullOrWhiteSpace(txtSalary.Text))
                    errors.Add("Salary is required.");
                else if (!decimal.TryParse(txtSalary.Text, out decimal salary) || salary < 0)
                    errors.Add("Salary must be a valid non-negative number.");

                // Password validation only for Cashier/Manager
                if ((role == "Cashier" || role == "Manager") && string.IsNullOrWhiteSpace(txtaddpsswrd.Text))
                    errors.Add("Password is required for " + role + ".");

                // Show errors if any
                if (errors.Count > 0)
                {
                    MessageBox.Show("Please fix the following errors:\n\n- " + string.Join("\n- ", errors),
                                    "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Insert into database if validation passed
                taEMPLOYEE.Insert(
                    txtfirstname.Text.Trim(),
                    txtlastname.Text.Trim(),
                    txtIDno.Text.Trim(),
                    role,
                    txtemail.Text.Trim(),
                    txtcontactno.Text.Trim(),
                    startdate,
                    Convert.ToDecimal(txtSalary.Text),
                    txtaddpsswrd.Text.Trim(),
                    txtStatus.Text.Trim()
                );

                MessageBox.Show("New Employee has been Added");
                taEMPLOYEE.Fill(dsTables1.Employee);
                clearAll();
            }



        }
        private void clearAll()
        {
            txtaddpsswrd.Clear();
            txtcontactno.Clear();
            txtemail.Clear();
            txtfirstname.Clear();
            txtIDno.Clear();
            txtlastname.Clear();
        }

        private void Manage_Staff_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'wstGrp31DataSet.Employee' table. You can move, or remove it, as needed.
            this.taEMPLOYEE.Fill(this.dsTables1.Employee);
            dateTimePicker1.MinDate = DateTime.Today;
            txtSalary.ReadOnly = true;
        }

        private void txtrole_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedrole = txtrole.SelectedItem.ToString();

            switch(selectedrole)
            {
                case "Manager":
                    txtSalary.Text = "17800";
                    txtaddpsswrd.Enabled = true;
                    break;
                case "Cashier":
                    txtSalary.Text = "7500";
                    txtaddpsswrd.Enabled = true;
                    break;
                case "Chef":
                    txtSalary.Text = "8500";
                    txtaddpsswrd.Enabled = false;
                    break;
                default:
                    txtSalary.Text = "";
                    break;
            }
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        //verify email
        private bool IsValidEmail(string email)
        {
            // Simple regex pattern for demonstration
            return Regex.IsMatch(email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.IgnoreCase);
        }
        //verify phone number
        private bool IsValidPhoneNumber(string number)
        {
            // Allow only 10 digits (change as needed)
            return Regex.IsMatch(number, @"^\d{10}$");
        }
        //verify name and surname
        private bool IsValidName(string input)
        {
            // Allows letters, spaces, hyphens, min 2 characters
            return Regex.IsMatch(input, @"^[A-Za-z\s\-]{2,}$");
        }
        //verify positive number
        private bool IsNaturalNumber(string input)
        {
            // Regex: Only digits, no leading zero, no decimal
            return Regex.IsMatch(input, @"^[1-9]\d*$");
        }
        private bool IsValidID(string idNumber)
        {
            return Regex.IsMatch(idNumber, @"^\d{13}$");
        }

        private void txtemail_TextChanged(object sender, EventArgs e)
        {
            if (IsValidEmail(txtemail.Text))
            {
                txtemail.ForeColor = Color.Black;
            }
            else
            {
                txtemail.ForeColor = Color.Red;
            }
        }

        private void txtcontactno_TextChanged(object sender, EventArgs e)
        {
            if (IsValidPhoneNumber(txtcontactno.Text))
            {
                txtcontactno.ForeColor = Color.Black;
            }
            else
            {
                txtcontactno.ForeColor = Color.Red;
            }
        }

        private void txtIDno_TextChanged(object sender, EventArgs e)
        {
            if (IsValidID(txtIDno.Text))
            {
                txtIDno.ForeColor = Color.Black;
            }
            else
            {
                txtIDno.ForeColor = Color.Red;
            }
        }
        
    }
}
