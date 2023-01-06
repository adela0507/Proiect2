namespace Proiect2.Models
{
    public class Expiration
    {
        public int ID { get; set; }
        public string ExpirationProductName { get; set; }
        public IEnumerable<Beauty> Cosmetics { get; internal set; }
    }
}
