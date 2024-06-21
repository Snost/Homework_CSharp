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
   
        public partial class AnimalsWindow : Window
        {
            public AnimalsWindow()
            {
                InitializeComponent();
                LoadAnimals();
            }

            private void LoadAnimals()
            {
                List<Animal> animals = new List<Animal>
            {
                new Animal { Image = "cat.jpg", Location = "Europe", Name = "Lion" },
                new Animal { Image = "panda.jpg", Location = "China", Name = "Panda" },
                 new Animal { Image = "penguins.jpg", Location = "Antarctica", Name = "Penguins"}
            };

                AnimalsListBox.ItemsSource = animals;
            }
        }
    }


