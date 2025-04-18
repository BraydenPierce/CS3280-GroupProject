using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            return invoice;
        }

        /// <summary>
        /// Used to gather all items as a list of clsItems
        /// </summary>
        /// <returns>A list of all items</returns>
        public List<clsItem> GetAllItems()
        {
            int iRet = 0;
            DataSet ds = db.ExecuteSQLStatement(clsMainSQL.GetItem(), ref iRet);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                clsItem tempItem = new clsItem(ds.Tables[0].Rows[i][0].ToString(), ds.Tables[0].Rows[i][1].ToString(), Convert.ToDouble(ds.Tables[0].Rows[i][2]));
                Items.Add(tempItem);
            }

            Items.Sort((a, b) => a.ItemCode.CompareTo(b.ItemCode));

            return Items;
        }

        /// <summary>
        /// Updates item label with currently selected items cost.
        /// </summary>
        /// <param name="idx">used to determine index of currently selected item</param>
        /// <returns>Cost converted to a string</returns>
        public string updateItemCost(int idx)
        {
            return Items[idx].Cost.ToString();
        }

        /// <summary>
        /// Passes back cost to main window
        /// </summary>
        /// <returns>returns total invoice cost</returns>
        public string updateCost()
        {
            return invoice.sInvoiceCost;
        }

        /// <summary>
        /// basic method used to instansiate new invoice item for adding items to.
        /// </summary>
        public void AddInvoice()
        {
            invoice = new clsInvoice();
            invoice.lstItems = new List<clsItem>();
        }

        /// <summary>
        /// Add item to item list held by invoice item and then returns list for display on datagrid
        /// </summary>
        /// <param name="idx">Index of item to add to list</param>
        /// <returns>A list of current items on the invoice</returns>
        public void AddItemToInvoice(int idx)
        {
            if (idx >= 0)
            {
                invoice.lstItems.Add(Items[idx]);
                double totalCost = Convert.ToDouble(invoice.sInvoiceCost);
                totalCost += Items[idx].Cost;
                invoice.sInvoiceCost = totalCost.ToString("F2");
            }
        }

        /// <summary>
        /// Returns current items in the invoice
        /// </summary>
        /// <returns>list of clsItems</returns>
        public List<clsItem> ReturnInvoiceItems()
        {
            return invoice.lstItems;
        }

        /// <summary>
        /// Saves a new invoice based off the date passed in and updates the invoice number to the new invoice number
        /// </summary>
        /// <param name="date">Date that was selected by the user or the current date</param>
        /// <returns>current invoice number</returns>
        public int SaveNewInvoice(string date)
        {
            invoice.sInvoiceDate = date;
            db.ExecuteNonQuery(clsMainSQL.AddNewInvoice(date, invoice.sInvoiceCost));
            invoice.sInvoiceNumber = db.ExecuteScalarSQL(clsMainSQL.RetrieveInvoiceNum());
            for (int i = 0; i < invoice.lstItems.Count; i++)
            {
                db.ExecuteNonQuery(clsMainSQL.AddLineItem(invoice.lstItems[i], invoice.sInvoiceNumber, i + 1));
            }

            return Convert.ToInt32(invoice.sInvoiceNumber);
        }

        /// <summary>
        /// Updates previously stored invoice based of current list of clsItems and uses invoice number to find and update
        /// </summary>
        /// <param name="num">Invoice number as passed in by main window</param>
        public void EditInvoice(int num)
        {
            invoice.sInvoiceNumber = num.ToString();
            db.ExecuteScalarSQL(clsMainSQL.UpdateInvoiceCost(invoice));
            db.ExecuteNonQuery(clsMainSQL.RemoveLineItems(Convert.ToInt32(invoice.sInvoiceNumber)));
            for (int i = 0; i < invoice.lstItems.Count; i++)
            {
                db.ExecuteNonQuery(clsMainSQL.AddLineItem(invoice.lstItems[i], invoice.sInvoiceNumber, i + 1));
            }
        }

        /// <summary>
        /// Removes item from current invoice and updates total cost
        /// </summary>
        /// <param name="idx">index of item to be removed from clsItems List</param>
        public void RemoveItem(int idx)
        {
            double cost = Convert.ToDouble(invoice.sInvoiceCost);
            cost -= invoice.lstItems[idx].Cost;
            invoice.sInvoiceCost = cost.ToString("F2");
            invoice.lstItems.RemoveAt(idx);
        }

        /// <summary>
        /// Grabs invoice from databased based off of invoice number and places into clsInvoice object
        /// Then updates the list of clsItem objects to be updated based off of link list.
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <returns>clsInvoice object of retrieved invoice</returns>
        public clsInvoice GetInvoice(int invoiceNum)
        {
            int iRet = 0;
            DataSet ds = db.ExecuteSQLStatement(clsMainSQL.GetInvoice(invoiceNum), ref iRet);
            clsInvoice temp = new clsInvoice();
            temp.sInvoiceNumber = invoiceNum.ToString();
            temp.sInvoiceDate = ds.Tables[0].Rows[0][1].ToString();
            temp.sInvoiceCost = ds.Tables[0].Rows[0][2].ToString();
            temp.lstItems = new List<clsItem>();
            ds = db.ExecuteSQLStatement(clsMainSQL.CheckLineItems(invoiceNum), ref iRet);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                clsItem tempItem = new clsItem(ds.Tables[0].Rows[i][0].ToString(), ds.Tables[0].Rows[i][1].ToString(), Convert.ToDouble(ds.Tables[0].Rows[i][2]));
                temp.lstItems.Add(tempItem);
            }

            return temp;
        }
    }
}
