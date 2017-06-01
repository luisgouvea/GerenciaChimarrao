using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GerenciaChimarrao.Models;

namespace GerenciaChimarrao.Controllers
{
    public class GauchoController : Controller
    {
        private MapeamentoEntidadesContext db = new MapeamentoEntidadesContext();

        // GET: Gaucho
        public ActionResult Index()
        {
            var gauchos = db.Gauchos.Include(g => g.Imagem).Include(g => g.StatusGaucho);
            return View(gauchos.ToList());
        }

        // GET: Gaucho/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gaucho gaucho = db.Gauchos.Find(id);
            if (gaucho == null)
            {
                return HttpNotFound();
            }
            return View(gaucho);
        }

        // GET: Gaucho/Create
        public ActionResult Create()
        {
            ViewBag.ImagemID = new SelectList(db.Imagens, "ImagemID", "Path");
            ViewBag.StatusGauchoID = new SelectList(db.StatusGauchos, "StatusGauchoID", "Descricao");
            return View();
        }

        // POST: Gaucho/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,ImagemID,StatusGauchoID")] Gaucho gaucho)
        {
            if (ModelState.IsValid)
            {
                db.Gauchos.Add(gaucho);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ImagemID = new SelectList(db.Imagens, "ImagemID", "Path", gaucho.ImagemID);
            ViewBag.StatusGauchoID = new SelectList(db.StatusGauchos, "StatusGauchoID", "Descricao", gaucho.StatusGauchoID);
            return View(gaucho);
        }

        // GET: Gaucho/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gaucho gaucho = db.Gauchos.Find(id);
            if (gaucho == null)
            {
                return HttpNotFound();
            }
            ViewBag.ImagemID = new SelectList(db.Imagens, "ImagemID", "Path", gaucho.ImagemID);
            ViewBag.StatusGauchoID = new SelectList(db.StatusGauchos, "StatusGauchoID", "Descricao", gaucho.StatusGauchoID);
            return View(gaucho);
        }

        // POST: Gaucho/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,ImagemID,StatusGauchoID")] Gaucho gaucho)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gaucho).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ImagemID = new SelectList(db.Imagens, "ImagemID", "Path", gaucho.ImagemID);
            ViewBag.StatusGauchoID = new SelectList(db.StatusGauchos, "StatusGauchoID", "Descricao", gaucho.StatusGauchoID);
            return View(gaucho);
        }

        // GET: Gaucho/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gaucho gaucho = db.Gauchos.Find(id);
            if (gaucho == null)
            {
                return HttpNotFound();
            }
            return View(gaucho);
        }

        // POST: Gaucho/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gaucho gaucho = db.Gauchos.Find(id);
            db.Gauchos.Remove(gaucho);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ViventesCaminhando()
        {
            var gauchosCaminhando = this.db.Gauchos.Where(o => o.StatusGaucho.Descricao == "Caminhando na rua").DefaultIfEmpty(null);
            return View(gauchosCaminhando.ToList());
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
