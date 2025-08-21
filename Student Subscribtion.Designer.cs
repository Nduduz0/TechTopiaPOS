
namespace TechTopiaM2
{
    partial class Student_Subscribtion
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
            this.dgvStuSub = new System.Windows.Forms.DataGridView();
            this.txtStuSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStuUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStuSub)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStuSub
            // 
            this.dgvStuSub.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStuSub.Location = new System.Drawing.Point(14, 127);
            this.dgvStuSub.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvStuSub.Name = "dgvStuSub";
            this.dgvStuSub.Size = new System.Drawing.Size(876, 390);
            this.dgvStuSub.TabIndex = 0;
            // 
            // txtStuSearch
            // 
            this.txtStuSearch.Location = new System.Drawing.Point(14, 97);
            this.txtStuSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtStuSearch.Name = "txtStuSearch";
            this.txtStuSearch.Size = new System.Drawing.Size(378, 22);
            this.txtStuSearch.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search by Name:";
            // 
            // btnStuUpdate
            // 
            this.btnStuUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnStuUpdate.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStuUpdate.ForeColor = System.Drawing.Color.White;
            this.btnStuUpdate.Location = new System.Drawing.Point(710, 577);
            this.btnStuUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnStuUpdate.Name = "btnStuUpdate";
            this.btnStuUpdate.Size = new System.Drawing.Size(180, 42);
            this.btnStuUpdate.TabIndex = 3;
            this.btnStuUpdate.Text = "UPDATE";
            this.btnStuUpdate.UseVisualStyleBackColor = false;
            this.btnStuUpdate.Click += new System.EventHandler(this.btnStuUpdate_Click);
            // 
            // Student_Subscribtion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TechTopiaM2.Properties.Resources.Picture1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1171, 713);
            this.Controls.Add(this.btnStuUpdate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtStuSearch);
            this.Controls.Add(this.dgvStuSub);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Student_Subscribtion";
            this.ShowIcon = false;
            this.Text = "Student_Subscribtion";
            ((System.ComponentModel.ISupportInitialize)(this.dgvStuSub)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStuSub;
        private System.Windows.Forms.TextBox txtStuSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStuUpdate;
    }
}