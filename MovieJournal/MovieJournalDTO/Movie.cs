﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieJournalDTO
{
    [JsonArray]
    public class Movies { public List<Movie> JSON; }
    public class Movie
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("original_title")]
        public string Title { get; set; }
        [JsonProperty("overview")]
        public string Overview { get; set; }
        [JsonProperty("vote_average")]
        public double Rating { get; set; }
        [JsonProperty("poster_path")]
        public string Image { get; set; }
    }
}