using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using WpfDashboardTutorial.Model;

namespace WpfDashboardTutorial.ViewModel
{
    public class DesktopViewModel : BaseViewModel
    {
        #region Constructor
        public DesktopViewModel()
        {
            ObservableCollection<DesktopItems> desktopItems = new ObservableCollection<DesktopItems>
            {
                new DesktopItems { DesktopName="File", DesktopImage="pack://application:,,,/Assets/file_icon.png"},
                new DesktopItems { DesktopName="Music", DesktopImage="pack://application:,,,/Assets/musical_icon.png"},
                new DesktopItems { DesktopName="Pictures", DesktopImage="pack://application:,,,/Assets/picture_icon.png"},
                new DesktopItems { DesktopName="Analytics", DesktopImage="pack://application:,,,/Assets/analytics_icon.png"},
                new DesktopItems { DesktopName="Webcam", DesktopImage="pack://application:,,,/Assets/webcam_icon.png"},
                new DesktopItems { DesktopName="Printer", DesktopImage="pack://application:,,,/Assets/printer_icon.png"},
                new DesktopItems { DesktopName="Services", DesktopImage="pack://application:,,,/Assets/services_icon.png"},
                new DesktopItems { DesktopName="Chart", DesktopImage="pack://application:,,,/Assets/chart_icon.png"},
                new DesktopItems { DesktopName="Film", DesktopImage="pack://application:,,,/Assets/film_icon.png"},
                new DesktopItems { DesktopName="Alarm", DesktopImage="pack://application:,,,/Assets/alarm_icon.png"},
                new DesktopItems { DesktopName="Headphone", DesktopImage="pack://application:,,,/Assets/headphone_icon.png"},
                new DesktopItems { DesktopName="Password", DesktopImage="pack://application:,,,/Assets/password_icon.png"},
                new DesktopItems { DesktopName = "Calendar", DesktopImage = "pack://application:,,,/Assets/calendar_icon.png" }
            };

            DesktopItemsCollection = new CollectionViewSource { Source = desktopItems };
            DesktopItemsCollection.Filter += MenuItems_Filter;
        }
        #endregion

        #region Collection
        // CollectionViewSource enables XAML code to set the commonly used CollectionView properties.
        // passing these settings to the underlying view.
        private CollectionViewSource DesktopItemsCollection;

        // ICollectionView enables collections to have the functionalities of current record management,
        // custom sorting, filtering, and grouping.
        public ICollectionView DesktopSourceCollection => DesktopItemsCollection.View;

        #endregion

        #region Properties

        // Text Search Filter.
        private string _filterText = string.Empty;
        public string FilterText
        {
            get => _filterText;
            set
            {
                _filterText = value;
                DesktopItemsCollection.View.Refresh();
                OnPropertyChanged();
            }
        }

        #endregion

        #region Methods
        private void MenuItems_Filter(object sender, FilterEventArgs e)
        {
            if (string.IsNullOrEmpty(FilterText))
            {
                e.Accepted = true;
                return;
            }

            DesktopItems? _items = e.Item as DesktopItems;
            if (_items!.DesktopName.ToUpper().Contains(FilterText.ToUpper()))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
        }
        #endregion
    }
}
