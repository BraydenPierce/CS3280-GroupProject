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
using GroupProject.Common;

namespace GroupProject.Items
{
    /// <summary>
    /// Interaction logic for wndItems.xaml
    /// </summary>
    public partial class wndItems : Window
    {
        /// <summary>
        /// clsItemsLogic instance to use Logic class
        /// </summary>
        clsItemsLogic itemsLogic = new clsItemsLogic();
        public wndItems()
        {
            InitializeComponent();
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
                //INSTRUCTOR NOTE: Cast into a clsItem, that is why you created the clsItem class and
                //used a List<clsItem> objects to bind to the DataGrid to display items
                if (dgItems.SelectedItem is clsItem clsMyItem)
                {
                    tbCode.Text = clsMyItem.ItemCode;
                    tbCost.Text = clsMyItem.Cost.ToString();
                    tbDescription.Text = clsMyItem.ItemDesc;
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
                if (tbCode.Text != "" && tbCost.Text != "" && tbDescription.Text != "")
                {
                    // Call the AddItem method from clsItemsLogic method, which then calls clsItemsSQL method
                    // Used with currently entered textbox values.
                    itemsLogic.AddItem(tbDescription.Text, tbCost.Text, tbCode.Text);

                    // Item as been added
                    bHasItemsBeenChanged = true;
                    Refresh();
                }
                else
                {
                    lblStatus.Content = "Please fill all text boxes";
                }
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
                // Call the UpdateItem method from clsItemsLogic method, which then calls clsItemsSQL method
                // Used with currently entered textbox values.
                itemsLogic.UpdateItem(tbDescription.Text, tbCode.Text, tbCode.Text);

                // Item has been edited.
                bHasItemsBeenChanged = true;
                Refresh();
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
                // Get currently selecteditem
                clsItem selectedItem = (clsItem)dgItems.SelectedItem;

                // Call the DeleteItem from clsItemsLogic method, which then calls clsItemsSQL method
                itemsLogic.DeleteItem(selectedItem.ItemCode);

                // Item has been deleted
                bHasItemsBeenChanged = true;
                Refresh();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                         MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Empties textboxes and updates the datagrid
        /// </summary>
        private void Refresh()
        {
            tbCode.Text = "";
            tbCost.Text = "";
            tbDescription.Text = "";
            lblStatus.Content = "";
            dgItems.ItemsSource = itemsLogic.GetItems();

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
