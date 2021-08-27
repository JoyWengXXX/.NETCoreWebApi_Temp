using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_Core_Proj.Models
{
    [Table("Test")]
    public class TestModel
    {
        [Key]
        public string Id { get; set; }
        public string Data { get; set; } 
    }
}
