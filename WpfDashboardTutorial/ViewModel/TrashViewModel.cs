
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using WpfDashboardTutorial.Model;

namespace WpfDashboardTutorial.ViewModel
{
    public class TrashViewModel : BaseViewModel
    {

        #region Constructor
        public TrashViewModel()
        {
            ObservableCollection<TrashItems> trashItems = new ObservableCollection<TrashItems>
            {

                new TrashItems { TrashName = "Data.txt", TrashImage = "pack://application:,,,/Assets/notepad_icon.png" }

            };

            TrashItemsCollection = new CollectionViewSource { Source = trashItems };
            TrashItemsCollection.Filter += MenuItems_Filter;

        }

        #endregion
        #region Collection
        private CollectionViewSource TrashItemsCollection;
        public ICollectionView TrashSourceCollection => TrashItemsCollection.View;
        #endregion

        #region Properties
        private string filterText;
        public string FilterText
        {
            get => filterText;
            set
            {
                filterText = value;
                TrashItemsCollection.View.Refresh();
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

            TrashItems _item = e.Item as TrashItems;
            if (_item.TrashName.ToUpper().Contains(FilterText.ToUpper()))
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
