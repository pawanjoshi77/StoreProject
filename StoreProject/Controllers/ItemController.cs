using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using StoreProject.Models;
using System.Data.SqlClient;

namespace StoreProject.Controllers
{
    public class ItemController : Controller
    {
        private StoreCMSContext db = new StoreCMSContext();
        // GET: Item
        public ActionResult Index()
        {
            return View(db.Items.ToList()); 
        }

        public ActionResult Create()
        {
            //in Create.cshtml I said I needed information about all stores
            return View(db.Stores.ToList());
        }

        [HttpPost]
        public ActionResult Create(string ItemName_New, float ItemPrice_New, int Store_StoreId_New)
        {
            string query = "Insert into items (ItemName, ItemPrice, Store_StoreId) values (@itemname_new, @itemprice_new, @store_storeid_new)";
            SqlParameter[] myparams = new SqlParameter[3];
            myparams[0] = new SqlParameter("@itemname_new", ItemName_New);
            myparams[1] = new SqlParameter("@itemprice_new", ItemPrice_New);
            myparams[2] = new SqlParameter("@store_storeid_new", Store_StoreId_New);

            db.Database.ExecuteSqlCommand(query, myparams);

            return RedirectToAction("List");
        }

    }
}