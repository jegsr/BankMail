using BankService.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BankService.Framework
{
    /// <summary>
    /// Classe responsavel pela criação e utilização das classes na base de dados
    /// </summary>
    public class ProjectContext : DbContext
    {
        public DbSet<Utilizador> Utilizadores { get; set; }
        public DbSet<Contato> Contactos { get; set; }
        public DbSet<Mensagem> Mensagens { get; set; }

        public ProjectContext()
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.AutoDetectChangesEnabled = true;
        }
    }
}