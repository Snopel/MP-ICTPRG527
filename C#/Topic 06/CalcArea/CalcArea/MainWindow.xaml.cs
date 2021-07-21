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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalcArea
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void calcArea()
        {
            if(txtLength.Text != String.Empty && txtWidth.Text != String.Empty)
            {
                try
                {
                    double length = Convert.ToDouble(txtLength.Text);
                    double width = Convert.ToDouble(txtLength.Text);
                    lblArea.Content = length * width;
                } catch (Exception)
                {
                    MessageBox.Show("ERROR: Invalid Input");
                }
            }
        }

        private void txtLength_TextChanged(object sender, TextChangedEventArgs e)
        {
            calcArea();
        }

        private void txtWidth_TextChanged(object sender, TextChangedEventArgs e)
        {
            calcArea();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            lblArea.Content = String.Empty;
            txtLength.Text = String.Empty;
            txtWidth.Text = String.Empty;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
