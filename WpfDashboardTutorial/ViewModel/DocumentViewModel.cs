using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using WpfDashboardTutorial.Model;

namespace WpfDashboardTutorial.ViewModel
{
    public class DocumentViewModel : BaseViewModel
    {
        #region Constructor
        public DocumentViewModel()
        {
            ObservableCollection<DocumentItems> documentItems = new ObservableCollection<DocumentItems>
            {
                new DocumentItems { DocumentName="Books", DocumentImage="pack://application:,,,/Assets/book_icon.png"},
                new DocumentItems { DocumentName="Music", DocumentImage="pack://application:,,,/Assets/studio_icon.png"},
                new DocumentItems { DocumentName="Pictures", DocumentImage="pack://application:,,,/Assets/export_icon.png"},
                new DocumentItems { DocumentName="Analytics", DocumentImage="pack://application:,,,/Assets/print_icon.png"},
                new DocumentItems { DocumentName="Webcam", DocumentImage="pack://application:,,,/Assets/order_icon.png"},
                new DocumentItems { DocumentName="Printer", DocumentImage="pack://application:,,,/Assets/stock_icon.png"},
                new DocumentItems { DocumentName="Services", DocumentImage="pack://application:,,,/Assets/invoice_icon.png"},
            };

            DocumentItemsCollection = new CollectionViewSource { Source = documentItems };
            DocumentItemsCollection.Filter += DocumentItems_Filter;
        }
        #endregion

        #region Collection
        // CollectionViewSource enables XAML code to set the commonly used CollectionView properties.
        // passing these settings to the underlying view.
        private CollectionViewSource DocumentItemsCollection;

        // ICollectionView enables collections to have the functionalities of current record management,
        // custom sorting, filtering, and grouping.
        public ICollectionView DocumentSourceCollection => DocumentItemsCollection.View;

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
                DocumentItemsCollection.View.Refresh();
                OnPropertyChanged();
            }
        }

        #endregion

        #region Methods
        private void DocumentItems_Filter(object sender, FilterEventArgs e)
        {
            if (string.IsNullOrEmpty(FilterText))
            {
                e.Accepted = true;
                return;
            }

            DocumentItems? _items = e.Item as DocumentItems;
            if (_items!.DocumentName.ToUpper().Contains(FilterText.ToUpper()))
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
