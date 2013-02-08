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
            //qfgCharacter.SetMaxValues();
            //qfgCharacter.CharacterName = "Blah2";
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

        [HttpPost]
        public ActionResult MaxStats(QfgCharacter qfgCharacter)
        {
            ModelState.Remove("Agility");
            ModelState.Remove("WeaponUse");
            ModelState.Remove("Intelligence");
            ModelState.Remove("Strength");
            ModelState.Remove("Vitality");
            ModelState.Remove("Luck");
            ModelState.Remove("Communication");
            ModelState.Remove("Parry");
            ModelState.Remove("Dodge");
            ModelState.Remove("Stealth");
            ModelState.Remove("PickLocks");
            ModelState.Remove("Throwing");
            ModelState.Remove("Climbing");
            ModelState.Remove("Magic");
            ModelState.Remove("Acrobatics");

            ModelState.Remove("MagicSkillCalm");
            ModelState.Remove("MagicSkillDazzle");
            ModelState.Remove("MagicSkillDetect");
            ModelState.Remove("MagicSkillFetch");
            ModelState.Remove("MagicSkillFlame");
            ModelState.Remove("MagicSkillForceBolt");
            ModelState.Remove("MagicSkillLevitate");
            ModelState.Remove("MagicSkillOpen");
            ModelState.Remove("MagicSkillReversal");
            ModelState.Remove("MagicSkillTrigger");
            ModelState.Remove("MagicSkillZap");

            ModelState.Remove("InventoryDaggers");
            ModelState.Remove("InventoryHealingPotions");
            ModelState.Remove("InventoryMagicPotions");
            ModelState.Remove("InventoryVigorPotions");

            qfgCharacter.SetMaxValues();

            return View("General", qfgCharacter);
        }
    }
}
