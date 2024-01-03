using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DM.Infrastructure.Data.CommandDb.Migrations
{
    /// <inheritdoc />
    public partial class Versao00100 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EstoqueSangues",
                keyColumn: "Id",
                keyValue: new Guid("4cd49427-68f3-46d4-99d5-c5820ad17152"));

            migrationBuilder.DeleteData(
                table: "EstoqueSangues",
                keyColumn: "Id",
                keyValue: new Guid("617d9602-47fd-43be-9746-011f85eb04f9"));

            migrationBuilder.DeleteData(
                table: "EstoqueSangues",
                keyColumn: "Id",
                keyValue: new Guid("901ad1bc-3eb8-45e1-a7ba-c554337509ec"));

            migrationBuilder.DeleteData(
                table: "EstoqueSangues",
                keyColumn: "Id",
                keyValue: new Guid("94fe7651-65fb-4cc6-a236-0c12338b475a"));

            migrationBuilder.DeleteData(
                table: "EstoqueSangues",
                keyColumn: "Id",
                keyValue: new Guid("b378a0c5-e8b2-4fa5-a78b-58ea88c278f8"));

            migrationBuilder.DeleteData(
                table: "EstoqueSangues",
                keyColumn: "Id",
                keyValue: new Guid("baac0b06-a0ea-4adb-89f1-628096ca9ccb"));

            migrationBuilder.DeleteData(
                table: "EstoqueSangues",
                keyColumn: "Id",
                keyValue: new Guid("be69cb34-0911-468b-91b8-c13afb783f8e"));

            migrationBuilder.DeleteData(
                table: "EstoqueSangues",
                keyColumn: "Id",
                keyValue: new Guid("f93e2ea6-e37f-496d-b59e-d10be251c3be"));

            migrationBuilder.CreateTable(
                name: "OutBoxMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Type = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TypeFullName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Content = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OccurrendOnUtc = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ProcessedOnUtc = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Error = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutBoxMessages", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "EstoqueSangues",
                columns: new[] { "Id", "DataAtualizado", "DataCadastro", "FatorRh", "QuantidadeML", "TipoSanguineo" },
                values: new object[,]
                {
                    { new Guid("35a05f1f-46a6-4195-8e94-0fc6f24c986f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0.0, 3 },
                    { new Guid("57a93711-7147-44b9-bc10-84d5c7a832e6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0.0, 1 },
                    { new Guid("802ad115-74ec-4092-b164-ce3ae9d44571"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0.0, 2 },
                    { new Guid("8395a06f-2280-4315-8eb5-8209da8fcffa"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0.0, 4 },
                    { new Guid("940f2ad2-de7c-476c-9268-765391dfd129"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0.0, 1 },
                    { new Guid("96efb611-0af2-413f-918c-808576784576"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0.0, 4 },
                    { new Guid("bde3e59c-20ba-46bd-90e5-65210160dfce"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0.0, 3 },
                    { new Guid("c6591fb6-938b-4d89-aec0-c64fcba0701b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0.0, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OutBoxMessages");

            migrationBuilder.DeleteData(
                table: "EstoqueSangues",
                keyColumn: "Id",
                keyValue: new Guid("35a05f1f-46a6-4195-8e94-0fc6f24c986f"));

            migrationBuilder.DeleteData(
                table: "EstoqueSangues",
                keyColumn: "Id",
                keyValue: new Guid("57a93711-7147-44b9-bc10-84d5c7a832e6"));

            migrationBuilder.DeleteData(
                table: "EstoqueSangues",
                keyColumn: "Id",
                keyValue: new Guid("802ad115-74ec-4092-b164-ce3ae9d44571"));

            migrationBuilder.DeleteData(
                table: "EstoqueSangues",
                keyColumn: "Id",
                keyValue: new Guid("8395a06f-2280-4315-8eb5-8209da8fcffa"));

            migrationBuilder.DeleteData(
                table: "EstoqueSangues",
                keyColumn: "Id",
                keyValue: new Guid("940f2ad2-de7c-476c-9268-765391dfd129"));

            migrationBuilder.DeleteData(
                table: "EstoqueSangues",
                keyColumn: "Id",
                keyValue: new Guid("96efb611-0af2-413f-918c-808576784576"));

            migrationBuilder.DeleteData(
                table: "EstoqueSangues",
                keyColumn: "Id",
                keyValue: new Guid("bde3e59c-20ba-46bd-90e5-65210160dfce"));

            migrationBuilder.DeleteData(
                table: "EstoqueSangues",
                keyColumn: "Id",
                keyValue: new Guid("c6591fb6-938b-4d89-aec0-c64fcba0701b"));

            migrationBuilder.InsertData(
                table: "EstoqueSangues",
                columns: new[] { "Id", "DataAtualizado", "DataCadastro", "FatorRh", "QuantidadeML", "TipoSanguineo" },
                values: new object[,]
                {
                    { new Guid("4cd49427-68f3-46d4-99d5-c5820ad17152"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0.0, 1 },
                    { new Guid("617d9602-47fd-43be-9746-011f85eb04f9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0.0, 3 },
                    { new Guid("901ad1bc-3eb8-45e1-a7ba-c554337509ec"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0.0, 2 },
                    { new Guid("94fe7651-65fb-4cc6-a236-0c12338b475a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0.0, 2 },
                    { new Guid("b378a0c5-e8b2-4fa5-a78b-58ea88c278f8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0.0, 3 },
                    { new Guid("baac0b06-a0ea-4adb-89f1-628096ca9ccb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0.0, 0 },
                    { new Guid("be69cb34-0911-468b-91b8-c13afb783f8e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0.0, 1 },
                    { new Guid("f93e2ea6-e37f-496d-b59e-d10be251c3be"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0.0, 0 }
                });
        }
    }
}
