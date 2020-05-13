namespace Employees
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonToFile = new System.Windows.Forms.Button();
            this.buttonFromFile = new System.Windows.Forms.Button();
            this.idText = new System.Windows.Forms.TextBox();
            this.labelCurrent = new System.Windows.Forms.Label();
            this.checkBoxFirst5 = new System.Windows.Forms.CheckBox();
            this.checkBoxLast3 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(43, 55);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(646, 221);
            this.dataGridView1.TabIndex = 0;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(42, 356);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(119, 34);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(167, 356);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(119, 34);
            this.buttonEdit.TabIndex = 1;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(292, 356);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(119, 34);
            this.buttonDelete.TabIndex = 1;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonToFile
            // 
            this.buttonToFile.Location = new System.Drawing.Point(415, 356);
            this.buttonToFile.Name = "buttonToFile";
            this.buttonToFile.Size = new System.Drawing.Size(119, 34);
            this.buttonToFile.TabIndex = 1;
            this.buttonToFile.Text = "Export to a file";
            this.buttonToFile.UseVisualStyleBackColor = true;
            this.buttonToFile.Click += new System.EventHandler(this.buttonToFile_Click);
            // 
            // buttonFromFile
            // 
            this.buttonFromFile.Location = new System.Drawing.Point(540, 356);
            this.buttonFromFile.Name = "buttonFromFile";
            this.buttonFromFile.Size = new System.Drawing.Size(149, 34);
            this.buttonFromFile.TabIndex = 1;
            this.buttonFromFile.Text = "Import from a file";
            this.buttonFromFile.UseVisualStyleBackColor = true;
            this.buttonFromFile.Click += new System.EventHandler(this.buttonFromFile_Click);
            // 
            // idText
            // 
            this.idText.Location = new System.Drawing.Point(135, 298);
            this.idText.Name = "idText";
            this.idText.ReadOnly = true;
            this.idText.Size = new System.Drawing.Size(244, 22);
            this.idText.TabIndex = 2;
            // 
            // labelCurrent
            // 
            this.labelCurrent.AutoSize = true;
            this.labelCurrent.Location = new System.Drawing.Point(44, 302);
            this.labelCurrent.Name = "labelCurrent";
            this.labelCurrent.Size = new System.Drawing.Size(76, 17);
            this.labelCurrent.TabIndex = 3;
            this.labelCurrent.Text = "Current ID:";
            // 
            // checkBoxFirst5
            // 
            this.checkBoxFirst5.AutoSize = true;
            this.checkBoxFirst5.Location = new System.Drawing.Point(42, 13);
            this.checkBoxFirst5.Name = "checkBoxFirst5";
            this.checkBoxFirst5.Size = new System.Drawing.Size(119, 21);
            this.checkBoxFirst5.TabIndex = 4;
            this.checkBoxFirst5.Text = "First 5  names";
            this.checkBoxFirst5.UseVisualStyleBackColor = true;
            this.checkBoxFirst5.CheckedChanged += new System.EventHandler(this.DataGridFilterChanged);
            // 
            // checkBoxLast3
            // 
            this.checkBoxLast3.AutoSize = true;
            this.checkBoxLast3.Location = new System.Drawing.Point(167, 13);
            this.checkBoxLast3.Name = "checkBoxLast3";
            this.checkBoxLast3.Size = new System.Drawing.Size(91, 21);
            this.checkBoxLast3.TabIndex = 5;
            this.checkBoxLast3.Text = "Last 3 ids";
            this.checkBoxLast3.UseVisualStyleBackColor = true;
            this.checkBoxLast3.CheckedChanged += new System.EventHandler(this.DataGridFilterChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 450);
            this.Controls.Add(this.checkBoxLast3);
            this.Controls.Add(this.checkBoxFirst5);
            this.Controls.Add(this.labelCurrent);
            this.Controls.Add(this.idText);
            this.Controls.Add(this.buttonFromFile);
            this.Controls.Add(this.buttonToFile);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonToFile;
        private System.Windows.Forms.Button buttonFromFile;
        private System.Windows.Forms.TextBox idText;
        private System.Windows.Forms.Label labelCurrent;
        private System.Windows.Forms.CheckBox checkBoxFirst5;
        private System.Windows.Forms.CheckBox checkBoxLast3;
    }
}

