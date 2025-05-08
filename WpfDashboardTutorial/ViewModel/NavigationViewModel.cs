/// <summary>
/// ViewModel - [ "The Connector" ]
/// ViewModel exposes data contained in the Model objects to the View. The ViewModel performs
/// all modifications made to the Model data.
/// </summary>


using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using WpfDashboardTutorial.Model;

namespace WpfDashboardTutorial.ViewModel
{
    public class NavigationViewModel : INotifyPropertyChanged
    {
        #region Constructor
        public NavigationViewModel()
        {
            ObservableCollection<MenuItems> menutItems = new ObservableCollection<MenuItems>
            {
                new MenuItems { MenuName = "Home", MenuImage = @"Assets/Home_Icon.png" },
                new MenuItems { MenuName = "Desktop", MenuImage = @"Assets/Desktop_Icon.png" },
                new MenuItems { MenuName = "Document", MenuImage = @"Assets/Document_Icon.png" },
                new MenuItems { MenuName = "Download", MenuImage = @"Assets/Download_Icon.png" },
                new MenuItems { MenuName = "Pictures", MenuImage = @"Assets/Images_Icon.png" },
                new MenuItems { MenuName = "Music", MenuImage = @"Assets/Music_Icon.png" },
                new MenuItems { MenuName = "Movies", MenuImage = @"Assets/Movies_Icon.png" },
                new MenuItems { MenuName = "Trash", MenuImage = @"Assets/Trash_Icon.png" },

            };

            MenuItemsCollection = new CollectionViewSource { Source = menutItems };
        }
        #endregion

        #region Collection
        // CollectionViewSource enables XAML code to set the commonly used CollectionView properties.
        // passing htes settings to the underlying view.
        private CollectionViewSource MenuItemsCollection;

        // ICollectionView enables collections to have the functionalities of current record management,
        // custom sorting, filtering, and grouping.
        public ICollectionView SourceCollection => MenuItemsCollection.View;
       
        #endregion

        #region PropertyChanged EventHandler
        // Implement interface member for INotifiyPropertyChanged.
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion


        #region Properties

        // Text Search Filter.
        private string _filterText;
        public string FilterText
        {
            get => _filterText;
            set
            {
                FilterText = value;
                MenuItemsCollection.View.Refresh();
                OnPropertyChanged();
            }
        }

        #endregion

        #region Methods
        private void MenuItems_Filter(object sender, FilterEventArgs e)
        {
            if(string.IsNullOrEmpty(FilterText))
            {
                e.Accepted = true;
                return;
            }
            
            MenuItems _items = e.Item as MenuItems;
            if(_items.MenuName.ToUpper().Contains(FilterText.ToUpper()))
            {
                e.Accepted= true;
            }
            else
            {
                e.Accepted = false;
            }
        }
        #endregion
    }
}
