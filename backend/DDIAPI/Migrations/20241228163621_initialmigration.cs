using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DDIAPI.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clinicalRecommendations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reccomendation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clinicalRecommendations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "drugCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_drugCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "severities",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LevelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LevelDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_severities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "interactions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    drug1ID = table.Column<int>(type: "int", nullable: false),
                    drug2ID = table.Column<int>(type: "int", nullable: false),
                    severityId = table.Column<int>(type: "int", nullable: false),
                    clinicalRecommendationId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_interactions", x => x.id);
                    table.ForeignKey(
                        name: "FK_interactions_clinicalRecommendations_clinicalRecommendationId",
                        column: x => x.clinicalRecommendationId,
                        principalTable: "clinicalRecommendations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_interactions_severities_severityId",
                        column: x => x.severityId,
                        principalTable: "severities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "healthCareProviders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Speciality = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_healthCareProviders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_healthCareProviders_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "drugs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrugName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenericDrugName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DosageForm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Strength = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrugCategoryId = table.Column<int>(type: "int", nullable: false),
                    Interactionid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_drugs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_drugs_drugCategories_DrugCategoryId",
                        column: x => x.DrugCategoryId,
                        principalTable: "drugCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_drugs_interactions_Interactionid",
                        column: x => x.Interactionid,
                        principalTable: "interactions",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "systemAlerts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    interactionID = table.Column<int>(type: "int", nullable: false),
                    dateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_systemAlerts", x => x.id);
                    table.ForeignKey(
                        name: "FK_systemAlerts_interactions_interactionID",
                        column: x => x.interactionID,
                        principalTable: "interactions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "medicationLogs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    drugID = table.Column<int>(type: "int", nullable: false),
                    dosage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    startDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicationLogs", x => x.id);
                    table.ForeignKey(
                        name: "FK_medicationLogs_drugs_drugID",
                        column: x => x.drugID,
                        principalTable: "drugs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_drugs_DrugCategoryId",
                table: "drugs",
                column: "DrugCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_drugs_Interactionid",
                table: "drugs",
                column: "Interactionid");

            migrationBuilder.CreateIndex(
                name: "IX_healthCareProviders_UserId",
                table: "healthCareProviders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_interactions_clinicalRecommendationId",
                table: "interactions",
                column: "clinicalRecommendationId");

            migrationBuilder.CreateIndex(
                name: "IX_interactions_severityId",
                table: "interactions",
                column: "severityId");

            migrationBuilder.CreateIndex(
                name: "IX_medicationLogs_drugID",
                table: "medicationLogs",
                column: "drugID");

            migrationBuilder.CreateIndex(
                name: "IX_systemAlerts_interactionID",
                table: "systemAlerts",
                column: "interactionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "healthCareProviders");

            migrationBuilder.DropTable(
                name: "medicationLogs");

            migrationBuilder.DropTable(
                name: "systemAlerts");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "drugs");

            migrationBuilder.DropTable(
                name: "drugCategories");

            migrationBuilder.DropTable(
                name: "interactions");

            migrationBuilder.DropTable(
                name: "clinicalRecommendations");

            migrationBuilder.DropTable(
                name: "severities");
        }
    }
}
