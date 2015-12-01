using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieJournalDTO
{
    public class Profile
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<MovieOnList> MovieOnList { get; set; }

        public virtual ICollection<Profile> Profiles { get; set; }
    }
}

