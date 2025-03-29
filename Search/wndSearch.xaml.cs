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
        //sSelectedInvoiceID - Holds the invoice ID if the user selected one, and zero if no invoice is selected
        //Data will be passed around with the following property that the main window can access:
            //SelectedInvoiceID - Property main window can access to get the selected invoice ID

        #region Properties
        /// <summary>
        /// Public property for the sSelectedInvoiceID
        /// </summary>
        public string SelectedInvoiceID {  get; set; }
        #endregion

        public wndSearch()
        {
            InitializeComponent();
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

            //When SelectInvoiceBTN is pressed the invoice number will be passed to main as SelectedInvoiceID (see comments at top)
            //When SelectInvoiceBTN is pressed we will update/refresh the form main when the window is closed
        }
    }
}
