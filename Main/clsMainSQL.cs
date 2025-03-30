using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using GroupProject.Common;

namespace GroupProject.Main
{
    internal class clsMainSQL
    {
        /// <summary>
        /// Adds Item into LineItems based off of item and invoice information passed in
        /// </summary>
        /// <param name="item">Item ID passed in</param>
        /// <param name="invoiceNum">Invoice number passed in</param>
        /// <returns>returns string to insert new lineitem into LineItems</returns>
        public static string AddItem(string item, int invoiceNum)
        {
            //Will update to non default values for final project
            string SQL = "INSERT INTO LineItems(InvoiceNum, LineItemNum, ItemCode) Values( 123, 1, 'AA')";
            return SQL;
        }
        
        /// <summary>
        /// Updates Invoice total cost based off of updated price in class 
        /// </summary>
        /// <param name="invoice">Passed in class with already updated total</param>
        /// <returns>returns string to update the total cost of the invoice</returns>
        public static string UpdateInvoiceCost(clsInvoice invoice)
        {
            //Will update to non default values for final project
            string SQL = "UPDATE Invoices SET TotalCost = 1200 WHERE InvoiceNum = 123";
            return SQL;
        }
        
        /// <summary>
        /// Updates Invoice Date to current date and updates it's total cost
        /// </summary>
        /// <param name="Cost">Total cost as passed in</param>
        /// <returns></returns>
        public static string UpdateInvoiceDateCost(double Cost)
        {
            //Will update to non default values for final project
            string SQL = "INSERT INTO Invoices(InvoiceDate, TotalCost) Values(#4/13/2018#, 100)";
            return SQL;
        }

        /// <summary>
        /// Gets Invoice based off of Invoice 
        /// </summary>
        /// <param name="invoiceNum">Invoice number passed in</param>
        /// <returns></returns>
        public static string GetInvoice(int invoiceNum)
        {
            string SQL = "SELECT InvoiceNum, InvoiceDate, TotalCost FROM Invoices WHERE InvoiceNum = " + invoiceNum;
            return SQL;
        }

        /// <summary>
        /// Gets item based off of item class passed in.
        /// </summary>
        /// <param name="item">Uses item object to get item information</param>
        /// <returns>returns string to select item matching item information.</returns>
        public static string GetItem(clsItem item)
        {
            //Will update to non default values for final project
            string SQL = "select ItemCode, ItemDesc, Cost from ItemDesc";
            return SQL;
        }

        /// <summary>
        /// Used to link Invoice and items together 
        /// </summary>
        /// <returns>returns string to check LineItems based off of Invoice Number passed in and Item ID passed in.</returns>
        public static string CheckLineItems()
        {
            //Will update to non default values for final project
            string SQL = "SELECT LineItems.ItemCode, ItemDesc.ItemDesc, ItemDesc.Cost FROM LineItems, ItemDesc Where LineItems.ItemCode = ItemDesc.ItemCode And LineItems.InvoiceNum = 5000";
            return SQL;
        }

        /// <summary>
        /// Removes appropriate line items from database based off of invoice number
        /// </summary>
        /// <param name="invoiceNum">invoice number passed in by the user</param>
        /// <returns>string to delete appropriate lineitem rows</returns>
        public static string RemoveLineItems(int invoiceNum)
        {
            string SQL = "DELETE FROM LineItems WHERE InvoiceNum = " + invoiceNum;
            return SQL;
        }

    }
}
