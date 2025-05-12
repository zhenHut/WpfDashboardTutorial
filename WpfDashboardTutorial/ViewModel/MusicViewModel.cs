
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using WpfDashboardTutorial.Model;

namespace WpfDashboardTutorial.ViewModel
{
    public class MusicViewModel : BaseViewModel
    {
        #region Constructor
        public MusicViewModel()
        {
            ObservableCollection<MusicItems> musicItems = new ObservableCollection<MusicItems>
            {

                new MusicItems { MusicName = "Bass", MusicImage = "pack://application:,,,/Assets/note_icon.png" },
                new MusicItems { MusicName = "Beats", MusicImage = "pack://application:,,,/Assets/note_icon.png" },
                new MusicItems { MusicName = "Electronic", MusicImage = "pack://application:,,,/Assets/note_icon.png" },
                new MusicItems { MusicName = "Hip hop", MusicImage = "pack://application:,,,/Assets/note_icon.png" },
                new MusicItems { MusicName = "Deep House", MusicImage = "pack://application:,,,/Assets/note_icon.png" },
                new MusicItems { MusicName = "Instrumental", MusicImage = "pack://application:,,,/Assets/note_icon.png" }

            };

            MusicItemsCollection = new CollectionViewSource { Source = musicItems };
            MusicItemsCollection.Filter += MenuItems_Filter;
        }
        #endregion

        #region Collection
        private CollectionViewSource MusicItemsCollection;
        public ICollectionView MusicSourceCollection => MusicItemsCollection.View;
        #endregion

        #region Properties
        private string filterText;
        public string FilterText
        {
            get => filterText;
            set
            {
                filterText = value;
                MusicItemsCollection.View.Refresh();
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

            MusicItems _item = e.Item as MusicItems;
            if (_item.MusicName.ToUpper().Contains(FilterText.ToUpper()))
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
