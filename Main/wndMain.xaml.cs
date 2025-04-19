using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using GroupProject.Common;
using GroupProject.Items;
using GroupProject.Search;

namespace GroupProject.Main
{
    /// <summary>
    /// Interaction logic for wndMain.xaml
    /// </summary>
    public partial class wndMain : Window
    {
        /// <summary>
        /// Used to initilaze logic class for holding invoices and running any neccessary logic
        /// </summary>
        clsMainLogic logic = new clsMainLogic();

        /// <summary>
        /// Bool to see if the invoice is a new one being added
        /// </summary>
        bool newInvoice = false;

        /// <summary>
        /// Bool to determine if editing on the current invoice is allowed
        /// </summary>
        bool editInvoice = false;

        /// <summary>
        /// Used to determine the invoice number
        /// </summary>
        int editingInvoiceNum = 0;

        public wndMain()
        {
            try
            {
                InitializeComponent();
                ///Gets list of all current items from database to store in combobox
                boxItems.ItemsSource = logic.GetAllItems();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Basic function to open Search window that allows users to search through invoices and return an invoice number if they choose to edit it.
        /// </summary>
        /// <param name="sender">Comes from search menu button</param>
        /// <param name="e"></param>
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ///Checks to see if user is currently editing a new invoice and confirms they wish to leave if they are
                if (newInvoice == true)
                {
                    MessageBoxResult res = MessageBox.Show("Unsave invoice may be deleted are you sure you wish to change windows?", "Unsaved Changes", MessageBoxButton.YesNo);
                    if (res == MessageBoxResult.No)
                    {
                        return;
                    }
                }


                ///Opens new search window so the user can sort through invoices
                this.Hide();
                wndSearch wnd = new wndSearch();
                wnd.ShowDialog();

                ///Converts passed invoiceID into integer
                editingInvoiceNum = Convert.ToInt32(wnd.SelectedInvoiceID);

                ///Checks to see if any invoice ID has been passed back and prepares displays to show properly if one has been
                if (editingInvoiceNum > 0)
                {
                    logic.GetInvoice(editingInvoiceNum);
                    grdInvoiceItems.ItemsSource = logic.ReturnInvoiceItems();
                    btnEdit.IsEnabled = true;
                    lblCostDisplay.Content = logic.updateCost();
                    lblNumDisplay.Content = editingInvoiceNum.ToString();
                    dateSelector.IsEnabled = false;
                }

                ///Shows window after previous window has been closed
                this.Show();
            }
            

            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Basic function to open Edit Items window will update to proper display later
        /// </summary>
        /// <param name="sender">Comes from edit items menu button</param>
        /// <param name="e"></param>
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Hide();
                wndItems wnd = new wndItems();
                wnd.ShowDialog();

                ///updates item combo box after edit window is closed in case any new items are added or any are deleted. 
                boxItems.ItemsSource = logic.GetAllItems();
                this.Show();
            }         

            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }


        /// <summary>
        /// Updates item cost label based off of what new item was selected from the combo box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void boxItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                lblItemCost.Content = "$" + logic.updateItemCost(boxItems.SelectedIndex);
            }

            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Creates a new invoice object to be modified by the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ///Enables and disables proper buttons for new invoice to be created
                btnAddInvoice.IsEnabled = false;
                btnEdit.IsEnabled = false;
                btnSaveInvoice.IsEnabled = true;
                btnAddItem.IsEnabled = true;

                ///Displays temporary cost and invoice num while user is creating invoice
                lblNumDisplay.Content = "TBD";
                lblCostDisplay.Content = "$0";

                ///Enables datepicker so that user may now select date for new invoice
                dateSelector.IsEnabled = true;
                dateSelector.DisplayDate = DateTime.Now;

                ///Allows for editing of new invoice and show that current invoice is a newly created one
                newInvoice = true;
                editInvoice = true;

                ///Runs logic for creating new invoice
                logic.AddInvoice();
            }      

            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Adds item to current invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ///Runs logic to add item to invoice
                logic.AddItemToInvoice(boxItems.SelectedIndex);

                ///Updates grid with new list of items on invoice
                grdInvoiceItems.ItemsSource = null;
                grdInvoiceItems.ItemsSource = logic.ReturnInvoiceItems();

                ///Updates total cost to new total cost
                lblCostDisplay.Content = "$" + logic.updateCost();
            }           

            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Saves invoice based off of currently displayed items and selected date if it's a new invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ///Checks to see if the invoice is new or not
                if (newInvoice == true)
                {
                    ///Uses selected date if user has chosen one
                    if (dateSelector.SelectedDate.HasValue)
                    {
                        editingInvoiceNum = logic.SaveNewInvoice(dateSelector.SelectedDate.Value.ToString("MM/dd/yyyy"));
                    }
                    ///Defaults to current date if user hasn't selected any
                    else
                    {
                        editingInvoiceNum = logic.SaveNewInvoice(DateTime.Now.ToString("MM/dd/yyyy"));
                    }

                    ///Updates invoice number display to newly created invoices number
                    lblNumDisplay.Content = editingInvoiceNum.ToString();
                }
                ///Saves invoice over old invoice
                else
                {
                    logic.EditInvoice(editingInvoiceNum);
                }
                ///Enables and disables buttons properly after invoice is saved
                btnSaveInvoice.IsEnabled = false;
                btnAddInvoice.IsEnabled = true;
                btnEdit.IsEnabled = true;
                btnAddItem.IsEnabled = false;
                btnRemoveItem.IsEnabled = false;

                ///disables these two options to ensure invoice can no longer be edited and won't be double saved.
                newInvoice = false;
                editInvoice = false;
            }           

            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Enables editing of invoice when pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ///Enables and disables proper buttons
                btnAddInvoice.IsEnabled = false;
                btnEdit.IsEnabled = false;
                btnSaveInvoice.IsEnabled = true;
                btnAddItem.IsEnabled = true;

                ///Sets editInvoice to true to allow for removal and addition of items
                editInvoice = true;
            }

            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Removes selected item when button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ///Removes item from invoice
                logic.RemoveItem(grdInvoiceItems.SelectedIndex);

                ///Renables all buttons and updates grid with proper items and new total cost
                btnRemoveItem.IsEnabled = false;
                grdInvoiceItems.ItemsSource = null;
                grdInvoiceItems.ItemsSource = logic.ReturnInvoiceItems();
                lblCostDisplay.Content = "$" + logic.updateCost();
            }

            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Enables remove button item if the selections is changed in the grid and editing is enabled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdInvoiceItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ///Checks to makes sure that editing is enabled and a selection is made before remove button is rehighlighted
                if (grdInvoiceItems.SelectedItems.Count > 0 && editInvoice == true)
                {
                    btnRemoveItem.IsEnabled = true;
                }
            }
            
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Handles error message displays from try and catch statements
        /// </summary>
        /// <param name="sClass">Used to display what class the exception came from</param>
        /// <param name="sMethod">Used to display what method the exception came from</param>
        /// <param name="sMessage">Used to display exactly what exception has been met</param>
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory.ToString() + "/error.txt", Environment.NewLine + "HandleError Exception " + ex.Message);
            }
        }
    }
}
