
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using WpfDashboardTutorial.Model;

namespace WpfDashboardTutorial.ViewModel
{
    public class PictureViewModel : BaseViewModel
    {
        #region Constructor
        public PictureViewModel()
        {           
            ObservableCollection<PictureItems> pictureItems = new ObservableCollection<PictureItems>
            {

                new PictureItems { PictureName = "Logo", PictureImage = "pack://application:,,,/Assets/channel_icon.png" }
               
            };

            PictureItemsCollection = new CollectionViewSource { Source = pictureItems };
            PictureItemsCollection.Filter += MenuItems_Filter;

        }
        #endregion

        #region Collection
        private CollectionViewSource PictureItemsCollection;
        public ICollectionView PictureSourceCollection => PictureItemsCollection.View;

        #endregion

        #region Propertiers
        private string filterText;
        public string FilterText
        {
            get => filterText;
            set
            {
                filterText = value;
                PictureItemsCollection.View.Refresh();
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

            PictureItems _item = e.Item as PictureItems;
            if (_item.PictureName.ToUpper().Contains(FilterText.ToUpper()))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
        }
        #endregion}

    }
}
