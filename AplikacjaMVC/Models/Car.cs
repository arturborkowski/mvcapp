using AplikacjaMVC.Validators;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace AplikacjaMVC.Models
{
    public class Car
    {
        public int ID { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string Brand { get; set; }

        [Required]
        [StringLength(30)]
        public string Model { get; set; }

        
        public Engine Engine { get; set;  }
        public Seller Seller { get; set;  }

        [Display(Name = "Date of Production")]
        [Required]
        [ValidDate]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy}", ApplyFormatInEditMode = true)]
        public string ProductionYear { get; set; }

        [StringLength(30, MinimumLength = 3)]
        public string Color { get; set; }

        [StringLength(11, MinimumLength = 11)]
        public string VIN { get; set; }

        [StringLength(10)]
        public string Mileage { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:###,###.## PLN}")]
        public decimal Price { get; set; }

       
    }

    

}