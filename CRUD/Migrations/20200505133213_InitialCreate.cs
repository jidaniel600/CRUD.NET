using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUD.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
   
            //migrationBuilder.CreateTable(
            //    name: "TipoIdentificacion",
            //    columns: table => new
            //    {
            //        codTipoId = table.Column<short>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        nombreTipoId = table.Column<string>(maxLength: 50, nullable: true),
            //        AbreviTipoId = table.Column<string>(fixedLength: true, maxLength: 2, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TipoIdentificacion", x => x.codTipoId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Usuarios",
            //    columns: table => new
            //    {
            //        id = table.Column<decimal>(type: "numeric(18, 0)", nullable: false),
            //        nombre = table.Column<string>(maxLength: 50, nullable: false),
            //        Apellido = table.Column<string>(maxLength: 50, nullable: false),
            //        TipoId = table.Column<short>(nullable: true),
            //        Contraseña = table.Column<string>(maxLength: 50, nullable: true),
            //        Email = table.Column<string>(maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Usuarios", x => x.id);
            //        table.ForeignKey(
            //            name: "FK_Usuarios_TipoIdentificacion",
            //            column: x => x.TipoId,
            //            principalTable: "TipoIdentificacion",
            //            principalColumn: "codTipoId",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Usuarios_TipoId",
            //    table: "Usuarios",
            //    column: "TipoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
       
        }
    }
}
