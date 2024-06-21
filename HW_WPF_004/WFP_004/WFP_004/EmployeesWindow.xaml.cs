using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.Generic;


namespace WFP_004

   
{
    public partial class EmployeesWindow : Window
    {
        public EmployeesWindow()
        {
            InitializeComponent();
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee { Image = "hum1.jpg", Name = "Tanya Rew", Salary = "$3000" },
                new Employee { Image = "hum2.jpg", Name = "Ron Wiew", Salary = "$600" },
                 new Employee { Image = "hum3.jpg", Name = "Gena Ojfe", Salary = "$1500" },
                new Employee { Image = "hum4.jpg", Name = "Ira Sadred", Salary = "$800" }
            };

            EmployeesListBox.ItemsSource = employees;
        }
    }
}


