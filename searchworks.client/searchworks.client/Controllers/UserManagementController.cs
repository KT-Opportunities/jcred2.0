﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace searchworks.client.Controllers
{
    public class UserManagementController : Controller
    {
        // GET: UserManagement
        public ActionResult UserManagementHome()
        {
            return View();
        }

        public ActionResult SearchHistory()
        {
            return View();
        }


    }
}