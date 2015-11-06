using MovieJournalDAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MovieJournalDTO.ModelDTO
{
    [DataContract(IsReference = true)]
    public class MovieOnListDTO
    {
        [Key]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public virtual int MovieId { get; set; }
        [DataMember]
        public int Rating { get; set; }
        [DataMember]
        public string Review { get; set; }
    }
}
