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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            string fmtStr = "{0,-20}{1,-50}{2,-15:C}";
            double partsCostDbl = Convert.ToDouble(partsCost.Text);
            const double LABOUR_RATE = 45.6;
            double totalLabour = Convert.ToDouble(labourHrs.Text) * 45.6;
            double partsGST = partsCostDbl * 0.1;
            double totalCost = totalLabour + partsGST + partsCostDbl;

            lstTable.Items.Clear();
            lstTable.Items.Add("Invoice To: " + customer.Text);
            lstTable.Items.Add("");
            lstTable.Items.Add(String.Format(fmtStr, "Item", "Cost", "Sub Total"));
            lstTable.Items.Add("----------------------------------------------------------------------------------");
            lstTable.Items.Add(String.Format(fmtStr, "Parts", "", partsCostDbl));
            lstTable.Items.Add(String.Format(fmtStr, "Labour", labourDesc(Convert.ToDouble(labourHrs.Text), LABOUR_RATE), totalLabour));
            lstTable.Items.Add(String.Format(fmtStr, "GST on Parts", "", partsGST));
            lstTable.Items.Add(String.Format(fmtStr, "", "", "------------"));
            lstTable.Items.Add(String.Format(fmtStr, "", "TOTAL", totalCost));
            lstTable.Items.Add(String.Format(fmtStr, "", "", "------------"));
        }

        private String labourDesc(double hours, double rate)
        {
            String output = String.Format("{0} hrs @ {1:C} Per Hour", hours, rate);
            return output;
        }
    }
}
