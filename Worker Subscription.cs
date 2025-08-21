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
    public partial class Worker_Subscription : Form
    {
        private dsTables ds;
        private dsTablesTableAdapters.SubscribedStudentTableAdapter studentAdapter;
        private dsTablesTableAdapters.SubscribedWorkersTableAdapter workersAdapter;
        private int ID = 0;
        public Worker_Subscription(dsTables ds,dsTablesTableAdapters.SubscribedStudentTableAdapter studentAdapter,
            dsTablesTableAdapters.SubscribedWorkersTableAdapter workersAdapter)
        {
            InitializeComponent();
            this.ds = ds;
            this.studentAdapter = studentAdapter;
            this.workersAdapter = workersAdapter;
            dataGridView1.DataSource = ds.SubscribedStudent;
            radioButton1.Checked = true;
            updateGroupBox.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*if (validUpdateBoxes())
             {
                 if (radioButton1.Checked)
                 {
                     studentAdapter.UpdateQuery(txtStatus.Text, dateTimePicker1.Value.Date.ToString(),
                     Convert.ToInt32(txtPeriod.Text),txtDelivery.Text ,Convert.ToDecimal(txtAmount.Text), txtDiets.Text, txtEmail.Text, txtContact.Text,
                     txtRoad.Text, txtSuburb.Text, txtAreaCode.Text,ID);
                     studentAdapter.Fill(ds.SubscribedStudent);
                     MessageBox.Show("Added");
                     clear();
                 }
                 else
                 {
                     workersAdapter.UpdateQuery(txtStatus.Text, dateTimePicker1.Value.Date.ToString(),
                     Convert.ToInt32(txtPeriod.Text), txtDelivery.Text, Convert.ToDecimal(txtAmount.Text), txtDiets.Text, txtEmail.Text, txtContact.Text,
                     txtRoad.Text, txtSuburb.Text, txtAreaCode.Text, ID);
                     workersAdapter.Fill(ds.SubscribedWorkers);
                     MessageBox.Show("Added");
                     clear();

                 }
             }
             else
             {
                 MessageBox.Show("Please fill in the required fields");
             }*/
            List<string> errors = new List<string>();

            // Validate each input field with specific checks
            if (string.IsNullOrWhiteSpace(txtStatus.Text))
                errors.Add("Status is required.");

            if (!int.TryParse(txtPeriod.Text, out int period) || period <= 0)
                errors.Add("Period must be a valid positive whole number.");

            if (string.IsNullOrWhiteSpace(txtDelivery.Text))
                errors.Add("Delivery method is required.");

            if (!decimal.TryParse(txtAmount.Text, out decimal amount) || amount < 0)
                errors.Add("Amount must be a valid non-negative number.");

            if (string.IsNullOrWhiteSpace(txtDiets.Text))
                errors.Add("Diet information is required.");

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
                errors.Add("Email is required.");
            else if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
                errors.Add("Email format is invalid.");

            if (string.IsNullOrWhiteSpace(txtContact.Text))
                errors.Add("Contact number is required.");
            else if (!txtContact.Text.All(char.IsDigit))
                errors.Add("Contact number must contain only digits.");

            if (string.IsNullOrWhiteSpace(txtRoad.Text))
                errors.Add("Road/Street name is required.");

            if (string.IsNullOrWhiteSpace(txtSuburb.Text))
                errors.Add("Suburb is required.");

            if (string.IsNullOrWhiteSpace(txtAreaCode.Text))
                errors.Add("Area code is required.");
            else if (!txtAreaCode.Text.All(char.IsDigit))
                errors.Add("Area code must contain only digits.");

            // If there are validation errors, show them and return early
            if (errors.Count > 0)
            {
                MessageBox.Show("Please fix the following errors:\n\n- " + string.Join("\n- ", errors),
                                "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Proceed with update depending on selected radio button
            try
            {
                if (radioButton1.Checked)
                {
                    studentAdapter.UpdateQuery(
                        txtStatus.Text,
                        dateTimePicker1.Value.Date.ToString(),
                        period,
                        txtDelivery.Text,
                        amount,
                        txtDiets.Text,
                        txtEmail.Text,
                        txtContact.Text,
                        txtRoad.Text,
                        txtSuburb.Text,
                        txtAreaCode.Text,
                        Convert.ToInt32(label13.Text)
                    ) ;
                    studentAdapter.Fill(ds.SubscribedStudent);
                }
                else
                {
                    workersAdapter.UpdateQuery(
                        txtStatus.Text,
                        dateTimePicker1.Value.Date.ToString(),
                        period,
                        txtDelivery.Text,
                        amount,
                        txtDiets.Text,
                        txtEmail.Text,
                        txtContact.Text,
                        txtRoad.Text,
                        txtSuburb.Text,
                        txtAreaCode.Text,
                        Convert.ToInt32(label13.Text)
                    );
                    workersAdapter.Fill(ds.SubscribedWorkers);
                }

                MessageBox.Show("Record has been updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update failed.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                dataGridView1.DataSource = ds.SubscribedStudent;
                studentAdapter.Fill(ds.SubscribedStudent);
                txtSearch.Clear();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                dataGridView1.DataSource = ds.SubscribedWorkers;
                workersAdapter.Fill(ds.SubscribedWorkers);
                txtSearch.Clear();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                studentAdapter.FillByName(ds.SubscribedStudent, txtSearch.Text);
            }
            else
            {
                workersAdapter.FillByName(ds.SubscribedWorkers, txtSearch.Text);
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (radioButton2.Checked)
                {
                    updateGroupBox.Enabled = true;
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                   label13.Text= row.Cells[0].Value.ToString();
                    txtStatus.Text = row.Cells[3].Value.ToString();
                    txtPeriod.Text = row.Cells[5].Value.ToString();
                    txtDelivery.Text = row.Cells[6].Value.ToString();
                    txtAmount.Text = row.Cells[7].Value.ToString();
                    txtDiets.Text = row.Cells[8].Value.ToString();
                    txtEmail.Text = row.Cells[9].Value.ToString();
                    txtContact.Text = row.Cells[14].Value.ToString();
                    txtRoad.Text = row.Cells[10].Value.ToString();
                    txtSuburb.Text = row.Cells[11].Value.ToString();
                    txtAreaCode.Text = row.Cells[13].Value.ToString();
                }
                else
                {
                    updateGroupBox.Enabled = true;
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    label13.Text= row.Cells[0].Value.ToString();
                    txtStatus.Text = row.Cells[3].Value.ToString();
                    txtPeriod.Text = row.Cells[5].Value.ToString();
                    txtDelivery.Text = row.Cells[6].Value.ToString();
                    txtAmount.Text = row.Cells[7].Value.ToString();
                    txtDiets.Text = row.Cells[8].Value.ToString();
                    txtEmail.Text = row.Cells[9].Value.ToString();
                    txtContact.Text = row.Cells[10].Value.ToString();
                    txtRoad.Text = row.Cells[11].Value.ToString();
                    txtSuburb.Text = row.Cells[12].Value.ToString();
                    txtAreaCode.Text = row.Cells[14].Value.ToString();
                }
                
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

        private void txtStatus_TextChanged(object sender, EventArgs e)
        {
            if (IsValidName(txtStatus.Text))
            {
                txtStatus.ForeColor = Color.Black;
            }
            else
            {
               txtStatus.ForeColor = Color.Red;
            }
        }

        private void txtPeriod_TextChanged(object sender, EventArgs e)
        {
            if (IsNaturalNumber(txtPeriod.Text))
            {
                txtPeriod.ForeColor = Color.Black;
                txtAmount.Text = (1000 * Convert.ToInt32(txtPeriod.Text)).ToString();
            }
            else
            {
                txtPeriod.ForeColor = Color.Red;
                txtAmount.Clear();
            }
        }

        private void txtDelivery_TextChanged(object sender, EventArgs e)
        {
            if(IsValidName(txtDelivery.Text))
            {
                txtDelivery.ForeColor = Color.Black;
            }
            else
            {
                txtDelivery.ForeColor = Color.Red;
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
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

        private void txtContact_TextChanged(object sender, EventArgs e)
        {
            if (IsValidPhoneNumber(txtContact.Text))
            {
                txtContact.ForeColor = Color.Black;
            }
            else
            {
                txtContact.ForeColor = Color.Red;
            }
        }
        private bool validUpdateBoxes()
        {
            bool valid = false;
            if (txtAmount.Text != ""  && txtContact.Text != "" && txtDiets.Text != ""  
                && txtPeriod.Text !="" && txtDelivery.Text !="" && txtStatus.Text != "" /*&& txtEmail.Text !="" && txtAreaCode.Text != ""&& txtRoad.Text !=""&&txtSuburb.Text!=""*/)
            {
                valid = true;
            }
            return valid;
        }
        private void clear()
        {
            txtAmount.Clear();
            txtAreaCode.Clear();
            txtContact.Clear();
            
            txtDiets.Clear();
            txtEmail.Clear();
            
            txtRoad.Clear();
            txtSuburb.Clear();
            
            updateGroupBox.Enabled = true;
        }

        private void btcnClear_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}
