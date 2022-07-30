using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyData.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public byte[]? Image { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public int Score { get; set; }
        public int GenreID { get; set; }
        public Genre Genres { get; set; }
        public List<Character> Characters { get; set; } = new List<Character>();

    }
}
