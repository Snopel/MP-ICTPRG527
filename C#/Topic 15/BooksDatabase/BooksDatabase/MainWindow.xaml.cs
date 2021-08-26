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
//Required Libraries
using System.Data.OleDb;
using System.Data;

namespace BooksDatabase
{
    /* Nicholas Balliro
     * S1509092
     * 26/08/2021
     * Assessment 15
     * Displaying a Data Grid showing books by the current publisher
     */
    public partial class MainWindow : Window
    {
        //Class level Declarations
        private OleDbConnection database;
        private OleDbDataAdapter daBooks;
        private DataSet dsBooks;
        private int rowIndex = 0;
        private bool isNewRow = false;
        private OleDbCommandBuilder builder;

        public MainWindow()
        {
            InitializeComponent();
            //Initialising Database functionalities
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Books.mdb";
            try
            {
                database = new OleDbConnection(connectionString);
                database.Open();
                dsBooks = new DataSet();

                string strQuery = "SELECT [BookCode], [Title], [PublisherCode], [Type], [Price], [Paperback]  FROM Book";
                daBooks = new OleDbDataAdapter(strQuery, database);
                builder = new OleDbCommandBuilder(daBooks);
                builder.QuotePrefix = "[";
                builder.QuoteSuffix = "]";
                daBooks.Fill(dsBooks, "Book");
                viewMode();
                DisplayRecord();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //DisplayRecord method
        public void DisplayRecord()
        {
            txtBookCode.Text = Convert.ToString(dsBooks.Tables["Book"].Rows[rowIndex]["BookCode"]);
            txtTitle.Text = Convert.ToString(dsBooks.Tables["Book"].Rows[rowIndex]["Title"]);
            txtPubCode.Text = Convert.ToString(dsBooks.Tables["Book"].Rows[rowIndex]["PublisherCode"]);
            txtType.Text = Convert.ToString(dsBooks.Tables["Book"].Rows[rowIndex]["Type"]);
            txtPrice.Text = String.Format("{0:F}", Convert.ToDouble(dsBooks.Tables["Book"].Rows[rowIndex]["Price"]));
            chkPaperback.IsChecked = Convert.ToBoolean(dsBooks.Tables["Book"].Rows[rowIndex]["Paperback"]);
        }

        //####### NAVIGATION #######
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (dsBooks.Tables["Book"].Rows.Count > 0)
            {
                if (rowIndex < dsBooks.Tables["Book"].Rows.Count - 1)
                {
                    rowIndex++;
                    DisplayRecord();
                }
            }
        }
        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            if (dsBooks.Tables["Book"].Rows.Count > 0)
            {
                if (rowIndex != 0)
                {
                    rowIndex--;
                    DisplayRecord();
                }
            }
        }
        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            if (dsBooks.Tables["Book"].Rows.Count > 0)
            {
                rowIndex = 0;
                DisplayRecord();
            }
        }
        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            if (dsBooks.Tables["Book"].Rows.Count > 0)
            {
                rowIndex = dsBooks.Tables["Book"].Rows.Count - 1;
                DisplayRecord();
            }
        }
        
        //####### ACTIONS #######
        //Add Function
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            txtBookCode.Clear();
            txtTitle.Clear();
            txtPubCode.Clear();
            txtType.Clear();
            txtPrice.Clear();
            chkPaperback.IsChecked = false;
            updateMode();
            txtBookCode.Focus();
            isNewRow = true;
        }

        //Edit Function
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            updateMode();
            txtBookCode.Focus();
            isNewRow = false;
            dsBooks.Tables["Book"].Rows[rowIndex].BeginEdit();
        }

        //Delete Function
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Delete this book?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    dsBooks.Tables["Book"].Rows[rowIndex].Delete();
                    daBooks.UpdateCommand = builder.GetUpdateCommand(); 
                    daBooks.Update(dsBooks, "Book");
                    if (rowIndex > dsBooks.Tables["Book"].Rows.Count - 1)
                    {
                        rowIndex -= 1;
                    }
                    DisplayRecord();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

       //####### UPDATE #######
       //Save Function
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isNewRow == true)
                {
                    DataRow newRow = dsBooks.Tables["Book"].NewRow();
                    newRow["BookCode"] = txtBookCode.Text;
                    newRow["Title"] = txtTitle.Text;
                    newRow["PublisherCode"] = txtPubCode.Text;
                    newRow["Type"] = txtType.Text;
                    newRow["Price"] = Convert.ToDouble(txtPrice.Text);
                    newRow["Paperback"] = chkPaperback.IsChecked;
                    dsBooks.Tables["Book"].Rows.Add(newRow);
                    rowIndex = dsBooks.Tables["Book"].Rows.Count - 1;
                }
                else
                {
                    dsBooks.Tables["Book"].Rows[rowIndex]["BookCode"] = txtBookCode.Text;
                    dsBooks.Tables["Book"].Rows[rowIndex]["Title"] = txtTitle.Text;
                    dsBooks.Tables["Book"].Rows[rowIndex]["PublisherCode"] = txtPubCode.Text;
                    dsBooks.Tables["Book"].Rows[rowIndex]["Type"] = txtType.Text;
                    dsBooks.Tables["Book"].Rows[rowIndex]["Price"] = Convert.ToDouble(txtPrice.Text);
                    dsBooks.Tables["Book"].Rows[rowIndex]["Paperback"] = chkPaperback.IsChecked;
                    dsBooks.Tables["Book"].Rows[rowIndex].EndEdit();
                }
                daBooks.UpdateCommand = builder.GetUpdateCommand();
                daBooks.Update(dsBooks, "Book");
                viewMode();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: A value you have entered is invalid.");
            }
        }

        //Cancel Function
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            dsBooks.Tables["Book"].Rows[rowIndex].CancelEdit();
            viewMode();
            DisplayRecord();
        }

        //NEW - Opening the Publishers window
        private void btnPublishers_Click(object sender, RoutedEventArgs e)
        {
            //Setting a variable to pass into the new window's constructor
            String bookCode = txtBookCode.Text;
            //Instantiating the Publishers window like a class
            Publishers winPublishers = new Publishers(bookCode, txtPubCode.Text);
            //Displaying the new window
            winPublishers.Show();
        }

        //View and Update Modes
        private void viewMode()
        {
            disableBooks();
            enableNavigation();
            enableActions();
            disableUpdate();
        }
        private void updateMode()
        {
            enableBooks();
            disableNavigation();
            disableActions();
            enableUpdate();
        }

        //####### GRID BOX ALTERNATIVES #######
        //DISABLERS
        private void disableBooks()
        {
            txtBookCode.IsEnabled = false;
            txtTitle.IsEnabled = false;
            txtPubCode.IsEnabled = false;
            txtType.IsEnabled = false;
            txtPrice.IsEnabled = false;
            chkPaperback.IsEnabled = false;
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
            btnAdd.IsEnabled = false;
            btnEdit.IsEnabled = false;
            btnDelete.IsEnabled = false;
        }
        private void disableUpdate()
        {
            btnSave.IsEnabled = false;
            btnCancel.IsEnabled = false;
        }

        //ENABLERS
        private void enableBooks()
        {
            txtBookCode.IsEnabled = true;
            txtTitle.IsEnabled = true;
            txtPubCode.IsEnabled = true;
            txtType.IsEnabled = true;
            txtPrice.IsEnabled = true;
            chkPaperback.IsEnabled = true;
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
            btnAdd.IsEnabled = true;
            btnEdit.IsEnabled = true;
            btnDelete.IsEnabled = true;
        }
        private void enableUpdate()
        {
            btnSave.IsEnabled = true;
            btnCancel.IsEnabled = true;
        }
    }
}
