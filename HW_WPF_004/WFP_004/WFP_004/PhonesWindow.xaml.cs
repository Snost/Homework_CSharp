using System;
using System.Collections.Generic;
using System.Linq;
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

namespace WFP_004
{
   
        public partial class PhonesWindow : Window
        {
            public PhonesWindow()
            {
                InitializeComponent();
                LoadPhones();
            }

            private void LoadPhones()
            {
                List<Phone> phones = new List<Phone>
            {
               
                new Phone { Image = "galaxy.jpg", Name = "Galaxy", Manufacturer = "Samsung" },
                 new Phone { Image = "iphone.jpg", Name = "iPhone", Manufacturer = "Apple" },
                 new Phone { Image = "xiomi.jpg", Name = "Redmi", Manufacturer = "Xiomi" }
            };

                PhonesListBox.ItemsSource = phones;
            }
        }
    }


