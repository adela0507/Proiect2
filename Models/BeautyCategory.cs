namespace Proiect2.Models
{
    public class BeautyCategory
    {
        public int ID { get; set; }
        public int BeautyID { get; set; }
        public Beauty Beauty { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }

    }
}
