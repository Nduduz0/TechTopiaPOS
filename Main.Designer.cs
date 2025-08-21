
namespace TechTopiaM2
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dailyMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mondayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tuesdayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wednesdayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thursdayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fridayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weekendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monthlyMealPlansToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentsSubscriptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.workersSubscriptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.businessReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesSummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.managementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentSubscriptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.credentialsManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayPanel = new System.Windows.Forms.Panel();
            this.mealsDataset = new TechTopiaM2.dsTables();
            this.mealsTableAdapter = new TechTopiaM2.dsTablesTableAdapters.MealsTableAdapter();
            this.productsTableAdapter = new TechTopiaM2.dsTablesTableAdapters.ProductsTableAdapter();
            this.dailyOrderTableAdapter = new TechTopiaM2.dsTablesTableAdapters.DailyOrderTableAdapter();
            this.daily_Order_ItemsTableAdapter = new TechTopiaM2.dsTablesTableAdapters.Daily_Order_ItemsTableAdapter();
            this.subscribedStudentTableAdapter = new TechTopiaM2.dsTablesTableAdapters.SubscribedStudentTableAdapter();
            this.subscribedWorkersTableAdapter = new TechTopiaM2.dsTablesTableAdapters.SubscribedWorkersTableAdapter();
            this.subscriptionDataset = new TechTopiaM2.dsTables();
            this.staffManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mealsDataset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subscriptionDataset)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dailyMenuToolStripMenuItem,
            this.monthlyMealPlansToolStripMenuItem,
            this.businessReportsToolStripMenuItem,
            this.managementToolStripMenuItem,
            this.logOutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(237, 661);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dailyMenuToolStripMenuItem
            // 
            this.dailyMenuToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.dailyMenuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mondayToolStripMenuItem,
            this.tuesdayToolStripMenuItem,
            this.wednesdayToolStripMenuItem,
            this.thursdayToolStripMenuItem,
            this.fridayToolStripMenuItem,
            this.weekendToolStripMenuItem});
            this.dailyMenuToolStripMenuItem.Font = new System.Drawing.Font("Elephant", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dailyMenuToolStripMenuItem.Image = global::TechTopiaM2.Properties.Resources.breakfast;
            this.dailyMenuToolStripMenuItem.Name = "dailyMenuToolStripMenuItem";
            this.dailyMenuToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 0, 4, 50);
            this.dailyMenuToolStripMenuItem.Size = new System.Drawing.Size(224, 81);
            this.dailyMenuToolStripMenuItem.Text = "Daily Menu";
            // 
            // mondayToolStripMenuItem
            // 
            this.mondayToolStripMenuItem.Name = "mondayToolStripMenuItem";
            this.mondayToolStripMenuItem.Size = new System.Drawing.Size(204, 32);
            this.mondayToolStripMenuItem.Text = "Monday";
            this.mondayToolStripMenuItem.Click += new System.EventHandler(this.mondayToolStripMenuItem_Click);
            // 
            // tuesdayToolStripMenuItem
            // 
            this.tuesdayToolStripMenuItem.Name = "tuesdayToolStripMenuItem";
            this.tuesdayToolStripMenuItem.Size = new System.Drawing.Size(204, 32);
            this.tuesdayToolStripMenuItem.Text = "Tuesday";
            this.tuesdayToolStripMenuItem.Click += new System.EventHandler(this.tuesdayToolStripMenuItem_Click);
            // 
            // wednesdayToolStripMenuItem
            // 
            this.wednesdayToolStripMenuItem.Name = "wednesdayToolStripMenuItem";
            this.wednesdayToolStripMenuItem.Size = new System.Drawing.Size(204, 32);
            this.wednesdayToolStripMenuItem.Text = "Wednesday";
            this.wednesdayToolStripMenuItem.Click += new System.EventHandler(this.wednesdayToolStripMenuItem_Click);
            // 
            // thursdayToolStripMenuItem
            // 
            this.thursdayToolStripMenuItem.Name = "thursdayToolStripMenuItem";
            this.thursdayToolStripMenuItem.Size = new System.Drawing.Size(204, 32);
            this.thursdayToolStripMenuItem.Text = "Thursday";
            this.thursdayToolStripMenuItem.Click += new System.EventHandler(this.thursdayToolStripMenuItem_Click);
            // 
            // fridayToolStripMenuItem
            // 
            this.fridayToolStripMenuItem.Name = "fridayToolStripMenuItem";
            this.fridayToolStripMenuItem.Size = new System.Drawing.Size(204, 32);
            this.fridayToolStripMenuItem.Text = "Friday";
            this.fridayToolStripMenuItem.Click += new System.EventHandler(this.fridayToolStripMenuItem_Click);
            // 
            // weekendToolStripMenuItem
            // 
            this.weekendToolStripMenuItem.Name = "weekendToolStripMenuItem";
            this.weekendToolStripMenuItem.Size = new System.Drawing.Size(204, 32);
            this.weekendToolStripMenuItem.Text = "Weekend";
            this.weekendToolStripMenuItem.Click += new System.EventHandler(this.weekendToolStripMenuItem_Click);
            // 
            // monthlyMealPlansToolStripMenuItem
            // 
            this.monthlyMealPlansToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.studentsSubscriptionToolStripMenuItem,
            this.workersSubscriptionToolStripMenuItem});
            this.monthlyMealPlansToolStripMenuItem.Font = new System.Drawing.Font("Elephant", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthlyMealPlansToolStripMenuItem.Image = global::TechTopiaM2.Properties.Resources.mealplan;
            this.monthlyMealPlansToolStripMenuItem.Name = "monthlyMealPlansToolStripMenuItem";
            this.monthlyMealPlansToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 0, 4, 50);
            this.monthlyMealPlansToolStripMenuItem.Size = new System.Drawing.Size(224, 79);
            this.monthlyMealPlansToolStripMenuItem.Text = "Monthly Meal Plans";
            // 
            // studentsSubscriptionToolStripMenuItem
            // 
            this.studentsSubscriptionToolStripMenuItem.Name = "studentsSubscriptionToolStripMenuItem";
            this.studentsSubscriptionToolStripMenuItem.Size = new System.Drawing.Size(299, 30);
            this.studentsSubscriptionToolStripMenuItem.Text = "Student\'s Subscription";
            this.studentsSubscriptionToolStripMenuItem.Click += new System.EventHandler(this.studentsSubscriptionToolStripMenuItem_Click);
            // 
            // workersSubscriptionToolStripMenuItem
            // 
            this.workersSubscriptionToolStripMenuItem.Name = "workersSubscriptionToolStripMenuItem";
            this.workersSubscriptionToolStripMenuItem.Size = new System.Drawing.Size(299, 30);
            this.workersSubscriptionToolStripMenuItem.Text = "Worker\'s Subscription";
            this.workersSubscriptionToolStripMenuItem.Click += new System.EventHandler(this.workersSubscriptionToolStripMenuItem_Click);
            // 
            // businessReportsToolStripMenuItem
            // 
            this.businessReportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salesSummaryToolStripMenuItem});
            this.businessReportsToolStripMenuItem.Font = new System.Drawing.Font("Elephant", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.businessReportsToolStripMenuItem.Image = global::TechTopiaM2.Properties.Resources.report;
            this.businessReportsToolStripMenuItem.Name = "businessReportsToolStripMenuItem";
            this.businessReportsToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 0, 4, 50);
            this.businessReportsToolStripMenuItem.Size = new System.Drawing.Size(224, 81);
            this.businessReportsToolStripMenuItem.Text = "Business Report";
            // 
            // salesSummaryToolStripMenuItem
            // 
            this.salesSummaryToolStripMenuItem.Name = "salesSummaryToolStripMenuItem";
            this.salesSummaryToolStripMenuItem.Size = new System.Drawing.Size(218, 32);
            this.salesSummaryToolStripMenuItem.Text = "Sales Report";
            this.salesSummaryToolStripMenuItem.Click += new System.EventHandler(this.salesSummaryToolStripMenuItem_Click);
            // 
            // managementToolStripMenuItem
            // 
            this.managementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.studentSubscriptionToolStripMenuItem,
            this.inventoryToolStripMenuItem,
            this.credentialsManagementToolStripMenuItem,
            this.staffManagementToolStripMenuItem});
            this.managementToolStripMenuItem.Font = new System.Drawing.Font("Elephant", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.managementToolStripMenuItem.Image = global::TechTopiaM2.Properties.Resources.profile1;
            this.managementToolStripMenuItem.Name = "managementToolStripMenuItem";
            this.managementToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 0, 4, 50);
            this.managementToolStripMenuItem.Size = new System.Drawing.Size(224, 81);
            this.managementToolStripMenuItem.Text = "Management";
            this.managementToolStripMenuItem.Click += new System.EventHandler(this.managementToolStripMenuItem_Click);
            // 
            // studentSubscriptionToolStripMenuItem
            // 
            this.studentSubscriptionToolStripMenuItem.Name = "studentSubscriptionToolStripMenuItem";
            this.studentSubscriptionToolStripMenuItem.Size = new System.Drawing.Size(360, 32);
            this.studentSubscriptionToolStripMenuItem.Text = "Subscription Management";
            this.studentSubscriptionToolStripMenuItem.Click += new System.EventHandler(this.studentSubscriptionToolStripMenuItem_Click);
            // 
            // inventoryToolStripMenuItem
            // 
            this.inventoryToolStripMenuItem.Name = "inventoryToolStripMenuItem";
            this.inventoryToolStripMenuItem.Size = new System.Drawing.Size(360, 32);
            this.inventoryToolStripMenuItem.Text = "Inventory Manangement";
            this.inventoryToolStripMenuItem.Click += new System.EventHandler(this.inventoryToolStripMenuItem_Click);
            // 
            // credentialsManagementToolStripMenuItem
            // 
            this.credentialsManagementToolStripMenuItem.Name = "credentialsManagementToolStripMenuItem";
            this.credentialsManagementToolStripMenuItem.Size = new System.Drawing.Size(360, 32);
            this.credentialsManagementToolStripMenuItem.Text = "Credentials Management";
            this.credentialsManagementToolStripMenuItem.Click += new System.EventHandler(this.credentialsManagementToolStripMenuItem_Click);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Font = new System.Drawing.Font("Elephant", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logOutToolStripMenuItem.Image = global::TechTopiaM2.Properties.Resources.logout;
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 0, 4, 50);
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(224, 81);
            this.logOutToolStripMenuItem.Text = "Log Out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // displayPanel
            // 
            this.displayPanel.BackgroundImage = global::TechTopiaM2.Properties.Resources.Picture1;
            this.displayPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.displayPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.displayPanel.Location = new System.Drawing.Point(237, 0);
            this.displayPanel.Name = "displayPanel";
            this.displayPanel.Size = new System.Drawing.Size(827, 661);
            this.displayPanel.TabIndex = 1;
            // 
            // mealsDataset
            // 
            this.mealsDataset.DataSetName = "mealsDataset";
            this.mealsDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mealsTableAdapter
            // 
            this.mealsTableAdapter.ClearBeforeFill = true;
            // 
            // productsTableAdapter
            // 
            this.productsTableAdapter.ClearBeforeFill = true;
            // 
            // dailyOrderTableAdapter
            // 
            this.dailyOrderTableAdapter.ClearBeforeFill = true;
            // 
            // daily_Order_ItemsTableAdapter
            // 
            this.daily_Order_ItemsTableAdapter.ClearBeforeFill = true;
            // 
            // subscribedStudentTableAdapter
            // 
            this.subscribedStudentTableAdapter.ClearBeforeFill = true;
            // 
            // subscribedWorkersTableAdapter
            // 
            this.subscribedWorkersTableAdapter.ClearBeforeFill = true;
            // 
            // subscriptionDataset
            // 
            this.subscriptionDataset.DataSetName = "dsTables";
            this.subscriptionDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // staffManagementToolStripMenuItem
            // 
            this.staffManagementToolStripMenuItem.Name = "staffManagementToolStripMenuItem";
            this.staffManagementToolStripMenuItem.Size = new System.Drawing.Size(360, 32);
            this.staffManagementToolStripMenuItem.Text = "Staff Management";
            this.staffManagementToolStripMenuItem.Click += new System.EventHandler(this.staffManagementToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 661);
            this.Controls.Add(this.displayPanel);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.ShowIcon = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mealsDataset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subscriptionDataset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dailyMenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monthlyMealPlansToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem businessReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem managementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mondayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tuesdayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wednesdayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thursdayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fridayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem weekendToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentsSubscriptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem workersSubscriptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesSummaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.Panel displayPanel;
        private dsTables mealsDataset;
        private dsTablesTableAdapters.MealsTableAdapter mealsTableAdapter;
        private dsTablesTableAdapters.ProductsTableAdapter productsTableAdapter;
        private dsTablesTableAdapters.DailyOrderTableAdapter dailyOrderTableAdapter;
        private dsTablesTableAdapters.Daily_Order_ItemsTableAdapter daily_Order_ItemsTableAdapter;
        private dsTablesTableAdapters.SubscribedStudentTableAdapter subscribedStudentTableAdapter;
        private dsTablesTableAdapters.SubscribedWorkersTableAdapter subscribedWorkersTableAdapter;
        private dsTables subscriptionDataset;
        private System.Windows.Forms.ToolStripMenuItem studentSubscriptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem credentialsManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem staffManagementToolStripMenuItem;
    }
}

