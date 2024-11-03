using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Topicos3Parcial.Models;

namespace Topicos3Parcial.Controllers
{
    [Authorize]
    public class AgendamentoesController : Controller
    {
        private AgendamentoDbContext db = new AgendamentoDbContext();

        // GET: Agendamentoes
        public ActionResult Index()
        {
            var agendamentos = db.Agendamentos.Include(a => a.Professor).Include(a => a.Sala);
            return View(agendamentos.ToList());
        }

        // GET: Agendamentoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agendamento agendamento = db.Agendamentos.Find(id);
            if (agendamento == null)
            {
                return HttpNotFound();
            }
            return View(agendamento);
        }

        // GET: Agendamentoes/Create
        public ActionResult Create()
        {
            ViewBag.ProfessorId = new SelectList(db.Professores, "Id", "Name");
            ViewBag.SalaId = new SelectList(db.Salas, "Id", "Codigo");
            return View();
        }

        // POST: Agendamentoes/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProfessorId,SalaId,Horario,Recorrente")] Agendamento agendamento)
        {
            if (ModelState.IsValid)
            {
                db.Agendamentos.Add(agendamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProfessorId = new SelectList(db.Professores, "Id", "Name", agendamento.ProfessorId);
            ViewBag.SalaId = new SelectList(db.Salas, "Id", "Codigo", agendamento.SalaId);
            return View(agendamento);
        }

        // GET: Agendamentoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agendamento agendamento = db.Agendamentos.Find(id);
            if (agendamento == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProfessorId = new SelectList(db.Professores, "Id", "Name", agendamento.ProfessorId);
            ViewBag.SalaId = new SelectList(db.Salas, "Id", "Codigo", agendamento.SalaId);
            return View(agendamento);
        }

        // POST: Agendamentoes/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProfessorId,SalaId,Horario,Recorrente")] Agendamento agendamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agendamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProfessorId = new SelectList(db.Professores, "Id", "Name", agendamento.ProfessorId);
            ViewBag.SalaId = new SelectList(db.Salas, "Id", "Codigo", agendamento.SalaId);
            return View(agendamento);
        }

        // GET: Agendamentoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agendamento agendamento = db.Agendamentos.Find(id);
            if (agendamento == null)
            {
                return HttpNotFound();
            }
            return View(agendamento);
        }

        // POST: Agendamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Agendamento agendamento = db.Agendamentos.Find(id);
            db.Agendamentos.Remove(agendamento);
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
