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
        public string UserName { get; set; }
        [Required]
        [DataMember]
        public string Name { get; set; }
        [DataMember]
<<<<<<< HEAD
        public virtual ICollection<movieOnList> MovieOnList { get; set; }
        [DataMember]
        public virtual ICollection<Profile> Profiles { get; set; }
=======
        public virtual IEnumerable<MovieOnList> MovieOnList { get; set; }
>>>>>>> 8e76df6e16d7366dab6be4f4386c0d3f67e3d295
    }
}
