using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                int red = int.Parse(textBoxRed.Text);
                int green = int.Parse(textBoxGreen.Text);
                int blue = int.Parse(textBoxBlue.Text);

               
                if (red < 0 || red > 255 || green < 0 || green > 255 || blue < 0 || blue > 255)
                {
                    MessageBox.Show("Please enter 0 - 255");
                    return;
                }

                this.BackColor = Color.FromArgb(red, green, blue);
            }
            catch (FormatException)
            {
                MessageBox.Show("Error!");
            }
        }
    }

}

