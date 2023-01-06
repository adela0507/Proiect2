using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace Proiect2.Models
{
    public class Testing
    {
        public int ID { get; set; }
        public int? TesterID { get; set; }
        public Tester? Tester { get; set; }
        public int? BeautyID { get; set; }
        public Beauty? Beauty { get; set; }
        [DataType(DataType.Date)]
        public DateTime TestingDate { get; set; }
    }
}
