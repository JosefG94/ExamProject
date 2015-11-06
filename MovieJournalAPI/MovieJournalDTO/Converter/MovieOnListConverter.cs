﻿using MovieJournalDAL.Model;
using MovieJournalDTO.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieJournalDTO.Converter
{
    class MovieOnListConverter : AbstractDTOConverter<MovieOnList, MovieOnListDTO>
    {
        public override MovieOnListDTO Convert(MovieOnList item)
        {
            var dto = new MovieOnListDTO()
            {
                Id = item.Id,
                Rating = item.Rating,
                Review = item.Review
            };
            return dto;
        }
    }
}