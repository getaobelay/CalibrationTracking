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

namespace CalibrationTracking.Desktop.CustomeMessageBox
{
    /// <summary>
    /// Interaction logic for CustomMessageBox.xaml
    /// </summary>
    public partial class CustomMessageBoxWindow : Window
    {
        public CustomMessageBoxWindow(string caption, string message, bool dialog)
        {
            InitializeComponent();
            tbMessageBoxCaption.Text = caption;
            tbMessageBoxMessage.Text = message;
            if (!dialog)
            {
                btnMessageBoxNo.Visibility = Visibility.Collapsed;
                btnMessageBoxYes.Visibility = Visibility.Collapsed;
            }

        }

       

        private void btnMessageBoxNo_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;

            this.Close();

        }

        private void imgMessageBoxCancel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void btnMessageBoxYes_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;

            this.Close();

        }

        private void btnMessageBoxClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

   


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
