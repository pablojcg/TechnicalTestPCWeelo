﻿// <auto-generated />
using System;
using Infraestructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infraestructure.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20210608160000_inicial")]
    partial class inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Infraestructure.Entities.Owner", b =>
                {
                    b.Property<int>("IdOwner")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdOwner");

                    b.ToTable("Owner");

                    b.HasData(
                        new
                        {
                            IdOwner = 1,
                            Address = "Dirección de Pedro Perez",
                            Birthday = new DateTime(1990, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Pedro Perez",
                            Photo = "C:/ruta_foto_perdro_perez/"
                        },
                        new
                        {
                            IdOwner = 2,
                            Address = "Dirección de Gustavo Delgado",
                            Birthday = new DateTime(1992, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Gustavo Delgado",
                            Photo = "C:/ruta_foto_gustavo_delgado/"
                        },
                        new
                        {
                            IdOwner = 3,
                            Address = "Dirección de Andrea Rodriguez",
                            Birthday = new DateTime(1990, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Andrea Rodriguez",
                            Photo = "C:/ruta_foto_andrea_rodriguez/"
                        },
                        new
                        {
                            IdOwner = 4,
                            Address = "Dirección de Maria Colmenarez",
                            Birthday = new DateTime(1999, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Maria Colmenarez",
                            Photo = "C:/ruta_foto_maria_colmenarez/"
                        });
                });

            modelBuilder.Entity("Infraestructure.Entities.Property", b =>
                {
                    b.Property<int>("IdProperty")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("CodeInternal")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("IdOwner")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.HasKey("IdProperty");

                    b.HasIndex("IdOwner");

                    b.ToTable("Property");

                    b.HasData(
                        new
                        {
                            IdProperty = 1,
                            Address = "Dirección de la Property 1",
                            CodeInternal = "0135",
                            IdOwner = 3,
                            Name = "Name Property 1",
                            Price = 150000.14999999999,
                            Year = "2010"
                        },
                        new
                        {
                            IdProperty = 2,
                            Address = "Dirección de la Property 2",
                            CodeInternal = "0245",
                            IdOwner = 2,
                            Name = "Name Property 2",
                            Price = 270000.15000000002,
                            Year = "2015"
                        },
                        new
                        {
                            IdProperty = 3,
                            Address = "Dirección de la Property 3",
                            CodeInternal = "0192",
                            IdOwner = 1,
                            Name = "Name Property 3",
                            Price = 390000.15000000002,
                            Year = "2012"
                        },
                        new
                        {
                            IdProperty = 4,
                            Address = "Dirección de la Property 4",
                            CodeInternal = "0141",
                            IdOwner = 4,
                            Name = "Name Property 4",
                            Price = 530000.15000000002,
                            Year = "2017"
                        });
                });

            modelBuilder.Entity("Infraestructure.Entities.PropertyImage", b =>
                {
                    b.Property<int>("IdPropertyImage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<int>("IdProperty")
                        .HasColumnType("int");

                    b.Property<string>("file")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("IdPropertyImage");

                    b.HasIndex("IdProperty");

                    b.ToTable("PropertyImage");

                    b.HasData(
                        new
                        {
                            IdPropertyImage = 1,
                            Enabled = true,
                            IdProperty = 1,
                            file = "C:/ruta_foto_casa_1/"
                        },
                        new
                        {
                            IdPropertyImage = 2,
                            Enabled = true,
                            IdProperty = 1,
                            file = "C:/ruta_foto_casa_2/"
                        },
                        new
                        {
                            IdPropertyImage = 3,
                            Enabled = false,
                            IdProperty = 2,
                            file = "C:/ruta_foto_casa_3/"
                        },
                        new
                        {
                            IdPropertyImage = 4,
                            Enabled = true,
                            IdProperty = 2,
                            file = "C:/ruta_foto_casa_4/"
                        },
                        new
                        {
                            IdPropertyImage = 5,
                            Enabled = true,
                            IdProperty = 3,
                            file = "C:/ruta_foto_casa_5/"
                        },
                        new
                        {
                            IdPropertyImage = 6,
                            Enabled = true,
                            IdProperty = 3,
                            file = "C:/ruta_foto_casa_6/"
                        },
                        new
                        {
                            IdPropertyImage = 7,
                            Enabled = true,
                            IdProperty = 4,
                            file = "C:/ruta_foto_casa_7/"
                        },
                        new
                        {
                            IdPropertyImage = 8,
                            Enabled = false,
                            IdProperty = 4,
                            file = "C:/ruta_foto_casa_8/"
                        });
                });

            modelBuilder.Entity("Infraestructure.Entities.PropertyTrace", b =>
                {
                    b.Property<int>("IdPropertyTrace")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateSale")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdProperty")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Tax")
                        .HasColumnType("float");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("IdPropertyTrace");

                    b.HasIndex("IdProperty");

                    b.ToTable("PropertyTrace");

                    b.HasData(
                        new
                        {
                            IdPropertyTrace = 1,
                            DateSale = new DateTime(2015, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdProperty = 1,
                            Name = "Name Property Trace 1",
                            Tax = 20000.150000000001,
                            Value = 130000.0
                        },
                        new
                        {
                            IdPropertyTrace = 2,
                            DateSale = new DateTime(2017, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdProperty = 2,
                            Name = "Name Property Trace 2",
                            Tax = 30000.150000000001,
                            Value = 240000.0
                        },
                        new
                        {
                            IdPropertyTrace = 3,
                            DateSale = new DateTime(2016, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdProperty = 3,
                            Name = "Name Property Trace 3",
                            Tax = 60000.150000000001,
                            Value = 330000.0
                        },
                        new
                        {
                            IdPropertyTrace = 4,
                            DateSale = new DateTime(2019, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdProperty = 4,
                            Name = "Name Property Trace 4",
                            Tax = 70000.149999999994,
                            Value = 460000.0
                        });
                });

            modelBuilder.Entity("Infraestructure.Entities.Property", b =>
                {
                    b.HasOne("Infraestructure.Entities.Owner", "Owner")
                        .WithMany("Propertys")
                        .HasForeignKey("IdOwner")
                        .HasConstraintName("FK_PropertyToOwner")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Infraestructure.Entities.PropertyImage", b =>
                {
                    b.HasOne("Infraestructure.Entities.Property", "Property")
                        .WithMany("PropertyImages")
                        .HasForeignKey("IdProperty")
                        .HasConstraintName("FK_PropertyImageToProperty")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Property");
                });

            modelBuilder.Entity("Infraestructure.Entities.PropertyTrace", b =>
                {
                    b.HasOne("Infraestructure.Entities.Property", "Property")
                        .WithMany("PropertyTraces")
                        .HasForeignKey("IdProperty")
                        .HasConstraintName("FK_PropertyTraceToProperty")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Property");
                });

            modelBuilder.Entity("Infraestructure.Entities.Owner", b =>
                {
                    b.Navigation("Propertys");
                });

            modelBuilder.Entity("Infraestructure.Entities.Property", b =>
                {
                    b.Navigation("PropertyImages");

                    b.Navigation("PropertyTraces");
                });
#pragma warning restore 612, 618
        }
    }
}
