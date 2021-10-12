using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectModels.Entities
{
    [Table("Test")]
    public class Test
    {
        [Key]
        [Required(ErrorMessage = "Id is required")]
        public string Id { get; set; }

        public string Data { get; set; }
    }
}
