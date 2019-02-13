using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StoreProject.Models;
//including this for the extra definition
//using StoreProject.Models.ViewModels;
using System.Diagnostics;

namespace StoreProject.Controllers
{
    public class ItemController : Controller
    {
        private StoreCMSContext db = new StoreCMSContext();
        // GET: Item
        public ActionResult Index()
        {
            return RedirectToAction("List");
            
        }
        public ActionResult List()
        {
            /*
            Alternate
            IEnumerable<Tag> tags = db.Tags.ToList();
            */

            string query = "select * from Items";
            IEnumerable<Item> items = db.Items.FromSql(query);

            return View(items);
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

            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

    }
}