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
using GroupProject.Items;
using GroupProject.Search;

namespace GroupProject.Main
{
    /// <summary>
    /// Interaction logic for wndMain.xaml
    /// </summary>
    public partial class wndMain : Window
    {
        public wndMain()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Basic function to open Search window will update to proper display later
        /// </summary>
        /// <param name="sender">Comes from search menu button</param>
        /// <param name="e"></param>
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            wndSearch wnd = new wndSearch();
            wnd.ShowDialog();
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
            this.Show();
        }
    }
}
