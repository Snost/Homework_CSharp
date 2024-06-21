using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WFP_004
{
    
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }

            private void ShowEmployees_Click(object sender, RoutedEventArgs e)
            {
                EmployeesWindow employeesWindow = new EmployeesWindow();
                employeesWindow.Show();
            }

            private void ShowAnimals_Click(object sender, RoutedEventArgs e)
            {
                AnimalsWindow animalsWindow = new AnimalsWindow();
                animalsWindow.Show();
            }

            private void ShowPhones_Click(object sender, RoutedEventArgs e)
            {
                PhonesWindow phonesWindow = new PhonesWindow();
                phonesWindow.Show();
            }
        }
    }

