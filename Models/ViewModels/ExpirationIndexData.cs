using System.Security.Policy;

namespace Proiect2.Models.ViewModels
{
    public class ExpirationIndexData
    {


        public IEnumerable<Expiration> Expirations { get; set; }
        public IEnumerable<Beauty> Cosmetics { get; set; }

    }
}
