using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Crud.Models;

public partial class PaginaContext : DbContext
{
    public PaginaContext()
    {
    }

    public PaginaContext(DbContextOptions<PaginaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DESKTOP-COFBV0T\\SQLSENA;Initial Catalog=Pagina;integrated security=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.Idpedido).HasName("PK__Pedido__00C11F990D473EC0");

            entity.ToTable("Pedido");

            entity.Property(e => e.Idpedido).HasColumnName("IDPedido");
            entity.Property(e => e.Idproducto).HasColumnName("IDProducto");
            entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");
            entity.Property(e => e.PrecioTotal).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.IdproductoNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.Idproducto)
                .HasConstraintName("FK__Pedido__IDProduc__4E88ABD4");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.Idusuario)
                .HasConstraintName("FK__Pedido__IDUsuari__4D94879B");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Idproducto).HasName("PK__Producto__ABDAF2B4B2D7013A");

            entity.ToTable("Producto");

            entity.Property(e => e.Idproducto).HasColumnName("IDProducto");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Idusuario).HasName("PK__Usuario__52311169C84BB10C");

            entity.ToTable("Usuario");

            entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Pago).HasColumnType("decimal(18, 0)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
