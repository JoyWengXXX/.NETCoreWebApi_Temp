using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectModels.Entities
{
    public class Products
    {
        [Key]
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Barcode is required")]
        public string Barcode { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Rate is required")]
        public decimal Rate { get; set; }

        public DateTime AddedOn { get; set; }

        [Required(ErrorMessage = "ModifiedOn is required")]
        public DateTime? ModifiedOn { get; set; }
    }
}
