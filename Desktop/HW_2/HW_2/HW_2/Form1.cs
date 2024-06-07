namespace HW_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void passwordBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (emailBox.Text != "" && passwordBox.Text != "")
            {
                MessageBox.Show("Ok!");
            }
            else
            {
                MessageBox.Show("Error!");
            }
        }
    }
}
