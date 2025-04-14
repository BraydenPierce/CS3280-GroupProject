using GroupProject.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Search
{
    class clsSearchLogic
    {
        /// <summary>
        /// Public variable to hold the list of invoices
        /// </summary>
        public List<clsInvoice> lstInvoices;

        /// <summary>
        /// Getting the distinct invoices to load a string into the combo boxes
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<clsInvoice> getDistinctInvoiceNumber()
        {
            try
            {
                clsDataAccess db = new clsDataAccess();
                DataSet ds = new DataSet();
                int iRet = 0;
                lstInvoices = new List<clsInvoice>();

                //Get query string
                string query = clsSearchSQL.GetDistinctInvoiceNum();
                //Execute query
                ds = db.ExecuteSQLStatement(query, ref iRet);

                //Looping through the data set. For each row we are creating a new clsInvoice, filling it up, and adding a list of invoices
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    clsInvoice Invoice = new clsInvoice();
                    Invoice.sInvoiceNumber = dr[0].ToString();
                    lstInvoices.Add(Invoice);
                }

                return lstInvoices;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Getting the distinct invoice dates to load a string into the combo boxes
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<clsInvoice> getDistinctInvoiceDates()
        {
            try
            {
                clsDataAccess db = new clsDataAccess();
                DataSet ds = new DataSet();
                int iRet = 0;
                lstInvoices = new List<clsInvoice>();

                //Get query string
                string query = clsSearchSQL.GetDistinctInvoiceDate();
                //Execute query
                ds = db.ExecuteSQLStatement(query, ref iRet);

                //Looping through the data set. For each row we are creating a new clsInvoice, filling it up, and adding a list of invoices
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    clsInvoice Invoice = new clsInvoice();
                    //Formatting for the combo box
                    Invoice.sInvoiceDate = Convert.ToDateTime(dr[0]).ToString("MM/dd/yyyy");
                    lstInvoices.Add(Invoice);
                }

                return lstInvoices;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Getting the distinct invoice costs to load a string into the combo boxes
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<clsInvoice> getDistinctInvoiceCosts()
        {
            try
            {
                clsDataAccess db = new clsDataAccess();
                DataSet ds = new DataSet();
                int iRet = 0;
                lstInvoices = new List<clsInvoice>();

                //Get query string
                string query = clsSearchSQL.GetDistinctInvoiceCost();
                //Execute query
                ds = db.ExecuteSQLStatement(query, ref iRet);

                //Looping through the data set. For each row we are creating a new clsInvoice, filling it up, and adding a list of invoices
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    clsInvoice Invoice = new clsInvoice();
                    Invoice.sInvoiceCost = dr[0].ToString();
                    lstInvoices.Add(Invoice);
                }

                return lstInvoices;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        //GetInvoices(InvoiceNumber, InvoiceDate, TotalCost) - returns List<clsInvoices>
        //Write a statement to build an SQL statement based on the properties passed in
        public List<clsInvoice> GetInvoices(string InvoiceNumber, string InvoiceDate, string TotalCost)
        {
            try
            {
                //Need to determine what was passed in and what SQL statement to execute
                return lstInvoices;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
