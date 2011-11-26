
namespace QfgCharacterLibrary.Interfaces
{
    public interface IQfgGameInfo
    {
        int MaxCharacterStatValue { get; }

        int MaxMagicStatValue { get; }

        int MaxDaggers { get; }

        int MaxHealingPotions { get; }

        int MaxVigorPotions { get; }

        int MaxMagicPotions { get; }

        bool HasCommunication { get; }

        bool HasAcrobatics { get; }

        bool HasForceBoltMagic { get; }

        bool HasLevitate { get; }

        bool HasReversal { get; }

        bool HasPaladin { get; }

        void LoadMappings(int index, int value, QfgCharacter character);
    }
}
