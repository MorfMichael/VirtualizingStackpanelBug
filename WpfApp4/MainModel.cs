using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp4
{
    internal class MainModel : INotifyPropertyChanged
    {
        public MainModel()
        {
            PropertyChanged += MainModel_PropertyChanged;

            Collection = new ObservableCollection<int>(Enumerable.Range(1,50));

            RemoveCommand = new RelayCommand(() =>
            {
                var remove = Collection.ToList();

                remove.ForEach(x => Collection.Remove(x));
            });

            RefreshCommand = new RelayCommand(() =>
            {
                Collection = new ObservableCollection<int>(Enumerable.Range(1, 50));
                ThrowPropertyChanged(nameof(Collection));
            });
        }

        private void MainModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
        }

        public ObservableCollection<int> Collection { get; set; }

        public ICommand RemoveCommand { get; set; }
        public ICommand RefreshCommand{ get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void ThrowPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
