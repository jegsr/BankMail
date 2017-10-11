using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TarefasWebService.Models;

namespace TarefasWebService.Framework
{
    /// <summary>
    /// Classe responsavel pela criação e utilização das classes na base de dados
    /// </summary>
    public class ProjectContext : DbContext
    {
        public DbSet<Tarefa> Tarefas { get; set; }

        public ProjectContext()
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.AutoDetectChangesEnabled = true;
        }
    }
}