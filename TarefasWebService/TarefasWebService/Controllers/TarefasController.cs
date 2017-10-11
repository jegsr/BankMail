using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TarefasWebService.Framework;
using TarefasWebService.Models;

namespace TarefasWebService.Controllers
{
    public class TarefasController : ApiController
    {
        private ProjectContext db = new ProjectContext();

        // GET: api/Tarefas
        public IQueryable<Tarefa> GetTarefas()
        {
            return db.Tarefas;
        }

        // GET: api/Tarefas/5
        [ResponseType(typeof(Tarefa))]
        public IHttpActionResult GetTarefa(int id)
        {
            Tarefa tarefa = db.Tarefas.Find(id);
            if (tarefa == null)
            {
                return NotFound();
            }

            return Ok(tarefa);
        }
        /// <summary>
        /// Metodo responsavel por enviar as tarefas de um utilizador em função da pesquisa
        /// </summary>
        /// <param name="pesquisa">Parametro a pesquisar</param>
        /// <param name="user">Username do utilizador logado</param>
        /// <returns></returns>
        public IQueryable<Tarefa> GetTarefas(string pesquisa,string user)
        {

            if (pesquisa != null)
            {
                return db.Tarefas.Where(c => c.User.Equals(user) && c.Nome.ToLower().Contains(pesquisa.ToLower()) &&
                ((c.Data.Day.ToString()).Equals(pesquisa) || (c.Data.Year.ToString()).Equals(pesquisa) ||
                 (c.Data.Month.ToString()).Equals(pesquisa) || (c.Data.Date.ToString()).Contains(pesquisa)));
            }
            else { 
                 return db.Tarefas.Where(c => c.User.Equals(user));
            }
        }

        // PUT: api/Tarefas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTarefa(int id, Tarefa tarefa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tarefa.Id)
            {
                return BadRequest();
            }

            db.Entry(tarefa).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarefaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Tarefas
        [ResponseType(typeof(Tarefa))]
        public IHttpActionResult PostTarefa(Tarefa tarefa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tarefas.Add(tarefa);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tarefa.Id }, tarefa);
        }

        // DELETE: api/Tarefas/5
        [ResponseType(typeof(Tarefa))]
        public IHttpActionResult DeleteTarefa(int id)
        {
            Tarefa tarefa = db.Tarefas.Find(id);
            if (tarefa == null)
            {
                return NotFound();
            }

            db.Tarefas.Remove(tarefa);
            db.SaveChanges();

            return Ok(tarefa);
        }

        [ResponseType(typeof(Tarefa))]
        public IHttpActionResult DeleteTarefas(string user)
        {
            var tarefa = this.GetTarefas(null,user);

            if (tarefa == null)
            {
                return NotFound();
            }

            db.Tarefas.RemoveRange(tarefa);
            db.SaveChanges();

            return Ok(tarefa);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }



        private bool TarefaExists(int id)
        {
            return db.Tarefas.Count(e => e.Id == id) > 0;
        }
    }
}