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

namespace BobsAutoRepairs
{
    /*
     * Topic 6 Assessment
     * Nicholas Balliro S1509092
     * 11/06/2021
     * Bob's Auto Repairs WPF Program.
     */
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //For when the Generate button is pressed
        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            //If any of the text boxes are left empty
            if (partsCost.Text == String.Empty || labourHrs.Text == String.Empty || customer.Text == String.Empty)
            {
                MessageBox.Show("ERROR:\nPlease fill out all fields.");
                return;
            }
            //Declaring variables
            double partsCostDbl = Convert.ToDouble(partsCost.Text);
            double labourHrsDbl = Convert.ToDouble(labourHrs.Text);
            //Checking if the above variables are within the desired conditions
            if (partsCostDbl < 1.5 || partsCostDbl > 7500)
            {
                MessageBox.Show("ERROR:\nParts cost must be between $1.50 and $7,500");
                return;
            }
            if(labourHrsDbl < 0.5 || labourHrsDbl > 50)
            {
                MessageBox.Show("ERROR:\nLabour Hours must be between half an hour and 50 hours");
                return;
            }

            //String format used, where C will change the values in this column to a Currency.
            string fmtStr = "{0,-20}{1,-50}{2,-15:C}";
            const double LABOUR_RATE = 45.6;
            const double GST = 0.1;
            //Calculations
            double totalLabour = labourHrsDbl * LABOUR_RATE;
            double partsGST = partsCostDbl * GST;
            double totalCost = totalLabour + partsGST + partsCostDbl;
            
            //List Table Display
            lstTable.Items.Clear(); //Clears the list table so text can have a fresh canvas
            lstTable.Items.Add("Invoice To: " + customer.Text);
            lstTable.Items.Add("");
            //Using the string format below to add items to the list neatly
            lstTable.Items.Add(String.Format(fmtStr, "Item", "Cost", "Sub Total"));
            lstTable.Items.Add("----------------------------------------------------------------------------------");
            lstTable.Items.Add(String.Format(fmtStr, "Parts", "", partsCostDbl));
            //Calling the labourDesc method to format the second item as necessary
            lstTable.Items.Add(String.Format(fmtStr, "Labour", labourDesc(labourHrsDbl, LABOUR_RATE), totalLabour));
            lstTable.Items.Add(String.Format(fmtStr, "GST on Parts", "", partsGST));
            lstTable.Items.Add(String.Format(fmtStr, "", "", "------------"));
            lstTable.Items.Add(String.Format(fmtStr, "", "TOTAL", totalCost));
            lstTable.Items.Add(String.Format(fmtStr, "", "", "------------"));
            customer.Text = String.Empty;
            labourHrs.Text = String.Empty;
            partsCost.Text = String.Empty;
        }

        //METHOD: Organises the two values of hours and rate and formats them into a usable string.
        //Was a cleaner way to add the item to the code above as doing so within a bracket was messy.
        private String labourDesc(double hours, double rate)
        {
            String output = String.Format("{0} hrs @ {1:C} Per Hour", hours, rate);
            return output;
        }
    }
}
