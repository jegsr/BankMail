﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BankService
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BankServiceEntities : DbContext
    {
        public BankServiceEntities()
            : base("name=BankServiceEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Contatoes> Contatoes { get; set; }
        public virtual DbSet<Mensagems> Mensagems { get; set; }
        public virtual DbSet<Utilizadors> Utilizadors { get; set; }
    }
}
