using MovieJournalDAL.Model;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

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
        [DataMember]
        public bool Watched { get; set; }
        [DataMember]
        public virtual ProfileDTO Profile { get; set; }
        [DataMember]
        public int ProfileId { get; set; }
    }
}
