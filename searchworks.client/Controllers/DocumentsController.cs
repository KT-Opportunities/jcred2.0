using System.Web.Mvc;

namespace searchworks.client.Controllers
{
    public class DocumentsController : Controller
    {
        // GET: Documents
        public ActionResult DeedsOfficeDocuments()
        {
            return View();
        }

        public ActionResult IFactsDocuments()
        {
            return View();
        }

        public ActionResult MIEDocuments()
        {
            return View();
        }

        public ActionResult XDSDocuments()
        {
            return View();
        }
    }
}