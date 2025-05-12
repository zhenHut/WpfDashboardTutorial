/// <summary>
/// ViewModel - [ "The Connector" ]
/// ViewModel exposes data contained in the Model objects to the View. The ViewModel performs
/// all modifications made to the Model data.
/// </summary>


using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using WpfDashboardTutorial.Commands;
using WpfDashboardTutorial.Model;
using WpfDashboardTutorial.View;

namespace WpfDashboardTutorial.ViewModel
{
    public class NavigationViewModel : BaseViewModel
    {
        #region Constructor
        public NavigationViewModel()
        {
            ObservableCollection<MenuItems> menutItems = new ObservableCollection<MenuItems>
            {
                new MenuItems { MenuName = "Home", MenuImage = "pack://application:,,,/Assets/Home_Icon.png" },
                new MenuItems { MenuName = "Desktop", MenuImage = "pack://application:,,,/Assets/Desktop_Icon.png" },
                new MenuItems { MenuName = "Document", MenuImage = "pack://application:,,,/Assets/Document_Icon.png" },
                new MenuItems { MenuName = "Download", MenuImage = "pack://application:,,,/Assets/Download_Icon.png" },
                new MenuItems { MenuName = "Pictures", MenuImage = "pack://application:,,,/Assets/Images_Icon.png" },
                new MenuItems { MenuName = "Music", MenuImage = "pack://application:,,,/Assets/Music_Icon.png" },
                new MenuItems { MenuName = "Movies", MenuImage = "pack://application:,,,/Assets/Movies_Icon.png" },
                new MenuItems { MenuName = "Trash", MenuImage = "pack://application:,,,/Assets/Trash_Icon.png" },

            };

            MenuItemsCollection = new CollectionViewSource { Source = menutItems };
            MenuItemsCollection.Filter += MenuItems_Filter;

            // Set Startup Page

            SelectedViewModel = new StartupViewModel();
        }
        #endregion

        #region Collection
        // CollectionViewSource enables XAML code to set the commonly used CollectionView properties.
        // passing these settings to the underlying view.
        private CollectionViewSource MenuItemsCollection;

        // ICollectionView enables collections to have the functionalities of current record management,
        // custom sorting, filtering, and grouping.
        public ICollectionView SourceCollection => MenuItemsCollection.View;

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
                MenuItemsCollection.View.Refresh();
                OnPropertyChanged();
            }
        }

        // Select ViewModel
        private object _selectedViewModel;
        public object SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                _selectedViewModel = value;
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

            MenuItems _items = e.Item as MenuItems;
            if (_items.MenuName.ToUpper().Contains(FilterText.ToUpper()))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
        }



        // Switch Views
        public void SwitchViews(object parameter)
        {
            switch (parameter)
            {
                case "Home":
                    SelectedViewModel = new HomeViewModel();
                    break;

                case "Desktop":
                    SelectedViewModel = new DesktopViewModel();
                    break;

                case "Document":
                    SelectedViewModel = new DocumentViewModel();
                    break;

                case "Download":
                    SelectedViewModel = new DownloadViewModel();
                    break;

                case "Pictures":
                    SelectedViewModel = new PictureViewModel();
                    break;

                case "Music":
                    SelectedViewModel = new MusicViewModel();
                    break;

                case "Movies":
                    SelectedViewModel = new MovieViewModel();
                    break;

                case "Trash":
                    SelectedViewModel = new TrashViewModel();
                    break;

                default:
                    SelectedViewModel = new HomeViewModel();
                    break;
            }

        }

      

        // Show PC view
        public void PCView()
        {
            SelectedViewModel = new PCViewModel();
        }
        #endregion

        #region Commands

        // Menu Button Command
        private ICommand _menuCommand;
        public ICommand MenuCommand
        {
            get
            {
                if (_menuCommand == null)
                {
                    _menuCommand = new RelayCommand(param => SwitchViews(param));
                }
                return _menuCommand;
            }
        }


        // This PC Button Command

        private ICommand _pcCommand;
        public ICommand ThisPCCommand
        {
            get
            {
                if (_pcCommand == null)
                {
                    _pcCommand = new RelayCommand(param => PCView());
                }
                return _pcCommand;
            }
        }

        // Show Home View

        private void ShowHome()
        {
            SelectedViewModel = new HomeViewModel();
        }

        // Back button Command

        private ICommand _backHomeCommand;
        public ICommand BackHomeCommand
        {
            get
            {
                if (_backHomeCommand == null)
                    _backHomeCommand = new RelayCommand(param => ShowHome());

                return _backHomeCommand;
            }
        }

        // Close App

        public void CloseApp(object obj)
        {
            if (obj is MainWindow win)
            {
                win.Close();
            }
        }

        // Close App Command

        private ICommand _closeCommand;
        public ICommand CloseAppCommand
        {
            get
            {
                if (_closeCommand == null)
                    _closeCommand = new RelayCommand(p => CloseApp(p));

                return _closeCommand;
            }
        }


        #endregion
    }
}
