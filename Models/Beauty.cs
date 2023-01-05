using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
using System.Xml.Linq;

namespace Proiect2.Models
{
    public class Beauty
    {
        public int ID { get; set; }
        [Display(Name = "Beauty Name")]
        public string Name { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "decimal(6, 2)")]

        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }
        public int? ExpirationID { get; set; }
        public Expiration? Expiration { get; set; }
        public int? BrandID { get; set; }
        public Brand? Brand { get; set; }
    }
}
