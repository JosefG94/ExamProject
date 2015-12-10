using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieJournalDTO
{
    
    public class MovieList
    { 
        [JsonProperty("page")]
        public int Page { get; set; }
        [JsonProperty("results")]
        public List<Movie> Movies { get; set; }
    }
    public class Movie
    {
        // String reference used for "Image" property"
        private string Path;
        // Start-link of every image.
        private string imgLink = "https://image.tmdb.org/t/p/w185";

        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("original_title")]
        public string Title { get; set; }
        [JsonProperty("overview")]
        public string Overview { get; set; }
        [JsonProperty("vote_average")]
        public double Rating { get; set; }
        [JsonProperty("poster_path")]
        public string Image
        {
            get
            {
                return Path;
            }
            set
            {
                Path = imgLink + value;
            }
        }

        // Shortening of the title for the bootstrap thumbnails
        public string ShortTitle
        {
            get
            {
                int max = 30;
                string title;
                title = (Title.Length <= max) ? Title : Title.Substring(0, max)+"..";
                return title;
            }
        }
        // Shortening of the overview for the bootstrap thumbnails
        public string ShortOverview
        {
            get
            {
                int max = 80;
                string overview;
                overview = (Overview.Length <= max) ? Overview : Overview.Substring(0, max) + "...";
                return overview;
            }
        }
    }
}
