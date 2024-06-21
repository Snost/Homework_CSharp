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

namespace HW_WPF_003
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as Border).Background = Brushes.DarkRed;
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as Border).Background = Brushes.DarkRed;
        }
    }
}