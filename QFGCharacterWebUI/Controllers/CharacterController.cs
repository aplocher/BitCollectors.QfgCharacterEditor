using System.Web.Mvc;

namespace QFGCharacterWebUI.Controllers
{
    public class CharacterController : Controller
    {
        //
        // GET: /Character/

        public ActionResult General()
        {
            return View();
        }

        public ActionResult CharacterStats()
        {
            return View();
        }

        public ActionResult Inventory()
        {
            return View();
        }

        public ActionResult MagicStats()
        {
            return View();
        }
    }
}
