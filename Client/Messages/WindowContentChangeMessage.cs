using Client.Models;
using Client.ViewModels;

namespace Client.Messages
{
    public class WindowContentChangeMessage
    {
        public WindowContentChangeMessage(ViewModelTypes vmType)
        {
            ViewModelType = vmType;
        }

        public ViewModelTypes ViewModelType { get; set; }
        public Character Character { get; set; }
    }
}
