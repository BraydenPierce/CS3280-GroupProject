using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GroupProject.Common;

namespace GroupProject.Items
{
    class clsItemsLogic
    {
        /// <summary>
        /// database variable to populate
        /// </summary>
        private clsDataAccess db;

        /// <summary>
        /// clsItemsLogic Constructor
        /// </summary>
        /// <exception cref="Exception"></exception>
        public clsItemsLogic()
        {
            try
            {
                db = new clsDataAccess();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Pulls items from ItemDesc table and returns a populated list
        /// </summary>
        /// <returns>List<clsItem></returns>
        /// <exception cref="Exception"></exception>
        public List<clsItem> GetItems()
        {
            try
            {
                // Initialize variables  
                DataSet ds;
                int iRet = 0;
                List<clsItem> items = new List<clsItem>();

                // Execute  
                ds = db.ExecuteSQLStatement(clsItemsSQL.GetItems(), ref iRet);

                // Loop through DataSet, for each Row, create a new clsItem object and add it to clsItem List.
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    clsItem item = new clsItem(
                        ds.Tables[0].Rows[i]["ItemCode"].ToString(),
                        ds.Tables[0].Rows[i]["ItemDesc"].ToString(),
                        Convert.ToDouble(ds.Tables[0].Rows[i]["Cost"])
                    );
                    items.Add(item);
                }

                return items;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Deletes an item from Invoice.mdb
        /// </summary>
        /// <param name="itemCode"></param>
        public void DeleteItem(string itemCode)
        {
            db.ExecuteNonQuery(clsItemsSQL.GetDeleteItem(itemCode));
        }

        /// <summary>
        /// Updates an item from Invoice.mdb
        /// </summary>
        /// <param name="itemDesc"></param>
        /// <param name="itemCode"></param>
        /// <param name="cost"></param>
        public void UpdateItem(string itemDesc, string itemCode, string cost)
        {
            db.ExecuteNonQuery(clsItemsSQL.GetUpdateItem(itemDesc, cost, itemCode));
        }

        /// <summary>
        /// Adds an item to Invoice.mdb
        /// </summary>
        /// <param name="itemDesc"></param>
        /// <param name="cost"></param>
        /// <param name="itemCode"></param>
        public void AddItem(string itemDesc, string cost, string itemCode)
        {
            db.ExecuteNonQuery(clsItemsSQL.GetInsertItem(itemDesc, cost, itemCode));
        }
    }
}
