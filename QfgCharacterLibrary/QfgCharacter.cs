using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using BitCollectors.QfgCharacterEditor.Library.Enums;
using BitCollectors.QfgCharacterEditor.Library.Interfaces;
using BitCollectors.QfgCharacterEditor.Library.GameInfo;

namespace BitCollectors.QfgCharacterEditor.Library
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

        private QfgGames _qfgGame = QfgGames.QFG1;
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
        private int _honor;
        private int _acrobatics;

        private int _inventoryDaggers;
        private int _inventoryHealingPotions;
        private int _inventoryMagicPotions;
        private int _inventoryVigorPotions;
        private int _inventoryPoisonCurePotions;

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

        private int GetStatProperty(ref int field, int max)
        {
            if (field > max)
                field = max;

            return field;
        }

        private void SetStatProperty(ref int field, int value)
        {
            if (field != value)
                IsDirty = true;

            field = value;
        }

        public int Strength
        {
            get
            {
                return GetStatProperty(ref _strength, this.QfgGameInfo.MaxCharacterStatValue);
            }
            set
            {
                SetStatProperty(ref _strength, value);
            }
        }

        public int Intelligence
        {
            get
            {
                return GetStatProperty(ref _intelligence, this.QfgGameInfo.MaxCharacterStatValue);
            }
            set
            {
                SetStatProperty(ref _intelligence, value);
            }
        }

        public int Agility
        {
            get
            {
                return GetStatProperty(ref _agility, this.QfgGameInfo.MaxCharacterStatValue);
            }
            set
            {
                SetStatProperty(ref _agility, value);
            }
        }

        public int Vitality
        {
            get
            {
                return GetStatProperty(ref _vitality, this.QfgGameInfo.MaxCharacterStatValue);
            }
            set
            {
                SetStatProperty(ref _vitality, value);
            }
        }

        public int Luck
        {
            get
            {
                return GetStatProperty(ref _luck, this.QfgGameInfo.MaxCharacterStatValue);
            }
            set
            {
                SetStatProperty(ref _luck, value);
            }
        }

        public int WeaponUse
        {
            get
            {
                return GetStatProperty(ref _weaponUse, this.QfgGameInfo.MaxCharacterStatValue);
            }
            set
            {
                SetStatProperty(ref _weaponUse, value);
            }
        }

        public int Parry
        {
            get
            {
                return GetStatProperty(ref _parry, this.QfgGameInfo.MaxCharacterStatValue);
            }
            set
            {
                SetStatProperty(ref _parry, value);
            }
        }

        public int Dodge
        {
            get
            {
                return GetStatProperty(ref _dodge, this.QfgGameInfo.MaxCharacterStatValue);
            }
            set
            {
                SetStatProperty(ref _dodge, value);
            }
        }

        public int Stealth
        {
            get
            {
                return GetStatProperty(ref _stealth, this.QfgGameInfo.MaxCharacterStatValue);
            }
            set
            {
                SetStatProperty(ref _stealth, value);
            }
        }

        public int PickLocks
        {
            get
            {
                return GetStatProperty(ref _pickLocks, this.QfgGameInfo.MaxCharacterStatValue);
            }
            set
            {
                SetStatProperty(ref _pickLocks, value);
            }
        }

        public int Throwing
        {
            get
            {
                return GetStatProperty(ref _throwing, this.QfgGameInfo.MaxCharacterStatValue);
            }
            set
            {
                SetStatProperty(ref _throwing, value);
            }
        }

        public int Climbing
        {
            get
            {
                return GetStatProperty(ref _climbing, this.QfgGameInfo.MaxCharacterStatValue);
            }
            set
            {
                SetStatProperty(ref _climbing, value);
            }
        }

        public int Magic
        {
            get
            {
                return GetStatProperty(ref _magic, this.QfgGameInfo.MaxCharacterStatValue);
            }
            set
            {
                SetStatProperty(ref _magic, value);
            }
        }

        public int Communication
        {
            get
            {
                return GetStatProperty(ref _communication, this.QfgGameInfo.MaxCharacterStatValue);
            }
            set
            {
                SetStatProperty(ref _communication, value);
            }
        }

        public int Honor
        {
            get
            {
                return GetStatProperty(ref _honor, this.QfgGameInfo.MaxCharacterStatValue);
            }
            set
            {
                SetStatProperty(ref _honor, value);
            }
        }

        public int Acrobatics
        {
            get
            {
                return GetStatProperty(ref _acrobatics, this.QfgGameInfo.MaxCharacterStatValue);
            }
            set
            {
                SetStatProperty(ref _acrobatics, value);
            }
        }

        public int InventoryDaggers
        {
            get
            {
                return GetStatProperty(ref _inventoryDaggers, this.QfgGameInfo.MaxDaggers);
            }
            set
            {
                SetStatProperty(ref _inventoryDaggers, value);
            }
        }

        public int InventoryHealingPotions 
        {
            get
            {
                return GetStatProperty(ref _inventoryHealingPotions, this.QfgGameInfo.MaxHealingPotions);
            }
            set
            {
                SetStatProperty(ref _inventoryHealingPotions, value);
            }
        }

        public int InventoryMagicPotions 
        {
            get
            {
                return GetStatProperty(ref _inventoryMagicPotions, this.QfgGameInfo.MaxMagicPotions);
            }
            set
            {
                SetStatProperty(ref _inventoryMagicPotions, value);
            }
        }

        public int InventoryVigorPotions
        {
            get
            {
                return GetStatProperty(ref _inventoryVigorPotions, this.QfgGameInfo.MaxVigorPotions);
            }
            set
            {
                SetStatProperty(ref _inventoryVigorPotions, value);
            }
        }

        public int InventoryPoisonCurePotions
        {
            get
            {
                return GetStatProperty(ref _inventoryPoisonCurePotions, this.QfgGameInfo.MaxPoisonCurePotions);
            }
            set
            {
                SetStatProperty(ref _inventoryPoisonCurePotions, value);
            }
        }

        public int MagicSkillOpen
        {
            get
            {
                return GetStatProperty(ref _magicSkillOpen, this.QfgGameInfo.MaxMagicStatValue);
            }
            set
            {
                SetStatProperty(ref _magicSkillOpen, value);
            }
        }

        public int MagicSkillDetect
        {
            get
            {
                return GetStatProperty(ref _magicSkillDetect, this.QfgGameInfo.MaxMagicStatValue);
            }
            set
            {
                SetStatProperty(ref _magicSkillDetect, value);
            }
        }

        public int MagicSkillTrigger 
        {
            get
            {
                return GetStatProperty(ref _magicSkillTrigger, this.QfgGameInfo.MaxMagicStatValue);
            }
            set
            {
                SetStatProperty(ref _magicSkillTrigger, value);
            }
        }

        public int MagicSkillDazzle
        {
            get
            {
                return GetStatProperty(ref _magicSkillDazzle, this.QfgGameInfo.MaxMagicStatValue);
            }
            set
            {
                SetStatProperty(ref _magicSkillDazzle, value);
            }
        }

        public int MagicSkillZap
        {
            get
            {
                return GetStatProperty(ref _magicSkillZap, this.QfgGameInfo.MaxMagicStatValue);
            }
            set
            {
                SetStatProperty(ref _magicSkillZap, value);
            }
        }

        public int MagicSkillCalm
        {
            get
            {
                return GetStatProperty(ref _magicSkillCalm, this.QfgGameInfo.MaxMagicStatValue);
            }
            set
            {
                SetStatProperty(ref _magicSkillCalm, value);
            }
        }

        public int MagicSkillFlame 
        {
            get
            {
                return GetStatProperty(ref _magicSkillFlame, this.QfgGameInfo.MaxMagicStatValue);
            }
            set
            {
                SetStatProperty(ref _magicSkillFlame, value);
            }
        }

        public int MagicSkillFetch
        {
            get
            {
                return GetStatProperty(ref _magicSkillFetch, this.QfgGameInfo.MaxMagicStatValue);
            }
            set
            {
                SetStatProperty(ref _magicSkillFetch, value);
            }
        }

        public int MagicSkillForceBolt 
        {
            get
            {
                return GetStatProperty(ref _magicSkillForceBolt, this.QfgGameInfo.MaxMagicStatValue);
            }
            set
            {
                SetStatProperty(ref _magicSkillForceBolt, value);
            }
        }

        public int MagicSkillLevitate 
        {
            get
            {
                return GetStatProperty(ref _magicSkillLevitate, this.QfgGameInfo.MaxMagicStatValue);
            }
            set
            {
                SetStatProperty(ref _magicSkillLevitate, value);
            }
        }

        public int MagicSkillReversal 
        {
            get
            {
                return GetStatProperty(ref _magicSkillReversal, this.QfgGameInfo.MaxMagicStatValue);
            }
            set
            {
                SetStatProperty(ref _magicSkillReversal, value);
            }
        }

        public bool CommunicationEnabled
        {
            get
            {
                return this.QfgGameInfo.HasCommunication;
            }
        }

        public bool HonorEnabled
        {
            get
            {
                return this.QfgGameInfo.HasHonor;
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

        public bool InventoryPoisonCurePotionEnabled
        {
            get
            {
                return this.QfgGameInfo.HasPoisonCurePotion;
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
            string encodedValue = this.QfgGameInfo.EncodedCharacterString(this);

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

            if (this.AcrobaticsEnabled)
                this.Acrobatics = this.QfgGameInfo.MaxCharacterStatValue;

            if (this.CommunicationEnabled)
                this.Communication = this.QfgGameInfo.MaxCharacterStatValue;

            if (this.HonorEnabled)
                this.Honor = this.QfgGameInfo.MaxCharacterStatValue;

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

            if (this.InventoryPoisonCurePotionEnabled)
                this.InventoryPoisonCurePotions = this.QfgGameInfo.MaxPoisonCurePotions;
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
            if (dataString.Length == 86)
                this.QfgGame = QfgGames.QFG1;
            else if (dataString.Length == 96)
                this.QfgGame = QfgGames.QFG2;

            this.CharacterName = name;
            this.QfgGameInfo.LoadCharacterString(dataString, this);
            this.IsDirty = false;
        }

        #endregion

        #region Private Methods
        public void LoadGameInfo()
        {
            switch (this.QfgGame)
            {
                case QfgGames.QFG1:
                    this.QfgGameInfo = new Qfg1GameInfo();
                    break;

                case QfgGames.QFG2:
                    this.QfgGameInfo = new Qfg2GameInfo();
                    break;
            }

            if (!this.AcrobaticsEnabled)
                this.Acrobatics = 0;

            if (!this.CommunicationEnabled)
                this.Communication = 0;

            if (!this.HonorEnabled)
                this.Honor = 0;

            if (!this.InventoryPoisonCurePotionEnabled)
                this.InventoryPoisonCurePotions = 0;

            if (!this.MagicSkillForceBoltEnabled)
                this.MagicSkillForceBolt = 0;

            if (!this.MagicSkillLevitateEnabled)
                this.MagicSkillLevitate = 0;

            if (!this.MagicSkillReversalEnabled)
                this.MagicSkillReversal = 0;
        }
        #endregion
    }
}
