using GroupProject.Common;
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

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        private void clearFilterBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
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

        private void selectInvoiceBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Assigning SelectedInvoiceID to the correct number
                if (invoiceNumberCB.SelectedItem is clsInvoice selectedInvoice)
                {
                    SelectedInvoiceID = selectedInvoice.sInvoiceNumber;
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

            //When SelectInvoiceBTN is pressed we will update/refresh the form main when the window is closed

            /*
                Note: The main window can access SelectedInvoiceID with the following code:
                        wnd.SelectedInvoiceID
                For example, if you wanted to show a dialog box with the SelectedInvoiceID you can do this IN wndMain.xaml.cs:
                                MessageBox.Show($"You selected Invoice ID: {wnd.SelectedInvoiceID}", "Invoice Selected", MessageBoxButton.OK, MessageBoxImage.Information);}
            */
        }
    }
}
