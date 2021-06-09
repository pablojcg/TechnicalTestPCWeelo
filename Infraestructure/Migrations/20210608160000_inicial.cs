using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructure.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    IdOwner = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.IdOwner);
                });

            migrationBuilder.CreateTable(
                name: "Property",
                columns: table => new
                {
                    IdProperty = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CodeInternal = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Year = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    IdOwner = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property", x => x.IdProperty);
                    table.ForeignKey(
                        name: "FK_PropertyToOwner",
                        column: x => x.IdOwner,
                        principalTable: "Owner",
                        principalColumn: "IdOwner",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyImage",
                columns: table => new
                {
                    IdPropertyImage = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    file = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    IdProperty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyImage", x => x.IdPropertyImage);
                    table.ForeignKey(
                        name: "FK_PropertyImageToProperty",
                        column: x => x.IdProperty,
                        principalTable: "Property",
                        principalColumn: "IdProperty",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyTrace",
                columns: table => new
                {
                    IdPropertyTrace = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateSale = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    Tax = table.Column<double>(type: "float", nullable: false),
                    IdProperty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyTrace", x => x.IdPropertyTrace);
                    table.ForeignKey(
                        name: "FK_PropertyTraceToProperty",
                        column: x => x.IdProperty,
                        principalTable: "Property",
                        principalColumn: "IdProperty",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Owner",
                columns: new[] { "IdOwner", "Address", "Birthday", "Name", "Photo" },
                values: new object[,]
                {
                    { 1, "Dirección de Pedro Perez", new DateTime(1990, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pedro Perez", "C:/ruta_foto_perdro_perez/" },
                    { 2, "Dirección de Gustavo Delgado", new DateTime(1992, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gustavo Delgado", "C:/ruta_foto_gustavo_delgado/" },
                    { 3, "Dirección de Andrea Rodriguez", new DateTime(1990, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrea Rodriguez", "C:/ruta_foto_andrea_rodriguez/" },
                    { 4, "Dirección de Maria Colmenarez", new DateTime(1999, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maria Colmenarez", "C:/ruta_foto_maria_colmenarez/" }
                });

            migrationBuilder.InsertData(
                table: "Property",
                columns: new[] { "IdProperty", "Address", "CodeInternal", "IdOwner", "Name", "Price", "Year" },
                values: new object[,]
                {
                    { 3, "Dirección de la Property 3", "0192", 1, "Name Property 3", 390000.15000000002, "2012" },
                    { 2, "Dirección de la Property 2", "0245", 2, "Name Property 2", 270000.15000000002, "2015" },
                    { 1, "Dirección de la Property 1", "0135", 3, "Name Property 1", 150000.14999999999, "2010" },
                    { 4, "Dirección de la Property 4", "0141", 4, "Name Property 4", 530000.15000000002, "2017" }
                });

            migrationBuilder.InsertData(
                table: "PropertyImage",
                columns: new[] { "IdPropertyImage", "Enabled", "IdProperty", "file" },
                values: new object[,]
                {
                    { 5, true, 3, "C:/ruta_foto_casa_5/" },
                    { 6, true, 3, "C:/ruta_foto_casa_6/" },
                    { 3, false, 2, "C:/ruta_foto_casa_3/" },
                    { 4, true, 2, "C:/ruta_foto_casa_4/" },
                    { 1, true, 1, "C:/ruta_foto_casa_1/" },
                    { 2, true, 1, "C:/ruta_foto_casa_2/" },
                    { 7, true, 4, "C:/ruta_foto_casa_7/" },
                    { 8, false, 4, "C:/ruta_foto_casa_8/" }
                });

            migrationBuilder.InsertData(
                table: "PropertyTrace",
                columns: new[] { "IdPropertyTrace", "DateSale", "IdProperty", "Name", "Tax", "Value" },
                values: new object[,]
                {
                    { 3, new DateTime(2016, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Name Property Trace 3", 60000.150000000001, 330000.0 },
                    { 2, new DateTime(2017, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Name Property Trace 2", 30000.150000000001, 240000.0 },
                    { 1, new DateTime(2015, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Name Property Trace 1", 20000.150000000001, 130000.0 },
                    { 4, new DateTime(2019, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Name Property Trace 4", 70000.149999999994, 460000.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Property_IdOwner",
                table: "Property",
                column: "IdOwner");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyImage_IdProperty",
                table: "PropertyImage",
                column: "IdProperty");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyTrace_IdProperty",
                table: "PropertyTrace",
                column: "IdProperty");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyImage");

            migrationBuilder.DropTable(
                name: "PropertyTrace");

            migrationBuilder.DropTable(
                name: "Property");

            migrationBuilder.DropTable(
                name: "Owner");
        }
    }
}
