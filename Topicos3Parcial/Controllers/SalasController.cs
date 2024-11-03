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
    public class SalasController : Controller
    {
        private AgendamentoDbContext db = new AgendamentoDbContext();

        // GET: Salas
        public ActionResult Index()
        {
            var salas = db.Salas.Include(s => s.Andar).Include(s => s.Curso);
            return View(salas.ToList());
        }

        // GET: Salas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sala sala = db.Salas.Find(id);
            if (sala == null)
            {
                return HttpNotFound();
            }
            return View(sala);
        }

        // GET: Salas/Create
        public ActionResult Create()
        {
            ViewBag.AndarId = new SelectList(db.Andares, "Id", "Indentificador");
            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "Nome");
            return View();
        }

        // POST: Salas/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo,HorarioDisponivel,Descricao,Nome,AndarId,CursoId")] Sala sala)
        {
            if (ModelState.IsValid)
            {
                db.Salas.Add(sala);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AndarId = new SelectList(db.Andares, "Id", "Indentificador", sala.AndarId);
            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "Nome", sala.CursoId);
            return View(sala);
        }

        // GET: Salas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sala sala = db.Salas.Find(id);
            if (sala == null)
            {
                return HttpNotFound();
            }
            ViewBag.AndarId = new SelectList(db.Andares, "Id", "Indentificador", sala.AndarId);
            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "Nome", sala.CursoId);
            return View(sala);
        }

        // POST: Salas/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo,HorarioDisponivel,Descricao,Nome,AndarId,CursoId")] Sala sala)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sala).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AndarId = new SelectList(db.Andares, "Id", "Indentificador", sala.AndarId);
            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "Nome", sala.CursoId);
            return View(sala);
        }

        // GET: Salas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sala sala = db.Salas.Find(id);
            if (sala == null)
            {
                return HttpNotFound();
            }
            return View(sala);
        }

        // POST: Salas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sala sala = db.Salas.Find(id);
            db.Salas.Remove(sala);
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
