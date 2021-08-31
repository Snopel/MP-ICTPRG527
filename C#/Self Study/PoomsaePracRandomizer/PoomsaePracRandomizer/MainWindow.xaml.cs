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

namespace PoomsaePracRandomizer
{
    public partial class MainWindow : Window
    {
        private String[] colour = new String[] {"Chon Ji Heung", "Taeguk 1", "Taeguk 2", "Taeguk 3", "Taeguk 4", "Taeguk 5", "Taeguk 6", "Taeguk 7", "Taeguk 8", "Palgue 7", "Palgue 8"};
        private String[] black = new String[] { "Koryo", "Keumgang", "Taebaek", "Pyongwon", "Sipjin", "Jitae", "Cheonkwon", "Hansu", "Ilyo" };
        private String[] all = new String[] { "Chon Ji Heung", "Taeguk 1", "Taeguk 2", "Taeguk 3", "Taeguk 4", "Taeguk 5", "Taeguk 6", "Taeguk 7", "Taeguk 8", "Palgue 7", "Palgue 8",
            "Koryo", "Keumgang", "Taebaek", "Pyongwon", "Sipjin", "Jitae", "Cheonkwon", "Hansu", "Ilyo" };

        private String[] focus = new String[] { "Synchronize", "Bopping", "Tempo", "Snap", "Setup", "Body Angle", "Kicks", "Blocks", "Transitions", "Stances"};

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRandomize_Click(object sender, RoutedEventArgs e)
        {
            if(radColour.IsChecked == true)
            {
                txtForm.Text = getRandom(colour);
            }
            else if (radBlack.IsChecked == true)
            {
                txtForm.Text = getRandom(black);
            }
            else if (radAll.IsChecked == true)
            {
                txtForm.Text = getRandom(all);
            }
            txtFocus.Text = getRandom(focus);
        }

        private String getRandom(String[] arr)
        {
            Random rand = new Random();
            int index = rand.Next(arr.Length);

            return arr[index];
        }
    }


}
