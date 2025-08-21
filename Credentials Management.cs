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
    public partial class Change_Password : Form
    {
        public Change_Password()
        {
            InitializeComponent();
        }

        private void btnChangePsswrd_Click(object sender, EventArgs e)
        {
            string employeeIDText = usertext.Text.Trim();
            string oldPassword = oldpsswrd.Text;
            string newPassword = newpsswrld.Text;
            string confirmPassword = confirmpsswrd.Text;

            if (string.IsNullOrEmpty(employeeIDText))
            {
                MessageBox.Show("Please enter an Employee ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("New passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Password fields cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Try parsing employee ID to int
            if (!int.TryParse(employeeIDText, out int employeeID))
            {
                MessageBox.Show("Invalid Employee ID format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Load employee record using EmployeeID
            var employeeData = taEmployee.GetDataBy3(employeeID);

            if (employeeData.Rows.Count == 0)
            {
                MessageBox.Show("Employee not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var employee = employeeData[0];

            // Validate old password
            if (employee.password != oldPassword)
            {
                MessageBox.Show("Incorrect old password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Perform the password update
            try
            {
                taEmployee.UpdateQueryPassword(newPassword, employeeID);
                MessageBox.Show("Password changed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating password: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string employeeIDText = employeeid.Text.Trim();
            string newEmail = email.Text.Trim();
            string newContact = contactno.Text.Trim();

            if (string.IsNullOrEmpty(employeeIDText))
            {
                MessageBox.Show("Please enter the Employee ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(employeeIDText, out int employeeID))
            {
                MessageBox.Show("Invalid Employee ID format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(newEmail) && string.IsNullOrEmpty(newContact))
            {
                MessageBox.Show("Please enter a new email or contact number to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Load the employee row first to make sure they exist
            var employeeData = taEmployee.GetDataBy3(employeeID);

            if (employeeData.Rows.Count == 0)
            {
                MessageBox.Show("Employee not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Use DBNull.Value if a field is not being updated
            string emailParam = string.IsNullOrEmpty(newEmail) ? null : newEmail;
            string contactParam = string.IsNullOrEmpty(newContact) ? null : newContact;

            try
            {
                taEmployee.UpdateQueryEmailandContact(emailParam, contactParam, employeeID);
                MessageBox.Show("Employee details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblshow_Click(object sender, EventArgs e)
        {
            newpsswrld.PasswordChar = '\0';
            confirmpsswrd.PasswordChar = '\0';

            lblshow.Visible = false;
            lblhide.Visible = true;
        }

        private void lblhide_Click(object sender, EventArgs e)
        {
            newpsswrld.PasswordChar = '*';
            confirmpsswrd.PasswordChar = '*';

            lblshow.Visible = true;
            lblhide.Visible = false;
        }

        private void btnClearPsswrd_Click(object sender, EventArgs e)
        {
            usertext.Clear();
            oldpsswrd.Clear();
            newpsswrld.Clear();
            confirmpsswrd.Clear();
        }

        private void btnClearCntct_Click(object sender, EventArgs e)
        {

            employeeid.Clear();
            email.Clear();
            contactno.Clear();
        }

        private void Change_Password_Load(object sender, EventArgs e)
        {
            newpsswrld.PasswordChar = '*';
            confirmpsswrd.PasswordChar = '*';

            lblshow.Visible = true;
            lblhide.Visible = false;
        }
    }
}
