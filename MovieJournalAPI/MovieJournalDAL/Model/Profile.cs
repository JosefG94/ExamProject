using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MovieJournalDAL.Model
{
    [DataContract(IsReference= true)]
    public class Profile
    {
        [Key]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [Required]
        public string Email { get; set; }
        [Required]
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public virtual ICollection<MovieOnList> MovieOnList { get; set; }
        [DataMember]
        public virtual ICollection<Profile> Profiles { get; set; }
    }
}
