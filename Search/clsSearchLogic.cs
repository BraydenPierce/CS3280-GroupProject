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
            try    //InvoiceNumber, InvoiceDate, and TotalCost will come in as null if nothing is selected
            {
                //For the following cases I am determining what was passed in and what SQL to execute

                clsDataAccess db = new clsDataAccess();
                DataSet ds = new DataSet();
                int iRet = 0;
                lstInvoices = new List<clsInvoice>();
                //Case: Num, Date, Cost
                if (InvoiceNumber != null && InvoiceDate != null && TotalCost != null)
                {
                    //Get query string
                    string query = clsSearchSQL.GetInvoiceFromNumDateAndCost(InvoiceNumber, InvoiceDate, TotalCost); //TODO - TEST
                    //Execute query
                    ds = db.ExecuteSQLStatement(query, ref iRet);
                    //Looping through the data set. For each row we are creating a new clsInvoice, filling it up, and adding a list of invoices
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        clsInvoice Invoice = new clsInvoice();
                        Invoice.sInvoiceNumber = dr[0].ToString();
                        Invoice.sInvoiceDate = Convert.ToDateTime(dr[1]).ToString("MM/dd/yyyy"); //Format date
                        Invoice.sInvoiceCost = dr[2].ToString();
                        lstInvoices.Add(Invoice);
                    }
                }
                //Case: Num, Date
                if (InvoiceNumber != null && InvoiceDate != null && TotalCost == null)
                {
                    //Get query string
                    string query = clsSearchSQL.GetInvoiceFromNumAndDate(InvoiceNumber, InvoiceDate); //TODO - TEST
                    //Execute query
                    ds = db.ExecuteSQLStatement(query, ref iRet);
                    //Looping through the data set. For each row we are creating a new clsInvoice, filling it up, and adding a list of invoices
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        clsInvoice Invoice = new clsInvoice();
                        Invoice.sInvoiceNumber = dr[0].ToString();
                        Invoice.sInvoiceDate = Convert.ToDateTime(dr[1]).ToString("MM/dd/yyyy"); //Format date
                        Invoice.sInvoiceCost = dr[2].ToString();
                        lstInvoices.Add(Invoice);
                    }
                }
                //Case: Num, Cost
                if (InvoiceNumber != null && TotalCost != null && InvoiceDate == null)
                {
                    //Get query string
                    string query = clsSearchSQL.GetInvoiceFromNumAndCost(InvoiceNumber, TotalCost); //TODO - TEST
                    //Execute query
                    ds = db.ExecuteSQLStatement(query, ref iRet);
                    //Looping through the data set. For each row we are creating a new clsInvoice, filling it up, and adding a list of invoices
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        clsInvoice Invoice = new clsInvoice();
                        Invoice.sInvoiceNumber = dr[0].ToString();
                        Invoice.sInvoiceDate = Convert.ToDateTime(dr[1]).ToString("MM/dd/yyyy"); //Format date
                        Invoice.sInvoiceCost = dr[2].ToString();
                        lstInvoices.Add(Invoice);
                    }
                }
                //Case: Date, Cost
                if (InvoiceDate != null && TotalCost != null && InvoiceNumber == null)
                {
                    //Get query string
                    string query = clsSearchSQL.GetInvoiceFromCostAndDate(TotalCost, InvoiceDate); //TODO - TEST
                    //Execute query
                    ds = db.ExecuteSQLStatement(query, ref iRet);
                    //Looping through the data set. For each row we are creating a new clsInvoice, filling it up, and adding a list of invoices
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        clsInvoice Invoice = new clsInvoice();
                        Invoice.sInvoiceNumber = dr[0].ToString();
                        Invoice.sInvoiceDate = Convert.ToDateTime(dr[1]).ToString("MM/dd/yyyy"); //Format date
                        Invoice.sInvoiceCost = dr[2].ToString();
                        lstInvoices.Add(Invoice);
                    }
                }
                //Case: Num
                if (InvoiceNumber != null && InvoiceDate == null && TotalCost == null)
                {
                    //Get query string
                    string query = clsSearchSQL.GetInvoiceFromNum(InvoiceNumber);
                    //Execute query
                    ds = db.ExecuteSQLStatement(query, ref iRet);
                    //Looping through the data set. For each row we are creating a new clsInvoice, filling it up, and adding a list of invoices
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        clsInvoice Invoice = new clsInvoice();
                        Invoice.sInvoiceNumber = dr[0].ToString();
                        Invoice.sInvoiceDate = Convert.ToDateTime(dr[1]).ToString("MM/dd/yyyy"); //Format date
                        Invoice.sInvoiceCost = dr[2].ToString();
                        lstInvoices.Add(Invoice);
                    }
                }
                //Case: Date
                if (InvoiceDate != null && InvoiceNumber == null && TotalCost == null)
                {
                    //Get query string
                    string query = clsSearchSQL.GetInvoiceFromDate(InvoiceDate); //TODO
                    //Execute query
                    ds = db.ExecuteSQLStatement(query, ref iRet);
                    //Looping through the data set. For each row we are creating a new clsInvoice, filling it up, and adding a list of invoices
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        clsInvoice Invoice = new clsInvoice();
                        Invoice.sInvoiceNumber = dr[0].ToString();
                        Invoice.sInvoiceDate = Convert.ToDateTime(dr[1]).ToString("MM/dd/yyyy"); //Format date
                        Invoice.sInvoiceCost = dr[2].ToString();
                        lstInvoices.Add(Invoice);
                    }
                }
                //Case: Cost
                if (TotalCost != null && InvoiceNumber == null && InvoiceDate == null)
                {
                    //Get query string
                    string query = clsSearchSQL.GetInvoiceFromCost(TotalCost); //TODO - TEST
                    //Execute query
                    ds = db.ExecuteSQLStatement(query, ref iRet);
                    //Looping through the data set. For each row we are creating a new clsInvoice, filling it up, and adding a list of invoices
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        clsInvoice Invoice = new clsInvoice();
                        Invoice.sInvoiceNumber = dr[0].ToString();
                        Invoice.sInvoiceDate = Convert.ToDateTime(dr[1]).ToString("MM/dd/yyyy"); //Format date
                        Invoice.sInvoiceCost = dr[2].ToString();
                        lstInvoices.Add(Invoice);
                    }
                }
                return lstInvoices;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Getting all the invoices to pass into the Data Grid
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<clsInvoice> GetAllInvoices()
        {
            try
            {
                clsDataAccess db = new clsDataAccess();
                DataSet ds = new DataSet();
                int iRet = 0;
                lstInvoices = new List<clsInvoice>();

                //Get query string
                string query = clsSearchSQL.GetInvoices();
                //Execute query
                ds = db.ExecuteSQLStatement(query, ref iRet);

                //Looping through the data set. For each row we are creating a new clsInvoice, filling it up, and adding a list of invoices
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    clsInvoice Invoice = new clsInvoice();
                    Invoice.sInvoiceNumber = dr[0].ToString();
                    Invoice.sInvoiceDate = Convert.ToDateTime(dr[1]).ToString("MM/dd/yyyy"); //Format date
                    Invoice.sInvoiceCost = dr[2].ToString();
                    lstInvoices.Add(Invoice);
                }

                return lstInvoices;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
