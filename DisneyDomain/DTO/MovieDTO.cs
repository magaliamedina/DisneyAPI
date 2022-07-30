using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyDomain.DTO
{
    public class MovieDTO
    {
        public int ID { get; set; }
        //public byte[]? Image { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public int Score { get; set; }
        public int GenreID { get; set; }
    }
}
