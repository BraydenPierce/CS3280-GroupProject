using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Common
{
    internal class clsItem
    {
        //All variables to be retrieved from database
        /// <summary>
        /// string ItemCode to store unique item ID
        /// </summary>
        private string sItemCode;
        /// <summary>
        /// string ItemDesc to store description of item
        /// </summary>
        private string sItemDesc;
        /// <summary>
        /// double Cost to store cost of item
        /// </summary>
        private double dItemCost;

        /// <summary>
        /// get/set for string variable itemCode
        /// </summary>
        public string ItemCode
        {
            get { return sItemCode; }
            set { sItemCode = value; }
        }
        
        /// <summary>
        /// get/set for string variable itemDesc
        /// </summary>
        public string ItemDesc
        {
            get { return sItemDesc; }
            set { sItemDesc = value; }
        }

        /// <summary>
        /// get/set for double variable cost
        /// </summary>
        public double Cost
        {
            get { return dItemCost; }
            set { dItemCost = value; }
        }

        /// <summary>
        /// public clsItem(ID, Desc, Cost) constructor builds new item based off information passed in
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Desc"></param>
        /// <param name="Cost"></param>
        public clsItem(string sID, string sDesc, double dCost)
        {

            try
            {
                sItemCode = sID;
                sItemDesc = sDesc;
                dItemCost = dCost;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Used to allow for items to be properly displayed in combo box
        /// </summary>
        /// <returns>Returns Item name as a string variable</returns>
        public override string ToString()
        {
            return sItemDesc;
        }
    }
}
