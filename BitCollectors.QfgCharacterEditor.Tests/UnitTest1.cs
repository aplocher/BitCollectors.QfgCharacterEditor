using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BitCollectors.QfgCharacterEditor.Library;
using BitCollectors.QfgCharacterEditor.Library.Enums;

namespace BitCollectors.QfgCharacterEditor.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private const string QFG1_FIGHTER_MAX_VAL = "Adam\n5351195e2d492d492d492d492d492d492d49555168234723472347234723262c262c2c5553 67e3d351868\n";
        private const string QFG1_MAGIC_MAX_VAL = "Adam\n5250185f2c482c482c482c482c482c482c48545069224622462246224622272d272d2d5452 47c3f371a6a\n";
        private const string QFG1_THIEF_MAX_VAL = "Adam\n51531b5c2f4b2f4b2f4b2f4b2f4b2f4b2f4b57536a214521452145214521242e242e2e5751 67e3d351868\n";
        private const string QFG2_FIGHTER_MAX_VAL = "Adam\n534a539b9a529a529a529a529a529a529a529a524b524b529a529a529a529a529a529a909590959030 e561936a6bf1c\n";
        private const string QFG2_MAGIC_MAX_VAL = "Adam\n524b529a9b539b539b539b539b539b539b539b534a534a539b539b539b539b539b539b919491949131 f561936a6bf1c\n";
        private const string QFG2_THIEF_MAX_VAL = "Adam\n5148519998509850985098509850985098509850495049509850985098509850985098929792979232 c561936a6bf1c\n";
        private const string QFG2_PALADIN_MAX_VAL = "Adam\n5049509899519951995199519951995199519951485148519951995199519951995199939693969333 d561936a6bf1c\n";

        [TestMethod]
        public void TestQfg1FighterMaxValues()
        {
            QfgCharacter qfgCharacter = new QfgCharacter();
            qfgCharacter.QfgGame = QfgGames.QFG1;
            qfgCharacter.QfgClass = QfgClasses.Fighter;
            qfgCharacter.CharacterName = "Adam";
            qfgCharacter.SetMaxValues();
            
            string characterString = qfgCharacter.Encode();

            Assert.AreEqual<string>(characterString, QFG1_FIGHTER_MAX_VAL);
        }

        [TestMethod]
        public void TestQfg1MagicMaxValues()
        {
            QfgCharacter qfgCharacter = new QfgCharacter();
            qfgCharacter.QfgGame = QfgGames.QFG1;
            qfgCharacter.QfgClass = QfgClasses.Magic;
            qfgCharacter.CharacterName = "Adam";
            qfgCharacter.SetMaxValues();

            string characterString = qfgCharacter.Encode();

            Assert.AreEqual<string>(characterString, QFG1_MAGIC_MAX_VAL);
        }

        [TestMethod]
        public void TestQfg1ThiefMaxValues()
        {
            QfgCharacter qfgCharacter = new QfgCharacter();
            qfgCharacter.QfgGame = QfgGames.QFG1;
            qfgCharacter.QfgClass = QfgClasses.Thief;
            qfgCharacter.CharacterName = "Adam";
            qfgCharacter.SetMaxValues();

            string characterString = qfgCharacter.Encode();

            Assert.AreEqual<string>(characterString, QFG1_THIEF_MAX_VAL);
        }

        [TestMethod]
        public void TestQfg2FighterMaxValues()
        {
            QfgCharacter qfgCharacter = new QfgCharacter();
            qfgCharacter.QfgGame = QfgGames.QFG2;
            qfgCharacter.QfgClass = QfgClasses.Fighter;
            qfgCharacter.CharacterName = "Adam";
            qfgCharacter.SetMaxValues();

            string characterString = qfgCharacter.Encode();

            Assert.AreEqual<string>(characterString, QFG2_FIGHTER_MAX_VAL);
        }

        [TestMethod]
        public void TestQfg2MagicMaxValues()
        {
            QfgCharacter qfgCharacter = new QfgCharacter();
            qfgCharacter.QfgGame = QfgGames.QFG2;
            qfgCharacter.QfgClass = QfgClasses.Magic;
            qfgCharacter.CharacterName = "Adam";
            qfgCharacter.SetMaxValues();

            string characterString = qfgCharacter.Encode();

            Assert.AreEqual<string>(characterString, QFG2_MAGIC_MAX_VAL);
        }

        [TestMethod]
        public void TestQfg2ThiefMaxValues()
        {
            QfgCharacter qfgCharacter = new QfgCharacter();
            qfgCharacter.QfgGame = QfgGames.QFG2;
            qfgCharacter.QfgClass = QfgClasses.Thief;
            qfgCharacter.CharacterName = "Adam";
            qfgCharacter.SetMaxValues();

            string characterString = qfgCharacter.Encode();

            Assert.AreEqual<string>(characterString, QFG2_THIEF_MAX_VAL);
        }

        [TestMethod]
        public void TestQfg2PaladinMaxValues()
        {
            QfgCharacter qfgCharacter = new QfgCharacter();
            qfgCharacter.QfgGame = QfgGames.QFG2;
            qfgCharacter.QfgClass = QfgClasses.Paladin;
            qfgCharacter.CharacterName = "Adam";
            qfgCharacter.SetMaxValues();

            string characterString = qfgCharacter.Encode();

            Assert.AreEqual<string>(characterString, QFG2_PALADIN_MAX_VAL);
        }


        [TestMethod]
        public void TestMaxValueReset()
        {
            QfgCharacter qfgCharacter = new QfgCharacter();
            qfgCharacter.QfgGame = QfgGames.QFG2;
            qfgCharacter.QfgClass = QfgClasses.Fighter;
            qfgCharacter.CharacterName = "Adam";

            qfgCharacter.SetMaxValues();

            qfgCharacter.QfgGame = QfgGames.QFG1;

            bool valueValid = true;

            if (qfgCharacter.Strength > qfgCharacter.QfgGameInfo.MaxCharacterStatValue)
                valueValid = false;

            if (qfgCharacter.Intelligence > qfgCharacter.QfgGameInfo.MaxCharacterStatValue)
                valueValid = false;

            if (qfgCharacter.Agility > qfgCharacter.QfgGameInfo.MaxCharacterStatValue)
                valueValid = false;

            if (qfgCharacter.Vitality > qfgCharacter.QfgGameInfo.MaxCharacterStatValue)
                valueValid = false;

            if (qfgCharacter.Luck > qfgCharacter.QfgGameInfo.MaxCharacterStatValue)
                valueValid = false;

            if (qfgCharacter.WeaponUse > qfgCharacter.QfgGameInfo.MaxCharacterStatValue)
                valueValid = false;

            if (qfgCharacter.Parry > qfgCharacter.QfgGameInfo.MaxCharacterStatValue)
                valueValid = false;

            if (qfgCharacter.Dodge > qfgCharacter.QfgGameInfo.MaxCharacterStatValue)
                valueValid = false;

            if (qfgCharacter.Stealth > qfgCharacter.QfgGameInfo.MaxCharacterStatValue)
                valueValid = false;

            if (qfgCharacter.PickLocks > qfgCharacter.QfgGameInfo.MaxCharacterStatValue)
                valueValid = false;

            if (qfgCharacter.Throwing > qfgCharacter.QfgGameInfo.MaxCharacterStatValue)
                valueValid = false;

            if (qfgCharacter.Climbing > qfgCharacter.QfgGameInfo.MaxCharacterStatValue)
                valueValid = false;

            if (qfgCharacter.Magic > qfgCharacter.QfgGameInfo.MaxCharacterStatValue)
                valueValid = false;

            if (qfgCharacter.Communication != 0)
                valueValid = false;

            if (qfgCharacter.Honor != 0)
                valueValid = false;

            if (qfgCharacter.Acrobatics != 0)
                valueValid = false;

            Assert.AreEqual<bool>(valueValid, true);
        }
    }
}
