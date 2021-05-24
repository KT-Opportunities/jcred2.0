using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace searchworks.client.Controllers
{
    public class TrustController : Controller
    {
        // GET: Trust
        public ActionResult CSITrustRecords()
        {
            return View();
        }
    }
}