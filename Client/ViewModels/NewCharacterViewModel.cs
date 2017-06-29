using Client.DataAccess.Sqlite;
using Client.Messages;
using Client.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Client.ViewModels
{
    public class NewCharacterViewModel : ViewModelBase
    {
        #region Fields
        private Character _newCharacter = new Character(new CharacterAccessor());
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
                    BeginQuestCmd.RaiseCanExecuteChanged();
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
                    BeginQuestCmd.RaiseCanExecuteChanged();
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
                    BeginQuestCmd.RaiseCanExecuteChanged();
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
                    BeginQuestCmd.RaiseCanExecuteChanged();
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
                    BeginQuestCmd.RaiseCanExecuteChanged();
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
                    BeginQuestCmd.RaiseCanExecuteChanged();
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
            RandomlySetCharacterRace();
            RandomlySetCharacterClass();
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
        public RelayCommand BeginQuestCmd => new RelayCommand(BeginQuest, CanBeginQuest);
        public RelayCommand RollStats => new RelayCommand(RollNewStatsForCharacter);
        public RelayCommand UnrollStats => new RelayCommand(UnrollPreviousStatsForCharacter, CanUnrollStats);
        public RelayCommand GetNewCharacterName => new RelayCommand(RandomlySetCharacterName);
        public RelayCommand<Races> SetCharacterRaceCmd => new RelayCommand<Races>(SetCharacterRace);
        public RelayCommand<Classes> SetCharacterClassCmd => new RelayCommand<Classes>(SetCharacterClass);
        #endregion

        #region Methods
        private void SetCharacterClass(Classes obj)
        {
            CharacterClass = obj;
        }

        private void SetCharacterRace(Races obj)
        {
            CharacterRace = obj;
        }

        private bool CanUnrollStats()
        {
            return _previousCharacterStats.Count > 0;
        }

        private bool CanBeginQuest()
        {
            return _newCharacter?.IsValid ?? false;
        }

        private void RandomlySetCharacterName()
        {
            CharacterName = RandomlyGenerateName();
        }

        private void RandomlySetCharacterRace()
        {
            var lastRace = (int)Enum.GetValues(typeof(Races)).Cast<Races>().Max();
            CharacterRace = (Races)Enum.Parse(typeof(Races), (new Random()).Next(1, lastRace).ToString());
        }

        private void RandomlySetCharacterClass()
        {
            var lastClass = (int)Enum.GetValues(typeof(Classes)).Cast<Classes>().Max();
            CharacterClass = (Classes)Enum.Parse(typeof(Classes), (new Random()).Next(1, lastClass).ToString());
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
            var stats = new CharacterStats { Strength = statGenerator.Next(1, 16), Constitution = statGenerator.Next(1, 16), Dexterity = statGenerator.Next(1, 16), Intelligence = statGenerator.Next(1, 16), Wisdom = statGenerator.Next(1, 16), Charisma = statGenerator.Next(1, 16), HpMax = statGenerator.Next(1, 16), MpMax = statGenerator.Next(1, 16) };
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
            BeginQuestCmd.RaiseCanExecuteChanged();
        }

        private void BeginQuest()
        {
            _newCharacter.Save();
            Messenger.Default.Send(new WindowContentChangeMessage(ViewModelTypes.Game) { Character = _newCharacter }, MessageTokens.WindowContentChange);
        }
        #endregion
    }
}