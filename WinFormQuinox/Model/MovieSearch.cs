using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormQuinox.Model
{
    class MovieSearch
    {
        public Movie[] Search { get; set; }
        public int TotalResults { get; set; }
        public bool Response { get; set; }
        public string Error { get; set; }
    }
}
