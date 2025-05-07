using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace GroupProject.Search
{
    class clsSearchSQL
    {
        /// <summary>
        /// This SQL returns a string to get all the invoices
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string GetInvoices()
        {
            try
            {
                string sSQL = "SELECT * FROM Invoices";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// This returns the invoice information with a specific invoice number and integer
        /// </summary>
        /// <param name="InvoiceNum"></param>
        /// <param name="integer"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string GetInvoiceFromNum(string integer)
        {
            try
            {
                string sSQL = "SELECT * FROM Invoices WHERE InvoiceNum = " + integer + "";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// This SQL returns all invoices with: A specific number and date
        /// </summary>
        /// <param name="InvoiceNum"></param>
        /// <param name="InvoiceDate"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string GetInvoiceFromNumAndDate(string InvoiceNum, string InvoiceDate)
        {
            try
            {
                string sSQL = "SELECT * FROM Invoices WHERE InvoiceNum = " + InvoiceNum + " AND InvoiceDate = #" + InvoiceDate + "#";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// This SQL returns all invoices with: A specific number, date, and cost
        /// </summary>
        /// <param name="InvoiceNum"></param>
        /// <param name="Date"></param>
        /// <param name="TotalCost"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string GetInvoiceFromNumDateAndCost(string InvoiceNum, string Date, string TotalCost)
        {
            try
            {
                string sSQL = "SELECT * FROM Invoices WHERE InvoiceNum = " + InvoiceNum + " AND InvoiceDate = #" + Date + "# AND TotalCost = " + TotalCost + "";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// This SQL returns all invoices with: A specific cost
        /// </summary>
        /// <param name="TotalCost"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string GetInvoiceFromCost(string TotalCost)
        {
            try
            {
                string sSQL = "SELECT * FROM Invoices WHERE TotalCost = " + TotalCost + "";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// This SQL returns all invoices with: A specific number and cost
        /// </summary>
        /// <param name="InvoiceNum"></param>
        /// <param name="TotalCost"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string GetInvoiceFromNumAndCost(string InvoiceNum, string TotalCost)
        {
            try
            {
                string sSQL = "SELECT * FROM Invoices WHERE InvoiceNum = " + InvoiceNum + " AND TotalCost = " + TotalCost + "";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// This SQL returns all invoices with: A specific cost and date
        /// </summary>
        /// <param name="TotalCost"></param>
        /// <param name="Date"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string GetInvoiceFromCostAndDate(string TotalCost, string Date)
        {
            try
            {
                string sSQL = "SELECT * FROM Invoices WHERE TotalCost = " + TotalCost + " AND InvoiceDate = #" + Date + "#";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// This SQL returns all invoices with: A specific date
        /// </summary>
        /// <param name="Date"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string GetInvoiceFromDate(string Date)
        {
            try
            {
                string sSQL = "SELECT * FROM Invoices WHERE InvoiceDate = #" + Date + "#";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// This SQL returns all invoices with: Distinct Num
        /// </summary>
        /// <param name="InvoiceNum"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string GetDistinctInvoiceNum()
        {
            try
            {
                string sSQL = "SELECT DISTINCT(InvoiceNum) From Invoices order by InvoiceNum";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// This SQL returns all invoices with: Distinct Date
        /// </summary>
        /// <param name="Date"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string GetDistinctInvoiceDate()
        {
            try
            {
                string sSQL = "SELECT DISTINCT(InvoiceDate) From Invoices order by InvoiceDate";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// This SQL returns all invoices with: Distinct Cost
        /// </summary>
        /// <param name="Cost"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string GetDistinctInvoiceCost()
        {
            try
            {
                string sSQL = "SELECT DISTINCT(TotalCost) From Invoices order by TotalCost";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
//This is a test