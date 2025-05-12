
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using WpfDashboardTutorial.Model;

namespace WpfDashboardTutorial.ViewModel
{
    public class DownloadViewModel : BaseViewModel
    {
        #region Constructor
        public DownloadViewModel()
        {
            ObservableCollection<DownloadItems> downloadItems = new ObservableCollection<DownloadItems>
            {
                new DownloadItems { DownloadName = "Visual Studio 2019", DownloadImage = "pack://application:,,,/Assets/vs_icon.png" },
                new DownloadItems { DownloadName = "Android Studio", DownloadImage = "pack://application:,,,/Assets/android_icon.png" },
                new DownloadItems { DownloadName = "Python", DownloadImage = "pack://application:,,,/Assets/python_icon.png" },
                new DownloadItems { DownloadName = "Swift", DownloadImage = "pack://application:,,,/Assets/swift_icon.png" },
                new DownloadItems { DownloadName = "Visual Studio Code", DownloadImage = "pack://application:,,,/Assets/vsc_icon.png" },
                new DownloadItems { DownloadName = "Javascript", DownloadImage = "pack://application:,,,/Assets/javascript_icon.png" },
                new DownloadItems { DownloadName = "HTML 5", DownloadImage = "pack://application:,,,/Assets/html_icon.png" },
                new DownloadItems { DownloadName = "Angular", DownloadImage = "pack://application:,,,/Assets/angular_icon.png" },
                new DownloadItems { DownloadName = "Flutter", DownloadImage = "pack://application:,,,/Assets/flutter_icon.png" }
            };

            DownloadItemsCollection = new CollectionViewSource { Source = downloadItems };
            DownloadItemsCollection.Filter += DownloadItems_Filter;

        }

        #endregion

        #region Collection
        private CollectionViewSource DownloadItemsCollection;
        public ICollectionView DownloadSourceCollection => DownloadItemsCollection.View;

        #endregion

        #region Properties

        private string _filterText = string.Empty;
        public string FilterText
        {
            get => _filterText;
            set
            {
                _filterText = value;
                DownloadItemsCollection.View.Refresh();
                OnPropertyChanged();
            }
        }

        #endregion

        #region Methods
        private void DownloadItems_Filter(object sender, FilterEventArgs e)
        {
            if (string.IsNullOrEmpty(FilterText))
            {
                e.Accepted = true;
                return;
            }

            DownloadItems? _item = e.Item as DownloadItems;
            if (_item!.DownloadName.ToUpper().Contains(FilterText.ToUpper()))
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
