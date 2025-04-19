using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using GroupProject.Common;

namespace GroupProject.Main
{
    class clsMainLogic
    {
        /// <summary>
        /// Data access class to be used in conjunction with SQL statements
        /// </summary>
        clsDataAccess db = new clsDataAccess();

        /// <summary>
        /// Variable to hold all currently addable items
        /// </summary>
        List<clsItem> Items = new List<clsItem>();

        /// <summary>
        /// Instansiation of invoice class to hold invoices for editing whether passed from search or done after adding
        /// </summary>
        clsInvoice invoice;

        /// <summary>
        /// used to return private invoice object
        /// </summary>
        /// <returns>currently selected invoice in logic class</returns>
        public clsInvoice ReturnInvoice()
        {
            try
            {
                return invoice;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Used to gather all items as a list of clsItems
        /// </summary>
        /// <returns>A list of all items</returns>
        public List<clsItem> GetAllItems()
        {
            try
            {
                int iRet = 0;

                ///Gets all current items for purchase into dataset
                DataSet ds = db.ExecuteSQLStatement(clsMainSQL.GetItem(), ref iRet);

                ///Add current items into Items list
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    clsItem tempItem = new clsItem(ds.Tables[0].Rows[i][0].ToString(), ds.Tables[0].Rows[i][1].ToString(), Convert.ToDouble(ds.Tables[0].Rows[i][2]));
                    Items.Add(tempItem);
                }

                ///Sorts items based off of item code for ease of sorting
                Items.Sort((a, b) => a.ItemCode.CompareTo(b.ItemCode));

                ///Returns list of items
                return Items;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Updates item label with currently selected items cost.
        /// </summary>
        /// <param name="idx">used to determine index of currently selected item</param>
        /// <returns>Cost converted to a string</returns>
        public string updateItemCost(int idx)
        {
            try
            {
                return Items[idx].Cost.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Passes back cost to main window
        /// </summary>
        /// <returns>returns total invoice cost</returns>
        public string updateCost()
        {
            try
            {
                ///Converts string to double and then back for proper display with cents included
                double totalCost = Convert.ToDouble(invoice.sInvoiceCost);
                invoice.sInvoiceCost = totalCost.ToString("F2");
                return invoice.sInvoiceCost;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// basic method used to instansiate new invoice item for adding items to.
        /// </summary>
        public void AddInvoice()
        {
            try
            {
                ///Prepares new invoice object and list of item objects within to be used
                invoice = new clsInvoice();
                invoice.lstItems = new List<clsItem>();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Add item to item list held by invoice item and then returns list for display on datagrid
        /// </summary>
        /// <param name="idx">Index of item to add to list</param>
        /// <returns>A list of current items on the invoice</returns>
        public void AddItemToInvoice(int idx)
        {
            try
            {
                ///Ensures a valid index has been passed in
                if (idx >= 0)
                {
                    ///Adds item to list of items held by invoice object
                    invoice.lstItems.Add(Items[idx]);
                    double totalCost = Convert.ToDouble(invoice.sInvoiceCost);
                    totalCost += Items[idx].Cost;
                    invoice.sInvoiceCost = totalCost.ToString("F2");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Returns current items in the invoice
        /// </summary>
        /// <returns>list of clsItems</returns>
        public List<clsItem> ReturnInvoiceItems()
        {
            try
            {
                return invoice.lstItems;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Saves a new invoice based off the date passed in and updates the invoice number to the new invoice number
        /// </summary>
        /// <param name="date">Date that was selected by the user or the current date</param>
        /// <returns>current invoice number</returns>
        public int SaveNewInvoice(string date)
        {
            try
            {
                ///Sets invoice date as the date passed in from date picker
                invoice.sInvoiceDate = date;

                ///inserts invoice into database
                db.ExecuteNonQuery(clsMainSQL.AddNewInvoice(date, invoice.sInvoiceCost));

                ///Retrieves autogenerated invoice number
                invoice.sInvoiceNumber = db.ExecuteScalarSQL(clsMainSQL.RetrieveInvoiceNum());

                ///Adds each item from item list into the database link 
                for (int i = 0; i < invoice.lstItems.Count; i++)
                {
                    db.ExecuteNonQuery(clsMainSQL.AddLineItem(invoice.lstItems[i], invoice.sInvoiceNumber, i + 1));
                }

                return Convert.ToInt32(invoice.sInvoiceNumber);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Updates previously stored invoice based of current list of clsItems and uses invoice number to find and update
        /// </summary>
        /// <param name="num">Invoice number as passed in by main window</param>
        public void EditInvoice(int num)
        {
            try
            {
                ///Converts passed in invoice number to a string
                invoice.sInvoiceNumber = num.ToString();

                ///Updates current invoice cost
                db.ExecuteScalarSQL(clsMainSQL.UpdateInvoiceCost(invoice));

                ///Removes line items from database based off of number
                db.ExecuteNonQuery(clsMainSQL.RemoveLineItems(Convert.ToInt32(invoice.sInvoiceNumber)));

                ///Adds back in appropriate line items into the database
                for (int i = 0; i < invoice.lstItems.Count; i++)
                {
                    db.ExecuteNonQuery(clsMainSQL.AddLineItem(invoice.lstItems[i], invoice.sInvoiceNumber, i + 1));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Removes item from current invoice and updates total cost
        /// </summary>
        /// <param name="idx">index of item to be removed from clsItems List</param>
        public void RemoveItem(int idx)
        {
            try
            {
                double cost = Convert.ToDouble(invoice.sInvoiceCost);
                cost -= invoice.lstItems[idx].Cost;
                invoice.sInvoiceCost = cost.ToString("F2");
                invoice.lstItems.RemoveAt(idx);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Grabs invoice from databased based off of invoice number and places into clsInvoice object
        /// Then updates the list of clsItem objects to be updated based off of link list.
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <returns>clsInvoice object of retrieved invoice</returns>
        public void GetInvoice(int invoiceNum)
        {
            try
            {
                int iRet = 0;

                ///Retrieves invoice based off of invoice number based in
                DataSet ds = db.ExecuteSQLStatement(clsMainSQL.GetInvoice(invoiceNum), ref iRet);

                ///Sets up a new invoice object to hold retrieved data
                clsInvoice temp = new clsInvoice();

                ///Adds all neccessary information into invoice object
                temp.sInvoiceNumber = invoiceNum.ToString();
                temp.sInvoiceDate = ds.Tables[0].Rows[0][1].ToString();
                temp.sInvoiceCost = ds.Tables[0].Rows[0][2].ToString();

                ///Prepares list of item objects 
                temp.lstItems = new List<clsItem>();

                ///Retrieves relevant line items from database for dislpay 
                ds = db.ExecuteSQLStatement(clsMainSQL.CheckLineItems(invoiceNum), ref iRet);

                ///Adds line items to list of item objects
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    clsItem tempItem = new clsItem(ds.Tables[0].Rows[i][0].ToString(), ds.Tables[0].Rows[i][1].ToString(), Convert.ToDouble(ds.Tables[0].Rows[i][2]));
                    temp.lstItems.Add(tempItem);
                }

                ///Sets temp invoice as currently working invoice 
                this.invoice = temp;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
