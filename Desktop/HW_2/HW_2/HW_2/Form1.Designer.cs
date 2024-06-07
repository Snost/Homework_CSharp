namespace HW_2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            button1 = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            emailBox = new TextBox();
            passwordBox = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.SlateBlue;
            label1.Location = new Point(300, 32);
            label1.Name = "label1";
            label1.Size = new Size(238, 50);
            label1.TabIndex = 0;
            label1.Text = "Resgister";
            // 
            // button1
            // 
            button1.BackColor = Color.SlateBlue;
            button1.Font = new Font("Showcard Gothic", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Snow;
            button1.Location = new Point(279, 326);
            button1.Name = "button1";
            button1.Size = new Size(274, 70);
            button1.TabIndex = 1;
            button1.Text = "comfirm";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(130, 104);
            label2.Name = "label2";
            label2.Size = new Size(93, 41);
            label2.TabIndex = 2;
            label2.Text = "Email";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.Location = new Point(76, 169);
            label3.Name = "label3";
            label3.Size = new Size(147, 41);
            label3.TabIndex = 3;
            label3.Text = "Password";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.Location = new Point(30, 235);
            label4.Name = "label4";
            label4.Size = new Size(193, 41);
            label4.TabIndex = 4;
            label4.Text = "Date of Birth";
            // 
            // emailBox
            // 
            emailBox.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            emailBox.ForeColor = SystemColors.ActiveCaptionText;
            emailBox.Location = new Point(240, 104);
            emailBox.Name = "emailBox";
            emailBox.PlaceholderText = "Enter your email here...";
            emailBox.Size = new Size(347, 47);
            emailBox.TabIndex = 5;
            emailBox.Tag = "";
            // 
            // passwordBox
            // 
            passwordBox.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            passwordBox.Location = new Point(240, 169);
            passwordBox.Name = "passwordBox";
            passwordBox.PasswordChar = '*';
            passwordBox.Size = new Size(347, 47);
            passwordBox.TabIndex = 6;
            passwordBox.TextChanged += passwordBox_TextChanged;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dateTimePicker1.Location = new Point(240, 230);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(347, 47);
            dateTimePicker1.TabIndex = 8;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 255);
            ClientSize = new Size(800, 450);
            Controls.Add(dateTimePicker1);
            Controls.Add(passwordBox);
            Controls.Add(emailBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox emailBox;
        private TextBox passwordBox;
        private DateTimePicker dateTimePicker1;
    }
}
