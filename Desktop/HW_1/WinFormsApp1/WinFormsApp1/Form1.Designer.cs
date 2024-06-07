namespace WinFormsApp1
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
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            textBoxRed = new TextBox();
            textBoxGreen = new TextBox();
            textBoxBlue = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(12, 43);
            label1.Name = "label1";
            label1.Size = new Size(84, 46);
            label1.TabIndex = 0;
            label1.Text = "Red:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(12, 101);
            label3.Name = "label3";
            label3.Size = new Size(117, 46);
            label3.TabIndex = 2;
            label3.Text = "Green:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(12, 156);
            label4.Name = "label4";
            label4.Size = new Size(91, 46);
            label4.TabIndex = 3;
            label4.Text = "Blue:";
            label4.Click += label4_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.Location = new Point(578, 43);
            button1.Name = "button1";
            button1.Size = new Size(154, 46);
            button1.TabIndex = 4;
            button1.Text = "Change color";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBoxRed
            // 
            textBoxRed.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxRed.Location = new Point(135, 49);
            textBoxRed.Name = "textBoxRed";
            textBoxRed.Size = new Size(82, 34);
            textBoxRed.TabIndex = 5;
            // 
            // textBoxGreen
            // 
            textBoxGreen.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxGreen.Location = new Point(135, 111);
            textBoxGreen.Name = "textBoxGreen";
            textBoxGreen.Size = new Size(82, 34);
            textBoxGreen.TabIndex = 6;
            // 
            // textBoxBlue
            // 
            textBoxBlue.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxBlue.Location = new Point(135, 166);
            textBoxBlue.Name = "textBoxBlue";
            textBoxBlue.Size = new Size(82, 34);
            textBoxBlue.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkOrchid;
            ClientSize = new Size(800, 450);
            Controls.Add(textBoxBlue);
            Controls.Add(textBoxGreen);
            Controls.Add(textBoxRed);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label3;
        private Label label4;
        private Button button1;
        private TextBox textBoxRed;
        private TextBox textBoxGreen;
        private TextBox textBoxBlue;
    }
}
