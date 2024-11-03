using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoEnsalamento.Models;
using Topicos3Parcial.Models;

namespace Topicos3Parcial.Controllers
{
    public class AndaresController : Controller
    {
        private AgendamentoDbContext db = new AgendamentoDbContext();

        // GET: Andares
        public ActionResult Index()
        {
            var andares = db.Andares.Include(a => a.Bloco);
            return View(andares.ToList());
        }

        // GET: Andares/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Andar andar = db.Andares.Find(id);
            if (andar == null)
            {
                return HttpNotFound();
            }
            return View(andar);
        }

        // GET: Andares/Create
        public ActionResult Create()
        {
            ViewBag.BlocoId = new SelectList(db.Blocos, "Id", "Indentificador");
            return View();
        }

        // POST: Andares/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Indentificador,BlocoId")] Andar andar)
        {
            if (ModelState.IsValid)
            {
                db.Andares.Add(andar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BlocoId = new SelectList(db.Blocos, "Id", "Indentificador", andar.BlocoId);
            return View(andar);
        }

        // GET: Andares/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Andar andar = db.Andares.Find(id);
            if (andar == null)
            {
                return HttpNotFound();
            }
            ViewBag.BlocoId = new SelectList(db.Blocos, "Id", "Indentificador", andar.BlocoId);
            return View(andar);
        }

        // POST: Andares/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Indentificador,BlocoId")] Andar andar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(andar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BlocoId = new SelectList(db.Blocos, "Id", "Indentificador", andar.BlocoId);
            return View(andar);
        }

        // GET: Andares/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Andar andar = db.Andares.Find(id);
            if (andar == null)
            {
                return HttpNotFound();
            }
            return View(andar);
        }

        // POST: Andares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Andar andar = db.Andares.Find(id);
            db.Andares.Remove(andar);
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
