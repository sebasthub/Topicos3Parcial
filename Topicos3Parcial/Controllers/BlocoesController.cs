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
    public class BlocoesController : Controller
    {
        private AgendamentoDbContext db = new AgendamentoDbContext();

        // GET: Blocoes
        public ActionResult Index()
        {
            var blocos = db.Blocos.Include(b => b.Unidade);
            return View(blocos.ToList());
        }

        // GET: Blocoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bloco bloco = db.Blocos.Find(id);
            if (bloco == null)
            {
                return HttpNotFound();
            }
            return View(bloco);
        }

        // GET: Blocoes/Create
        public ActionResult Create()
        {
            ViewBag.UnidadeId = new SelectList(db.Unidades, "ID", "Nome");
            return View();
        }

        // POST: Blocoes/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Indentificador,UnidadeId")] Bloco bloco)
        {
            if (ModelState.IsValid)
            {
                db.Blocos.Add(bloco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UnidadeId = new SelectList(db.Unidades, "ID", "Nome", bloco.UnidadeId);
            return View(bloco);
        }

        // GET: Blocoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bloco bloco = db.Blocos.Find(id);
            if (bloco == null)
            {
                return HttpNotFound();
            }
            ViewBag.UnidadeId = new SelectList(db.Unidades, "ID", "Nome", bloco.UnidadeId);
            return View(bloco);
        }

        // POST: Blocoes/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Indentificador,UnidadeId")] Bloco bloco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bloco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UnidadeId = new SelectList(db.Unidades, "ID", "Nome", bloco.UnidadeId);
            return View(bloco);
        }

        // GET: Blocoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bloco bloco = db.Blocos.Find(id);
            if (bloco == null)
            {
                return HttpNotFound();
            }
            return View(bloco);
        }

        // POST: Blocoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bloco bloco = db.Blocos.Find(id);
            db.Blocos.Remove(bloco);
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
