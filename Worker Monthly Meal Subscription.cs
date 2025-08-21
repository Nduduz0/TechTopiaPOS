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
using System.Drawing.Drawing2D;
using System.Globalization;

namespace TechTopiaM2
{
    public partial class Wokers_Monthly_Meal_Subscription : Form
    {
        private dsTables ds;
        private dsTablesTableAdapters.SubscribedWorkersTableAdapter workersAdapter;
        private String DeliveryOrPickup = "";
        private Dictionary<String, Boolean> validIputs;
        private decimal totalAmount = 0;
        public Wokers_Monthly_Meal_Subscription(dsTables ds, dsTablesTableAdapters.SubscribedWorkersTableAdapter workersAdapter)
        {
            InitializeComponent();
            studentRadio.Checked = true;
            this.ds = ds;
            this.workersAdapter = workersAdapter;
            this.subscribedStudentTableAdapter.Fill(subscribers.SubscribedStudent);
            validIputs = new Dictionary<String, bool>();
            StartDatePicker.MinDate = DateTime.Today;
        }


        private void fillTextBoxErrors() {
            validIputs.Add("Name", false);
            validIputs.Add("Surname", false);
            validIputs.Add("Email", false);
            validIputs.Add("Contact", false);
            validIputs.Add("Period", false);
            validIputs.Add("Diet", false);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool errors = ShowInvalidInputs();           
            if (!errors)
            {
                subscribedStudentTableAdapter.InsertSubscriber(txtName.Text,txtSurname.Text ,"Active", StartDatePicker.Value.Date.ToString(),
                    DeliveryOrPickup, totalAmount, txtEmail.Text, txtContact.Text, txtRoad.Text, txtSuburb.Text, txtCity.Text, txtCode.Text,null);
                MessageBox.Show("Subscriber has been added", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //`clearAll();
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


        //verify name and surname
        private bool IsValidName(string input)
        {
            // Allows letters, spaces, hyphens, min 2 characters
            return Regex.IsMatch(input, @"^[A-Za-z\s\-]{2,}$");
        }
        public bool IsTextOnly(string input)
        {
            // Check each character
            foreach (char c in input)
            {
                if (!char.IsLetter(c) && c != ' ')
                    return false;
            }
            return true;
        }
        //verify phone number
        private bool IsValidSouthAfricanCell(string number)
        {
            // South African cell numbers are 10 digits, starting with 0
            // Regex pattern covers all the given valid ranges
            string pattern = @"^0(?:
            60[1-2] |                 # TelkomSA 0601 - 0602
            60[3-5] |                 # MTN 0603 - 0605
            60[6-9] |                 # Vodacom 0606 - 0609
            61 |                      # Cell C 061
            62 |                      # Cell C 062
            630|631|632|633|634|635 | # MTN 0630-0635
            636|637 |                 # Vodacom 0636-0637
            640 |                     # MTN 0640
            641|642|643|644|645 |     # Cell C 0641-0645
            646|647|648|649 |         # Vodacom 0646-0649
            650|651|652|653|654 |     # Cell C 0650-0654
            655|656|657 |             # MTN 0655-0657
            658|659 |                 # TelkomSA 0658-0659
            66 |                      # Vodacom 066
            670|671|672 |             # TelkomSA 0670-0672
            673|674|675 |             # Vodacom 0673-0675
            676|677|678|679 |         # TelkomSA 0676-0679
            680|681|682|683|684|685 | # TelkomSA 0680-0685
            686|687|688|689 |         # MTN 0686-0689
            690 |                     # MTN 0690
            691|692|693|694|695|696|697|698|699 | # TelkomSA 0691-0699
            7\d{2} |                  # All 07xx ranges are valid
            810 |                     # MTN 0810
            811|812|813|814|815 |     # TelkomSA 0811-0815
            816 |                     # Rain 0816
            817 |                     # TelkomSA 0817
            818 |                     # Vodacom 0818
            819 |                     # TelkomSA 0819
            82 |                      # Vodacom 082
            83                        # MTN 083
        )\d{6}$";

            return Regex.IsMatch(number, pattern, RegexOptions.IgnorePatternWhitespace);
        }
        private bool addressProvided()
        {
            if (txtRoad.Text != "" && txtSuburb.Text != "" && txtCity.Text != "" && txtCode.Text != "")
            {
                return true;
            }
            return false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (IsTextOnly(txtName.Text))
            {
                txtName.ForeColor = Color.Black;
                validIputs["Name"] = true;
            }
            else
            {
                txtName.ForeColor = Color.Red;
                validIputs["Name"] = false;
            }
        }

        private void txtSurname_TextChanged(object sender, EventArgs e)
        {
            if (IsTextOnly(txtSurname.Text))
            {
                txtSurname.ForeColor = Color.Black;
                validIputs["Surname"] = true;
            }
            else
            {
                txtSurname.ForeColor = Color.Red;
                validIputs["Surname"] = false;
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (IsValidEmail(txtEmail.Text))
            {
                txtEmail.ForeColor = Color.Black;
                validIputs["Email"] = true;
            }
            else
            {
                txtEmail.ForeColor = Color.Red;
                validIputs["Email"] = false;
            }
        }

        private void txtContact_TextChanged(object sender, EventArgs e)
        {
            if (IsValidSouthAfricanCell(txtContact.Text))
            {
                txtContact.ForeColor = Color.Black;
                validIputs["Contact"] = true;
            }
            else
            {
                txtContact.ForeColor = Color.Red;
                validIputs["Contact"] = false;
            }
        }

        private void txtPeriod_TextChanged(object sender, EventArgs e)
        {
            validIputs["Period"] = true;
        }

        private void Wokers_Monthly_Meal_Subscription_Load(object sender, EventArgs e)
        {

            int radius = 20; // corner radius
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(AddPanel.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(AddPanel.Width - radius, AddPanel.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, AddPanel.Height - radius, radius, radius, 90, 90);
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.CloseAllFigures();

            AddPanel.Region = new Region(path);

        }

        private void managePanel_Paint(object sender, PaintEventArgs e)
        {
            int radius = 20; // corner radius
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(managePanel.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(managePanel.Width - radius, managePanel.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, managePanel.Height - radius, radius, radius, 90, 90);
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.CloseAllFigures();

            managePanel.Region = new Region(path);
        }

        private void studentRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (studentRadio.Checked == true)
            {
                subscribedStudentTableAdapter.Fill(subscribers.SubscribedStudent);
            }
            else
            {

            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            subscribedStudentTableAdapter.FillBy(subscribers.SubscribedStudent, txtSearch.Text);
        }

        private void txtPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedValue = Convert.ToInt32(txtPeriod.SelectedItem.ToString());
            txtAmount.Text = (selectedValue * 1000).ToString("C3", System.Globalization.CultureInfo.CreateSpecificCulture("en-ZA"));
            totalAmount = (selectedValue * 1000);
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            DeliveryOrPickup = "Delivery";
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            DeliveryOrPickup = "Pick up";
        }

        private void txtDiets_TextChanged(object sender, EventArgs e)
        {
            if (IsTextOnly(txtDiets.Text))
            {
                txtDiets.ForeColor = Color.Black;
                validIputs["Diet"] = true;
            }
            else
            {
                txtDiets.ForeColor = Color.Red;
                validIputs["Diet"] = false;
            }

        }
        private Boolean ShowInvalidInputs()
        {
            var errors = new List<string>();

            foreach (var item in validIputs)
            {
                if (!item.Value)
                    errors.Add($"{item.Key} is invalid or missing.");
            }

            if (errors.Count > 0)
            {
                MessageBox.Show(string.Join(Environment.NewLine, errors),
                                "Validation Errors",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return true;
            }
            return false;
        }
        private void clearAll()
        {
            txtName.Clear();
            txtSurname.Clear();
            txtEmail.Clear();
            txtContact.Clear();
            txtAmount.Clear();
            txtPeriod.SelectedIndex = -1;
            txtPeriod.SelectedItem = null;
        }
    }

}
