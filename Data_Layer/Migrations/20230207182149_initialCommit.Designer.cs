﻿// <auto-generated />
using System;
using Data_Layer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(AlmacenContext))]
    [Migration("20230207182149_initialCommit")]
    partial class initialCommit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Data.Categoria", b =>
                {
                    b.Property<int>("idCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idCategoria"));

                    b.Property<int>("estado")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idCategoria");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Data.Producto", b =>
                {
                    b.Property<int>("idProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idProducto"));

                    b.Property<int>("estado")
                        .HasColumnType("int");

                    b.Property<int>("idCategoria")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("stock")
                        .HasColumnType("int");

                    b.HasKey("idProducto");

                    b.HasIndex("idCategoria");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("Data.Producto_Venta", b =>
                {
                    b.Property<int>("idProducto_Venta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idProducto_Venta"));

                    b.Property<int>("cantidad")
                        .HasColumnType("int");

                    b.Property<int>("id_Producto")
                        .HasColumnType("int");

                    b.Property<int>("id_Venta")
                        .HasColumnType("int");

                    b.Property<decimal>("precio")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("idProducto_Venta");

                    b.HasIndex("id_Producto");

                    b.HasIndex("id_Venta");

                    b.ToTable("Producto_Ventas");
                });

            modelBuilder.Entity("Data.TipoUsuario", b =>
                {
                    b.Property<int>("idTipoUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idTipoUsuario"));

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idTipoUsuario");

                    b.ToTable("TipoUsuarios");
                });

            modelBuilder.Entity("Data.Usuario", b =>
                {
                    b.Property<int>("idUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idUsuario"));

                    b.Property<string>("contrasena")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("id_TipoUsuario")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idUsuario");

                    b.HasIndex("id_TipoUsuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Data.Venta", b =>
                {
                    b.Property<int>("idVenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idVenta"));

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("id_Vendedor")
                        .HasColumnType("int");

                    b.Property<decimal>("tazas")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("idVenta");

                    b.HasIndex("id_Vendedor");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("Data.Producto", b =>
                {
                    b.HasOne("Data.Categoria", "Categoria")
                        .WithMany("Productos")
                        .HasForeignKey("idCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("Data.Producto_Venta", b =>
                {
                    b.HasOne("Data.Producto", "Producto")
                        .WithMany("Productos_Venta")
                        .HasForeignKey("id_Producto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Venta", "Venta")
                        .WithMany("Productos_Venta")
                        .HasForeignKey("id_Venta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("Data.Usuario", b =>
                {
                    b.HasOne("Data.TipoUsuario", "TipoUsuario")
                        .WithMany()
                        .HasForeignKey("id_TipoUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoUsuario");
                });

            modelBuilder.Entity("Data.Venta", b =>
                {
                    b.HasOne("Data.Usuario", "Vendedor")
                        .WithMany()
                        .HasForeignKey("id_Vendedor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vendedor");
                });

            modelBuilder.Entity("Data.Categoria", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("Data.Producto", b =>
                {
                    b.Navigation("Productos_Venta");
                });

            modelBuilder.Entity("Data.Venta", b =>
                {
                    b.Navigation("Productos_Venta");
                });
#pragma warning restore 612, 618
        }
    }
}
