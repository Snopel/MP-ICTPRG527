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

namespace MyDates
{
    /* Nicholas Balliro
     * S1509092
     * Assessment 9 
     * Creating a WPF Application that takes a Date class and outputs a comparison
     */
    public partial class MainWindow : Window
    {
        //Boolean to check if the two dates match
        bool match = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            //Initialise match for next use
            match = false;

            //Error checking for date descrepancies
            if (Convert.ToInt32(dayTxt.Text) > 31 || Convert.ToInt32(dayTxt.Text) < 1
                || Convert.ToInt32(monthTxt.Text) > 12 || Convert.ToInt32(monthTxt.Text) < 0)
            {
                MessageBox.Show("Please enter a valid date.");
                return;
            }

            if (dayTxt.Text != String.Empty && monthTxt.Text != String.Empty && yearTxt.Text != String.Empty)
            {
                //Instantiate a default date 1/1/2021
                Date date1 = new Date();
                //Instantiate a new date from user input
                Date date2 = new Date(Convert.ToInt32(dayTxt.Text), Convert.ToInt32(monthTxt.Text), Convert.ToInt32(yearTxt.Text));

                //Add the two dates to the list box
                lstBox.Items.Add("Date 1: " + date1.getDate());
                lstBox.Items.Add("Date 2: " + date2.getDate());

                //Check if they are the same
                if (date1.getYear() == date2.getYear())
                {
                    match = true;
                }

                //Final output
                lstBox.Items.Add("Dates in the same year: " + match + "\n");
            }
            //Code for if any of the fields are empty
            else
            {
                MessageBox.Show("Please fill in all fields.");
            }
        }

    }
}
