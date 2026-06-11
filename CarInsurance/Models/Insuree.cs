using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarInsurance.Models
{
    public class Insuree
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Birthdate")]
        public DateTime Birthdate { get; set; }

        [Required]
        [Range(1900, 2100)]
        [Display(Name = "Car Year")]
        public int CarYear { get; set; }

        [Required]
        [Display(Name = "Car Make")]
        public string CarMake { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Car Model")]
        public string CarModel { get; set; } = string.Empty;

        [Required]
        public bool DUI { get; set; }

        [Required]
        [Range(0,100)]
        [Display(Name = "Speeding Tickets")]
        public int SpeedingTickets { get; set; }

        [Required]
        [Display(Name = "Coverage Type")]
        public string CoverageType {  get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [DataType(DataType.Currency)]
        public decimal Quote { get; set; }
    }
}
