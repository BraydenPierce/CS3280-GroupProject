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
        clsMainLogic logic = new clsMainLogic();

        bool newInvoice = false;

        bool editInvoice = false;

        int editingInvoiceNum = 0;

        public wndMain()
        {
            InitializeComponent();
            boxItems.ItemsSource = logic.GetAllItems();
        }
        
        /// <summary>
        /// Basic function to open Search window that allows users to search through invoices and return an invoice number if they choose to edit it.
        /// </summary>
        /// <param name="sender">Comes from search menu button</param>
        /// <param name="e"></param>
        private void Search_Click(object sender, RoutedEventArgs e)
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

            ///Sets previous invoice number for if statement
            int oldInvoiceNum = editingInvoiceNum;
            this.Hide();
            wndSearch wnd = new wndSearch();
            wnd.ShowDialog();

            ///Checks to see if a new invoice number was passed in and updates information if it was
            if (oldInvoiceNum != editingInvoiceNum)
            {
                btnEdit.IsEnabled = true;
                btnAddInvoice.IsEnabled = true;
                btnSaveInvoice.IsEnabled = false;
                dateSelector.IsEnabled = false;
                clsInvoice temp = logic.GetInvoice(editingInvoiceNum);
                dateSelector.DisplayDate = Convert.ToDateTime(temp.DisplayInvoiceDate);
            }
            this.Show();
        }

        /// <summary>
        /// Basic function to open Edit Items window will update to proper display later
        /// </summary>
        /// <param name="sender">Comes from edit items menu button</param>
        /// <param name="e"></param>
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            wndItems wnd = new wndItems();
            wnd.ShowDialog();

            ///updates item combo box after edit window is closed in case any new items are added or any are deleted. 
            boxItems.ItemsSource = logic.GetAllItems();
            this.Show();
        }


        /// <summary>
        /// Updates item cost label based off of what new item was selected from the combo box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void boxItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblItemCost.Content = "$" + logic.updateItemCost(boxItems.SelectedIndex);
        }
        /// <summary>
        /// Creates a new invoice object to be modified by the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddInvoice_Click(object sender, RoutedEventArgs e)
        {
            btnAddInvoice.IsEnabled = false;
            btnEdit.IsEnabled = false;
            btnSaveInvoice.IsEnabled = true;
            lblNumDisplay.Content = "TBD";
            lblCostDisplay.Content = "$0";
            dateSelector.IsEnabled = true;
            dateSelector.DisplayDate = DateTime.Now;
            btnAddItem.IsEnabled = true;
            newInvoice = true;
            editInvoice = true;
            logic.AddInvoice();
        }
        /// <summary>
        /// Adds item to current invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            logic.AddItemToInvoice(boxItems.SelectedIndex);
            grdInvoiceItems.ItemsSource = null;
            grdInvoiceItems.ItemsSource = logic.ReturnInvoiceItems();
            lblCostDisplay.Content = "$" + logic.updateCost();
        }

        /// <summary>
        /// Saves invoice based off of currently displayed items and selected date if it's a new invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveInvoice_Click(object sender, RoutedEventArgs e)
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

        /// <summary>
        /// Enables editing of invoice when pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        { 
            ///Enables and disables proper buttons
            btnAddInvoice.IsEnabled = false;
            btnEdit.IsEnabled = false;
            btnSaveInvoice.IsEnabled = true;
            btnAddItem.IsEnabled = true;

            ///Sets editInvoice to true to allow for removal and addition of items
            editInvoice = true;
        }

        /// <summary>
        /// Removes selected item when button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveItem_Click(object sender, RoutedEventArgs e)
        {
            ///Removes item from invoice
            logic.RemoveItem(grdInvoiceItems.SelectedIndex);

            ///Renables all buttons and updates grid with proper items and new total cost
            btnRemoveItem.IsEnabled = false;
            grdInvoiceItems.ItemsSource = null;
            grdInvoiceItems.ItemsSource = logic.ReturnInvoiceItems();
            lblCostDisplay.Content = "$" + logic.updateCost();
        }

        /// <summary>
        /// Enables remove button item if the selections is changed in the grid and editing is enabled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdInvoiceItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(grdInvoiceItems.SelectedItems.Count > 0 && editInvoice == true)
            {
                btnRemoveItem.IsEnabled = true;
            }     
        }
    }
}
