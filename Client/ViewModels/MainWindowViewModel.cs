using Client.DataAccess.Sqlite;
using Client.Messages;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
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
        private void SetCurrentViewModel(WindowContentChangeMessage msg)
        {
            ViewModelBase vm = null;
            ViewModelTypes viewModelType = msg.ViewModelType;
            switch (viewModelType)
            {
                case ViewModelTypes.CharacterSelect:
                    vm = new CharacterSelectViewModel(new CharacterAccessor());
                    break;
                case ViewModelTypes.NewCharacter:
                    vm = new NewCharacterViewModel();
                    break;
                case ViewModelTypes.Game:
                    vm = new GameViewModel(msg.Character);
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
            Messenger.Default.Register<WindowContentChangeMessage>(this, MessageTokens.WindowContentChange, SetCurrentViewModel);
            CurrentViewModel = new CharacterSelectViewModel(new CharacterAccessor());
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.

                ((CharacterSelectViewModel)CurrentViewModel).CharacterSummaries.Add(new Models.CharacterSummary { Name = "Chuck" });
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

        public RelayCommand OpenNewCharacterSheet => new RelayCommand(() => SetCurrentViewModel(new WindowContentChangeMessage(ViewModelTypes.NewCharacter)));
        public RelayCommand OpenCharacterRoster => new RelayCommand(() => SetCurrentViewModel(new WindowContentChangeMessage(ViewModelTypes.CharacterSelect)));

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