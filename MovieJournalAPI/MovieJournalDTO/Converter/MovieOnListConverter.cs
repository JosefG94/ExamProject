using MovieJournalDAL.Model;
using MovieJournalDTO.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieJournalDTO.Converter
{
    public class MovieOnListDTOConverter : AbstractDTOConverter<MovieOnList, MovieOnListDTO>
    {
        public override MovieOnListDTO Convert(MovieOnList item)
        {
            var dto = new MovieOnListDTO()
            {
                Id = item.Id,
                Rating = item.Rating,
                Review = item.Review,
                MovieId = item.MovieId,
                Profile = item.Profile,
                Watched = item.Watched
                
            };

            if (item.Profile != null)
            {
                dto.Profile = new Profile()
                {
                    Id = item.Profile.Id,
                    Name = item.Profile.Name,
                    UserName = item.Profile.UserName
                };
            }
            return dto;
        }

      
    }
}
