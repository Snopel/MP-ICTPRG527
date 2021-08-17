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
//Required libraries
using System.Data.OleDb;
using System.Data;

namespace MovieDatabase
{
    public partial class MainWindow : Window
    {
        //Class Level Declarations
        private OleDbConnection database;
        private OleDbDataAdapter daMovie;
        private DataSet dsMovie;
        private int rowIndex = 0;

        public MainWindow()
        {
            InitializeComponent();
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = movieDB.mdb";
            try
            {
                database = new OleDbConnection(connectionString);
                database.Open();
                dsMovie = new DataSet();

                //SQL Query to list movies
                string queryString = "SELECT * FROM movie";
                daMovie = new OleDbDataAdapter(queryString, database);
                daMovie.Fill(dsMovie, "movie");
                //Calling DisplayRecord method
                DisplayRecord();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Display Record method
        public void DisplayRecord()
        {
            txtMovieNo.Text = Convert.ToString(dsMovie.Tables["movie"].Rows[rowIndex]["movieno"]);
            txtTitle.Text = Convert.ToString(dsMovie.Tables["movie"].Rows[rowIndex]["title"]);
            txtYear.Text = Convert.ToString(dsMovie.Tables["movie"].Rows[rowIndex]["year"]);
            txtRating.Text = Convert.ToString(dsMovie.Tables["movie"].Rows[rowIndex]["rating"]);
            txtRuntime.Text = Convert.ToString(dsMovie.Tables["movie"].Rows[rowIndex]["runtime"]);
            txtImdbScore.Text = Convert.ToString(dsMovie.Tables["movie"].Rows[rowIndex]["imdb_score"]);
            txtDistCode.Text = Convert.ToString(dsMovie.Tables["movie"].Rows[rowIndex]["distcode"]);
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            //If the table is at a count
            if (dsMovie.Tables["movie"].Rows.Count > 0)
            {
                //If the table has not reached the end
                if (rowIndex < dsMovie.Tables["movie"].Rows.Count - 1)
                {
                    rowIndex++;
                    DisplayRecord();
                }
            }
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            if (dsMovie.Tables["movie"].Rows.Count > 0)
            {
                //As long as the database is not at its first point
                if (rowIndex != 0)
                {
                    rowIndex--;
                    DisplayRecord();
                }
            }
        }

        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            if (dsMovie.Tables["movie"].Rows.Count > 0)
            {
                //Simply set the table to its first set
                rowIndex = 0;
                DisplayRecord();
            }
        }

        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            if (dsMovie.Tables["movie"].Rows.Count > 0)
            {
                //Set the table to its final set
                rowIndex = dsMovie.Tables["movie"].Rows.Count - 1;
                DisplayRecord();
            }
        }
    }
}
