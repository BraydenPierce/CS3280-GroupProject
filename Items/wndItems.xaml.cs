using System;
using System.Collections.Generic;
using System.Data;
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

namespace GroupProject.Items
{
    /// <summary>
    /// Interaction logic for wndItems.xaml
    /// </summary>
    public partial class wndItems : Window
    {
        public wndItems()
        {
            InitializeComponent();
            clsItemsLogic itemsLogic = new clsItemsLogic();
            dgItems.ItemsSource = itemsLogic.GetItems();
        }

        /// <summary>
        /// Set to true when an item has been added/edited/deleted. Used by main window to know if needs to refresh items list
        /// </summary>
        private bool bHasItemsBeenChanged = false;

        /// <summary>
        /// get/set for bHasItemsBeenChanged. Set to true when an item has been added/edited/deleted. 
        /// Used by main window to know if needs to refresh items list
        /// </summary>
        public bool HasItemsBeenChanged
        {
            get { return bHasItemsBeenChanged; }
            set { bHasItemsBeenChanged = value; }
        }

        private void dgItems_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                //TODO: Fix, this code doesnt work
                if (dgItems.SelectedItem is DataRowView selectedRow)
                {
                    tbCode.Text = selectedRow["ItemCode"].ToString();
                    tbCost.Text = selectedRow["Cost"].ToString();
                    tbDescription.Text = selectedRow["ItemDesc"].ToString();
                }

                btnEditItem.IsEnabled = true;
                btnDeleteItem.IsEnabled = true;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                         MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Click handler for the "Add Item" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                return;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                         MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Click handler for the "Edit Item" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                return;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                         MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Click handler for the "Delete Item" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                return;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                         MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Top level error handler
        /// </summary>
        /// <param name="sClass"></param>
        /// <param name="sMethod"></param>
        /// <param name="sMessage"></param>
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine +
                                            "HandleError Exception: " + ex.Message);
            }
        }
    }
}
