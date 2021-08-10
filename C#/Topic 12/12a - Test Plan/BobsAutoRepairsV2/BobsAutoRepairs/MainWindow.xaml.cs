using System;
using System.Text.RegularExpressions;
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
     * Topic 12A Assessment
     * Nicholas Balliro S1509092
     * 03/08/2021
     * Bob's Auto Repairs WPF Program Testing Phase
     */
    public partial class MainWindow : Window
    {
        //Creating a Regular Expression to omit input failures
        private Regex rxStr = new Regex("[A-Za-z]+");
        private Regex rxNum = new Regex("[0-9]+");

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            if (partsCost.Text == String.Empty || labourHrs.Text == String.Empty || customer.Text == String.Empty)
            {
                MessageBox.Show("ERROR:\nPlease fill out all fields.");
                return;
            }

            //CORRECTING CUSTOMER TEST PLAN
            //Test: "1234" AND "-"
            if (rxStr.IsMatch(customer.Text) == false) //Checks if the text does not match the regex "[A-Za-z]+" (Only letters)
            {
                MessageBox.Show("ERROR: \nPlease enter a valid name."); //ERROR Message
                return;
            }

            //CORRECTING COST OF PARTS AND LABOUR HOURS TEST PLAN
            //Test: "Test"
            if (rxNum.IsMatch(partsCost.Text) == false) //Same as above, except this time with "[0-9]+" (Only numbers)
            {
                MessageBox.Show("ERROR: \nPlease enter valid parts cost.");
                return;
            } 
            if (rxNum.IsMatch(labourHrs.Text) == false)
            {
                MessageBox.Show("ERROR: \nPlease enter valid hours.");
                return;
            }

            double partsCostDbl = Convert.ToDouble(partsCost.Text);
            double labourHrsDbl = Convert.ToDouble(labourHrs.Text);

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

            string fmtStr = "{0,-20}{1,-50}{2,-15:C}";
            const double LABOUR_RATE = 45.6;
            const double GST = 0.1;
            double totalLabour = labourHrsDbl * LABOUR_RATE;
            double partsGST = partsCostDbl * GST;
            double totalCost = totalLabour + partsGST + partsCostDbl; 
            
            lstTable.Items.Clear();
            lstTable.Items.Add("Invoice To: " + customer.Text);
            lstTable.Items.Add("");
            lstTable.Items.Add(String.Format(fmtStr, "Item", "Cost", "Sub Total"));
            lstTable.Items.Add("----------------------------------------------------------------------------------");
            lstTable.Items.Add(String.Format(fmtStr, "Parts", "", partsCostDbl));
            lstTable.Items.Add(String.Format(fmtStr, "Labour", labourDesc(labourHrsDbl, LABOUR_RATE), totalLabour));
            lstTable.Items.Add(String.Format(fmtStr, "GST on Parts", "", partsGST));
            lstTable.Items.Add(String.Format(fmtStr, "", "", "------------"));
            lstTable.Items.Add(String.Format(fmtStr, "", "TOTAL", totalCost));
            lstTable.Items.Add(String.Format(fmtStr, "", "", "------------"));
            customer.Text = String.Empty;
            labourHrs.Text = String.Empty;
            partsCost.Text = String.Empty;
        }

        private String labourDesc(double hours, double rate)
        {
            String output = String.Format("{0} hrs @ {1:C} Per Hour", hours, rate);
            return output;
        }
    }
}
