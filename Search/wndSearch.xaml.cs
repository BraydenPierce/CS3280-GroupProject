using GroupProject.Common;
using GroupProject.Items;
using GroupProject.Main;
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

namespace GroupProject.Search
{
    /// <summary>
    /// Interaction logic for wndSearch.xaml
    /// </summary>
    public partial class wndSearch : Window
    {
        #region Properties/Variables
        /// <summary>
        /// Public property for the sSelectedInvoiceID
        /// </summary>
        public string SelectedInvoiceID { get; set; } = "0";
        /// <summary>
        /// Local variable for the clsSearchLogic class
        /// </summary>
        clsSearchLogic clsSearchLogic = new clsSearchLogic();
        /// <summary>
        /// Local InvoiceNumber property so we can pass into GetInvoices();
        /// </summary>
        string InvoiceNumber = null;
        /// <summary>
        /// Local InvoiceDate property so we can pass into GetInvoices();
        /// </summary>
        string InvoiceDate = null;
        /// <summary>
        /// Local TotalCost property so we can pass into GetInvoices();
        /// </summary>
        string TotalCost = null;
        /// <summary>
        /// Creating a bool so we don't have an infinite loop updating the comboBox display
        /// </summary>
        bool updatingComboBox = false;
        #endregion

        public wndSearch()
        {
            try
            {
                InitializeComponent();
                //Assigning all the combo boxes
                //Had to do a round-about way to display the invoice numbers due to not being able to override the ToString() method for Invoice number, date, and cost
                invoiceNumberCB.ItemsSource = clsSearchLogic.getDistinctInvoiceNumber();
                invoiceNumberCB.DisplayMemberPath = "DisplayInvoiceNumber";
                invoiceDateCB.ItemsSource = clsSearchLogic.getDistinctInvoiceDates();
                invoiceDateCB.DisplayMemberPath = "DisplayInvoiceDate";
                totalCostsCB.ItemsSource = clsSearchLogic.getDistinctInvoiceCosts();
                totalCostsCB.DisplayMemberPath = "DisplayInvoiceCost";
                //Assigning Data Grid
                invoicesDG.ItemsSource = clsSearchLogic.GetAllInvoices();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// This will assign SelectedInvoiceID so main can access that data, close this window, and open up main
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception"></exception>
        private void selectInvoiceBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Assigning SelectedInvoiceID to the correct number
                if (invoiceNumberCB.SelectedItem is clsInvoice selectedInvoice)
                {
                    SelectedInvoiceID = selectedInvoice.sInvoiceNumber;
                }
                if (invoicesDG.SelectedItem is clsInvoice clsMyInvoice)
                {
                    SelectedInvoiceID = clsMyInvoice.sInvoiceNumber;
                }
                else
                {
                    SelectedInvoiceID = "0";
                }



                //Hide current opened window
                this.Hide();
                //Show the main window
                wndMain mainWindow = new wndMain();
                mainWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// This button will reset the Data Grid, Combo Boxes, and SelectedInvoiceID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception"></exception>
        private void clearFilterBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                updatingComboBox = true;

                //Reset SelectedInvoiceID
                SelectedInvoiceID = "0";
                //Reset local values to null
                InvoiceNumber = null;
                InvoiceDate = null;
                TotalCost = null;
                //Reset Data Grid
                invoicesDG.ItemsSource = clsSearchLogic.GetAllInvoices();
                //Reset combo boxes
                invoiceNumberCB.ItemsSource = clsSearchLogic.getDistinctInvoiceNumber();
                invoiceNumberCB.DisplayMemberPath = "DisplayInvoiceNumber";
                invoiceDateCB.ItemsSource = clsSearchLogic.getDistinctInvoiceDates();
                invoiceDateCB.DisplayMemberPath = "DisplayInvoiceDate";
                totalCostsCB.ItemsSource = clsSearchLogic.getDistinctInvoiceCosts();
                totalCostsCB.DisplayMemberPath = "DisplayInvoiceCost";

                updatingComboBox = false;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }
        /// <summary>
        /// Will do everything the clear filter does. However, this will close the window and open up the main window as well
        /// It will reset data grid, combo boxes, and SelectedInvoiceID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception"></exception>
        private void cancelBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Reset SelectedInvoiceID
                SelectedInvoiceID = "0";
                //Reset local values to null
                InvoiceNumber = null;
                InvoiceDate = null;
                TotalCost = null;
                //Reset Data Grid
                invoicesDG.ItemsSource = clsSearchLogic.GetAllInvoices();
                //Reset combo boxes
                invoiceNumberCB.ItemsSource = clsSearchLogic.getDistinctInvoiceNumber();
                invoiceNumberCB.DisplayMemberPath = "DisplayInvoiceNumber";
                invoiceDateCB.ItemsSource = clsSearchLogic.getDistinctInvoiceDates();
                invoiceDateCB.DisplayMemberPath = "DisplayInvoiceDate";
                totalCostsCB.ItemsSource = clsSearchLogic.getDistinctInvoiceCosts();
                totalCostsCB.DisplayMemberPath = "DisplayInvoiceCost";

                //Hide current opened window
                this.Hide();
                //Show the main window
                wndMain mainWindow = new wndMain();
                mainWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// When the invoice number selection is changed we will assign the InvoiceNumber, update the combo boxes to have all invoices with that number, and update the data grid with all invoices with that number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception"></exception>
        private void invoiceNumberCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //Using bool to prevent infinite loop
                if (updatingComboBox) return;

                //Assign InvoiceNumber
                if (invoiceNumberCB.SelectedItem is clsInvoice selectedInvoice)
                {
                    InvoiceNumber = selectedInvoice.sInvoiceNumber;
                }
                //Using bool to prevent infinite loop
                updatingComboBox = true;

                //Updating Combo boxes
                invoiceNumberCB.ItemsSource = clsSearchLogic.GetInvoices(InvoiceNumber, InvoiceDate, TotalCost);
                invoiceNumberCB.DisplayMemberPath = "DisplayInvoiceNumber";
                invoiceNumberCB.SelectedValuePath = "sInvoiceNumber";
                invoiceNumberCB.SelectedValue = InvoiceNumber;
                invoiceDateCB.ItemsSource = clsSearchLogic.GetInvoices(InvoiceNumber, InvoiceDate, TotalCost);
                invoiceDateCB.DisplayMemberPath = "DisplayInvoiceDate";
                invoiceDateCB.SelectedValuePath = "sInvoiceDate";
                invoiceDateCB.SelectedValue = InvoiceDate;
                totalCostsCB.ItemsSource = clsSearchLogic.GetInvoices(InvoiceNumber, InvoiceDate, TotalCost);
                totalCostsCB.DisplayMemberPath = "DisplayInvoiceCost";
                totalCostsCB.SelectedValuePath = "sInvoiceCost";
                totalCostsCB.SelectedValue = TotalCost;
                //Update Data Grid to have the specific invoice number on the list
                invoicesDG.ItemsSource = clsSearchLogic.GetInvoices(InvoiceNumber, InvoiceDate, TotalCost);
                //Using bool to prevent infinite loop
                updatingComboBox = false;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// When the invoice date selection is changed we will assign the InvoiceDate, update the combo boxes to have all invoices with that date, and update the data grid with all invoices with that date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception"></exception>
        private void invoiceDateCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //Using bool to prevent infinite loop
                if (updatingComboBox) return;

                //Assign InvoiceNumber
                //Assign InvoiceDate
                if (invoiceDateCB.SelectedItem is clsInvoice selectedInvoice)
                {
                    InvoiceDate = selectedInvoice.sInvoiceDate;
                }
                //Using bool to prevent infinite loop
                updatingComboBox = true;

                //Updating Combo boxes
                invoiceNumberCB.ItemsSource = clsSearchLogic.GetInvoices(InvoiceNumber, InvoiceDate, TotalCost);
                invoiceNumberCB.DisplayMemberPath = "DisplayInvoiceNumber";
                invoiceNumberCB.SelectedValuePath = "sInvoiceNumber";
                invoiceNumberCB.SelectedValue = InvoiceNumber;
                invoiceDateCB.ItemsSource = clsSearchLogic.GetInvoices(InvoiceNumber, InvoiceDate, TotalCost);
                invoiceDateCB.DisplayMemberPath = "DisplayInvoiceDate";
                invoiceDateCB.SelectedValuePath = "sInvoiceDate";
                invoiceDateCB.SelectedValue = InvoiceDate;
                totalCostsCB.ItemsSource = clsSearchLogic.GetInvoices(InvoiceNumber, InvoiceDate, TotalCost);
                totalCostsCB.DisplayMemberPath = "DisplayInvoiceCost";
                totalCostsCB.SelectedValuePath = "sInvoiceCost";
                totalCostsCB.SelectedValue = TotalCost;
                //Update Data Grid to have the specific invoice number on the list
                invoicesDG.ItemsSource = clsSearchLogic.GetInvoices(InvoiceNumber, InvoiceDate, TotalCost);
                //Using bool to prevent infinite loop
                updatingComboBox = false;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// When the cost selection is changed we will assign the TotalCost, update the combo boxes to have all invoices with that cost, and update the data grid with all invoices with that cost
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception"></exception>
        private void totalCostsCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //Using bool to prevent infinite loop
                if (updatingComboBox) return;

                //Assign TotalCost
                if (totalCostsCB.SelectedItem is clsInvoice selectedInvoice)
                {
                    TotalCost = selectedInvoice.sInvoiceCost;
                }
                //Using bool to prevent infinite loop
                updatingComboBox = true;

                //Updating Combo boxes
                invoiceNumberCB.ItemsSource = clsSearchLogic.GetInvoices(InvoiceNumber, InvoiceDate, TotalCost);
                invoiceNumberCB.DisplayMemberPath = "DisplayInvoiceNumber";
                invoiceNumberCB.SelectedValuePath = "sInvoiceNumber";
                invoiceNumberCB.SelectedValue = InvoiceNumber;
                invoiceDateCB.ItemsSource = clsSearchLogic.GetInvoices(InvoiceNumber, InvoiceDate, TotalCost);
                invoiceDateCB.DisplayMemberPath = "DisplayInvoiceDate";
                invoiceDateCB.SelectedValuePath = "sInvoiceDate";
                invoiceDateCB.SelectedValue = InvoiceDate;
                totalCostsCB.ItemsSource = clsSearchLogic.GetInvoices(InvoiceNumber, InvoiceDate, TotalCost);
                totalCostsCB.DisplayMemberPath = "DisplayInvoiceCost";
                totalCostsCB.SelectedValuePath = "sInvoiceCost";
                totalCostsCB.SelectedValue = TotalCost;
                //Update Data Grid to have the specific invoice number on the list
                invoicesDG.ItemsSource = clsSearchLogic.GetInvoices(InvoiceNumber, InvoiceDate, TotalCost);
                //Using bool to prevent infinite loop
                updatingComboBox = false;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// When an invoice from the Data Grid is selected we are going to assign the InvoiceNumber so when the invoice is selected it will pass over to Main
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception"></exception>
    }
}
/*
    Note: The main window can access SelectedInvoiceID with the following code:
            wnd.SelectedInvoiceID
    For example, if you wanted to show a dialog box with the SelectedInvoiceID you can do this IN wndMain.xaml.cs:
                    MessageBox.Show($"You selected Invoice ID: {wnd.SelectedInvoiceID}", "Invoice Selected", MessageBoxButton.OK, MessageBoxImage.Information);
*/