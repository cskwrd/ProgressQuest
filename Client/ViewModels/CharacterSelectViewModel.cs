using Client.Messages;
using Client.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Client.ViewModels
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class CharacterSelectViewModel : ViewModelBase
    {
        [PreferredConstructor]
        public CharacterSelectViewModel()
        {

        }

        /// <summary>
        /// Initializes a new instance of the CharacterSelectViewModel class.
        /// </summary>
        public CharacterSelectViewModel(ICharacterAccessor characterAccessor)
        {
            CharacterSummaries = new List<CharacterSummary>();

            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                // Code runs "for real"
                CharacterSummaries = characterAccessor.GetSavedCharacterSummaries();
            }
        }

        private Action<ViewModelBase> _setNewScreen = new Action<ViewModelBase>(vm => { });

        public bool CharactersExist => CharacterSummaries.Any();

        private List<CharacterSummary> _characterSummaries;
        public List<CharacterSummary> CharacterSummaries
        {
            get => _characterSummaries;
            set
            {
                _characterSummaries = value;
                RaisePropertyChanged(nameof(CharacterSummaries));
            }
        }

        public RelayCommand OpenNewCharacterSheet => new RelayCommand(() => Messenger.Default.Send(new WindowContentChangeMessage(ViewModelTypes.NewCharacter), MessageTokens.WindowContentChange));
        public RelayCommand<string> ContinueQuestingCmd => new RelayCommand<string>(ContinueQuesting);

        private void ContinueQuesting(string obj)
        {
            MessageBox.Show("Would load character here");
        }

        public RelayCommand<string> DeleteCharacterCmd => new RelayCommand<string>(DeleteCharacter);

        private void DeleteCharacter(string obj)
        {
            MessageBox.Show("Would load character here");
        }
    }
}