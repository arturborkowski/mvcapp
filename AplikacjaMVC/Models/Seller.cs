using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AplikacjaMVC.Models
{
    public class Seller
    {

        public Seller()
        {
            Cars = new List<Car>();
        }

        public int ID { get; set; }

        [Display(Name = "Seller First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Seller Last Name")]
        public string LastName { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}