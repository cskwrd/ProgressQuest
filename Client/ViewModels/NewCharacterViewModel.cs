using Client.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;

namespace Client.ViewModels
{
    public class NewCharacterViewModel : ViewModelBase
    {
        #region Fields
        private Character _newCharacter = new Character();
        private Stack<CharacterStats> _previousCharacterStats = new Stack<CharacterStats>();
        #endregion

        #region Properties
        public string CharacterName
        {
            get => _newCharacter.Name;
            set
            {
                if (value != _newCharacter.Name)
                {
                    _newCharacter.Name = value;
                    RaisePropertyChanged(nameof(CharacterName));
                }
            }
        }

        public int CharacterStrength
        {
            get => _newCharacter.Stats.Strength;
            set
            {
                if (value != _newCharacter.Stats.Strength)
                {
                    _newCharacter.Stats.Strength = value;
                    RaisePropertyChanged(nameof(CharacterStrength));
                    RaisePropertyChanged(nameof(TotalStats));
                }
            }
        }

        public int CharacterConstitution
        {
            get => _newCharacter.Stats.Constitution;
            set
            {
                if (value != _newCharacter.Stats.Constitution)
                {
                    _newCharacter.Stats.Constitution = value;
                    RaisePropertyChanged(nameof(CharacterConstitution));
                    RaisePropertyChanged(nameof(TotalStats));
                }
            }
        }

        public int CharacterDexterity
        {
            get => _newCharacter.Stats.Dexterity;
            set
            {
                if (value != _newCharacter.Stats.Dexterity)
                {
                    _newCharacter.Stats.Dexterity = value;
                    RaisePropertyChanged(nameof(CharacterDexterity));
                    RaisePropertyChanged(nameof(TotalStats));
                }
            }
        }

        public int CharacterIntelligence
        {
            get => _newCharacter.Stats.Intelligence;
            set
            {
                if (value != _newCharacter.Stats.Intelligence)
                {
                    _newCharacter.Stats.Intelligence = value;
                    RaisePropertyChanged(nameof(CharacterIntelligence));
                    RaisePropertyChanged(nameof(TotalStats));
                }
            }
        }

        public int CharacterWisdom
        {
            get => _newCharacter.Stats.Wisdom;
            set
            {
                if (value != _newCharacter.Stats.Wisdom)
                {
                    _newCharacter.Stats.Wisdom = value;
                    RaisePropertyChanged(nameof(CharacterWisdom));
                    RaisePropertyChanged(nameof(TotalStats));
                }
            }
        }

        public int CharacterCharisma
        {
            get => _newCharacter.Stats.Charisma;
            set
            {
                if (value != _newCharacter.Stats.Charisma)
                {
                    _newCharacter.Stats.Charisma = value;
                    RaisePropertyChanged(nameof(CharacterCharisma));
                    RaisePropertyChanged(nameof(TotalStats));
                }
            }
        }

        public Races CharacterRace
        {
            get => _newCharacter.Race;
            set
            {
                if (value != _newCharacter.Race)
                {
                    _newCharacter.Race = value;
                    RaisePropertyChanged(nameof(CharacterRace));
                }
            }
        }

        public Classes CharacterClass
        {
            get => _newCharacter.Class;
            set
            {
                if (value != _newCharacter.Class)
                {
                    _newCharacter.Class = value;
                    RaisePropertyChanged(nameof(CharacterClass));
                }
            }
        }

        public int TotalStats
        {
            get => CharacterStrength + CharacterConstitution + CharacterDexterity + CharacterIntelligence + CharacterWisdom + CharacterCharisma;
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the NewCharacterViewModel class.
        /// </summary>
        public NewCharacterViewModel()
        {
            RandomlySetCharacterName();
            SetCharacterStats(GenerateRandomCharacterStatSet());
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                // Code runs "for real"
            }
        }

        #region Commands
        public RelayCommand BeginQuest => new RelayCommand(() => Messenger.Default.Send(ViewModelTypes.NewCharacter, MessageTokens.WindowContentChange));
        public RelayCommand RollStats => new RelayCommand(RollNewStatsForCharacter);
        public RelayCommand UnrollStats => new RelayCommand(UnrollPreviousStatsForCharacter, CanUnrollStats);
        public RelayCommand GetNewCharacterName => new RelayCommand(RandomlySetCharacterName);
        #endregion

        #region Methods
        private bool CanUnrollStats()
        {
            return _previousCharacterStats.Count > 0;
        }

        private void RandomlySetCharacterName()
        {
            CharacterName = RandomlyGenerateName();
        }

        private string RandomlyGenerateName()
        {
            string[][] KParts = { "br|cr|dr|fr|gr|j|kr|l|m|n|pr||||r|sh|tr|v|wh|x|y|z".Split('|'), "a|a|e|e|i|i|o|o|u|u|ae|ie|oo|ou".Split('|'), "b|ck|d|g|k|m|n|p|t|v|x|z".Split('|') };
            string name = string.Empty;
            for (int i = 0; i < 6; i++)
            {
                if (name != string.Empty)
                {
                    name += RandomPick(KParts[i % 3]);
                }
                else
                {
                    name += RandomPick(KParts[i % 3]).ToUpper();
                }
            }

            return name;
        }

        private string RandomPick(string[] pickableSet)
        {
            var rand = new Random();
            return pickableSet[rand.Next(pickableSet.Length)];
        }

        private void RollNewStatsForCharacter()
        {
            _previousCharacterStats.Push(_newCharacter.Stats);
            SetCharacterStats(GenerateRandomCharacterStatSet());
            UnrollStats.RaiseCanExecuteChanged();
        }

        private void UnrollPreviousStatsForCharacter()
        {
            SetCharacterStats(_previousCharacterStats.Pop());
            UnrollStats.RaiseCanExecuteChanged();
        }

        private CharacterStats GenerateRandomCharacterStatSet()
        {
            Random statGenerator = new Random();
            var stats = new CharacterStats { Strength = statGenerator.Next(1, 16), Constitution = statGenerator.Next(1, 16), Dexterity = statGenerator.Next(1, 16), Intelligence = statGenerator.Next(1, 16), Wisdom = statGenerator.Next(1, 16), Charisma = statGenerator.Next(1, 16) };
            return stats;
        }

        private void SetCharacterStats(CharacterStats stats)
        {
            _newCharacter.Stats = stats;

            RaisePropertyChanged(nameof(CharacterStrength));
            RaisePropertyChanged(nameof(CharacterConstitution));
            RaisePropertyChanged(nameof(CharacterDexterity));
            RaisePropertyChanged(nameof(CharacterIntelligence));
            RaisePropertyChanged(nameof(CharacterWisdom));
            RaisePropertyChanged(nameof(CharacterCharisma));
            RaisePropertyChanged(nameof(TotalStats));
        }
        #endregion
    }
}