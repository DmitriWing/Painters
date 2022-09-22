using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Painters.Models
{
    public class Painting
    {
        public int Id { get; set; }

        [Display(Name = "Painting Title")]
        public string Title { get; set; }

        [Display(Name = "Year of creation")]
        public int Year { get; set; }

        [Display(Name = "Storing place")]
        public string Museum { get; set; }

        [Display(Name = "Canvas")]
        public byte[] Canvas { get; set; }

        public string CanvasType { get; set; }

        public int? PainterId { get; set; }

        public Painter Painter { get; set; }

    }
}