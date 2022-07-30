using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyData.Models
{
    public class Genre
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public byte[]? Image { get; set; }
        public List<Movie> Movies { get; set; } = new List<Movie>();

    }
}
