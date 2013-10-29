using System;
using System.Web.Mvc;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using BitCollectors.QfgCharacterEditor.Library;

namespace BitCollectors.QfgCharacterEditor.WebUI.Controllers
{
    public class CharacterController : Controller
    {
        public ActionResult General()
        {
            return View("General", new QfgCharacter());
        }

        [HttpPost]
        public ActionResult General(QfgCharacter qfgCharacter)
        {
            return View("General", qfgCharacter);
        }

        public ActionResult CharacterStats()
        {
            return RedirectToAction("General");
        }

        [HttpPost]
        public ActionResult CharacterStats(QfgCharacter qfgCharacter)
        {
            ViewBag.MaxCharacterStats = qfgCharacter.QfgGameInfo.MaxCharacterStatValue;

            return View("CharacterStats", qfgCharacter);
        }

        public ActionResult Inventory()
        {
            return RedirectToAction("General");
        }

        [HttpPost]
        public ActionResult Inventory(QfgCharacter qfgCharacter)
        {
            ViewBag.MaxDaggers = qfgCharacter.QfgGameInfo.MaxDaggers;
            ViewBag.MaxHealingPotions = qfgCharacter.QfgGameInfo.MaxHealingPotions;
            ViewBag.MaxMagicPotions = qfgCharacter.QfgGameInfo.MaxMagicPotions;
            ViewBag.MaxVigorPotions = qfgCharacter.QfgGameInfo.MaxVigorPotions;

            return View("Inventory", qfgCharacter);
        }

        public ActionResult MagicStats()
        {
            return RedirectToAction("General");
        }

        [HttpPost]
        public ActionResult MagicStats(QfgCharacter qfgCharacter)
        {
            ViewBag.MaxMagicStats = qfgCharacter.QfgGameInfo.MaxMagicStatValue;

            return View("MagicStats", qfgCharacter);
        }

        public ActionResult MaxStats()
        {
            QfgCharacter qfgCharacter = new QfgCharacter();
            qfgCharacter.SetMaxValues();
            return View("General", qfgCharacter);
        }

        [HttpPost]
        public ActionResult MaxStats(QfgCharacter qfgCharacter)
        {
            ResetModelState();

            qfgCharacter.SetMaxValues();

            switch (Request.Form["Page"].ToLower())
            {
                case "inventory":
                    return Inventory(qfgCharacter);

                case "magicstats":
                    return MagicStats(qfgCharacter);

                case "characterstats":
                    return CharacterStats(qfgCharacter);

                default:
                    return General(qfgCharacter);
            }


            //RedirectToAction(Request.Form["Page"], )

            

            //return View(Request.Form["Page"], qfgCharacter);
        }

        [HttpPost]
        public ActionResult ChangeGame(QfgCharacter qfgCharacter)
        {
            ResetModelState();

            qfgCharacter.LoadGameInfo();

            return View(Request.Form["Page"], qfgCharacter);
        }

        [HttpPost]
        public ActionResult Load(HttpPostedFileBase file)
        {
            QfgCharacter qfgCharacter = new QfgCharacter();

            if (file.ContentLength > 0)
            {
                using (var reader = new StreamReader(file.InputStream))
                {
                    string characterFileString = reader.ReadToEnd();

                    string[] filePieces = characterFileString.Split('\n');

                    if (filePieces.Length > 1)
                    {
                        qfgCharacter.LoadCharacter(filePieces[0].Trim(), filePieces[1]);
                    }
                }
            }

            return View("General", qfgCharacter);
        }

        [HttpPost]
        public ActionResult Save(QfgCharacter qfgCharacter)
        {
            string characterString = qfgCharacter.Encode();

            return File(Encoding.ASCII.GetBytes(characterString), "application/force-download", "character.sav");
        }

        private void ResetModelState()
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
            ModelState.Remove("Honor");

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
            ModelState.Remove("InventoryPoisonCurePotions");
        }
    }
}
