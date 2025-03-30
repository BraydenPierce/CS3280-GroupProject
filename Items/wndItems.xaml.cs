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
        }

        //bool bHasItemsBeenChanged;     //Set to true when an item has been added/edited/deleted.   Used by main window to know if needs to refresh items list
        //bool HasItemsBeenChanged;     //Property

        /// <summary>
        /// Click handler for the "Add Item" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            return;
        }

        /// <summary>
        /// Click handler for the "Edit Item" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditItem_Click(object sender, RoutedEventArgs e)
        {
            return;
        }

        /// <summary>
        /// Click handler for the "Delete Item" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            return;
        }
    }
}
