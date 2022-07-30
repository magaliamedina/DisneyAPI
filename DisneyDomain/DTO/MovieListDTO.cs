using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyDomain.DTO
{
    public class MovieListDTO
    {
        public byte[]? Image { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
