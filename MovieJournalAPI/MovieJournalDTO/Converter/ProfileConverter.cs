using MovieJournalDAL.Model;
using MovieJournalDTO.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieJournalDTO.Converter
{
    public class ProfileConverter : AbstractDTOConverter<Profile, ProfileDTO>
    {
        public override ProfileDTO Convert(Profile item)
        {
            if (item == null)
                return null;
            var dto = new ProfileDTO()
            {
                Id = item.Id,
                Name = item.Name,
                UserName = item.UserName
            };
            if (item.MovieOnList != null)
            {
                dto.MoviesOnList = new List<MovieOnListDTO>();
                foreach (var mol in item.MovieOnList)
                {
                    dto.MoviesOnList.Add(new MovieOnListDTO()
                    {
                        Id = mol.Id,
                        Rating = mol.Rating,
                        Review = mol.Review,
                        Watched = mol.Watched,
                        ProfileId = mol.ProfileId
                    });
                }
            }
            return dto;
        }
    }
}
