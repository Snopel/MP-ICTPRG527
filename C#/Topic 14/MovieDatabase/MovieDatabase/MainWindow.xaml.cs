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
        //NEW
        private bool isNewRow = false;
        private OleDbCommandBuilder builder;

        public MainWindow()
        {
            InitializeComponent();
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = movieDB.mdb";
            try
            {
                database = new OleDbConnection(connectionString);
                database.Open();
                dsMovie = new DataSet();

                //NEW - Setting up the Command Builder
                string strQuery = "SELECT [movieno], [title], [year], [rating], [runtime], [imdb_score], [distcode] FROM movie";
                daMovie = new OleDbDataAdapter(strQuery, database);
                builder = new OleDbCommandBuilder(daMovie);
                builder.QuotePrefix = "[";
                builder.QuoteSuffix = "]";

                //SQL Query to list movies
                string queryString = "SELECT * FROM movie";
                daMovie = new OleDbDataAdapter(queryString, database);
                daMovie.Fill(dsMovie, "movie");
                //NEW - Calling View Mode method
                viewMode();
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

        //NEW - View Mode
        private void viewMode()
        {
            disableMovie();
            enableNavigation();
            enableActions();
            disableUpdate();
        }

        //NEW - Update Mode
        private void updateMode()
        {
            enableMovie();
            disableNavigation();
            disableActions();
            enableUpdate();
        }

        //NEW - Adding movie to the database
        private void btnAddMovie_Click(object sender, RoutedEventArgs e)
        {
            txtMovieNo.Clear();
            txtDistCode.Clear();
            txtImdbScore.Clear();
            txtRating.Clear();
            txtRuntime.Clear();
            txtTitle.Clear();
            txtYear.Clear();
            updateMode();
            txtMovieNo.Focus();
            isNewRow = true;
        }

        //NEW - Save the record
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (isNewRow)
            {
                DataRow newRow = dsMovie.Tables["movie"].NewRow();
                newRow["movieno"] = Convert.ToInt64(txtMovieNo.Text);
                newRow["title"] = txtTitle.Text;
                newRow["year"] = Convert.ToInt64(txtYear.Text);
                newRow["distcode"] = txtDistCode.Text;
                newRow["imdb_score"] = Convert.ToDouble(txtImdbScore.Text);
                newRow["runtime"] = Convert.ToInt64(txtRuntime.Text);
                newRow["rating"] = txtRating.Text;
                dsMovie.Tables["movie"].Rows.Add(newRow);
                rowIndex = dsMovie.Tables["movie"].Rows.Count - 1;
            }
            else
            {
                dsMovie.Tables["movie"].Rows[rowIndex]["movieno"] = Convert.ToInt64(txtMovieNo.Text);
                dsMovie.Tables["movie"].Rows[rowIndex]["title"] = txtTitle.Text;
                dsMovie.Tables["movie"].Rows[rowIndex]["year"] = Convert.ToInt64(txtYear.Text);
                dsMovie.Tables["movie"].Rows[rowIndex]["distcode"] = txtDistCode.Text;
                dsMovie.Tables["movie"].Rows[rowIndex]["imdb_score"] = Convert.ToDouble(txtImdbScore.Text);
                dsMovie.Tables["movie"].Rows[rowIndex]["runtime"] = Convert.ToInt64(txtRuntime.Text);
                dsMovie.Tables["movie"].Rows[rowIndex]["rating"] = txtRating.Text;
                dsMovie.Tables["movie"].Rows[rowIndex].EndEdit();
            }
            daMovie.UpdateCommand = builder.GetUpdateCommand();
            daMovie.Update(dsMovie, "movie");
            viewMode();
        }


        //Grouping Workaround...
        //DISABLE
        private void disableMovie()
        {
            txtMovieNo.IsEnabled = false;
            txtDistCode.IsEnabled = false;
            txtImdbScore.IsEnabled = false;
            txtRating.IsEnabled = false;
            txtRuntime.IsEnabled = false;
            txtTitle.IsEnabled = false;
            txtYear.IsEnabled = false;
        }
        private void disableNavigation()
        {
            btnNext.IsEnabled = false;
            btnPrevious.IsEnabled = false;
            btnFirst.IsEnabled = false;
            btnLast.IsEnabled = false;
        }
        private void disableActions()
        {
            btnAddMovie.IsEnabled = false;
            btnEditMovie.IsEnabled = false;
            btnDeleteMovie.IsEnabled = false;
        }
        private void disableUpdate()
        {
            btnSave.IsEnabled = false;
            btnCancel.IsEnabled = false;
        }
        //ENABLE
        private void enableMovie()
        {
            txtMovieNo.IsEnabled = true;
            txtDistCode.IsEnabled = true;
            txtImdbScore.IsEnabled = true;
            txtRating.IsEnabled = true;
            txtRuntime.IsEnabled = true;
            txtTitle.IsEnabled = true;
            txtYear.IsEnabled = true;
        }
        private void enableNavigation()
        {
            btnNext.IsEnabled = true;
            btnPrevious.IsEnabled = true;
            btnFirst.IsEnabled = true;
            btnLast.IsEnabled = true;
        }
        private void enableActions()
        {
            btnAddMovie.IsEnabled = true;
            btnEditMovie.IsEnabled = true;
            btnDeleteMovie.IsEnabled = true;
        }
        private void enableUpdate()
        {
            btnSave.IsEnabled = true;
            btnCancel.IsEnabled = true;
        }

        private void btnEditMovie_Click(object sender, RoutedEventArgs e)
        {
            updateMode();
            txtMovieNo.Focus();
            isNewRow = false;
            dsMovie.Tables["movie"].Rows[rowIndex].BeginEdit();
        }
    }


}
