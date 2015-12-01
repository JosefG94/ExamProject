using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace MovieJournalDAL.Model
{
    [DataContract(IsReference = true)]
    public class MovieOnList
    {
        [Key]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int MovieId { get; set; }
        [DataMember]
        public int Rating { get; set; }
        [DataMember]
        public string Review { get; set; }
        [DataMember]
        public bool Watched { get; set; }
        [DataMember]
        public virtual Profile Profile { get; set; }
        [DataMember]
        public int ProfileId { get; set; }
    }
}
