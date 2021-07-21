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

namespace Students
{

    public partial class MainWindow : Window
    {
        Student student = new Student();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnTxt_Click(object sender, RoutedEventArgs e)
        {
            txtBox.Text = student.displayStudent();
        }

        private void phoneTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            student.setPhone(phoneTxt.Text);
        }

        private void studNoTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            student.setStudNo(studNoTxt.Text);
        }

        private void nameTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            student.setName(nameTxt.Text);
        }
    }
}
