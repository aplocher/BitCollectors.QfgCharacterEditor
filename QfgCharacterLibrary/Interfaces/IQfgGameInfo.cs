
namespace BitCollectors.QfgCharacterEditor.Library.Interfaces
{
    public interface IQfgGameInfo
    {
        int MaxCharacterStatValue { get; }

        int MaxMagicStatValue { get; }

        int MaxDaggers { get; }

        int MaxHealingPotions { get; }

        int MaxVigorPotions { get; }

        int MaxPoisonCurePotions { get; }

        int MaxMagicPotions { get; }

        bool HasCommunication { get; }

        bool HasHonor { get; }

        bool HasAcrobatics { get; }

        bool HasForceBoltMagic { get; }

        bool HasLevitate { get; }

        bool HasReversal { get; }

        bool HasPaladin { get; }

        bool HasPoisonCurePotion { get; }

        void LoadMappings(int index, int value, QfgCharacter character);

        string EncodedCharacterString(QfgCharacter character);

        void LoadCharacterString(string characterString, QfgCharacter character);
    }
}
