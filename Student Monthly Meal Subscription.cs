using System;
using System.Text.RegularExpressions;
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
    public partial class Student_Monthly_Meal_Subscription : Form
    {
        private dsTables ds;
        private dsTablesTableAdapters.SubscribedStudentTableAdapter studentAdapter;
        private String DeliveryOrPickup = "";
        public Student_Monthly_Meal_Subscription(dsTables ds, dsTablesTableAdapters.SubscribedStudentTableAdapter studentAdapter)
        {
            InitializeComponent();
            groupBox2.Enabled = false;
            this.ds = ds;
            this.studentAdapter = studentAdapter;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void Student_Monthly_Meal_Subscription_Load(object sender, EventArgs e)
        {

        }

        private void txtSEmail_TextChanged(object sender, EventArgs e)
        {

            if (IsValidEmail(txtEmail.Text))
            {
                txtEmail.ForeColor = Color.Black; 
            }
            else
            {
                txtEmail.ForeColor = Color.Red;   
            }
        }

        private void txtSContact_TextChanged(object sender, EventArgs e)
        {
            if (IsValidPhoneNumber(txtSContact.Text))
            {
                txtSContact.ForeColor = Color.Black;
            }
            else
            {
                txtSContact.ForeColor = Color.Red;
            }
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

        private void txtSName_TextChanged(object sender, EventArgs e)
        {
            if (IsValidName(txtSName.Text))
            {
                txtSName.ForeColor = Color.Black;
            }
            else
            {
                txtSName.ForeColor = Color.Red;
            }
        }

        private void txtSSurname_TextChanged(object sender, EventArgs e)
        {
            if (IsValidName(txtSSurname.Text))
            {
                txtSSurname.ForeColor = Color.Black;
            }
            else
            {
                txtSSurname.ForeColor = Color.Red;
            }
        }

        private void txtSPeriod_TextChanged(object sender, EventArgs e)
        {
            if (IsNaturalNumber(txtSPeriod.Text))
            {
                txtSPeriod.ForeColor = Color.Black;
                txtSAmount.Text = (1000 * Convert.ToInt32(txtSPeriod.Text)).ToString();
            }
            else
            {
                txtSPeriod.ForeColor = Color.Red;
                txtSAmount.Clear();
            }
        }

        private void btnSaveS_Click(object sender, EventArgs e)
        {
            List<string> errors = new List<string>();

            // Validate Name and Surname
            if (!IsValidName(txtSName.Text))
                errors.Add("First name must contain only letters, spaces or hyphens, and be at least 2 characters long.");

            if (!IsValidName(txtSSurname.Text))
                errors.Add("Surname must contain only letters, spaces or hyphens, and be at least 2 characters long.");

            // Validate Period
            if (!IsNaturalNumber(txtSPeriod.Text))
                errors.Add("Period must be a valid positive number.");

            // Validate Amount
            if (!decimal.TryParse(txtSAmount.Text, out decimal amount) || amount < 0)
                errors.Add("Amount must be a valid non-negative number.");

            // Validate Email
            if (!IsValidEmail(txtEmail.Text))
                errors.Add("Email format is invalid.");

            // Validate Contact
            if (!IsValidPhoneNumber(txtSContact.Text))
                errors.Add("Contact number must contain exactly 10 digits.");

            // Validate address if Delivery is selected
            if (DeliveryOrPickup == "delivery")
            {
                if (string.IsNullOrWhiteSpace(txtSRoad.Text))
                    errors.Add("Road/Street is required for delivery.");

                if (string.IsNullOrWhiteSpace(txtSSuburb.Text))
                    errors.Add("Suburb is required for delivery.");

                if (string.IsNullOrWhiteSpace(txtSCity.Text))
                    errors.Add("City is required for delivery.");

                if (string.IsNullOrWhiteSpace(txtSCode.Text))
                    errors.Add("Postal code is required for delivery.");
                else if (!IsNaturalNumber(txtSCode.Text))
                    errors.Add("Postal code must be a valid number.");
            }

            // Show errors if any
            if (errors.Count > 0)
            {
                MessageBox.Show("Please correct the following errors:\n\n- " + string.Join("\n- ", errors),
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Proceed with save if validation passes
            try
            {
                if (DeliveryOrPickup == "pickup")
                {
                    studentAdapter.InsertWithoutAddress(txtSName.Text, txtSSurname.Text, "ACTIVE", dateTimePicker1.Value.Date.ToString(),
                        Convert.ToInt32(txtSPeriod.Text), DeliveryOrPickup, Convert.ToDecimal(txtSAmount.Text), txtSDiets.Text, txtEmail.Text, txtSContact.Text);
                }
                else
                {
                    studentAdapter.Insert(txtSName.Text, txtSSurname.Text, "ACTIVE", dateTimePicker1.Value.Date,
                        Convert.ToInt32(txtSPeriod.Text), DeliveryOrPickup, Convert.ToDecimal(txtSAmount.Text), txtSDiets.Text, txtEmail.Text, txtSContact.Text,
                        txtSRoad.Text, txtSSuburb.Text, txtSCity.Text, txtSCode.Text);
                }

                MessageBox.Show("New Subscriber: " + txtSName.Text + " added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // You could add a clear method here if desired
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to add subscriber.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (DeliveryOrPickup == "pickup")
            {
                studentAdapter.InsertWithoutAddress(txtSName.Text, txtSSurname.Text, "ACTIVE", dateTimePicker1.Value.Date.ToString()
                    , Convert.ToInt32(txtSPeriod.Text), DeliveryOrPickup, Convert.ToDecimal(txtSAmount.Text), txtSDiets.Text, txtEmail.Text, txtSContact.Text);
                MessageBox.Show("New Subscriber: " + txtSName.Text + " Added Successfully");
                return;
            }
            else if (DeliveryOrPickup == "delivery" && addressProvided())
            {
                studentAdapter.Insert(txtSName.Text, txtSSurname.Text, "ACTIVE", dateTimePicker1.Value.Date
                    , Convert.ToInt32(txtSPeriod.Text), DeliveryOrPickup, Convert.ToDecimal(txtSAmount.Text), txtSDiets.Text, txtEmail.Text, txtSContact.Text, txtSRoad.Text, txtSSuburb.Text, txtSCity.Text, txtSCode.Text);
                MessageBox.Show("New Subscriber: " + txtSName.Text + " Added Successfully");
                return;
            }
            MessageBox.Show("Please Fill All the required Fields");
            return;
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                groupBox2.Enabled = true;
                DeliveryOrPickup = "delivery";
            }
            else
            {
                groupBox2.Enabled = false;
                DeliveryOrPickup = "pickup";
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                DeliveryOrPickup = "pickup";
            }
            else
            {
                DeliveryOrPickup = "delivery";
            }
        }
        private bool addressProvided()
        {
            if(txtSRoad.Text != "" && txtSSuburb.Text !=""&&txtSCity.Text != "" && txtSCode.Text != "")
            {
                return true;
            }
            return false;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
