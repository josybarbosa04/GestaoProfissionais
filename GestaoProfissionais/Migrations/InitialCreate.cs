using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoProfissionais.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    TipoDocumento = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profissionais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Especialidade = table.Column<string>(type: "TEXT", nullable: false),
                    TipoDocumento = table.Column<string>(type: "TEXT", nullable: false),
                    NumeroDocumento = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profissionais", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Nome", "TipoDocumento" },
                values: new object[] { 1, "Cardiologia", "CRM" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Nome", "TipoDocumento" },
                values: new object[] { 2, "Ortopedia", "CRM" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Nome", "TipoDocumento" },
                values: new object[] { 3, "Pediatria", "CRM" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Nome", "TipoDocumento" },
                values: new object[] { 4, "Dermatologia", "CRM" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Nome", "TipoDocumento" },
                values: new object[] { 5, "Ginecologia", "CRM" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Nome", "TipoDocumento" },
                values: new object[] { 6, "Neurologia", "CRM" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Nome", "TipoDocumento" },
                values: new object[] { 7, "Psiquiatria", "CRM" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Nome", "TipoDocumento" },
                values: new object[] { 8, "Anestesiologia", "CRM" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Nome", "TipoDocumento" },
                values: new object[] { 9, "Radiologia", "CRM" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Nome", "TipoDocumento" },
                values: new object[] { 10, "Endocrinologia", "CRM" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Nome", "TipoDocumento" },
                values: new object[] { 11, "Nutricionista Clínico", "CRN" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Nome", "TipoDocumento" },
                values: new object[] { 12, "Nutrição Esportiva", "CRN" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Nome", "TipoDocumento" },
                values: new object[] { 13, "Nutrição Oncológica", "CRN" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Nome", "TipoDocumento" },
                values: new object[] { 14, "Fisioterapia Ortopédica", "CREFITO" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Nome", "TipoDocumento" },
                values: new object[] { 15, "Fisioterapia Neurológica", "CREFITO" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Nome", "TipoDocumento" },
                values: new object[] { 16, "Fisioterapia Respiratória", "CREFITO" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Nome", "TipoDocumento" },
                values: new object[] { 17, "Ortodontia", "CRO" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Nome", "TipoDocumento" },
                values: new object[] { 18, "Implantodontia", "CRO" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Nome", "TipoDocumento" },
                values: new object[] { 19, "Endodontia", "CRO" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Nome", "TipoDocumento" },
                values: new object[] { 20, "Enfermagem Geral", "COREN" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Nome", "TipoDocumento" },
                values: new object[] { 21, "Enfermagem Obstétrica", "COREN" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Nome", "TipoDocumento" },
                values: new object[] { 22, "Psicologia Clínica", "CRP" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Nome", "TipoDocumento" },
                values: new object[] { 23, "Psicologia Organizacional", "CRP" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Nome", "TipoDocumento" },
                values: new object[] { 24, "Neuropsicologia", "CRP" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Nome", "TipoDocumento" },
                values: new object[] { 25, "Farmácia Clínica", "CRF" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Nome", "TipoDocumento" },
                values: new object[] { 26, "Farmácia Hospitalar", "CRF" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Nome", "TipoDocumento" },
                values: new object[] { 27, "Análises Clínicas", "CRF" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Nome", "TipoDocumento" },
                values: new object[] { 28, "Personal Trainer", "CREF" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Nome", "TipoDocumento" },
                values: new object[] { 29, "Preparação Física", "CREF" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.DropTable(
                name: "Profissionais");
        }
    }
}
