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

namespace Exe7D
{
    public partial class MainWindow : Window
    {
        //Instantiating the Computer Class and creating a new computer.
        Computer com = new Computer();

        public MainWindow()
        {
            InitializeComponent();
        }

        //Submitting the final output
        private void purchaseBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        //Checkbox Conditions
        private void chkSSD_Checked(object sender, RoutedEventArgs e)
        {
            com.setSSD(true);
        }
        private void chkGPU_Checked(object sender, RoutedEventArgs e)
        {
            com.setGPU(true);
        }
        private void chkScreen_Checked(object sender, RoutedEventArgs e)
        {
            com.setScreen(true);
        }
        private void chkAssembly_Checked(object sender, RoutedEventArgs e)
        {
            com.setAssembly(true);
        }
        private void chkOSDisk_Checked(object sender, RoutedEventArgs e)
        {
            com.setOSDisk(true);
        }
        private void chkInstall_Checked(object sender, RoutedEventArgs e)
        {
            com.setOSInstall(true);
        }
    }
}
