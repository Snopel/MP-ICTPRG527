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
using System.Windows.Shapes;
using System.Data.OleDb;
using System.Data;

namespace BooksDatabase
{
    //Publishers window function.
    public partial class Publishers : Window
    {
        //Class level declarations
        //GRID
        private OleDbConnection databaseGrid;
        private OleDbDataAdapter daPublisherGrid;
        private DataSet dsPublisherGrid;
        private OleDbCommand gridCommand;
        //TITLE
        private OleDbConnection databaseTitle;
        private OleDbDataAdapter daPublisherTitle;
        private DataSet dsPublisherTitle;
        private OleDbCommand titleCommand;

        //Constructor which will aim to use the Book Code and also a pubCode for queries
        public Publishers(String bookCode, String pubCode)
        {
            InitializeComponent();
            //Initializing the database as usual
            String connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Books.mdb";
            try
            {
                //GRID PART
                databaseGrid = new OleDbConnection(connectionString);
                databaseGrid.Open();
                dsPublisherGrid = new DataSet();
                //New query to list all books from the current publisher in the Book table
                string gridQuery = "SELECT BookCode, Title, Type " +
                    " FROM Book " +
                    " WHERE PublisherCode = " + "'" + pubCode + "';";
                //Querying and displaying the Data Grid
                gridCommand = new OleDbCommand(gridQuery, databaseGrid);
                daPublisherGrid = new OleDbDataAdapter(gridQuery, databaseGrid);
                daPublisherGrid.Fill(dsPublisherGrid, "Publisher");
                dgPublisher.DataContext = dsPublisherGrid.Tables["Publisher"];
                dgPublisher.ItemsSource = dsPublisherGrid.Tables["Publisher"].AsDataView();

                //TITLE PART
                databaseTitle = new OleDbConnection(connectionString);
                databaseTitle.Open();
                dsPublisherTitle = new DataSet();
                //Query to grab the Title of the Publisher
                string titleQuery = "SELECT PublisherName FROM Publisher " +
                    " WHERE PublisherCode = " + "'" + pubCode + "';";
                //Querying and displaying the Title
                titleCommand = new OleDbCommand(titleQuery, databaseTitle);
                daPublisherTitle = new OleDbDataAdapter(titleQuery, databaseTitle);
                daPublisherTitle.Fill(dsPublisherTitle, "Title");
                txtPub.Text = Convert.ToString(dsPublisherTitle.Tables["Title"].Rows[0]["PublisherName"]);

                //Close the databases
                databaseGrid.Close();
                databaseTitle.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
