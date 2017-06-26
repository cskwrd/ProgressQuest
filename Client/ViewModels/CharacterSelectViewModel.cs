using Client.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;

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
        /// <summary>
        /// Initializes a new instance of the CharacterSelectViewModel class.
        /// </summary>
        public CharacterSelectViewModel()
        {
            Characters = new List<Character>();

            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                // Code runs "for real"
            }
        }

        private Action<ViewModelBase> _setNewScreen = new Action<ViewModelBase>(vm => { });

        public bool CharactersExist => Characters.Any();

        private List<Character> _characters;
        public List<Character> Characters
        {
            get => _characters;
            set
            {
                _characters = value;
                RaisePropertyChanged(nameof(Characters));
            }
        }

        public RelayCommand OpenNewCharacterSheet => new RelayCommand(() => Messenger.Default.Send(ViewModelTypes.NewCharacter, MessageTokens.WindowContentChange));

    }
}