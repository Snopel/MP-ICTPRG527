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

namespace Books
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

        private void bookBtn_Click(object sender, RoutedEventArgs e)
        {
            Book book = new Book("Holes", 120);
            txtBox.Text = "Title: " + book.getTitle() + "\nPages: " + book.getPages();
        }

        private void textBookBtn_Click(object sender, RoutedEventArgs e)
        {
            Textbook txtbook = new Textbook("Science", 480, 9);
            txtBox.Text = "Title: " + txtbook.getTitle() + "\nPages: " + txtbook.getPages() + "\nGrade: Yr. " + txtbook.getGrade();
        }
    }
}
