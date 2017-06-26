using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace Client.ViewModels
{
    public class NewCharacterViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the NewCharacterViewModel class.
        /// </summary>
        public NewCharacterViewModel()
        {
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                // Code runs "for real"
            }
        }

        public RelayCommand BeginQuest => new RelayCommand(() => Messenger.Default.Send(ViewModelTypes.NewCharacter, MessageTokens.WindowContentChange));
    }
}