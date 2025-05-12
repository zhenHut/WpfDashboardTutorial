
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using WpfDashboardTutorial.Model;

namespace WpfDashboardTutorial.ViewModel
{
    public class PCViewModel : BaseViewModel
    {
        #region Constructor
        public PCViewModel()
        {
            ObservableCollection<PCItems> pcItems = new ObservableCollection<PCItems>
            {
                new PCItems { PCName = "Local Disk (C:)", PCImage = "pack://application:,,,/Assets/drive_icon.png" },
                new PCItems { PCName = "Local Disk (D:)", PCImage = "pack://application:,,,/Assets/drive_icon.png" },
                new PCItems { PCName = "Local Disk (E:)", PCImage = "pack://application:,,,/Assets/drive_icon.png" },
                new PCItems { PCName = "Local Disk (F:)", PCImage = "pack://application:,,,/Assets/drive_icon.png" }

            };

            PCItemsCollection = new CollectionViewSource { Source = pcItems };
        }

        #endregion

        #region Collection
        private readonly CollectionViewSource PCItemsCollection;
        public ICollectionView PCSourceCollection => PCItemsCollection.View;

        #endregion

    }
}
