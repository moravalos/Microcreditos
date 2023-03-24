using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MicrocreditosLola.Models;

public partial class Microcreditos3Context : DbContext
{
    public Microcreditos3Context()
    {
    }

    public Microcreditos3Context(DbContextOptions<Microcreditos3Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Prestamo> Prestamos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
  //      => optionsBuilder.UseSqlServer("server=LAPTOP-DQEPM0TK\\MORAVALOS; database=microcreditos3; integrated security=true; Trust Server Certificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Idcliente).HasName("PK__clientes__7B86132F8B2C2550");

            entity.ToTable("clientes");

            entity.Property(e => e.Idcliente).HasColumnName("idcliente");
            entity.Property(e => e.Apellidom)
                .HasMaxLength(50)
                .HasColumnName("apellidom");
            entity.Property(e => e.Apellidop)
                .HasMaxLength(50)
                .HasColumnName("apellidop");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(32)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Prestamo>(entity =>
        {
            entity.HasKey(e => e.Idprestamo).HasName("PK__prestamo__CB759CB11677F2CD");

            entity.ToTable("prestamos");

            entity.Property(e => e.Idprestamo).HasColumnName("idprestamo");
            entity.Property(e => e.Cantidad)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("cantidad");
            entity.Property(e => e.Diadecobro).HasColumnName("diadecobro");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.Idcliente).HasColumnName("idcliente");
            entity.Property(e => e.Intereses).HasColumnName("intereses");
            entity.Property(e => e.Mesesdeprestamo).HasColumnName("mesesdeprestamo");

            entity.HasOne(d => d.IdclienteNavigation).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.Idcliente)
                .HasConstraintName("fk_clientes");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
