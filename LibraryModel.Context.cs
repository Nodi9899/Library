﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Library
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LibraryBaseEntities1 : DbContext
    {
        public LibraryBaseEntities1()
            : base("name=LibraryBaseEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Autorzy> Autorzy { get; set; }
        public virtual DbSet<Gatunek> Gatunek { get; set; }
        public virtual DbSet<Ksiazki> Ksiazki { get; set; }
        public virtual DbSet<Uczniowie> Uczniowie { get; set; }
        public virtual DbSet<Wydawnictwo> Wydawnictwo { get; set; }
        public virtual DbSet<Wypozyczenia> Wypozyczenia { get; set; }
    }
}
