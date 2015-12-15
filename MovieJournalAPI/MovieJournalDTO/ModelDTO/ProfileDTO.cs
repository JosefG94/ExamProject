using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MovieJournalDTO.ModelDTO
{
    [DataContract(IsReference = true)]
    public class ProfileDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public virtual ICollection<MovieOnListDTO> MoviesOnList { get; set; }
    }
}
