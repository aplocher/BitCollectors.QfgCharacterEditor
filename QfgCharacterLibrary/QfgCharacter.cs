using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using QfgCharacterLibrary.Enums;
using QfgCharacterLibrary.GameInfo;
using QfgCharacterLibrary.Interfaces;

namespace QfgCharacterLibrary
{
    public class QfgCharacter
    {
        public QfgCharacter()
        {
            LoadGameInfo();
        }

        public delegate void LogDataDelegate(object sender, string logData);

        public event LogDataDelegate LogData;

        protected void OnLogData(string logData)
        {
            if (LogData != null)
                LogData(this, logData);
        }

        private QfgGames _qfgGame = QfgGames.Qfg1;
        private QfgClasses _qfgClass = QfgClasses.Fighter;
        private string _characterName = "";
        private int _strength;
        private int _intelligence;
        private int _agility;
        private int _vitality;
        private int _luck;
        private int _weaponUse;
        private int _parry;
        private int _dodge;
        private int _stealth;
        private int _pickLocks;
        private int _throwing;
        private int _climbing;
        private int _magic;
        private int _communication;
        private int _acrobatics;

        private int _inventoryDaggers;
        private int _inventoryHealingPotions;
        private int _inventoryMagicPotions;
        private int _inventoryVigorPotions;

        private int _magicSkillOpen;
        private int _magicSkillDetect;
        private int _magicSkillTrigger;
        private int _magicSkillDazzle;
        private int _magicSkillZap;
        private int _magicSkillCalm;
        private int _magicSkillFlame;
        private int _magicSkillFetch;
        private int _magicSkillForceBolt;
        private int _magicSkillLevitate;
        private int _magicSkillReversal;

        #region Public Properties
        public bool IsDirty { get; set; }

        public IQfgGameInfo QfgGameInfo { get; private set; }

        public QfgGames QfgGame
        {
            get { return _qfgGame; }
            set
            {
                if (_qfgGame != value)
                    IsDirty = true;

                _qfgGame = value;
                LoadGameInfo();
            }
        }

        public QfgClasses QfgClass
        {
            get
            {
                return _qfgClass;
            }
            set
            {
                if (_qfgClass != value)
                    IsDirty = true;

                _qfgClass = value;
            }
        }

        public string CharacterName
        {
            get
            {
                return _characterName;
            }
            set
            {
                if (_characterName != value)
                    IsDirty = true;

                _characterName = value;
            }
        }

        public int Strength
        {
            get
            {
                return _strength;
            }
            set
            {
                if (_strength != value)
                    IsDirty = true;

                _strength = value;
            }
        }

        public int Intelligence
        {
            get
            {
                return _intelligence;
            }
            set
            {
                if (_intelligence != value)
                    IsDirty = true;

                _intelligence = value;
            }
        }

        public int Agility
        {
            get
            {
                return _agility;
            }
            set
            {
                if (_agility != value)
                    IsDirty = true;

                _agility = value;
            }
        }

        public int Vitality
        {
            get
            {
                return _vitality;
            }
            set
            {
                if (_vitality != value)
                    IsDirty = true;

                _vitality = value;
            }
        }

        public int Luck
        {
            get
            {
                return _luck;
            }
            set
            {
                if (_luck != value)
                    IsDirty = true;

                _luck = value;
            }
        }

        public int WeaponUse
        {
            get
            {
                return _weaponUse;
            }
            set
            {
                if (_weaponUse != value)
                    IsDirty = true;

                _weaponUse = value;
            }
        }

        public int Parry
        {
            get
            {
                return _parry;
            }
            set
            {
                if (_parry != value)
                    IsDirty = true;

                _parry = value;
            }
        }

        public int Dodge
        {
            get
            {
                return _dodge;
            }
            set
            {
                if (_dodge != value)
                    IsDirty = true;

                _dodge = value;
            }
        }

        public int Stealth
        {
            get
            {
                return _stealth;
            }
            set
            {
                if (_stealth != value)
                    IsDirty = true;

                _stealth = value;
            }
        }

        public int PickLocks
        {
            get
            {
                return _pickLocks;
            }
            set
            {
                if (_pickLocks != value)
                    IsDirty = true;

                _pickLocks = value;
            }
        }

        public int Throwing
        {
            get
            {
                return _throwing;
            }
            set
            {
                if (_throwing != value)
                    IsDirty = true;

                _throwing = value;
            }
        }

        public int Climbing
        {
            get
            {
                return _climbing;
            }
            set
            {
                if (_climbing != value)
                    IsDirty = true;

                _climbing = value;
            }
        }

        public int Magic
        {
            get
            {
                return _magic;
            }
            set
            {
                if (_magic != value)
                    IsDirty = true;

                _magic = value;
            }
        }

        public int Communication
        {
            get
            {
                return _communication;
            }
            set
            {
                if (_communication != value)
                    IsDirty = true;

                _communication = value;
            }
        }

        public int Acrobatics
        {
            get
            {
                return _acrobatics;
            }
            set
            {
                if (_acrobatics != value)
                    IsDirty = true;

                _acrobatics = value;
            }
        }

        public int InventoryDaggers
        {
            get
            {
                return _inventoryDaggers;
            }
            set
            {
                if (_inventoryDaggers != value)
                    IsDirty = true;

                _inventoryDaggers = value;
            }
        }

        public int InventoryHealingPotions 
        {
            get
            {
                return _inventoryHealingPotions;
            }
            set
            {
                if (_inventoryHealingPotions != value)
                    IsDirty = true;

                _inventoryHealingPotions = value;
            }
        }

        public int InventoryMagicPotions 
        {
            get
            {
                return _inventoryMagicPotions;
            }
            set
            {
                if (_inventoryMagicPotions != value)
                    IsDirty = true;

                _inventoryMagicPotions = value;
            }
        }

        public int InventoryVigorPotions
        {
            get
            {
                return _inventoryVigorPotions;
            }
            set
            {
                if (_inventoryVigorPotions != value)
                    IsDirty = true;

                _inventoryVigorPotions = value;
            }
        }

        public int MagicSkillOpen
        {
            get
            {
                return _magicSkillOpen;
            }
            set
            {
                if (_magicSkillOpen != value)
                    IsDirty = true;

                _magicSkillOpen = value;
            }
        }

        public int MagicSkillDetect
        {
            get
            {
                return _magicSkillDetect;
            }
            set
            {
                if (_magicSkillDetect != value)
                    IsDirty = true;

                _magicSkillDetect = value;
            }
        }

        public int MagicSkillTrigger 
        {
            get
            {
                return _magicSkillTrigger;
            }
            set
            {
                if (_magicSkillTrigger != value)
                    IsDirty = true;

                _magicSkillTrigger = value;
            }
        }

        public int MagicSkillDazzle
        {
            get
            {
                return _magicSkillDazzle;
            }
            set
            {
                if (_magicSkillDazzle != value)
                    IsDirty = true;

                _magicSkillDazzle = value;
            }
        }

        public int MagicSkillZap
        {
            get
            {
                return _magicSkillZap;
            }
            set
            {
                if (_magicSkillZap != value)
                    IsDirty = true;

                _magicSkillZap = value;
            }
        }

        public int MagicSkillCalm
        {
            get
            {
                return _magicSkillCalm;
            }
            set
            {
                if (_magicSkillCalm != value)
                    IsDirty = true;

                _magicSkillCalm = value;
            }
        }

        public int MagicSkillFlame 
        {
            get
            {
                return _magicSkillFlame;
            }
            set
            {
                if (_magicSkillFlame != value)
                    IsDirty = true;

                _magicSkillFlame = value;
            }
        }

        public int MagicSkillFetch
        {
            get
            {
                return _magicSkillFetch;
            }
            set
            {
                if (_magicSkillFetch != value)
                    IsDirty = true;

                _magicSkillFetch = value;
            }
        }

        public int MagicSkillForceBolt { get; set; }
        public int MagicSkillLevitate { get; set; }
        public int MagicSkillReversal { get; set; }

        public bool CommunicationEnabled
        {
            get
            {
                return this.QfgGameInfo.HasCommunication;
            }
        }

        public bool AcrobaticsEnabled
        {
            get
            {
                return this.QfgGameInfo.HasAcrobatics;
            }
        }

        public bool MagicSkillForceBoltEnabled
        {
            get
            {
                return this.QfgGameInfo.HasForceBoltMagic;
            }
        }

        public bool MagicSkillLevitateEnabled
        {
            get
            {
                return this.QfgGameInfo.HasLevitate;
            }
        }

        public bool MagicSkillReversalEnabled
        {
            get
            {
                return this.QfgGameInfo.HasReversal;
            }
        }

        public int CheckSum1 { get; set; }
        public int CheckSum2 { get; set; }
        #endregion

        #region Public Methods
        public void EncodeToFile(string filename)
        {
            File.WriteAllText(filename, this.Encode());
        }

        public string Encode()
        {
            string str = string.Format("83-{25}-2-72-71-115-{0}-{1}-{2}-{3}-{4}-{5}-{6}-{7}-{8}-{9}-{10}-{11}-{12}-28-4-57-75-{13}-{14}-{15}-{16}-{17}-{18}-{19}-{20}-{21}-{22}-{23}-{24}-0-121-6-9991-9992-67-8-45-112-",
                //string str = string.Format("112-45-8-67-9992-9991-6-121-0-{24}-{23}-{22}-{21}-{20}-{19}-{18}-{17}-{16}-{15}-{14}-{13}-75-57-4-28-{12}-{11}-{10}-{9}-{8}-{7}-{6}-{5}-{4}-{3}-{2}-{1}-{0}-115-71-72-2-0-83-",
                this.Strength.ToString(),
                this.Intelligence.ToString(),
                this.Agility.ToString(),
                this.Vitality.ToString(),
                this.Luck.ToString(),
                this.WeaponUse.ToString(),
                this.Parry.ToString(),
                this.Dodge.ToString(),
                this.Stealth.ToString(),
                this.PickLocks.ToString(),
                this.Throwing.ToString(),
                this.Climbing.ToString(),
                this.Magic.ToString(),
                this.MagicSkillOpen.ToString(),
                this.MagicSkillDetect.ToString(),
                this.MagicSkillTrigger.ToString(),
                this.MagicSkillDazzle.ToString(),
                this.MagicSkillZap.ToString(),
                this.MagicSkillCalm.ToString(),
                this.MagicSkillFlame.ToString(),
                this.MagicSkillFetch.ToString(),
                this.InventoryDaggers.ToString(),
                this.InventoryHealingPotions.ToString(),
                this.InventoryMagicPotions.ToString(),
                this.InventoryVigorPotions.ToString(),
                ((int)this.QfgClass).ToString()
                );


            OnLogData("----------------SAVING------------------");

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

            OnLogData(total1.ToString() + " - " + total2.ToString());



            //int idx = 0;
            //int total1 = 0;
            //int total2 = 0;
            //foreach (int i in decodedStrArray)
            //{
            //    if (idx > 9 && idx % 2 == 1)
            //    {
            //        total1 += i;
            //    }

            //    if (idx > 9 && idx % 2 == 0)
            //    {
            //        total2 += i;
            //    }

            //    idx++;
            //}

            this.CheckSum1 = total1;
            this.CheckSum2 = total2;

            str = str.Replace("-9992-", "-" + total2.ToString() + "-");
            str = str.Replace("-9991-", "-" + total1.ToString() + "-");

            OnLogData(str);

            ar = null;
            ar = str.Split('-');
            decodedStrArray.Clear();
            foreach (string st in ar)
            {
                if (st != "")
                    decodedStrArray.Add(Int32.Parse(st));
            }


            //foreach (int val in hexArray)
            //{
            //    int decoded = (prev ^ val);

            //    //this.OnLogData(decoded.ToString());

            //    decodedValues.Add(decoded);

            //    this.QfgGameInfo.LoadMappings(index, decoded, this);

            //    if (index > 9 && index % 2 == 1)
            //    {
            //        total1 += decoded;
            //    }

            //    if (index > 9 && index % 2 == 0)
            //    {
            //        total2 += decoded;
            //    }

            //    prev = val;
            //    index++;
            //}

            ////total += 83;

            //int check1 = 0xce + total1;

            ////for (int i = 0; i < OLD_NUM_ATTRIBS + CHECK_DATA; i += 2)
            ////{
            ////    stats[i + 1] = stats[i + 1] & 127;
            ////    check1 += stats[i + 1];
            ////}

            //int check2 = 0 + total2;

            ////for (int i = 1; i < OLD_NUM_ATTRIBS + CHECK_DATA; i += 2)
            ////{
            ////    stats[i + 1] = stats[i + 1] & 127;
            ////    check2 += stats[i + 1];
            ////}

            //check1 &= 127;
            //check2 &= 127;

            int prev = 0;// x53;
            int index = 0;
            List<int> encodedVal = new List<int>();
            //List<int> decodedValues = new List<int>();
            string decodedStr = "";
            foreach (int val in decodedStrArray)
            {
                int encoded = val;
                encoded ^= prev & 127;

                if (index > 0)
                    encodedVal.Add(encoded);
                //decodedStr += decoded.ToString() + "-";
                //decodedValues.Add(decoded);

                //this.QfgGameInfo.LoadMappings(index, decoded, this);

                prev = encoded;
                index++;
            }

            //int prev = 0;
            //List<int> encodedVal = new List<int>();

            //foreach (int val in decodedStrArray)
            //{
            //    encodedVal.Add((val ^ prev));

            //    prev = val ^ prev;
            //}

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

            //StringBuilder sb = new StringBuilder();
            //foreach (System.Reflection.PropertyInfo propInfo in this.GetType().GetProperties())
            //{
            //    sb.Append(propInfo.Name);
            //    sb.Append(": ");
            //    sb.AppendLine(propInfo.GetValue(this, null).ToString());
            //}
            //this.OnLogData(sb.ToString() + "--------------------------------" + Environment.NewLine);

            this.OnLogData(encodedValue);

            this.IsDirty = false;

            return string.Format("{0}\n{1}\n", this.CharacterName, encodedValue);
        }

        public void SetMaxValues()
        {
            this.Strength = this.QfgGameInfo.MaxCharacterStatValue;
            this.Intelligence = this.QfgGameInfo.MaxCharacterStatValue;
            this.Agility = this.QfgGameInfo.MaxCharacterStatValue;
            this.Vitality = this.QfgGameInfo.MaxCharacterStatValue;
            this.Luck = this.QfgGameInfo.MaxCharacterStatValue;
            this.WeaponUse = this.QfgGameInfo.MaxCharacterStatValue;
            this.Dodge = this.QfgGameInfo.MaxCharacterStatValue;
            this.Parry = this.QfgGameInfo.MaxCharacterStatValue;
            this.Stealth = this.QfgGameInfo.MaxCharacterStatValue;
            this.PickLocks = this.QfgGameInfo.MaxCharacterStatValue;
            this.Climbing = this.QfgGameInfo.MaxCharacterStatValue;
            this.Throwing = this.QfgGameInfo.MaxCharacterStatValue;
            this.Magic = this.QfgGameInfo.MaxCharacterStatValue;

            this.MagicSkillCalm = this.QfgGameInfo.MaxMagicStatValue;
            this.MagicSkillDazzle = this.QfgGameInfo.MaxMagicStatValue;
            this.MagicSkillDetect = this.QfgGameInfo.MaxMagicStatValue;
            this.MagicSkillFetch = this.QfgGameInfo.MaxMagicStatValue;
            this.MagicSkillFlame = this.QfgGameInfo.MaxMagicStatValue;
            this.MagicSkillOpen = this.QfgGameInfo.MaxMagicStatValue;
            this.MagicSkillTrigger = this.QfgGameInfo.MaxMagicStatValue;
            this.MagicSkillZap = this.QfgGameInfo.MaxMagicStatValue;

            if (this.MagicSkillForceBoltEnabled)
                this.MagicSkillForceBolt = this.QfgGameInfo.MaxMagicStatValue;

            if (this.MagicSkillLevitateEnabled)
                this.MagicSkillLevitate = this.QfgGameInfo.MaxMagicStatValue;

            if (this.MagicSkillReversalEnabled)
                this.MagicSkillReversal = this.QfgGameInfo.MaxMagicStatValue;

            this.InventoryDaggers = this.QfgGameInfo.MaxDaggers;
            this.InventoryHealingPotions = this.QfgGameInfo.MaxHealingPotions;
            this.InventoryMagicPotions = this.QfgGameInfo.MaxMagicPotions;
            this.InventoryVigorPotions = this.QfgGameInfo.MaxVigorPotions;
        }

        public void LoadCharacter(string filename)
        {
            string fileText = File.ReadAllText(filename);

            string[] filePieces = fileText.Split('\n');

            if (filePieces.Length > 1)
            {
                LoadCharacter(filePieces[0].Trim(), filePieces[1]);
            }
        }

        public void LoadCharacter(string name, string dataString)
        {

            OnLogData("----------------LOADING------------------");
            this.OnLogData(dataString);

            this.CharacterName = name;
            this.QfgClass = QfgClasses.Fighter;
            this.QfgGame = QfgGames.Qfg1;

            //int SCORE_BIT = 64;
            //int CHECK_DATA = 10;
            //int EXTRA_DATA = 18;
            //int OLD_NUM_ATTRIBS = 25;

            //string other = dataString;
            ////OnLogData(other);
            //int[] stats = new int[OLD_NUM_ATTRIBS + EXTRA_DATA + 1];
            //stats[0] = 0x53;
            //for (int i = 0; i < OLD_NUM_ATTRIBS + EXTRA_DATA; i++)
            //{
            //    stats[i + 1] = convWord((other[i * 2 + 1] << 8) | other[i * 2]);
            //}


            ////string test2 = "";
            ////for (int i = stats.Length - 1; i >= 0; i--)
            ////{
            ////    test2 += stats[i] + "-";
            ////}
            ////OnLogData(test2);

            //for (int i = OLD_NUM_ATTRIBS + EXTRA_DATA; i > 0; i--)
            //{
            //    stats[i] ^= stats[i - 1] & 127;
            //}

            //int tcheck1 = 0xce;
            //string tcheckStr = "";

            //for (int i = 0; i < OLD_NUM_ATTRIBS + CHECK_DATA; i += 2)
            //{
            //    stats[i + 1] = stats[i + 1] & 127;
            //    tcheck1 += stats[i + 1];

            //    tcheckStr += stats[i + 1].ToString() + "-";
            //}

            //int tcheck2 = 0;

            //for (int i = 1; i < OLD_NUM_ATTRIBS + CHECK_DATA; i += 2)
            //{
            //    stats[i + 1] = stats[i + 1] & 127;
            //    tcheck2 += stats[i + 1];
            //}

            //tcheck1 &= 127;
            //tcheck2 &= 127;

            //string test = "";
            ////foreach (int t in stats)
            ////{
            ////    test += t + "-";
            ////}

            //for (int i = 0; i < stats.Length; i++)
            //{
            //    test += stats[i] + "-";
            //}

            //OnLogData(test);
            //OnLogData(tcheckStr);
            //OnLogData(tcheck1.ToString() + " - " + tcheck2.ToString());

            //LoadGameInfo();

            string hexString = dataString;
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

                this.QfgGameInfo.LoadMappings(index, decoded, this);

                prev = val;
                index++;
            }

            OnLogData(decodedStr);

            string total1Str = "";

            for (int i = 0; i < 35; i += 2)
            {
                total1 += decodedValues[i + 1];

                total1Str += decodedValues[i + 1].ToString() + "-";
            }

            //OnLogData(total1Str);

            for (int i = 1; i < 35; i += 2)
            {
                total2 += decodedValues[i + 1];
            }

            total1 &= 127;
            total2 &= 127;

            OnLogData(total1.ToString() + " - " + total2.ToString());

            //StringBuilder sb = new StringBuilder();
            //foreach (System.Reflection.PropertyInfo propInfo in this.GetType().GetProperties())
            //{
            //    sb.Append(propInfo.Name);
            //    sb.Append(": ");
            //    sb.AppendLine(propInfo.GetValue(this, null).ToString());
            //}
            //this.OnLogData(sb.ToString());

            if (this.CheckSum1 != total1 || this.CheckSum2 != total2)
            {
                //throw new Exception("Invalid Character Checksums");
            }

            this.IsDirty = false;
        }

        #endregion

        #region Private Methods
        private void LoadGameInfo()
        {
            switch (this.QfgGame)
            {
                case QfgGames.Qfg1:
                    this.QfgGameInfo = new Qfg1GameInfo();
                    break;

                case QfgGames.Qfg2:
                    // TODO: Implement QFG2 Settings
                    break;

                case QfgGames.Qfg3:
                    // TODO: Implement QFG3 Settings
                    break;

                case QfgGames.Qfg4:
                    // TODO: Implement QFG4 Settings
                    break;
            }
        }
        #endregion
    }
}
