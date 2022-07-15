using Demo_MVVM_03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_MVVM_03
{
    public static class FakeDbContext
    {
        public class CarService
        {
            private static List<Car> _Cars = new List<Car>
            {
                new Car
                {
                    Id = 1,
                    Brand = "Ford",
                    Model = "Fiesta",
                    Condition = ConditionCar.DAMAGED,
                    IsFunctional = false,
                    Kilometers = 200_000,
                    Price = 199.99,
                    HasStock = true
                },
                new Car
                {
                    Id = 2,
                    Brand = "Dodge",
                    Model = "Viper",
                    Condition = ConditionCar.NEW,
                    IsFunctional = true,
                    Kilometers = 20,
                    Price = 95000,
                    HasStock = true
                }
            };
            private static int _LastId = 2;

            public Car? GetById(int id)
            {
                Car? car = _Cars.SingleOrDefault(c => c.Id == id);

                if (car is null) return null;

                return new Car
                {
                    Id = car.Id,
                    Brand = car.Brand,
                    Model = car.Model,
                    Condition = car.Condition,
                    IsFunctional = car.IsFunctional,
                    Kilometers = car.Kilometers,
                    HasStock = car.HasStock,
                    Price = car.Price
                };
            }

            public IEnumerable<Car> GetAll()
            {
                return _Cars.Select(car => new Car
                {
                    Id = car.Id,
                    Brand = car.Brand,
                    Model = car.Model,
                    Condition = car.Condition,
                    IsFunctional = car.IsFunctional,
                    Kilometers = car.Kilometers,
                    HasStock = car.HasStock,
                    Price = car.Price
                });
            }

            public int Insert(Car car)
            {
                int newId = ++_LastId;
                _Cars.Add(new Car
                {
                    Id = newId,
                    Brand = car.Brand,
                    Model = car.Model,
                    Condition = car.Condition,
                    IsFunctional = car.IsFunctional,
                    Kilometers = car.Kilometers,
                    HasStock = car.HasStock,
                    Price = car.Price
                });
                return newId;
            }

            public bool Update(Car car)
            {
                Car? carUpdated = _Cars.SingleOrDefault(c => c.Id == car.Id);

                if (carUpdated is null) return false;

                carUpdated.Id = car.Id;
                carUpdated.Model = car.Model;
                carUpdated.Brand = car.Brand;
                carUpdated.IsFunctional = car.IsFunctional;
                carUpdated.Condition = car.Condition;
                carUpdated.Kilometers = car.Kilometers;
                carUpdated.HasStock = car.HasStock;
                carUpdated.Price = car.Price;
                return true;
            }

            public bool Delete(int id)
            {
                int count = _Cars.RemoveAll(c => c.Id == id);
                return count == 1;
            }
        }
    }
}
