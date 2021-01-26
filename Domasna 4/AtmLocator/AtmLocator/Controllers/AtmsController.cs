using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AtmLocator.Models;

namespace AtmLocator.Controllers
{
    public class AtmsController : Controller
    {
        private AtmsContext db = new AtmsContext();


        // GET: Atms
        public ActionResult Index()
        {
            /*var locations = "";
            var i = 0;
            foreach (var atm in db.Atms.ToList())
            {
                locations += "{latLng:{lat:" + atm.Latitude + ",lng:" + atm.Longitude + "}}";
                i++;
                if (i <= 98) locations += ",";
            }
            locations += "]";*/

            //Variable to store the locations  
            var locations = AtmsLocationFinder();
            ViewBag.locations = locations;
            var url = "http://open.mapquestapi.com/directions/v2/routematrix?key=QbatUJWoSWVuXhsUyWPuUjWCwBTUM6TJ&json={locations:" + locations +
            ",options:{allToAll:false}}";
            ViewBag.url = url;
            ViewBag.allAtms = db.Atms.ToList();
            return View(db.Atms.ToList());
        }

        //Function to get all the locations of the ATMs
        public string AtmsLocationFinder()
        {
            var locations = "";
            var i = 0;
            foreach (var atm in db.Atms.ToList())
            {
                locations += "{latLng:{lat:" + atm.Latitude + ",lng:" + atm.Longitude + "}}"; 
            }
            locations = locations.Substring(0, locations.Length - 1);
            locations += "]";
            return locations;
        }

        // GET: Atms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atm atm = db.Atms.Find(id);
            if (atm == null)
            {
                return HttpNotFound();
            }
            return View(atm);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
