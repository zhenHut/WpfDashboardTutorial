
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using WpfDashboardTutorial.Model;

namespace WpfDashboardTutorial.ViewModel
{
    public class MovieViewModel : BaseViewModel
    {
        #region Constructor
        public MovieViewModel()
        {           
            ObservableCollection<MovieItems> movieItems = new ObservableCollection<MovieItems>
            {

                new MovieItems { MovieName = "Action", MovieImage = "pack://application:,,,/Assets/clap_icon.png" },
                new MovieItems { MovieName = "Thriller", MovieImage = "pack://application:,,,/Assets/clap_icon.png" },
                new MovieItems { MovieName = "Adventure", MovieImage = "pack://application:,,,/Assets/clap_icon.png" },
                new MovieItems { MovieName = "Drama", MovieImage = "pack://application:,,,/Assets/clap_icon.png" },
                new MovieItems { MovieName = "Fantasy", MovieImage = "pack://application:,,,/Assets/clap_icon.png" },
                new MovieItems { MovieName = "Mystery", MovieImage = "pack://application:,,,/Assets/clap_icon.png" }

            };

            MovieItemsCollection = new CollectionViewSource { Source = movieItems };
            MovieItemsCollection.Filter += MenuItems_Filter;

        }

        #endregion

        #region Collection

        private CollectionViewSource MovieItemsCollection;
        public ICollectionView MovieSourceCollection => MovieItemsCollection.View;

        #endregion

        #region properties
        private string filterText;
        public string FilterText
        {
            get => filterText;
            set
            {
                filterText = value;
                MovieItemsCollection.View.Refresh();
                OnPropertyChanged();
            }
        }

        #endregion

        #region Method
        private void MenuItems_Filter(object sender, FilterEventArgs e)
        {
            if (string.IsNullOrEmpty(FilterText))
            {
                e.Accepted = true;
                return;
            }

            MovieItems _item = e.Item as MovieItems;
            if (_item!.MovieName.ToUpper().Contains(FilterText.ToUpper()))
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
