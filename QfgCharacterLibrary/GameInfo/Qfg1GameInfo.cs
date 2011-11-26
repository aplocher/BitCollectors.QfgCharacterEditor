using QfgCharacterLibrary.Enums;
using QfgCharacterLibrary.Interfaces;

namespace QfgCharacterLibrary.GameInfo
{
    public class Qfg1GameInfo : IQfgGameInfo
    {
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
                    character.MagicSkillFetch = value;
                    break;

                case 24:
                    character.MagicSkillFlame = value;
                    break;

                case 25:
                    character.MagicSkillCalm = value;
                    break;

                case 26:
                    character.MagicSkillZap = value;
                    break;

                case 27:
                    character.MagicSkillDazzle = value;
                    break;

                case 28:
                    character.MagicSkillTrigger = value;
                    break;

                case 29:
                    character.MagicSkillDetect = value;
                    break;

                case 30:
                    character.MagicSkillOpen = value;
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
            get { return 8; }
        }

        public int MaxVigorPotions
        {
            get { return 7; }
        }

        public int MaxMagicPotions
        {
            get { return 6; }
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

        #region IQfgGameInfo Members


        public bool HasCommunication
        {
            get { return false; }
        }

        public bool HasAcrobatics
        {
            get { return false; }
        }

        #endregion
    }
}
