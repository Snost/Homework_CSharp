using System;
using System.Windows;
using System.Data;
using System.Windows.Controls;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        private string input = string.Empty;
        private string equation = string.Empty;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            string butTxt = button.Content.ToString();

            if (butTxt == "C")
            {
                input = string.Empty;
                equation = string.Empty;
                txtDisplay.Text = string.Empty;
                txtEquation.Text = string.Empty;
            }
            else if (butTxt == "CE")
            {
                if (!string.IsNullOrEmpty(input))
                {
                    input = string.Empty;
                    txtDisplay.Text = string.Empty;
                }
            }
            else if (butTxt == "<")
            {
                if (input.Length > 0)
                {
                    input = input.Substring(0, input.Length - 1);
                    txtDisplay.Text = input;
                }
            }
            else if (butTxt == "=")
            {
                try
                {
                    equation += input;
                    txtEquation.Text = equation;
                    var result = new DataTable().Compute(equation, null);
                    txtDisplay.Text = result.ToString();
                    input = result.ToString();
                    equation = string.Empty;
                }
                catch (Exception)
                {
                    txtDisplay.Text = "Error";
                }
            }
            else
            {
                if ("+-*/".Contains(butTxt) && !string.IsNullOrEmpty(input))
                {
                    equation += input + " " + butTxt + " ";
                    txtEquation.Text = equation;
                    input = string.Empty;
                }
                else
                {
                    input += butTxt;
                    txtDisplay.Text = input;
                }
            }
        }
    }
}
