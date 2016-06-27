using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AplikacjaMVC.Validators;

namespace AplikacjaMVC.Models
{
    public enum EngineType
    {
        Benz,
        Diesel,
        Benz_LPG,
        Hybrid
    }

    public class Engine
    {
        public Engine()
        {
            Cars = new List<Car>();
        }

        public int ID { get; set; }

        [RegularExpression(@"\d{1}.\d{1,2}", ErrorMessage = "Capacity should be in *.* format, e.g. \'1.8\'")]
        public string Capacity { get; set; }

        [Display(Name = "Engine Type")]
        public EngineType Type { get; set; }

        public virtual ICollection<Car> Cars { get; set; }

    }
}