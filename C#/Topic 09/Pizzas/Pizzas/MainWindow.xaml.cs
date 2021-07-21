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

namespace Pizzas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Pizza pizza = new Pizza();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void toppingsTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            pizza.setToppings(toppingsTxt.Text);
        }

        private void sizeTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            pizza.setDiameter(Convert.ToInt32(sizeTxt.Text));
        }

        private void purchaseBtn_Click(object sender, RoutedEventArgs e)
        {
            pizza.setPrice(12.99);

            displayTxt.Text = pizza.displayPizza();
        }
    }
}
