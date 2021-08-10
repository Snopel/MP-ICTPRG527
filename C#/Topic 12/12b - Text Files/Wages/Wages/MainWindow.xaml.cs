using System;
using System.IO; //Using IO library
using System.Collections.Generic;
using System.Text.RegularExpressions; //Using Regex library
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
 * S1509092
 * 10/08/2021
 * Assessment 12b
 * Design a program to read from a file, sort information into respective arrays and calculate average wage based on these
 * arrays and display relative information.
 */

namespace Wages
{
    public partial class MainWindow : Window
    {
        //Creating Regular Expressions for reading purposes
        private Regex numCheck = new Regex("[0-9]+");
        private Regex txtCheck = new Regex("[a-zA-Z]+");
        //Creating Arrays to store variables
        private String[] fileArr;
        private double[] wageArr;
        private String[] nameArr;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        //MAIN METHOD - When the button is clicked, undergo the process
        private void dispBtn_Click(object sender, RoutedEventArgs e)
        {
            //Setting a pointer to the text file
            String wages = "wages.txt";

            if(File.Exists(wages) == true) //Making sure the file is actually there
            {
                //Assign every value into an array 'fileArr' to then be sorted by the 'arraySort' method
                fileArr = File.ReadAllLines(wages);

                arraySort(fileArr); //Calling the arraySort method to separate fileArr into wage and name arr's
                
                //Display the information
                lstBox.Items.Add("### WAGES ###");
                for (int j = 0; j < nameArr.Length; j++)
                {
                    lstBox.Items.Add(String.Format(nameArr[j] + ": {0:C}", wageArr[j]));
                }

                //Calling the calcAveWage function and displaying the result
                lstBox.Items.Add(String.Format("\nAVERAGE WAGE: {0:C}", calcAveWage(wageArr)));
            }
            else
            {
                //If the file is not found, issue an error
                MessageBox.Show("FATAL:\nFile does not exist.");
            }
        }

        //ARRAYSORT METHOD - Sort one array into two arrays separated by Regex
        private void arraySort(String[] input)
        {
            //Since the array will be halved, set the length of the separate arrays into half the origin's
            wageArr = new double[fileArr.Length/2];
            nameArr = new string[fileArr.Length/2];
            //Setting separate counters so that the arrays count on their own terms (Lots and lots of error checking lead to this decision)
            int a = 0;
            int b = 0;
            int c = 0;

            //While Loop to fill the arrays
            while (a < fileArr.Length)
            {
                //Using the Regex to check if it's a number
                if (numCheck.IsMatch(input[a]) == true)
                {
                    wageArr[b] = Convert.ToInt32(input[a]);
                    b++;
                } 
                //Using the Regex to check if it's text
                if (txtCheck.IsMatch(input[a]) == true)
                {
                    nameArr[c] = fileArr[a];
                    c++;
                }
                a++;
            }
        }

        //CALCEAVEWAGE METHOD - Output the average of all numbers in an array
        private double calcAveWage(double[] input)
        {
            //Add all the numbers in the array
            double sum = 0;
            for (int a = 0; a < input.Length; a++)
            {
                sum += input[a];
            }
            //Divide the sum of the numbers by length to get the average
            double ave = sum / input.Length;

            //Return the value for use
            return ave;
        }
    }
}
