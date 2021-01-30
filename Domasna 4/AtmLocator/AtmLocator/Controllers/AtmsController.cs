using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AtmLocator.Data;
using AtmLocator.Models;

namespace AtmLocator.Controllers
{
    public class AtmsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AtmsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Atms
        public async Task<IActionResult> Index()
        {
            var locations = "";
            var i = 0;
            foreach (var atm in _context.Atm.ToList())
            {
                locations += "{latLng:{lat:" + atm.Latitude + ",lng:" + atm.Longitude + "}}";
                i++;
                if (i <= 98) locations += ",";
            }
            locations += "]";
            //Variable to store the locations  
            //var locations = AtmsLocationFinder();
            ViewBag.locations = locations;
            var url = "http://open.mapquestapi.com/directions/v2/routematrix?key=QbatUJWoSWVuXhsUyWPuUjWCwBTUM6TJ&json={locations:" + locations +
            ",options:{allToAll:false}}";
            ViewBag.url = url;
            return View(await _context.Atm.ToListAsync());
        }

        //Function to get all the locations of the ATMs
        public string AtmsLocationFinder()
        {
            var locations = "";
            var i = 0;
            foreach (var atm in _context.Atm.ToList())
            {
                locations += "{latLng:{lat:" + atm.Latitude + ",lng:" + atm.Longitude + "}}";
            }
            locations = locations.Substring(0, locations.Length - 2);
            locations += "]";
            return locations;
        }

        // GET: Atms/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atm = await _context.Atm
                .FirstOrDefaultAsync(m => m.ID == id);
            if (atm == null)
            {
                return NotFound();
            }

            return View(atm);
        }

        private bool AtmExists(long id)
        {
            return _context.Atm.Any(e => e.ID == id);
        }
    }
}
