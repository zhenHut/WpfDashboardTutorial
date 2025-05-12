using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfDashboardTutorial.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region PropertyChanged EventHandler
        // Implement interface member for INotifiyPropertyChanged.
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
