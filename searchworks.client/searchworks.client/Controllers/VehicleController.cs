﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace searchworks.client.Controllers
{
    public class VehicleController : Controller
    {
        // GET: Vehicle
        public ActionResult TransUnionAutoReport()
        {
            return View();
        }

        public ActionResult TransUnionAutoValuation()
        {
            return View();
        }
    }
}