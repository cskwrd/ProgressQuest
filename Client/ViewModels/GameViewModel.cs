using Client.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace Client.ViewModels
{
    public class GameViewModel : ViewModelBase
    {
        #region Fields
        private Character _character;
        #endregion

        #region Properties
        public string CharacterName
        {
            get => _character.Name;
        }

        public Races CharacterRace
        {
            get => _character.Race;
        }

        public Classes CharacterClass
        {
            get => _character.Class;
        }

        public int CharacterLevel
        {
            get => _character.Level;
        }

        public int CharacterStrength
        {
            get => _character.Stats.Strength;
        }

        public int CharacterConstitution
        {
            get => _character.Stats.Constitution;
        }

        public int CharacterDexterity
        {
            get => _character.Stats.Dexterity;
        }

        public int CharacterIntelligence
        {
            get => _character.Stats.Intelligence;
        }

        public int CharacterWisdom
        {
            get => _character.Stats.Wisdom;
        }

        public int CharacterCharisma
        {
            get => _character.Stats.Charisma;
        }

        public int CharacterMaxHp
        {
            get => _character.Stats.HpMax;
        }

        public int CharacterMaxMp
        {
            get => _character.Stats.MpMax;
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the GameViewModel class.
        /// </summary>
        [PreferredConstructor]
        public GameViewModel()
        {
            // TODO : load character from datastore
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                // Code runs "for real"
            }
        }

        public GameViewModel(Character character) : this()
        {
            _character = character;
        }

        #region Commands
        #endregion

        #region Methods
        #endregion
    }
}