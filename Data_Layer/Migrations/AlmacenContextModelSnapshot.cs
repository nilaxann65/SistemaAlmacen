﻿// <auto-generated />
using System;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(AlmacenContext))]
    partial class AlmacenContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Data.Models.Categoria", b =>
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

                    b.HasData(
                        new
                        {
                            idCategoria = 1,
                            estado = 0,
                            nombre = "Lacteos"
                        },
                        new
                        {
                            idCategoria = 2,
                            estado = 0,
                            nombre = "Carnes"
                        });
                });

            modelBuilder.Entity("Data.Models.Producto", b =>
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

                    b.HasData(
                        new
                        {
                            idProducto = 1,
                            estado = 1,
                            idCategoria = 1,
                            nombre = "Leche",
                            precio = 10m,
                            stock = 10
                        },
                        new
                        {
                            idProducto = 2,
                            estado = 1,
                            idCategoria = 1,
                            nombre = "Queso",
                            precio = 20m,
                            stock = 10
                        },
                        new
                        {
                            idProducto = 3,
                            estado = 1,
                            idCategoria = 2,
                            nombre = "Carne de res",
                            precio = 30m,
                            stock = 10
                        },
                        new
                        {
                            idProducto = 4,
                            estado = 1,
                            idCategoria = 2,
                            nombre = "Carne de cerdo",
                            precio = 40m,
                            stock = 10
                        });
                });

            modelBuilder.Entity("Data.Models.Producto_Venta", b =>
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

            modelBuilder.Entity("Data.Models.Venta", b =>
                {
                    b.Property<int>("idVenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idVenta"));

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("tazas")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("idVenta");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("Data.Models.Producto", b =>
                {
                    b.HasOne("Data.Models.Categoria", "Categoria")
                        .WithMany("Productos")
                        .HasForeignKey("idCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("Data.Models.Producto_Venta", b =>
                {
                    b.HasOne("Data.Models.Producto", "Producto")
                        .WithMany("Productos_Venta")
                        .HasForeignKey("id_Producto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Models.Venta", "Venta")
                        .WithMany("Productos_Venta")
                        .HasForeignKey("id_Venta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("Data.Models.Categoria", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("Data.Models.Producto", b =>
                {
                    b.Navigation("Productos_Venta");
                });

            modelBuilder.Entity("Data.Models.Venta", b =>
                {
                    b.Navigation("Productos_Venta");
                });
#pragma warning restore 612, 618
        }
    }
}
