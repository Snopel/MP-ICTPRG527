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

namespace FtoC
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            double temp;

            try
            {
                if (txtTempF.Text != String.Empty) //Checking if the F box isn't empty
                {
                    //Changing the text in the box to a Double value in order to perform calculations
                    temp = Convert.ToDouble(txtTempF.Text) - 32.0;
                    //Perform calculations on the temp
                    temp = Math.Round(5.0 / 9.0 * temp, 2);
                    //Convert back into a string to be compatible with the text box display
                    txtTempC.Text = Convert.ToString(temp);
                    //Empty the F box so that pressing Convert again can work both ways
                    txtTempF.Text = String.Empty;
                }
                else if (txtTempC.Text != String.Empty)
                {
                    temp = Convert.ToDouble(txtTempC.Text);
                    temp = 9.0 / 5.0 * temp;
                    temp += 32.0;
                    txtTempF.Text = String.Format("{0:N2}", Math.Round(temp, 2));
                    txtTempC.Text = String.Empty;
                }
                else
                {
                    //If both boxes are empty
                    MessageBox.Show("Please enter a value in either box.");
                }
            } catch (Exception)
            {
                //If anything else is entered
                MessageBox.Show("ERROR: Invalid Input.");
            }
        }
    }
}
