using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyDomain.DTO
{
    public class CharacterDTO
    {
        public int ID { get; set; }

        //public byte[]? Image { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public long Weight { get; set; }

        public string History { get; set; }

        public int MovieID { get; set; }
    }
}
