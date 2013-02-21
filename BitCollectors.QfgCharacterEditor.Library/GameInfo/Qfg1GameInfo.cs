using System;
using System.Collections.Generic;
using BitCollectors.QfgCharacterEditor.Library.Enums;
using BitCollectors.QfgCharacterEditor.Library.Interfaces;

namespace BitCollectors.QfgCharacterEditor.Library.GameInfo
{
    public class Qfg1GameInfo : IQfgGameInfo
    {
        #region IQfgGameInfo Members

        public int MaxCharacterStatValue
        {
            get { return 100; }
        }

        public void LoadMappings(int index, int value, QfgCharacter character)
        {
            switch (index)
            {
                case 39:
                    character.CheckSum2 = value;
                    break;

                case 38:
                    character.CheckSum1 = value;
                    break;

                case 34:
                    character.InventoryVigorPotions = value;
                    break;

                case 33:
                    character.InventoryMagicPotions = value;
                    break;

                case 32:
                    character.InventoryHealingPotions = value;
                    break;

                case 31:
                    character.InventoryDaggers = value;
                    break;

                case 23:
                    character.MagicSkillOpen = value;
                    break;

                case 24:
                    character.MagicSkillDetect = value;
                    break;

                case 25:
                    character.MagicSkillTrigger = value;
                    break;

                case 26:
                    character.MagicSkillDazzle = value;
                    break;

                case 27:
                    character.MagicSkillZap = value;
                    break;

                case 28:
                    character.MagicSkillCalm = value;
                    break;

                case 29:
                    character.MagicSkillFlame = value;
                    break;

                case 30:
                    character.MagicSkillFetch = value;
                    break;

                case 18:
                    character.Magic = value;
                    break;

                case 17:
                    character.Climbing = value;
                    break;

                case 16:
                    character.Throwing = value;
                    break;

                case 15:
                    character.PickLocks = value;
                    break;

                case 14:
                    character.Stealth = value;
                    break;

                case 13:
                    character.Dodge = value;
                    break;

                case 12:
                    character.Parry = value;
                    break;

                case 11:
                    character.WeaponUse = value;
                    break;

                case 10:
                    character.Luck = value;
                    break;

                case 9:
                    character.Vitality = value;
                    break;

                case 8:
                    character.Agility = value;
                    break;

                case 7:
                    character.Intelligence = value;
                    break;

                case 6:
                    character.Strength = value;
                    break;

                case 1:
                    character.QfgClass = (QfgClasses)value;
                    break;
            }
        }


        public int MaxMagicStatValue
        {
            get { return 100; }
        }

        public int MaxDaggers
        {
            get { return 10; }
        }

        public int MaxHealingPotions
        {
            get { return 10; }
        }

        public int MaxVigorPotions
        {
            get { return 10; }
        }

        public int MaxMagicPotions
        {
            get { return 10; }
        }

        public bool HasForceBoltMagic
        {
            get { return false; }
        }

        public bool HasLevitate
        {
            get { return false; }
        }

        public bool HasReversal
        {
            get { return false; }
        }

        public bool HasPaladin
        {
            get { return false; }
        }

        public bool HasCommunication
        {
            get { return false; }
        }

        public bool HasHonor
        {
            get { return false; }
        }

        public bool HasAcrobatics
        {
            get { return false; }
        }

        #endregion


        public string EncodedCharacterString(QfgCharacter character)
        {
            string str = string.Format("83-{25}-2-72-71-115-{0}-{1}-{2}-{3}-{4}-{5}-{6}-{7}-{8}-{9}-{10}-{11}-{12}-28-4-57-75-{13}-{14}-{15}-{16}-{17}-{18}-{19}-{20}-{21}-{22}-{23}-{24}-0-121-6-9991-9992-67-8-45-112-",
                character.Strength.ToString(),
                character.Intelligence.ToString(),
                character.Agility.ToString(),
                character.Vitality.ToString(),
                character.Luck.ToString(),
                character.WeaponUse.ToString(),
                character.Parry.ToString(),
                character.Dodge.ToString(),
                character.Stealth.ToString(),
                character.PickLocks.ToString(),
                character.Throwing.ToString(),
                character.Climbing.ToString(),
                character.Magic.ToString(),
                character.MagicSkillOpen.ToString(),
                character.MagicSkillDetect.ToString(),
                character.MagicSkillTrigger.ToString(),
                character.MagicSkillDazzle.ToString(),
                character.MagicSkillZap.ToString(),
                character.MagicSkillCalm.ToString(),
                character.MagicSkillFlame.ToString(),
                character.MagicSkillFetch.ToString(),
                character.InventoryDaggers.ToString(),
                character.InventoryHealingPotions.ToString(),
                character.InventoryMagicPotions.ToString(),
                character.InventoryVigorPotions.ToString(),
                ((int)character.QfgClass).ToString()
                );


            string[] ar = str.Split('-');
            List<int> decodedStrArray = new List<int>();

            foreach (string st in ar)
            {
                if (st != "")
                    decodedStrArray.Add(Int32.Parse(st));
            }

            int total1 = 0xce;
            int total2 = 0;

            for (int i = 0; i < 35; i += 2)
            {
                total1 += decodedStrArray[i + 1];
            }

            for (int i = 1; i < 35; i += 2)
            {
                total2 += decodedStrArray[i + 1];
            }

            total1 &= 127;
            total2 &= 127;

            character.CheckSum1 = total1;
            character.CheckSum2 = total2;

            str = str.Replace("-9992-", "-" + total2.ToString() + "-");
            str = str.Replace("-9991-", "-" + total1.ToString() + "-");

            ar = null;
            ar = str.Split('-');
            decodedStrArray.Clear();
            foreach (string st in ar)
            {
                if (st != "")
                    decodedStrArray.Add(Int32.Parse(st));
            }


            int prev = 0;// x53;
            int index = 0;
            List<int> encodedVal = new List<int>();

            foreach (int val in decodedStrArray)
            {
                int encoded = val;
                encoded ^= prev & 127;

                if (index > 0)
                    encodedVal.Add(encoded);

                prev = encoded;
                index++;
            }

            List<string> encodedStrArray = new List<string>();
            foreach (int val in encodedVal)
            {
                encodedStrArray.Add(val.ToString("X"));
            }

            string encodedValue = "";

            for (int i = 0; i < encodedStrArray.Count; i++)
            {
                encodedValue += encodedStrArray[i].PadLeft(2, ' ').ToLower();
            }

            return encodedValue;
        }

        public void LoadCharacterString(string characterString, QfgCharacter character)
        {
            character.QfgClass = QfgClasses.Fighter;
            character.QfgGame = QfgGames.QFG1;

            string hexString = characterString;
            List<int> hexArray = new List<int>();

            while (hexString.Length > 0)
            {
                string hexValue = hexString.Substring(hexString.Length - 2, 2);
                hexString = hexString.Substring(0, hexString.Length - 2);
                hexArray.Add(Convert.ToInt32(hexValue.Trim(), 16));
            }

            hexArray.Add(0x53);
            hexArray.Reverse();

            int prev = 0;// x53;
            int index = 0;
            int total1 = 0xce;
            int total2 = 0;

            List<int> decodedValues = new List<int>();
            string decodedStr = "";
            foreach (int val in hexArray)
            {
                int decoded = val;
                decoded ^= prev & 127;

                decodedStr += decoded.ToString() + "-";
                decodedValues.Add(decoded);

                this.LoadMappings(index, decoded, character);

                prev = val;
                index++;
            }

            string total1Str = "";

            for (int i = 0; i < 35; i += 2)
            {
                total1 += decodedValues[i + 1];

                total1Str += decodedValues[i + 1].ToString() + "-";
            }

            for (int i = 1; i < 35; i += 2)
            {
                total2 += decodedValues[i + 1];
            }

            total1 &= 127;
            total2 &= 127;

            if (character.CheckSum1 != total1 || character.CheckSum2 != total2)
            {
                //throw new Exception("Invalid Character Checksums");
            }
        }


        public bool HasPoisonCurePotion
        {
            get { return false; }
        }


        public int MaxPoisonCurePotions
        {
            get { return 0; }
        }
    }
}
