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
 * S15090902
 * Exercise 7D: Assessment
 * Creating a WPF application that allows a user to select a system and
 * calculate and display the results of the order in a listbox as per
 * requirements
 */

namespace Exe7D
{
    public partial class MainWindow : Window
    {
        //Instantiating the Computer Class and creating a new computer.
        Computer com = new Computer();
        //Costing variables
        private String comDesc;
        private double comPrice;
        private double extras;
        private double total;

        public MainWindow()
        {
            InitializeComponent();
        }

        //Submitting the final output
        private void purchaseBtn_Click(object sender, RoutedEventArgs e)
        {
            //Check if any required field is empty
            if(nameTxt.Text == String.Empty || cityCmb.SelectedIndex == -1 || compCmb.SelectedIndex == -1)
            {
                MessageBox.Show("Name, City and Computer are required.");
                return;
            }
            //Clear the list
            lstReceipt.Items.Clear();
            //Run final calculations
            chkChecker();
            com.setRAM(cmbRAM.SelectedIndex);
            computeComputer();
            computeExtras();
            computeTotal();

            //Format a string for a list output
            String fmtStr = "{0,-78}{1,15:C}";

            //Output the string and all its final components
            lstReceipt.Items.Add("PolyTech Computer Systems - Order for " + nameTxt.Text);
            lstReceipt.Items.Add("\nOrder: " + comDesc + " - " + cityCmb.Text + " Store Pickup\n");
            lstReceipt.Items.Add(String.Format(fmtStr, "Base Price: ", comPrice));

            //Upgrades
            if (extras > 0)
            {
                lstReceipt.Items.Add("\nUpgrades: ");
                if (com.getSSD() == true)
                {
                    lstReceipt.Items.Add(String.Format(fmtStr, "500GB Solid State Drive", 178));
                }
                if (com.getGPU() == true)
                {
                    lstReceipt.Items.Add(String.Format(fmtStr, "8GB Dedicated Graphics Card", 178));
                }
                if (com.getScreen() == true)
                {
                    lstReceipt.Items.Add(String.Format(fmtStr, "27\u0022 LED Monitor", 520));
                }
                if (com.getRAM() >= 0)
                {
                    lstReceipt.Items.Add(String.Format(fmtStr, (com.getRAM() + 1) + "x Additional 8GB RAM Module", ((com.getRAM() + 1) * 67.45)));
                }
                if (com.getAssembly() == true)
                {
                    lstReceipt.Items.Add(String.Format(fmtStr, "Assembly by PolyTech Systems", 254.5));
                }
                if (com.getOSDisk() == true)
                {
                    lstReceipt.Items.Add(String.Format(fmtStr, "Windows Operating System OEM Disk", 168));
                }
                if (com.getOSInstall() == true)
                {
                    lstReceipt.Items.Add(String.Format(fmtStr, "Windows OS Installation", 68));
                }
                lstReceipt.Items.Add(String.Format(fmtStr, "", "--------------"));
                lstReceipt.Items.Add(String.Format(fmtStr, "Extras' Total: ", extras));
            }
            else if (extras == 0)
            {
                lstReceipt.Items.Add(String.Format(fmtStr, "Upgrades: ", "N/A"));
            }

            //Final Total
            lstReceipt.Items.Add(String.Format(fmtStr, "", "--------------"));
            lstReceipt.Items.Add(String.Format(fmtStr, "Order Total (Payable at Pickup): ", total));

            //Clear all selections
            clearAll();
        }

        //Checkbox Conditions
        private void chkChecker()
        {
            if (chkSSD.IsChecked == true)
            {
                com.setSSD(true);
            }
            else
            {
                com.setSSD(false);
            }
            if (chkGPU.IsChecked == true)
            {
                com.setGPU(true);
            }
            else
            {
                com.setGPU(false);
            }
            if (chkScreen.IsChecked == true)
            {
                com.setScreen(true);
            }
            else
            {
                com.setScreen(false);
            }
            if (chkAssembly.IsChecked == true)
            {
                com.setAssembly(true);
            }
            else
            {
                com.setAssembly(false);
            }
            if (chkOSDisk.IsChecked == true)
            {
                com.setOSDisk(true);
            }
            else
            {
                com.setOSDisk(false);
            }
            if (chkInstall.IsChecked == true)
            {
                com.setOSInstall(true);
            }
            else
            {
                com.setOSInstall(false);
            }
        }

        //Enabling and Disabling OS Installation according to OS Disk
        private void chkOSDisk_Checked(object sender, RoutedEventArgs e)
        {
            chkInstall.IsEnabled = true;
        }
        private void chkOSDisk_Unchecked(object sender, RoutedEventArgs e)
        {
            chkInstall.IsEnabled = false;
            chkInstall.IsChecked = false;
        }

        //Combobox event to disable all upgrade events upon 'Ultimate' selection
        private void compCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (compCmb.SelectedIndex == 3)
            {
                chkSSD.IsChecked = false;
                chkGPU.IsChecked = false;
                chkScreen.IsChecked = false;
                chkSSD.IsEnabled = false;
                chkGPU.IsEnabled = false;
                chkScreen.IsEnabled = false;
                cmbRAM.IsEnabled = false;
                cmbRAM.SelectedIndex = -1;
            }
            else
            {
                chkSSD.IsEnabled = true;
                chkGPU.IsEnabled = true;
                chkScreen.IsEnabled = true;
                cmbRAM.IsEnabled = true;
            }
        }

        //Calculating the computer price and description
        private void computeComputer()
        {
            switch (compCmb.SelectedIndex)
            {
                case 0:
                    comDesc = "PolyTech Home Kit";
                    comPrice = 759.99;
                    break;
                case 1:
                    comDesc = "PolyTech Business Kit";
                    comPrice = 1159.99;
                    break;
                case 2:
                    comDesc = "PolyTech Gamer Kit";
                    comPrice = 1789.99;
                    break;
                case 3:
                    comDesc = "PolyTech Ultimate Kit";
                    comPrice = 2799.99;
                    break;
                default:
                    break;
            }
        }

        //Calculating the extras price
        private void computeExtras()
        {
            if (com.getSSD() == true)
            {
                extras += 178;
            }
            if (com.getGPU() == true)
            {
                extras += 520;
            }
            if (com.getScreen() == true)
            {
                extras += 275;
            }
            if (com.getRAM() >= 0)
            {
                extras += (67.45 * (com.getRAM() + 1));
            }
            if (com.getAssembly() == true)
            {
                extras += 254.5;
            }
            if (com.getOSDisk() == true)
            {
                extras += 168;
            }
            if (com.getOSInstall() == true)
            {
                extras += 68.6;
            }
        }

        //Calculating the final total
        public void computeTotal()
        {
            total = comPrice + extras;
        }

        //Clear all fields
        public void clearAll()
        {
            nameTxt.Text = String.Empty;
            cityCmb.SelectedIndex = -1;
            compCmb.SelectedIndex = -1;
            chkSSD.IsChecked = false;
            chkGPU.IsChecked = false;
            chkScreen.IsChecked = false;
            cmbRAM.SelectedIndex = -1;
            chkAssembly.IsChecked = false;
            chkOSDisk.IsChecked = false;
            chkInstall.IsChecked = false;
            comPrice = 0;
            extras = 0;
            total = 0;
        }
    }
}
