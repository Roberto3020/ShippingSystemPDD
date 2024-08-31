﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShippingSystemPDD.Data;

namespace ShippingSystemPDD.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("ShippingSystemPDD.Destinario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("DireccionId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DireccionId");

                    b.ToTable("Destinarios");
                });

            modelBuilder.Entity("ShippingSystemPDD.Direccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Barrio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Calle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ciudad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Departamento")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Direcciones");
                });

            modelBuilder.Entity("ShippingSystemPDD.Paquete", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("DestinarioId")
                        .HasColumnType("int");

                    b.Property<int>("RemitenteId")
                        .HasColumnType("int");

                    b.Property<int>("TipoDePaqueteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DestinarioId");

                    b.HasIndex("RemitenteId");

                    b.HasIndex("TipoDePaqueteId");

                    b.ToTable("Paquetes");
                });

            modelBuilder.Entity("ShippingSystemPDD.Remitente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Remitentes");
                });

            modelBuilder.Entity("ShippingSystemPDD.TipoPaquete", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Peso")
                        .HasColumnType("real");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TiposDePaquete");

                    b.HasDiscriminator<string>("Tipo").HasValue("TipoDePaquete");
                });

            modelBuilder.Entity("ShippingSystemPDD.PaqueteEstandar", b =>
                {
                    b.HasBaseType("ShippingSystemPDD.TipoPaquete");

                    b.HasDiscriminator().HasValue("PaqueteEstandar");
                });

            modelBuilder.Entity("ShippingSystemPDD.Destinario", b =>
                {
                    b.HasOne("ShippingSystemPDD.Direccion", "Direccion")
                        .WithMany()
                        .HasForeignKey("DireccionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Direccion");
                });

            modelBuilder.Entity("ShippingSystemPDD.Paquete", b =>
                {
                    b.HasOne("ShippingSystemPDD.Destinario", "Destinario")
                        .WithMany()
                        .HasForeignKey("DestinarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShippingSystemPDD.Remitente", "Remitente")
                        .WithMany()
                        .HasForeignKey("RemitenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShippingSystemPDD.PaqueteEstandar", "TipoDePaquete")
                        .WithMany()
                        .HasForeignKey("TipoDePaqueteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Destinario");

                    b.Navigation("Remitente");

                    b.Navigation("TipoDePaquete");
                });
#pragma warning restore 612, 618
        }
    }
}
