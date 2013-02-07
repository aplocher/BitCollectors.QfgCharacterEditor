using QfgCharacterLibrary;
using System;
using System.Web.Mvc;
using System.Linq;

namespace QFGCharacterWebUI.Controllers
{
    public class CharacterController : Controller
    {
        //
        // GET: /Character/
        public ActionResult General()
        {
            return View(new QfgCharacter());
        }

        [HttpPost]
        public ActionResult General(QfgCharacter qfgCharacter)
        {
            return View(qfgCharacter);
        }

        [HttpPost]
        public ActionResult CharacterStats(QfgCharacter qfgCharacter)
        {
            return View(qfgCharacter);
        }

        [HttpPost]
        public ActionResult Inventory(QfgCharacter qfgCharacter)
        { 
            return View(qfgCharacter);
        }

        [HttpPost]
        public ActionResult MagicStats(QfgCharacter qfgCharacter)
        {
            return View(qfgCharacter);
        }
    }
}
