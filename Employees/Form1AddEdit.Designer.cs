namespace Employees
{
    partial class Form1AddEdit
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
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.FirstName = new System.Windows.Forms.TextBox();
            this.labelFirstName = new System.Windows.Forms.Label();
            this.LastName = new System.Windows.Forms.TextBox();
            this.labelLastName = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            this.Id = new System.Windows.Forms.TextBox();
            this.fixedPriceButton = new System.Windows.Forms.RadioButton();
            this.bytimeButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelSalary = new System.Windows.Forms.Label();
            this.Salary = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(128, 265);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(227, 264);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FirstName
            // 
            this.FirstName.Location = new System.Drawing.Point(109, 118);
            this.FirstName.Name = "FirstName";
            this.FirstName.Size = new System.Drawing.Size(244, 22);
            this.FirstName.TabIndex = 2;
            // 
            // labelFirstName
            // 
            this.labelFirstName.AutoSize = true;
            this.labelFirstName.Location = new System.Drawing.Point(29, 121);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Size = new System.Drawing.Size(74, 17);
            this.labelFirstName.TabIndex = 3;
            this.labelFirstName.Text = "First name";
            // 
            // LastName
            // 
            this.LastName.Location = new System.Drawing.Point(109, 146);
            this.LastName.Name = "LastName";
            this.LastName.Size = new System.Drawing.Size(244, 22);
            this.LastName.TabIndex = 2;
            // 
            // labelLastName
            // 
            this.labelLastName.AutoSize = true;
            this.labelLastName.Location = new System.Drawing.Point(29, 149);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(74, 17);
            this.labelLastName.TabIndex = 3;
            this.labelLastName.Text = "Last name";
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(29, 178);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(85, 17);
            this.labelId.TabIndex = 3;
            this.labelId.Text = "Employee Id";
            // 
            // Id
            // 
            this.Id.Location = new System.Drawing.Point(120, 173);
            this.Id.Name = "Id";
            this.Id.Size = new System.Drawing.Size(134, 22);
            this.Id.TabIndex = 2;
            // 
            // fixedPriceButton
            // 
            this.fixedPriceButton.AutoSize = true;
            this.fixedPriceButton.Location = new System.Drawing.Point(6, 12);
            this.fixedPriceButton.Name = "fixedPriceButton";
            this.fixedPriceButton.Size = new System.Drawing.Size(92, 21);
            this.fixedPriceButton.TabIndex = 4;
            this.fixedPriceButton.TabStop = true;
            this.fixedPriceButton.Text = "Fixed sum";
            this.fixedPriceButton.UseVisualStyleBackColor = true;
            this.fixedPriceButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // bytimeButton
            // 
            this.bytimeButton.AutoSize = true;
            this.bytimeButton.Location = new System.Drawing.Point(6, 48);
            this.bytimeButton.Name = "bytimeButton";
            this.bytimeButton.Size = new System.Drawing.Size(75, 21);
            this.bytimeButton.TabIndex = 5;
            this.bytimeButton.TabStop = true;
            this.bytimeButton.Text = "By time";
            this.bytimeButton.UseVisualStyleBackColor = true;
            this.bytimeButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bytimeButton);
            this.groupBox1.Controls.Add(this.fixedPriceButton);
            this.groupBox1.Location = new System.Drawing.Point(32, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 75);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // labelSalary
            // 
            this.labelSalary.AutoSize = true;
            this.labelSalary.Location = new System.Drawing.Point(29, 213);
            this.labelSalary.Name = "labelSalary";
            this.labelSalary.Size = new System.Drawing.Size(48, 17);
            this.labelSalary.TabIndex = 3;
            this.labelSalary.Text = "Salary";
            // 
            // Salary
            // 
            this.Salary.Location = new System.Drawing.Point(120, 213);
            this.Salary.Name = "Salary";
            this.Salary.Size = new System.Drawing.Size(134, 22);
            this.Salary.TabIndex = 2;
            // 
            // Form1AddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 316);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelSalary);
            this.Controls.Add(this.labelId);
            this.Controls.Add(this.labelLastName);
            this.Controls.Add(this.labelFirstName);
            this.Controls.Add(this.Salary);
            this.Controls.Add(this.Id);
            this.Controls.Add(this.LastName);
            this.Controls.Add(this.FirstName);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Name = "Form1AddEdit";
            this.Text = "Form1AddEdit";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox FirstName;
        private System.Windows.Forms.Label labelFirstName;
        private System.Windows.Forms.TextBox LastName;
        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.TextBox Id;
        private System.Windows.Forms.RadioButton fixedPriceButton;
        private System.Windows.Forms.RadioButton bytimeButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelSalary;
        private System.Windows.Forms.TextBox Salary;
    }
}