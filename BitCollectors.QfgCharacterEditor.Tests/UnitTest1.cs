using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BitCollectors.QfgCharacterEditor.Library;
using BitCollectors.QfgCharacterEditor.Library.Enums;

namespace BitCollectors.QfgCharacterEditor.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private const string QFG1_FIGHTER_MAX_VAL = "Adam\n5351195e2d492d492d492d492d492d492d4955516823472347234723472329232923235a5c 67e3d351868\n";
        private const string QFG1_MAGIC_MAX_VAL = "Adam\n5250185f2c482c482c482c482c482c482c4854506922462246224622462228222822225b5d 67e3d351868\n";
        private const string QFG1_THIEF_MAX_VAL = "Adam\n51531b5c2f4b2f4b2f4b2f4b2f4b2f4b2f4b57536a2145214521452145212b212b2121585e 27a39311c6c\n";
        private const string QFG2_FIGHTER_MAX_VAL = "Adam\n534a539b9a529a529a529a529a529a529a529a524b524b529a529a529a529a529a529a909a909a9030 e6c351a8a9330\n";
        private const string QFG2_MAGIC_MAX_VAL = "Adam\n524b529a9b539b539b539b539b539b539b539b534a534a539b539b539b539b539b539b919b919b9131 f6c351a8a9330\n";
        private const string QFG2_THIEF_MAX_VAL = "Adam\n5148519998509850985098509850985098509850495049509850985098509850985098929892989232 c68311e8e9734\n";
        private const string QFG2_PALADIN_MAX_VAL = "Adam\n5049509899519951995199519951995199519951485148519951995199519951995199939993999333 d68311e8e9734\n";

        [TestMethod]
        public void TestQfg1FighterMaxValues()
        {
            QfgCharacter qfgCharacter = new QfgCharacter();
            qfgCharacter.QfgGame = QfgGames.QFG1;
            qfgCharacter.QfgClass = QfgClasses.Fighter;
            qfgCharacter.CharacterName = "Adam";
            qfgCharacter.SetMaxValues();
            
            string characterString = qfgCharacter.Encode();

            Assert.AreEqual<string>(QFG1_FIGHTER_MAX_VAL, characterString);
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

            Assert.AreEqual<string>(QFG1_MAGIC_MAX_VAL, characterString);
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

            Assert.AreEqual<string>(QFG1_THIEF_MAX_VAL, characterString);
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

            Assert.AreEqual<string>(QFG2_FIGHTER_MAX_VAL, characterString);
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

            Assert.AreEqual<string>(QFG2_MAGIC_MAX_VAL, characterString);
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

            Assert.AreEqual<string>(QFG2_THIEF_MAX_VAL, characterString);
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

            Assert.AreEqual<string>(QFG2_PALADIN_MAX_VAL, characterString);
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

            Assert.AreEqual<bool>(true, valueValid);
        }
    }
}
