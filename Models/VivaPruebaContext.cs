using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace APPWeb_CRUD.Models;

public partial class VivaPruebaContext : DbContext
{
    public VivaPruebaContext()
    {
    }

    public VivaPruebaContext(DbContextOptions<VivaPruebaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CatUserApplication> CatUserApplications { get; set; }

    public virtual DbSet<LogWebAppWbapiCrud> LogWebAppWbapiCruds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
    }
        

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CatUserApplication>(entity =>
        {
            entity.HasKey(x => x.Id);
            //entity
            //    .HasNoKey()
            //    .ToTable("catUserApplications");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).HasMaxLength(450);
            entity.Property(e => e.UserName).HasMaxLength(250);
        });

        modelBuilder.Entity<LogWebAppWbapiCrud>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("logWebAppWBAPI_CRUD");

            entity.Property(e => e.Error).HasColumnName("error");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IdLog)
                .ValueGeneratedOnAdd()
                .HasColumnName("idLog");
            entity.Property(e => e.Request).HasColumnName("request");
            entity.Property(e => e.Uidd)
                .HasMaxLength(150)
                .HasColumnName("UIDd");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
