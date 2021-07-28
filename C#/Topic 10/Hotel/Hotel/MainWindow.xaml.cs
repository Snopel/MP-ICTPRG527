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

/* Nicholas Balliro
 * S1509092
 * Topic 10 Q3 Assessment
 * Using Inheritance to determine a Parent and Child relationship between
 * HotelRoom and HotelSuite classes and using their values in conjunction
 * to create a functional program.
 */
namespace Hotel
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //When the Studio is selected, HotelRoom class is instantiated
        private void regularBtn_Click(object sender, RoutedEventArgs e)
        {
            lstBox.Items.Clear(); //Clear previous entry

            try
            {
                HotelRoom studio = new HotelRoom(Convert.ToInt32(roomTxt.Text)); //Instantiating the HotelRoom class, 'studio'
                lstBox.Items.Add("Room Number: " + studio.getRoomNum()); //Using a getter for display purposes
                lstBox.Items.Add("Type: STUDIO");
                lstBox.Items.Add(String.Format("Nightly Rate: {0:C}", studio.getNightlyRate())); //Using another getter along with a string format for currency
            }
            catch (Exception)
            {
                //Blanket exception handle for empty or non-integer entries
                MessageBox.Show("Invalid Input.");
            }
        }

        //When the Suite is selected, the child HotelSuite is instantiated
        private void suiteBtn_Click(object sender, RoutedEventArgs e)
        {
            //Same deal except this time using the child class with its additional $40 Surcharge
            lstBox.Items.Clear();

            try
            {
                HotelSuite suite = new HotelSuite(Convert.ToInt32(roomTxt.Text));
                lstBox.Items.Add("Room Number: " + suite.getRoomNum());
                lstBox.Items.Add("Type: SUITE");
                lstBox.Items.Add(String.Format("Nightly Rate: {0:C}", suite.getNightlyRate()));
            } catch (Exception)
            {
                MessageBox.Show("Invalid Input.");
            }
        }
    }
}
