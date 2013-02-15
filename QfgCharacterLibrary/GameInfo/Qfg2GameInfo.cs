using QfgCharacterLibrary.Enums;
using QfgCharacterLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QfgCharacterLibrary.GameInfo
{
    public class Qfg2GameInfo: IQfgGameInfo
    {
        public int MaxCharacterStatValue
        {
            get { return 200; }
        }

        public int MaxMagicStatValue
        {
            get { return 200; }
        }

        public int MaxDaggers
        {
            get { return 10; }
        }

        public int MaxHealingPotions
        {
            get { return 5; }
        }

        public int MaxVigorPotions
        {
            get { return 5; }
        }

        public int MaxMagicPotions
        {
            get { return 5; }
        }

        public bool HasCommunication
        {
            get { return true; }
        }

        public bool HasHonor
        {
            get { return true; }
        }

        public bool HasAcrobatics
        {
            get { return false; }
        }

        public bool HasForceBoltMagic
        {
            get { return true; }
        }

        public bool HasLevitate
        {
            get { return true; }
        }

        public bool HasReversal
        {
            get { return true; }
        }

        public bool HasPaladin
        {
            get { return true; }
        }

        public void LoadMappings(int index, int value, QfgCharacter character)
        {
            switch (index)
            {
                case 44:
                    character.CheckSum2 = value;
                    break;
                case 43:
                    character.CheckSum1 = value;
                    break;

                case 36:
                    character.InventoryDaggers = value;
                    break;

                case 25:
                    character.MagicSkillOpen = value;
                    break;

                case 26:
                    character.MagicSkillDetect = value;
                    break;

                case 27:
                    character.MagicSkillTrigger = value;
                    break;

                case 28:
                    character.MagicSkillDazzle = value;
                    break;

                case 29:
                    character.MagicSkillZap = value;
                    break;

                case 30:
                    character.MagicSkillCalm = value;
                    break;

                case 31:
                    character.MagicSkillFlame = value;
                    break;

                case 32:
                    character.MagicSkillFetch = value;
                    break;

                case 33:
                    character.MagicSkillForceBolt = value;
                    break;

                case 34:
                    character.MagicSkillLevitate = value;
                    break;

                case 35:
                    character.MagicSkillReversal = value;
                    break;

                case 20:
                    character.Honor = value;
                    break;

                case 19:
                    character.Communication = value;
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


        public string EncodedCharacterString(QfgCharacter character)
        {
            string str = string.Format("83-{27}-25-25-200-1-{0}-{1}-{2}-{3}-{4}-{5}-{6}-{7}-{8}-{9}-{10}-{11}-{12}-{13}-{14}-25-25-25-25-{15}-{16}-{17}-{18}-{19}-{20}-{21}-{22}-{23}-{24}-{25}-{26}-5-5-5-5-160-62-9991-9992-47-144-25-163-",
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
                character.Communication.ToString(),
                character.Honor.ToString(),
                character.MagicSkillOpen.ToString(),
                character.MagicSkillDetect.ToString(),
                character.MagicSkillTrigger.ToString(),
                character.MagicSkillDazzle.ToString(),
                character.MagicSkillZap.ToString(),
                character.MagicSkillCalm.ToString(),
                character.MagicSkillFlame.ToString(),
                character.MagicSkillFetch.ToString(),
                character.MagicSkillForceBolt.ToString(),
                character.MagicSkillLevitate.ToString(),
                character.MagicSkillReversal.ToString(),
                character.InventoryDaggers.ToString(),
                ((int)character.QfgClass).ToString()
                );

            string[] ar = str.Split('-');
            List<int> decodedStrArray = new List<int>();

            foreach (string st in ar)
            {
                if (st != "")
                    decodedStrArray.Add(Int32.Parse(st));
            }

            int total1 = 0xda;
            int total2 = 0;

            for (int i = 0; i < 40; i += 2)
            {
                decodedStrArray[i + 1] = decodedStrArray[i + 1] & 255;
                total1 += decodedStrArray[i + 1];
            }

            for (int i = 1; i < 40; i += 2)
            {
                decodedStrArray[i + 1] = decodedStrArray[i + 1] & 255;
                total2 += decodedStrArray[i + 1];
            }

            total1 &= 255;
            total2 &= 255;

            character.CheckSum1 = total1;
            character.CheckSum2 = total2;

            str = str.Replace("-9992-", "-" + total2.ToString() + "-");
            str = str.Replace("-9991-", "-" + total1.ToString() + "-");

            for (int i = 0; i < 48; i++)
            {
                decodedStrArray[i + 1] = decodedStrArray[i + 1] & 255;
                decodedStrArray[i + 1] ^= decodedStrArray[i];
            }

            ar = null;
            ar = str.Split('-');
            decodedStrArray.Clear();
            foreach (string st in ar)
            {
                if (st != "")
                    decodedStrArray.Add(Int32.Parse(st));
            }

            int prev = 0;
            int index = 0;
            List<int> encodedVal = new List<int>();

            foreach (int val in decodedStrArray)
            {
                int encoded = val;
                encoded ^= prev & 255;

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
            character.QfgGame = QfgGames.Qfg2;

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
            int total1 = 0xda;
            int total2 = 0;

            List<int> decodedValues = new List<int>();
            string decodedStr = "";
            foreach (int val in hexArray)
            {
                int decoded = val;
                decoded ^= prev & 255;

                decodedStr += decoded.ToString() + "-";
                decodedValues.Add(decoded);

                this.LoadMappings(index, decoded, character);

                prev = val;
                index++;
            }

            string total1Str = "";

            for (int i = 0; i < 40; i += 2)
            {
                total1 += decodedValues[i + 1];

                total1Str += decodedValues[i + 1].ToString() + "-";
            }

            for (int i = 1; i < 40; i += 2)
            {
                total2 += decodedValues[i + 1];
            }

            total1 &= 255;
            total2 &= 255;

            if (character.CheckSum1 != total1 || character.CheckSum2 != total2)
            {
                //throw new Exception("Invalid Character Checksums");
            }
        }
    }
}
