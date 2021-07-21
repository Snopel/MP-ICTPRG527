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

namespace ListFormatEx
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnDisplay_Click(object sender, RoutedEventArgs e)
        {
            string fmtStr = "{0,-12}{1,12:N0}{2,16}{3,15:P0}";
            lstTable.Items.Clear();
            lstTable.Items.Add(String.Format(fmtStr, "University", "Number of Students", "Scholarship", "Govt Funding"));
            lstTable.Items.Add(String.Format(fmtStr, "Monash", 8700, 15.2, 0.735));
            lstTable.Items.Add(String.Format(fmtStr, "La Trobe", 6990, 18.5, 0.598));
        }
    }
}
