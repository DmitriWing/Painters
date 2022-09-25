using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Painters.Models;

namespace Painters.Controllers
{
    public class PaintersPaintingsController : Controller
    {
        private PainterContext db = new PainterContext();

        // GET: PaintersPaintings
        public ActionResult Index()
        {
            return View(db.Painters.ToList());
        }

        // GET: PaintersPaintings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Painter painter = db.Painters.Find(id);
            painter = db.Painters.Include(p => p.Paintings).FirstOrDefault(p => p.Id == id);
            if (painter == null)
            {
                return HttpNotFound();
            }
            return View(painter);
        }
        // partial view
        [ChildActionOnly]
        public ActionResult PingsOfPers (int id)
        {
            var persPings = db.Painting.Where(p => p.PainterId == id);
            return PartialView(persPings);
        }
        // GET: Image
        public FileContentResult GetImage(int id)
        {
            //запрос в БД таблица Painters по переданному id
            Painting painting = db.Painting.FirstOrDefault(g => g.Id == id);
            if (painting != null)
            {
                return File(painting.Canvas, painting.CanvasType);
            }
            return null;
        }

        // render image from byte[] to picture
        public async Task<ActionResult> RenderImage(int id)
        {
            Painting item = await db.Painting.FindAsync(id);
            byte[] photoBack = item.Canvas;
            return File(photoBack, "image/png");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
