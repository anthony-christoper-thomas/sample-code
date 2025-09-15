using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarrierApplication1.Models
{
    public class CarrierView
    {
        public int ID { get; set; }

        [Required]
        [DisplayName("Carrier Name")]
        public string CarrierName { get; set; }

        [Required]
        public string Address { get; set; }

        [DisplayName("Address (Secondary)")]
        public string Address2 { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Zip { get; set; }

        [DisplayName("Postal Code")]
        public string Zip2 { get; set; }

        [Required]
        [DisplayName("Primary Contact")]
        public string Contact { get; set; }

        [Required]
        public string Phone { get; set; }
        public string Fax { get; set; }

        [Required]
        public string Email { get; set; }
    }
}