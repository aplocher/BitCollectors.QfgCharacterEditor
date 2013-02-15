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
        private int _honor;
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

        public int Honor
        {
            get
            {
                return _honor;
            }
            set
            {
                if (_honor != value)
                    IsDirty = true;

                _honor = value;
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
            if (dataString.Length == 86)
                this.QfgGame = QfgGames.Qfg1;
            else if (dataString.Length == 96)
                this.QfgGame = QfgGames.Qfg2;

            this.CharacterName = name;
            this.QfgGameInfo.LoadCharacterString(dataString, this);
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
                    this.QfgGameInfo = new Qfg2GameInfo();
                    break;
            }
        }
        #endregion
    }
}
