using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace GroupProject.Main
{
    class clsMainSQL
    {
        //AddItem(clsItem, clsInvoice) Adds Item to invoice
        //- INSERT INTO LineItems(InvoiceNum, LineItemNum, ItemCode) Values(123, 1, 'AA')
        //- UPDATE Invoices SET TotalCost = 1200 WHERE InvoiceNum = 123

        //AddInvoice(double Cost) Adds a new invoice based off of total cost and current date
        //- INSERT INTO Invoices(InvoiceDate, TotalCost) Values(#4/13/2018#, 100)

        //GetInvoice() gets invoice based off of data received.
        //- SELECT InvoiceNum, InvoiceDate, TotalCost FROM Invoices WHERE InvoiceNum = 123

        //GetItem() gets item based off of data recevied
        //- select ItemCode, ItemDesc, Cost from ItemDesc

        //
        //- SELECT LineItems.ItemCode, ItemDesc.ItemDesc, ItemDesc.Cost FROM LineItems, ItemDesc Where LineItems.ItemCode = ItemDesc.ItemCode And LineItems.InvoiceNum = 5000

        //DeleteInvoice() Deletes Invoice from database
        //- DELETE FROM LineItems WHERE InvoiceNum = 5000

    }
}
