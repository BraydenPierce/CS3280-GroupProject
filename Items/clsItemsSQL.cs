using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Items
{
    class clsItemsSQL
    {
        /// <summary>
        /// Returns the sql string needed to query all items
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string GetItems()
        {
            try
            {
                string sSQL = "SELECT ItemCode, ItemDesc, Cost FROM ItemDesc";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Returns the sql string needed to query all items for a specific invoice
        /// </summary>
        /// <param name="itemCode"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string GetInvoiceItems(string itemCode)
        {
            try
            {
                string sSQL = "select distinct(InvoiceNum) from LineItems where ItemCode = '" + itemCode + "'";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Returns the sql string needed to update an item
        /// </summary>
        /// <param name="itemDesc"></param>
        /// <param name="cost"></param>
        /// <param name="itemCode"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string GetUpdateItem(string itemDesc, string cost, string itemCode)
        {
            try
            {
                // TODO: set dynamic values
                string sSQL = "Update ItemDesc Set ItemDesc = '" + itemDesc + "', Cost = " + cost + " where ItemCode = '" + itemCode + "'";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Returns the sql string needed to insert an item
        /// </summary>
        /// <param name="itemDesc"></param>
        /// <param name="cost"></param>
        /// <param name="itemCode"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string GetInsertItem(string itemDesc, string cost, string itemCode)
        {
            try
            {
                // TODO: set dynamic values
                string sSQL = "Insert into ItemDesc (ItemCode, ItemDesc, Cost) Values ('" + itemCode + "', '" + itemDesc + "', " + cost + ")";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Returns the sql string needed to delete an item
        /// </summary>
        /// <param name="itemCode"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string GetDeleteItem(string itemCode)
        {
            try
            {
                // TODO: set dynamic values
                string sSQL = "Delete from ItemDesc Where ItemCode = '" + itemCode + "'";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
