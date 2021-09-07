using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace WebAPI_Core_Proj.Models.Entities
{
    [Table("Test")]
    public class TestEntity : BaseEntityModel
    {
        [Key]
        public string Id { get; set; }
        public string Data { get; set; }
    }
}
