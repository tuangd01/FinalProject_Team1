﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BanHangXachTay.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CsK23T2aEntities1 : DbContext
    {
        public CsK23T2aEntities1()
            : base("name=CsK23T2aEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tableBILL> tableBILLs { get; set; }
        public virtual DbSet<tableCUSTOMER> tableCUSTOMERs { get; set; }
        public virtual DbSet<tablePRODUCT> tablePRODUCTs { get; set; }
    }
}
