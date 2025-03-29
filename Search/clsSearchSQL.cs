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
        /*
           Overall Note:
           - I tested all queries in Microsoft Access to ensure they work
           - I got all SQL statements from the Database Help.doc provided from the professor
        */

        /// <summary>
        /// This SQL returns a string to get all the invoices
        /// </summary>
        /// <returns></returns>
        public string GetInvoices()
        {
            try
            {
                //GetInvoices()
                //  SELECT * FROM Invoices
                string sSQL = "SELECT * FROM Invoices";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// This SQL returns all invoices with the Num 5000
        /// </summary>
        /// <returns></returns>
        public string GetInvoiceNum5000()
        {
            try
            {
                //GetInvoiceNum5000()
                //  SELECT * FROM Invoices WHERE InvoiceNum = 5000
                string sSQL = "SELECT * FROM Invoices WHERE InvoiceNum = 5000";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// This SQL returns all invoices with: Num 5000, and Date 4/13/2018
        /// </summary>
        /// <returns></returns>
        public string GetInvoiceNum5000AndDate4_13_2018()
        {
            try
            {
                //GetInvoiceNum5000AndDate4_13_2018()
                //  SELECT* FROM Invoices WHERE InvoiceNum = 5000 AND InvoiceDate = #4/13/2018#
                //Note: Query works but doesn't return anything due to no invoices existing with that information
                string sSQL = "SELECT* FROM Invoices WHERE InvoiceNum = 5000 AND InvoiceDate = #4/13/2018#";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// This SQL returns all invoices with: Num 5000, Date 4/13/2018, and Cost 120
        /// </summary>
        /// <returns></returns>
        public string GetInvoiceNum5000AndDate4_13_2018AndCost120()
        {
            try
            {
                //GetInvoiceNum5000AndDate4_13_2018AndCost120()
                //  SELECT * FROM Invoices WHERE InvoiceNum = 5000 AND InvoiceDate = #4/13/2018# AND TotalCost = 120
                //Note: Query works but doesn't return anything due to no invoices existing with that information
                string sSQL = "SELECT * FROM Invoices WHERE InvoiceNum = 5000 AND InvoiceDate = #4/13/2018# AND TotalCost = 120";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// This SQL returns all invoices with: Cost 1200
        /// </summary>
        /// <returns></returns>
        public string GetInvoiceCost1200()
        {
            try
            {
                //GetInvoiceCost1200()
                //  SELECT * FROM Invoices WHERE TotalCost = 1200
                //Note: Query works but doesn't return anything due to no invoices existing with that information
                string sSQL = "SELECT * FROM Invoices WHERE TotalCost = 1200";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// This SQL returns all invoices with: Cost 1300, and Date 4/13/2018
        /// </summary>
        /// <returns></returns>
        public string GetInvoiceCost1300AndDate4_13_2018()
        {
            try
            {
                //GetInvoiceCost1300AndDate4_13_2018()
                //  SELECT * FROM Invoices WHERE TotalCost = 1300 and InvoiceDate = #4/13/2018#
                //Note: Query works but doesn't return anything due to no invoices existing with that information
                string sSQL = "SELECT * FROM Invoices WHERE TotalCost = 1300 and InvoiceDate = #4/13/2018#";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// This SQL returns all invoices with: Date 4/13/2018
        /// </summary>
        /// <returns></returns>
        public string GetInvoiceDate4_13_2018()
        {
            try
            {
                //GetInvoiceDate4_13_2018()
                //  SELECT * FROM Invoices WHERE InvoiceDate = #4/13/2018#
                //Note: Query works but doesn't return anything due to no invoices existing with that information
                string sSQL = "SELECT * FROM Invoices WHERE InvoiceDate = #4/13/2018#";
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
        /// <returns></returns>
        public string GetDistinctInvoiceNum()
        {
            try
            {
                //GetDistinctInvoiceNum()
                //  SELECT DISTINCT(InvoiceNum) From Invoices order by InvoiceNum
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
        /// <returns></returns>
        public string GetDistinctInvoiceDate()
        {
            try
            {
                //GetDistinctInvoiceDate()
                //  SELECT DISTINCT(InvoiceDate) From Invoices order by InvoiceDate
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
        /// <returns></returns>
        public string GetDistinctInvoiceCost()
        {
            try
            {
                //GetDistinctInvoiceCost()
                //  SELECT DISTINCT(TotalCost) From Invoices order by TotalCost
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
