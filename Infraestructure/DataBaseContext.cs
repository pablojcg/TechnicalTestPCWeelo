using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Infraestructure.Entities;
using Newtonsoft.Json;

namespace Infraestructure
{
    public partial class DataBaseContext : DbContext
	{
		#region " [ Variables globales ] "

		protected readonly string Connection = "";

		#endregion

		#region " [ Constructor e inicializador de variables ] "

		public DataBaseContext()
		{
			//dynamic Data = JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json")));
			dynamic Data = JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(Path.Combine(@"..\Infraestructure\", "appsettings.json")));
			this.Connection = Data.DataBaseInfo.Connection.Value;
		}
		public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }

		#endregion

		#region " [ Definición inicial de tablas DbSet ] "

		public virtual DbSet<Owner> Owners { get; set; }
		public virtual DbSet<Property> Propertys { get; set; }
		public virtual DbSet<PropertyImage> PropertyImages { get; set; }
		public virtual DbSet<PropertyTrace> PropertyTraces { get; set; }

		#endregion

		#region " [ Creacion de modelo de tablas y relaciones ] "

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			modelBuilder.Entity<Owner>(entity =>
			{
				entity.ToTable("Owner");

				entity.Property(e => e.Name)
					.IsRequired()
					.HasMaxLength(100);

				entity.Property(e => e.Address)
					.IsRequired()
					.HasMaxLength(250);

				entity.Property(e => e.Photo)
					.IsRequired()
					.HasMaxLength(100);

				entity.Property(e => e.Birthday)
					.IsRequired();

				entity.HasData(
					new Owner() { IdOwner = 1, Name = "Pedro Perez", Address = "Dirección de Pedro Perez", Photo = "C:/ruta_foto_perdro_perez/", Birthday = DateTime.Parse("23/09/1990") },
					new Owner() { IdOwner = 2, Name = "Gustavo Delgado", Address = "Dirección de Gustavo Delgado", Photo = "C:/ruta_foto_gustavo_delgado/", Birthday = DateTime.Parse("09/06/1992") },
					new Owner() { IdOwner = 3, Name = "Andrea Rodriguez", Address = "Dirección de Andrea Rodriguez", Photo = "C:/ruta_foto_andrea_rodriguez/", Birthday = DateTime.Parse("20/03/1990") },
					new Owner() { IdOwner = 4, Name = "Maria Colmenarez", Address = "Dirección de Maria Colmenarez", Photo = "C:/ruta_foto_maria_colmenarez/", Birthday = DateTime.Parse("05/12/1999") }
				);

			});

			modelBuilder.Entity<Property>(entity =>
			{
				entity.ToTable("Property");

				entity.Property(e => e.Name)
					.IsRequired()
					.HasMaxLength(100);

				entity.Property(e => e.Address)
					.IsRequired()
					.HasMaxLength(250);

				entity.Property(e => e.Price)
					.IsRequired();

				entity.Property(e => e.CodeInternal)
					.IsRequired()
					.HasMaxLength(15);

				entity.Property(e => e.Year)
					.IsRequired()
					.HasMaxLength(4);

				entity.HasOne(d => d.Owner)
					.WithMany(p => p.Propertys)
					.HasForeignKey(d => d.IdOwner)
					.HasConstraintName("FK_PropertyToOwner");

				entity.HasData(
					new Property() { IdProperty = 1, Name = "Name Property 1", Address = "Dirección de la Property 1", Price = 150000.15, CodeInternal = "0135", Year = "2010", IdOwner = 3 },
					new Property() { IdProperty = 2, Name = "Name Property 2", Address = "Dirección de la Property 2", Price = 270000.15, CodeInternal = "0245", Year = "2015", IdOwner = 2 },
					new Property() { IdProperty = 3, Name = "Name Property 3", Address = "Dirección de la Property 3", Price = 390000.15, CodeInternal = "0192", Year = "2012", IdOwner = 1 },
					new Property() { IdProperty = 4, Name = "Name Property 4", Address = "Dirección de la Property 4", Price = 530000.15, CodeInternal = "0141", Year = "2017", IdOwner = 4 }
				);

			});

			modelBuilder.Entity<PropertyImage>(entity =>
			{
				entity.ToTable("PropertyImage");

				entity.Property(e => e.file)
					.IsRequired()
					.HasMaxLength(250);

				entity.Property(e => e.Enabled)
					.IsRequired();

				entity.HasOne(d => d.Property)
					.WithMany(p => p.PropertyImages)
					.HasForeignKey(d => d.IdProperty)
					.HasConstraintName("FK_PropertyImageToProperty");

				entity.HasData(
					new PropertyImage() { IdPropertyImage = 1, file = "C:/ruta_foto_casa_1/", Enabled = true, IdProperty = 1 },
					new PropertyImage() { IdPropertyImage = 2, file = "C:/ruta_foto_casa_2/", Enabled = true, IdProperty = 1 },
					new PropertyImage() { IdPropertyImage = 3, file = "C:/ruta_foto_casa_3/", Enabled = false, IdProperty = 2 },
					new PropertyImage() { IdPropertyImage = 4, file = "C:/ruta_foto_casa_4/", Enabled = true, IdProperty = 2 },
					new PropertyImage() { IdPropertyImage = 5, file = "C:/ruta_foto_casa_5/", Enabled = true, IdProperty = 3 },
					new PropertyImage() { IdPropertyImage = 6, file = "C:/ruta_foto_casa_6/", Enabled = true, IdProperty = 3 },
					new PropertyImage() { IdPropertyImage = 7, file = "C:/ruta_foto_casa_7/", Enabled = true, IdProperty = 4 },
					new PropertyImage() { IdPropertyImage = 8, file = "C:/ruta_foto_casa_8/", Enabled = false, IdProperty = 4 }
				);
			});

			modelBuilder.Entity<PropertyTrace>(entity =>
			{
				entity.ToTable("PropertyTrace");

				entity.Property(e => e.DateSale)
					.IsRequired();

				entity.Property(e => e.Name)
					.IsRequired()
					.HasMaxLength(100);

				entity.Property(e => e.Value)
					.IsRequired();

				entity.Property(e => e.Tax)
					.IsRequired();

				entity.HasOne(d => d.Property)
					.WithMany(p => p.PropertyTraces)
					.HasForeignKey(d => d.IdProperty)
					.HasConstraintName("FK_PropertyTraceToProperty");

				entity.HasData(
					new PropertyTrace() { IdPropertyTrace = 1, DateSale = DateTime.Parse("20/05/2015"), Name = "Name Property Trace 1", Value = 130000.00, Tax = 20000.15, IdProperty = 1 },
					new PropertyTrace() { IdPropertyTrace = 2, DateSale = DateTime.Parse("15/11/2017"), Name = "Name Property Trace 2", Value = 240000.00, Tax = 30000.15, IdProperty = 2 },
					new PropertyTrace() { IdPropertyTrace = 3, DateSale = DateTime.Parse("23/02/2016"), Name = "Name Property Trace 3", Value = 330000.00, Tax = 60000.15, IdProperty = 3 },
					new PropertyTrace() { IdPropertyTrace = 4, DateSale = DateTime.Parse("05/08/2019"), Name = "Name Property Trace 4", Value = 460000.00, Tax = 70000.15, IdProperty = 4 }
				);
			});

			OnModelCreatingPartial(modelBuilder);
		}

		#endregion

		#region " [Configuración para conexión del contexto] "
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				if (string.IsNullOrEmpty(this.Connection))
				{
					throw new System.Exception("Connection is not defined.");
				}
				optionsBuilder.UseSqlServer(this.Connection);
			}
		}

		#endregion
		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
