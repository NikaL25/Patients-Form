namespace DisplayDBTable
{
    partial class AddPatients
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
            panel2 = new Panel();
            emailFieldValue = new TextBox();
            emailField = new Label();
            idField = new TextBox();
            ID = new Label();
            femaleBtn = new RadioButton();
            addressField = new TextBox();
            label8 = new Label();
            maleBtn = new RadioButton();
            phoneField = new TextBox();
            label7 = new Label();
            label6 = new Label();
            dateOfBirthField = new TextBox();
            label5 = new Label();
            fullNameField = new TextBox();
            label4 = new Label();
            addBtn = new Button();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(emailFieldValue);
            panel2.Controls.Add(emailField);
            panel2.Controls.Add(idField);
            panel2.Controls.Add(ID);
            panel2.Controls.Add(femaleBtn);
            panel2.Controls.Add(addressField);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(maleBtn);
            panel2.Controls.Add(phoneField);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(dateOfBirthField);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(fullNameField);
            panel2.Controls.Add(label4);
            panel2.Location = new Point(2, 44);
            panel2.Name = "panel2";
            panel2.Size = new Size(1017, 50);
            panel2.TabIndex = 3;
            // 
            // emailFieldValue
            // 
            emailFieldValue.Location = new Point(661, 25);
            emailFieldValue.Name = "emailFieldValue";
            emailFieldValue.Size = new Size(104, 23);
            emailFieldValue.TabIndex = 15;
            // 
            // emailField
            // 
            emailField.AutoSize = true;
            emailField.Location = new Point(698, 9);
            emailField.Name = "emailField";
            emailField.Size = new Size(36, 15);
            emailField.TabIndex = 14;
            emailField.Text = "Email";
            // 
            // idField
            // 
            idField.Location = new Point(523, 25);
            idField.Name = "idField";
            idField.Size = new Size(104, 23);
            idField.TabIndex = 13;
            // 
            // ID
            // 
            ID.AutoSize = true;
            ID.Location = new Point(564, 9);
            ID.Name = "ID";
            ID.Size = new Size(18, 15);
            ID.TabIndex = 12;
            ID.Text = "ID";
            // 
            // femaleBtn
            // 
            femaleBtn.AutoSize = true;
            femaleBtn.Location = new Point(953, 24);
            femaleBtn.Name = "femaleBtn";
            femaleBtn.Size = new Size(63, 19);
            femaleBtn.TabIndex = 11;
            femaleBtn.TabStop = true;
            femaleBtn.Text = "Female";
            femaleBtn.UseVisualStyleBackColor = true;
            femaleBtn.CheckedChanged += femaleBtn_CheckedChanged;
            // 
            // addressField
            // 
            addressField.Location = new Point(398, 26);
            addressField.Name = "addressField";
            addressField.Size = new Size(104, 23);
            addressField.TabIndex = 9;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(424, 9);
            label8.Name = "label8";
            label8.Size = new Size(49, 15);
            label8.TabIndex = 8;
            label8.Text = "Address";
            // 
            // maleBtn
            // 
            maleBtn.AutoSize = true;
            maleBtn.Location = new Point(812, 25);
            maleBtn.Name = "maleBtn";
            maleBtn.Size = new Size(51, 19);
            maleBtn.TabIndex = 10;
            maleBtn.TabStop = true;
            maleBtn.Text = "Male";
            maleBtn.UseVisualStyleBackColor = true;
            maleBtn.CheckedChanged += maleBtn_CheckedChanged;
            // 
            // phoneField
            // 
            phoneField.Location = new Point(264, 26);
            phoneField.Name = "phoneField";
            phoneField.Size = new Size(104, 23);
            phoneField.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(290, 9);
            label7.Name = "label7";
            label7.Size = new Size(41, 15);
            label7.TabIndex = 6;
            label7.Text = "Phone";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(884, 6);
            label6.Name = "label6";
            label6.Size = new Size(45, 15);
            label6.TabIndex = 4;
            label6.Text = "Gender";
            // 
            // dateOfBirthField
            // 
            dateOfBirthField.Location = new Point(132, 27);
            dateOfBirthField.Name = "dateOfBirthField";
            dateOfBirthField.Size = new Size(104, 23);
            dateOfBirthField.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(167, 9);
            label5.Name = "label5";
            label5.Size = new Size(29, 15);
            label5.TabIndex = 2;
            label5.Text = "Dob";
            // 
            // fullNameField
            // 
            fullNameField.Location = new Point(3, 27);
            fullNameField.Name = "fullNameField";
            fullNameField.Size = new Size(104, 23);
            fullNameField.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 9);
            label4.Name = "label4";
            label4.Size = new Size(61, 15);
            label4.TabIndex = 0;
            label4.Text = "Full Name";
            // 
            // addBtn
            // 
            addBtn.BackColor = Color.Green;
            addBtn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            addBtn.ForeColor = Color.White;
            addBtn.Location = new Point(482, 141);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(95, 37);
            addBtn.TabIndex = 4;
            addBtn.Text = "Add";
            addBtn.UseVisualStyleBackColor = false;
            addBtn.Click += addBtn_Click;
            // 
            // AddPatients
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1097, 450);
            Controls.Add(addBtn);
            Controls.Add(panel2);
            Name = "AddPatients";
            Text = "AddPatients";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private TextBox addressField;
        private Label label8;
        private TextBox phoneField;
        private Label label7;
        private Label label6;
        private TextBox dateOfBirthField;
        private Label label5;
        private TextBox fullNameField;
        private Label label4;
        private Button addBtn;
        private RadioButton femaleBtn;
        private RadioButton maleBtn;
        private TextBox emailFieldValue;
        private Label emailField;
        private TextBox idField;
        private Label ID;
    }
}