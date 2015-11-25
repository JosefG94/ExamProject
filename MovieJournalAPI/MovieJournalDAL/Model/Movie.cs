using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieJournalDAL.Model
{
    public class Movie
    {
        //[DataMember]
        //[Key]
        public int Id { get; set; }
        //[DataMember]
        public string Title { get; set; }
    }
}
