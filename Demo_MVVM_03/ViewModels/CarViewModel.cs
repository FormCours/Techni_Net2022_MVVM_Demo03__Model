using Demo_MVVM_03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.MVVM.Commands;
using Tools.MVVM.ViewModels;
using static Demo_MVVM_03.FakeDbContext;

namespace Demo_MVVM_03.ViewModels
{
    public class CarViewModel : ViewModelBase<Car>
    {
        #region Events
        public static event Action<CarViewModel>? OnCarDeleted;
        #endregion

        #region Proprietes
        public string Brand
        {
            get { return Entity.Brand; }
        }
        public string Model
        {
            get { return Entity.Model; }
        }
        public ConditionCar Condition
        {
            get { return Entity.Condition; }
        }
        public int Kilometers
        {
            get { return Entity.Kilometers; }
            set 
            { 
                Entity.Kilometers = value;
                RaisePropertyChanged();
            }
        }
        public bool IsFunctionnal
        {
            get { return Entity.IsFunctional; }
            set 
            { 
                Entity.IsFunctional = value;
                RaisePropertyChanged();
            }
        }
        public double Price
        {
            get { return Entity.Price; }
            set 
            { 
                Entity.Price = value; 
                RaisePropertyChanged();
            }
        }
        public bool HasStock
        {
            get { return Entity.HasStock; }
            private set 
            { 
                Entity.HasStock = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Command
        private IRelayCommand? _DeleteCommand;
        private IRelayCommand? _SoldCommand;

        public IRelayCommand DeleteCommand 
        { 
            get { return _DeleteCommand ?? (_DeleteCommand = new RelayCommand(Delete)); }
        }
        public IRelayCommand SoldCommand
        {
            get { return _SoldCommand ?? (_SoldCommand = new RelayCommand(Sold, CanSold)); }
        }
        #endregion

        public CarViewModel(Car car) : base(car) { }

        protected override void RaiseAllCanExecuteChanged()
        {
            SoldCommand.RaiseCanExecuteChanged();
        }

        private void Delete()
        {
            // Modification des données en « DB »
            // - Initialisation du service
            CarService carService = new CarService();
            // - Delete in DB
            carService.Delete(Entity.Id);

            // Notification via un event static que l'element est supprimé
            OnCarDeleted?.Invoke(this);
        }
        private void Sold()
        {
            // Met a jours des données
            HasStock = false;

            // Modification des données en « DB »
            // - Initialisation du service
            //   Evolution : Injection de dépedences / Implementer le pattern Locator
            CarService carService = new CarService();
            // - Save
            carService.Update(Entity);
        }
        private bool CanSold()
        {
            return HasStock;
        }
    }
}
