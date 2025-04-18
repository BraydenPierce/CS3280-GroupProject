using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GroupProject.Common
{
    class clsInvoice
    {
        #region Properties/Variables
        /// <summary>
        /// Public property for the Invoice Number
        /// </summary>
        public string sInvoiceNumber { get; set; }
        /// <summary>
        /// Public property for the Invoice Date
        /// </summary>
        public string sInvoiceDate { get; set; }
        /// <summary>
        /// Public property for the Invoice Total Cost
        /// </summary>
        public string sInvoiceCost { get; set; }
        /// <summary>
        /// public variable to hold all the items
        /// </summary>
        public List<clsItem> lstItems;
        /// <summary>
        /// Read-only property for displaying the invoice number
        /// </summary>
        public string DisplayInvoiceNumber { get { return sInvoiceNumber; } }
        /// <summary>
        /// Read-only property for displaying the invoice date
        /// </summary>
        public string DisplayInvoiceDate { get { return sInvoiceDate; } }
        /// <summary>
        /// Read-only property for displaying the invoice cost
        /// </summary>
        public string DisplayInvoiceCost
        {
            get
            {
                //Formatting for the format '$XX.XX'
                if (decimal.TryParse(sInvoiceCost, out decimal cost))
                {
                    return cost.ToString("C");
                }
                return sInvoiceCost;
            }
        }
        #endregion
    }
}
