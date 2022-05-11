using inter.Interface;
using inter.Models;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inter.Controllers
{
    public class testtblController : Controller
    {
        ItesttblService itesttblService;
        private readonly string _connectionString;

        public testtblController(ItesttblService _itesttblService)
        {
            itesttblService = _itesttblService;
        }
        public ActionResult Index()
        {
            IEnumerable<testtbl> testtbls = itesttblService.GetALL();
            
                return View(testtbls);
        }
        public ActionResult Create() {
            return View();
        }
        [HttpPost]
        public ActionResult Create(testtbl testtbl)
        {
            itesttblService.Addtesttbl(testtbl);
            return View();
        }
    }
}
