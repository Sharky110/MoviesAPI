using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Core.Models
{
    public class Genre
    {
        public Genre()
        {

        }
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
