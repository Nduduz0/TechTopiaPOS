
namespace TechTopiaM2
{
    partial class Change_Password
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblhide = new System.Windows.Forms.Label();
            this.lblshow = new System.Windows.Forms.Label();
            this.btnClearPsswrd = new System.Windows.Forms.Button();
            this.btnChangePsswrd = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.confirmpsswrd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.newpsswrld = new System.Windows.Forms.TextBox();
            this.oldpsswrd = new System.Windows.Forms.TextBox();
            this.usertext = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.employeeid = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClearCntct = new System.Windows.Forms.Button();
            this.email = new System.Windows.Forms.TextBox();
            this.contactno = new System.Windows.Forms.TextBox();
            this.taEmployee = new TechTopiaM2.dsTablesTableAdapters.EmployeeTableAdapter();
            this.dsTables1 = new TechTopiaM2.dsTables();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsTables1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.lblhide);
            this.groupBox1.Controls.Add(this.lblshow);
            this.groupBox1.Controls.Add(this.btnClearPsswrd);
            this.groupBox1.Controls.Add(this.btnChangePsswrd);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.confirmpsswrd);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.newpsswrld);
            this.groupBox1.Controls.Add(this.oldpsswrd);
            this.groupBox1.Controls.Add(this.usertext);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(72, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(638, 293);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Change Password...";
            // 
            // lblhide
            // 
            this.lblhide.AutoSize = true;
            this.lblhide.Location = new System.Drawing.Point(378, 215);
            this.lblhide.Name = "lblhide";
            this.lblhide.Size = new System.Drawing.Size(85, 16);
            this.lblhide.TabIndex = 18;
            this.lblhide.Text = "hide password";
            this.lblhide.Click += new System.EventHandler(this.lblhide_Click);
            // 
            // lblshow
            // 
            this.lblshow.AutoSize = true;
            this.lblshow.Location = new System.Drawing.Point(283, 215);
            this.lblshow.Name = "lblshow";
            this.lblshow.Size = new System.Drawing.Size(90, 16);
            this.lblshow.TabIndex = 17;
            this.lblshow.Text = "show password";
            this.lblshow.Click += new System.EventHandler(this.lblshow_Click);
            // 
            // btnClearPsswrd
            // 
            this.btnClearPsswrd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnClearPsswrd.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearPsswrd.ForeColor = System.Drawing.Color.White;
            this.btnClearPsswrd.Location = new System.Drawing.Point(554, 253);
            this.btnClearPsswrd.Name = "btnClearPsswrd";
            this.btnClearPsswrd.Size = new System.Drawing.Size(68, 34);
            this.btnClearPsswrd.TabIndex = 16;
            this.btnClearPsswrd.Text = "CLEAR";
            this.btnClearPsswrd.UseVisualStyleBackColor = false;
            this.btnClearPsswrd.Click += new System.EventHandler(this.btnClearPsswrd_Click);
            // 
            // btnChangePsswrd
            // 
            this.btnChangePsswrd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnChangePsswrd.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePsswrd.ForeColor = System.Drawing.Color.White;
            this.btnChangePsswrd.Location = new System.Drawing.Point(381, 253);
            this.btnChangePsswrd.Name = "btnChangePsswrd";
            this.btnChangePsswrd.Size = new System.Drawing.Size(158, 34);
            this.btnChangePsswrd.TabIndex = 15;
            this.btnChangePsswrd.Text = "CHANGE PASSWORD";
            this.btnChangePsswrd.UseVisualStyleBackColor = false;
            this.btnChangePsswrd.Click += new System.EventHandler(this.btnChangePsswrd_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(25, 236);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(170, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "NB: Create Strong Password...";
            // 
            // confirmpsswrd
            // 
            this.confirmpsswrd.Location = new System.Drawing.Point(25, 209);
            this.confirmpsswrd.Name = "confirmpsswrd";
            this.confirmpsswrd.Size = new System.Drawing.Size(235, 22);
            this.confirmpsswrd.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Confirm New Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "New Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Old Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Username";
            // 
            // newpsswrld
            // 
            this.newpsswrld.Location = new System.Drawing.Point(22, 153);
            this.newpsswrld.Name = "newpsswrld";
            this.newpsswrld.Size = new System.Drawing.Size(238, 22);
            this.newpsswrld.TabIndex = 2;
            // 
            // oldpsswrd
            // 
            this.oldpsswrd.Location = new System.Drawing.Point(22, 101);
            this.oldpsswrd.Name = "oldpsswrd";
            this.oldpsswrd.Size = new System.Drawing.Size(238, 22);
            this.oldpsswrd.TabIndex = 1;
            // 
            // usertext
            // 
            this.usertext.Location = new System.Drawing.Point(22, 44);
            this.usertext.Name = "usertext";
            this.usertext.Size = new System.Drawing.Size(238, 22);
            this.usertext.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.employeeid);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btnClearCntct);
            this.groupBox2.Controls.Add(this.email);
            this.groupBox2.Controls.Add(this.contactno);
            this.groupBox2.Location = new System.Drawing.Point(72, 379);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(638, 162);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Change Contact Info";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 16);
            this.label8.TabIndex = 12;
            this.label8.Text = "EmployeeID";
            // 
            // employeeid
            // 
            this.employeeid.Location = new System.Drawing.Point(109, 42);
            this.employeeid.Name = "employeeid";
            this.employeeid.Size = new System.Drawing.Size(171, 22);
            this.employeeid.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Email Address";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Contact Number";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnSave.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(471, 122);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(68, 34);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClearCntct
            // 
            this.btnClearCntct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnClearCntct.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearCntct.ForeColor = System.Drawing.Color.White;
            this.btnClearCntct.Location = new System.Drawing.Point(554, 122);
            this.btnClearCntct.Name = "btnClearCntct";
            this.btnClearCntct.Size = new System.Drawing.Size(68, 34);
            this.btnClearCntct.TabIndex = 2;
            this.btnClearCntct.Text = "CLEAR";
            this.btnClearCntct.UseVisualStyleBackColor = false;
            this.btnClearCntct.Click += new System.EventHandler(this.btnClearCntct_Click);
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(109, 79);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(171, 22);
            this.email.TabIndex = 4;
            // 
            // contactno
            // 
            this.contactno.Location = new System.Drawing.Point(109, 117);
            this.contactno.MaxLength = 10;
            this.contactno.Name = "contactno";
            this.contactno.Size = new System.Drawing.Size(171, 22);
            this.contactno.TabIndex = 3;
            // 
            // taEmployee
            // 
            this.taEmployee.ClearBeforeFill = true;
            // 
            // dsTables1
            // 
            this.dsTables1.DataSetName = "dsTables";
            this.dsTables1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Change_Password
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TechTopiaM2.Properties.Resources.Picture1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1013, 629);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Change_Password";
            this.ShowIcon = false;
            this.Text = "Change Password";
            this.Load += new System.EventHandler(this.Change_Password_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsTables1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblhide;
        private System.Windows.Forms.Label lblshow;
        private System.Windows.Forms.Button btnClearPsswrd;
        private System.Windows.Forms.Button btnChangePsswrd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox confirmpsswrd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox newpsswrld;
        private System.Windows.Forms.TextBox oldpsswrd;
        private System.Windows.Forms.TextBox usertext;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox employeeid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClearCntct;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.TextBox contactno;
        private dsTablesTableAdapters.EmployeeTableAdapter taEmployee;
        private dsTables dsTables1;
    }
}