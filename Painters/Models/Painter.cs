using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Painters.Models
{
    public class Painter
    {
        public int Id { get; set; }

        [Display(Name = "Author")]
        public string Name { get; set; }

        [Display(Name = "Place of birth")]
        public string Country { get; set; }

        [Display(Name = "About")]
        public string Biography { get; set; }

        [Display(Name = "Photo")]
        public byte[] Photo { get; set; }
        public string PhotoType { get; set; }

        [Display(Name = "Painting name")]
        public ICollection<Painting> Paintings { get; set; }

        public Painter()
        {
            Paintings = new List<Painting>();
        }
    }
}