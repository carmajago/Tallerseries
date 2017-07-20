using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TallerSeries.Models;

namespace TallerSeries.Controllers
{
    public class CapitulosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Capitulos
        public ActionResult Index()
        {
            var capituloes = db.Capituloes.Include(c => c.temporada);
            return View(capituloes.ToList());
        }

        // GET: Capitulos/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Capitulo capitulo = db.Capituloes.Find(id);
            if (capitulo == null)
            {
                return HttpNotFound();
            }
            return View(capitulo);
        }

        // GET: Capitulos/Create
        public ActionResult Create()
        {
            ViewBag.temporadaFK = new SelectList(db.Temporadas, "temporadaID", "nombre");
            return View();
        }

        // POST: Capitulos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,nombre,numero_cap,valor,imagen,video,fecha_publicacion,valoracion,temporadaFK")] Capitulo capitulo)
        {
            if (ModelState.IsValid)
            {
                db.Capituloes.Add(capitulo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.temporadaFK = new SelectList(db.Temporadas, "temporadaID", "nombre", capitulo.temporadaFK);
            return View(capitulo);
        }

        // GET: Capitulos/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Capitulo capitulo = db.Capituloes.Find(id);
            if (capitulo == null)
            {
                return HttpNotFound();
            }
            ViewBag.temporadaFK = new SelectList(db.Temporadas, "temporadaID", "nombre", capitulo.temporadaFK);
            return View(capitulo);
        }

        // POST: Capitulos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,nombre,numero_cap,valor,imagen,video,fecha_publicacion,valoracion,temporadaFK")] Capitulo capitulo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(capitulo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.temporadaFK = new SelectList(db.Temporadas, "temporadaID", "nombre", capitulo.temporadaFK);
            return View(capitulo);
        }

        // GET: Capitulos/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Capitulo capitulo = db.Capituloes.Find(id);
            if (capitulo == null)
            {
                return HttpNotFound();
            }
            return View(capitulo);
        }

        // POST: Capitulos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Capitulo capitulo = db.Capituloes.Find(id);
            db.Capituloes.Remove(capitulo);
            db.SaveChanges();
            return RedirectToAction("Index");
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
