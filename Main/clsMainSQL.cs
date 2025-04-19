using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        public static string AddLineItem(clsItem item, string invoiceNum, int idx)
        {
            try
            {
                string SQL = "INSERT INTO LineItems(InvoiceNum, LineItemNum, ItemCode) Values( " + invoiceNum + ", " + idx.ToString() + ", '" + item.ItemCode + "')";
                return SQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        
        /// <summary>
        /// Updates Invoice total cost based off of updated price in class 
        /// </summary>
        /// <param name="invoice">Passed in class with already updated total</param>
        /// <returns>returns string to update the total cost of the invoice</returns>
        public static string UpdateInvoiceCost(clsInvoice invoice)
        {           
            try
            {
                string SQL = "UPDATE Invoices SET TotalCost = " + invoice.sInvoiceCost + " WHERE InvoiceNum = " + invoice.sInvoiceNumber;
                return SQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        
        /// <summary>
        /// Adds a new invoice to the database
        /// </summary>
        /// <param name="Cost">Total cost as passed in</param>
        /// <returns></returns>
        public static string AddNewInvoice(string date, string cost)
        {            
            try
            {
                string SQL = "INSERT INTO Invoices(InvoiceDate, TotalCost) Values(#" + date + "#," + cost + ")";
                return SQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Gets Invoice based off of Invoice 
        /// </summary>
        /// <param name="invoiceNum">Invoice number passed in</param>
        /// <returns></returns>
        public static string GetInvoice(int invoiceNum)
        {           
            try
            {
                string SQL = "SELECT InvoiceNum, InvoiceDate, TotalCost FROM Invoices WHERE InvoiceNum = " + invoiceNum;
                return SQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Gets all items from database
        /// </summary>
        /// <returns>returns string to select all items from database.</returns>
        public static string GetItem()
        {           
            try
            {
                string SQL = "SELECT ItemCode, ItemDesc, Cost from ItemDesc";
                return SQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Used to link Invoice and items together 
        /// </summary>
        /// <param name="invoiceNum">invoice number passed in by the user</param>
        /// <returns>returns string to check LineItems based off of Invoice Number passed in and Item ID passed in.</returns>
        public static string CheckLineItems(int invoiceNum)
        {          
            try
            {
                string SQL = "SELECT LineItems.ItemCode, ItemDesc.ItemDesc, ItemDesc.Cost FROM LineItems, ItemDesc Where LineItems.ItemCode = ItemDesc.ItemCode And LineItems.InvoiceNum = " + invoiceNum.ToString();
                return SQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Removes appropriate line items from database based off of invoice number
        /// </summary>
        /// <param name="invoiceNum">invoice number passed in by the user</param>
        /// <returns>string to delete appropriate lineitem rows</returns>
        public static string RemoveLineItems(int invoiceNum)
        {
            try
            {
                string SQL = "DELETE FROM LineItems WHERE InvoiceNum = " + invoiceNum;
                return SQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Grabs invoice number based off of max to find newest created invoice
        /// </summary>
        /// <returns>Returns invoice number of most recently created invoice</returns>
        public static string RetrieveInvoiceNum()
        {           
            try
            {
                string SQL = "SELECT MAX(InvoiceNum) FROM Invoices";
                return SQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

    }
}
