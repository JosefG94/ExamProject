using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieJournalDTO
{
    public class MovieOnList
    {

        public int Id { get; set; }

        public int MovieId { get; set; }

        public int Rating { get; set; }

        public string Review { get; set; }

        public bool Watched { get; set; }

        public virtual Profile Profile { get; set; }

        public int ProfileId { get; set; }
    }
}
