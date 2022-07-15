using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.MVVM.ViewModels
{
    public abstract class ViewModelCollectionBase<TViewModel> : ViewModelBase
        where TViewModel : ViewModelBase
    {
        private ObservableCollection<TViewModel>? _Items;

        public ObservableCollection<TViewModel> Items
        {
            get { return _Items ?? (_Items = LoadItems()); }
        }

        protected abstract ObservableCollection<TViewModel> LoadItems();
    }
}
