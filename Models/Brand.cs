﻿namespace Proiect2.Models
{
    public class Brand
    {
        public int ID { get; set; }
        public string? BrandName { get; set; }
        public ICollection<Beauty>? Cosmetics { get; set; }

    }
}
