using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quinnox.WebApi.ViewModel
{
    public class Movie
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string ImdbId { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }
    }
}
