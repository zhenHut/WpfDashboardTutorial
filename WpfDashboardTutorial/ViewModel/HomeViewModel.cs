
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using WpfDashboardTutorial.Model;

namespace WpfDashboardTutorial.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {
        #region constructor
        public HomeViewModel()
        {           
            ObservableCollection<HomeItems> homeItems = new ObservableCollection<HomeItems>
            {
                new HomeItems { HomeName = "This PC", HomeImage = "pack://application:,,,/Assets/pc_icon.png" },               
            };

            HomeItemsCollection = new CollectionViewSource { Source = homeItems };
        }
        #endregion

        #region Collection

        private CollectionViewSource HomeItemsCollection;
        public ICollectionView HomeSourceCollection => HomeItemsCollection.View;
        #endregion
    }

}