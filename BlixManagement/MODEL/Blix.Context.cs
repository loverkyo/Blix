﻿//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MODEL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BlixManagementEntities : DbContext
    {
        public BlixManagementEntities()
            : base("name=BlixManagementEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<T_Accessories> T_Accessories { get; set; }
        public DbSet<T_Admin> T_Admin { get; set; }
        public DbSet<T_Authority> T_Authority { get; set; }
        public DbSet<T_Brand> T_Brand { get; set; }
        public DbSet<T_Color> T_Color { get; set; }
        public DbSet<T_Frame> T_Frame { get; set; }
        public DbSet<T_FrameCategory> T_FrameCategory { get; set; }
        public DbSet<T_FrameMaterial> T_FrameMaterial { get; set; }
        public DbSet<T_FrameShape> T_FrameShape { get; set; }
        public DbSet<T_FrameSize> T_FrameSize { get; set; }
        public DbSet<T_FrameSN> T_FrameSN { get; set; }
        public DbSet<T_FrameStyle> T_FrameStyle { get; set; }
        public DbSet<T_FrameType> T_FrameType { get; set; }
        public DbSet<T_Gender> T_Gender { get; set; }
        public DbSet<T_Lens> T_Lens { get; set; }
        public DbSet<T_LensAdvanced> T_LensAdvanced { get; set; }
        public DbSet<T_LensIndex> T_LensIndex { get; set; }
        public DbSet<T_LensType> T_LensType { get; set; }
        public DbSet<T_Module> T_Module { get; set; }
        public DbSet<T_Supplier> T_Supplier { get; set; }
        public DbSet<T_User> T_User { get; set; }
    }
}