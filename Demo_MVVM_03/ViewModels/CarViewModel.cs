using Demo_MVVM_03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.MVVM.Commands;
using Tools.MVVM.ViewModels;

namespace Demo_MVVM_03.ViewModels
{
    public class CarViewModel : ViewModelBase<Car>
    {
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
        }
        #endregion

        #region Command
        private IRelayCommand _DeleteCommand;
        private IRelayCommand _SoldCommand;

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
            // TODO After meal :)
            throw new NotImplementedException();
        }
        private void Sold()
        {
            // TODO After meal :)
            throw new NotImplementedException();
        }
        private bool CanSold()
        {
            // TODO After meal :)
            throw new NotImplementedException();
        }
    }
}
