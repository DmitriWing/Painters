using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Painters.Models
{
    public class PainterContext : DbContext
    {
        
        // Current class is for describing model's data and connection to DB - DbContext

        public DbSet<Painter> Painters { get; set; }  // <Player> - model's name. Players - name of the table in DB
        public DbSet<Painting> Painting { get; set; }


        // after class has written go to Web.config in root catalog and settup <connectionStrings></connectionStrings>
    }

}