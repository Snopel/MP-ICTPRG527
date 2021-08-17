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
//Using the required libraries
using System.Data;
using System.Data.OleDb;

namespace ActorDatatable
{
    /* Nicholas Balliro
     * S1509092
     * 17/08/2021
     * Assessment 13 - Actor Datatable
     * Create a link to a Movie Database and search through the Actor table to
     * produce a relative record and activate buttones to search
     */
    public partial class MainWindow : Window
    {
        //Class Level Declarations
        private OleDbConnection database;
        private OleDbDataAdapter daActor;
        private DataSet dsActor;
        private int rowIndex = 0;

        public MainWindow()
        {
            //Initialization level code to activate upon opening
            InitializeComponent();
            //Activating the database provider and the database itself located in the Debug folder
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = movieDb.mdb";

            //Opening the Movie database
            try
            {
                database = new OleDbConnection(connectionString);
                database.Open();
                dsActor = new DataSet();

                //SQL query to list the actors
                string queryString = "SELECT * FROM actor";
                daActor = new OleDbDataAdapter(queryString, database);
                daActor.Fill(dsActor, "actor");

                //Calling the DisplayRecord method
                DisplayRecord();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //METHOD: Fills the textboxes with data from the Actor table according to the current row index
        public void DisplayRecord()
        {
            txtActorNo.Text = Convert.ToString(dsActor.Tables["actor"].Rows[rowIndex]["actorno"]);
            txtFirstname.Text = Convert.ToString(dsActor.Tables["actor"].Rows[rowIndex]["firstname"]);
            txtSurname.Text = Convert.ToString(dsActor.Tables["actor"].Rows[rowIndex]["surname"]);
        }

        //BUTTON SETUPS - Used to cycle through the data and alter the DisplayRecord method
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            //If the table is at a count
            if (dsActor.Tables["actor"].Rows.Count > 0)
            {
                //If the table has not reached the end
                if (rowIndex < dsActor.Tables["actor"].Rows.Count - 1)
                {
                    rowIndex++; //Increment the row
                    DisplayRecord(); //Refresh the text boxes
                }
            }
        }
        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            if (dsActor.Tables["actor"].Rows.Count > 0)
            {
                //As long as the database is not at its first point
                if (rowIndex != 0)
                {
                    rowIndex--; //Decrement
                    DisplayRecord();
                }
            }
        }
        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            if (dsActor.Tables["actor"].Rows.Count > 0)
            {
                //Simply set the table to its first set
                rowIndex = 0;
                DisplayRecord();
            }
        }
        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            if (dsActor.Tables["actor"].Rows.Count > 0)
            {
                //Set the table to its final set
                rowIndex = dsActor.Tables["actor"].Rows.Count - 1;
                DisplayRecord();
            }
        }
    }
}
