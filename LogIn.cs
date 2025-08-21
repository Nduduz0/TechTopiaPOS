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
    public partial class LogIn : Form
    {
        Main main;
        public LogIn(Main main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkShow_CheckedChanged(object sender, EventArgs e)
        {
            if (checkShow.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //int employeeid = Convert.ToInt16(mealsDataset.Employee.Rows[0].ItemArray[0]);
            string id = txtUsername.Text;//(txtUsername.Text); khumaloll@gmail.com    thabo.n@yahoo.com
            string passwod = txtPassword.Text;//txtPassword.Text; 2333
            //string employeerole = mealsDataset.Employee.Rows[0].ItemArray[3].ToString();

            employeeTableAdapter.FillByByDetails(dsTables.Employee, id, passwod);
            if (dsTables.Employee.Rows.Count > 0)
            {
                string Name = dsTables.Employee.Rows[0].ItemArray[1].ToString();
                string Surname = dsTables.Employee.Rows[0].ItemArray[2].ToString();
                string employeerole = dsTables.Employee.Rows[0].ItemArray[4].ToString();
                if (employeerole == "Manager")
                {
                    main.enableAll();
                    main.Text = "KwaMshana     " + "            User Logged In: " + Name + " " + Surname + "       " + DateTime.Now.ToString("dd-MMM-yyyy");
                    // main.enableAll();
                }
                else if (employeerole == "Cashier")
                {
                    main.enableAll();
                    main.MainMenuStrip.Items[0].Enabled = true;

                    DayOfWeek today = DateTime.Now.DayOfWeek;

                    ToolStripMenuItem mainMenuItem = (ToolStripMenuItem)main.MainMenuStrip.Items[0];
                    mainMenuItem.DropDownItems[0].Visible = false;
                    mainMenuItem.DropDownItems[1].Visible = false;
                    mainMenuItem.DropDownItems[2].Visible = false;
                    mainMenuItem.DropDownItems[3].Visible = false;
                    mainMenuItem.DropDownItems[4].Visible = false;
                    mainMenuItem.DropDownItems[5].Visible = false;

                    switch (today)
                    {
                        case DayOfWeek.Monday:
                            mainMenuItem.DropDownItems[0].Visible = true;
                            break;
                        case DayOfWeek.Tuesday:
                            mainMenuItem.DropDownItems[1].Visible = true;
                            break;
                        case DayOfWeek.Wednesday:
                            mainMenuItem.DropDownItems[2].Visible = true;
                            break;
                        case DayOfWeek.Thursday:
                            mainMenuItem.DropDownItems[3].Visible = true;
                            break;
                        case DayOfWeek.Friday:
                            mainMenuItem.DropDownItems[4].Visible = true;
                            break;
                        case DayOfWeek.Saturday:
                            mainMenuItem.DropDownItems[5].Visible = true;
                            break;
                        case DayOfWeek.Sunday:
                            mainMenuItem.DropDownItems[5].Visible = true;
                            break;

                    }
                    main.MainMenuStrip.Items[1].Enabled = true;
                    main.MainMenuStrip.Items[2].Visible = false;
                    main.MainMenuStrip.Items[3].Visible = false;
                    main.MainMenuStrip.Items[4].Enabled = true;
                    main.Text = "KwaMshana     " + "            User Logged In: " + Name + " " + Surname + "       " + DateTime.Now.ToString("dd-MMM-yyyy");
                }

            }
            else
            {
                MessageBox.Show(null, "Please enter valid details", "Invalid Details");
                txtPassword.Clear();
                txtUsername.Clear();
            }
        }
        public void clere()
        {
            main.Text = " ";
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }
    }
}
