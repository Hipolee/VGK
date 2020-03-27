using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;
namespace Library
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        internal IDataManager DataManager { get; set; }
        private object selectedViewModel;
        public event PropertyChangedEventHandler PropertyChanged;

        public object SelectedViewModel
        {
            get { return selectedViewModel; }
            set
            {
                selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public ViewModelBase()
        {
            
        }

        //private void OnPropertyChanged(string propName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public Action CloseAction { get; set; }



    }
}
