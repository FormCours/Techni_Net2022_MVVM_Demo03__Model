using System.ComponentModel.DataAnnotations;

namespace Demo_MVVM_03.Models
{
    public enum ConditionCar
    {
        NEW,
        OCCASION,
        DAMAGED
    }

    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public ConditionCar Condition { get; set; }
        public int Kilometers { get; set; }
        public bool IsFunctional { get; set; }
        public double Price { get; set; }
        public bool HasStock { get; set; }
    }
}
