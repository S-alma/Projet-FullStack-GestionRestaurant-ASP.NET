﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GestionRestaurant.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BD_Gestion_restaurantEntities : DbContext
    {
        public BD_Gestion_restaurantEntities()
            : base("name=BD_Gestion_restaurantEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<COMMENTAIRE> COMMENTAIREs { get; set; }
        public virtual DbSet<RESERVATION> RESERVATIONs { get; set; }
        public virtual DbSet<RESTAURANT> RESTAURANTs { get; set; }
        public virtual DbSet<TABLE_RESTAURANT> TABLE_RESTAURANT { get; set; }
        public virtual DbSet<UTILISATEUR> UTILISATEURs { get; set; }
    }
}
