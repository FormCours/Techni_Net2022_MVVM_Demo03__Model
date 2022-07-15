using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Tools.MVVM.ViewModels
{
    // ViewModelBase => Met en place la méthode pour notifier la vue d'un changement
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            RaiseAllCanExecuteChanged();
        }

        protected virtual void RaiseAllCanExecuteChanged() { }
    }

    // ViewModelBase Generique => Pour encapsuler les models avant de les utilisés
    public abstract class ViewModelBase<TEntity> : ViewModelBase
    {
        // Instance interne du Model dans le ViewModel => Warpper
        private readonly TEntity _Entity;

        protected TEntity Entity
        {
            get { return _Entity; }
        }

        public ViewModelBase(TEntity entity)
        {
            if (entity is null) throw new ArgumentNullException();

            _Entity = entity;
        }
    }
}
