﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BanHangXachTay
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BanHangEntities : DbContext
    {
        public BanHangEntities()
            : base("name=BanHangEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tableTTHD> tableTTHDs { get; set; }
        public virtual DbSet<tableTTKH> tableTTKHs { get; set; }
        public virtual DbSet<tableTTSP> tableTTSPs { get; set; }
    }
}
