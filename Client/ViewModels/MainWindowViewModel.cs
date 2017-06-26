using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
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
    public class MainWindowViewModel : ViewModelBase
    {
        private void SetCurrentViewModel(ViewModelTypes viewModelType)
        {
            ViewModelBase vm = null;
            switch (viewModelType)
            {
                case ViewModelTypes.CharacterSelect:
                    vm = new CharacterSelectViewModel();
                    break;
                case ViewModelTypes.NewCharacter:
                    vm = new NewCharacterViewModel();
                    break;
                default:
                    throw new ArgumentException($"Cannot change to type: {viewModelType.ToString()}");
            }
            CurrentViewModel = vm;
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainWindowViewModel()
        {
            Messenger.Default.Register<ViewModelTypes>(this, MessageTokens.WindowContentChange, SetCurrentViewModel);
            SetCurrentViewModel(ViewModelTypes.CharacterSelect);
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.

                ((CharacterSelectViewModel)CurrentViewModel).Characters.Add(new Models.Character { Name = "Chuck" });
            }
            else
            {
                // Code runs "for real"
            }
        }

        public RelayCommand<Window> CloseWindowCommand => new RelayCommand<Window>(CloseWindow);
        private void CloseWindow(Window view)
        {
            view.Close();
        }

        public RelayCommand OpenNewCharacterSheet => new RelayCommand(() => SetCurrentViewModel(ViewModelTypes.NewCharacter));
        public RelayCommand OpenCharacterRoster => new RelayCommand(() => SetCurrentViewModel(ViewModelTypes.CharacterSelect));

        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                RaisePropertyChanged(nameof(CurrentViewModel));
            }
        }
    }
}