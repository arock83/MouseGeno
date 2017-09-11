using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MouseGeno.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.AddColumn<string>(
                name: "Initials",
                table: "AspNetUsers",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Cage",
                columns: table => new
                {
                    CageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Breeding = table.Column<bool>(type: "bit", nullable: false),
                    CageNumber = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Cubicle = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cage", x => x.CageID);
                });

            migrationBuilder.CreateTable(
                name: "Condition",
                columns: table => new
                {
                    ConditionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Instructions = table.Column<string>(type: "nvarchar(155)", maxLength: 155, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condition", x => x.ConditionID);
                });

            migrationBuilder.CreateTable(
                name: "GenoType",
                columns: table => new
                {
                    GenoTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortHand = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenoType", x => x.GenoTypeID);
                });

            migrationBuilder.CreateTable(
                name: "HealthStatus",
                columns: table => new
                {
                    HealthStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "nvarchar(155)", maxLength: 155, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthStatus", x => x.HealthStatusID);
                });

            migrationBuilder.CreateTable(
                name: "Line",
                columns: table => new
                {
                    LineID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "nvarchar(155)", maxLength: 155, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Line", x => x.LineID);
                });

            migrationBuilder.CreateTable(
                name: "TaskType",
                columns: table => new
                {
                    TaskTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Instructions = table.Column<string>(type: "nvarchar(155)", maxLength: 155, nullable: false),
                    MeasurementType = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskType", x => x.TaskTypeID);
                });

            migrationBuilder.CreateTable(
                name: "CageCondition",
                columns: table => new
                {
                    CageConditionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CageID = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConditionID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CageCondition", x => x.CageConditionID);
                    table.ForeignKey(
                        name: "FK_CageCondition_Cage_CageID",
                        column: x => x.CageID,
                        principalTable: "Cage",
                        principalColumn: "CageID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CageCondition_Condition_ConditionID",
                        column: x => x.ConditionID,
                        principalTable: "Condition",
                        principalColumn: "ConditionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CageCondition_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LineGenoType",
                columns: table => new
                {
                    LineGenoTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GenoTypeID = table.Column<int>(type: "int", nullable: false),
                    LineID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineGenoType", x => x.LineGenoTypeID);
                    table.ForeignKey(
                        name: "FK_LineGenoType_GenoType_GenoTypeID",
                        column: x => x.GenoTypeID,
                        principalTable: "GenoType",
                        principalColumn: "GenoTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineGenoType_Line_LineID",
                        column: x => x.LineID,
                        principalTable: "Line",
                        principalColumn: "LineID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mouse",
                columns: table => new
                {
                    MouseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Birth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DadID = table.Column<int>(type: "int", nullable: false),
                    Death = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EarTag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenoTypeID = table.Column<int>(type: "int", nullable: false),
                    LineID = table.Column<int>(type: "int", nullable: false),
                    MomID = table.Column<int>(type: "int", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToeClip = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mouse", x => x.MouseID);
                    table.ForeignKey(
                        name: "FK_Mouse_GenoType_GenoTypeID",
                        column: x => x.GenoTypeID,
                        principalTable: "GenoType",
                        principalColumn: "GenoTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mouse_Line_LineID",
                        column: x => x.LineID,
                        principalTable: "Line",
                        principalColumn: "LineID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MouseCage",
                columns: table => new
                {
                    MouseCageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CageID = table.Column<int>(type: "int", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MouseID = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MouseCage", x => x.MouseCageID);
                    table.ForeignKey(
                        name: "FK_MouseCage_Cage_CageID",
                        column: x => x.CageID,
                        principalTable: "Cage",
                        principalColumn: "CageID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MouseCage_Mouse_MouseID",
                        column: x => x.MouseID,
                        principalTable: "Mouse",
                        principalColumn: "MouseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MouseHealthStatus",
                columns: table => new
                {
                    MouseHealthStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HealthStatusID = table.Column<int>(type: "int", nullable: false),
                    MouseID = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MouseHealthStatus", x => x.MouseHealthStatusID);
                    table.ForeignKey(
                        name: "FK_MouseHealthStatus_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MouseHealthStatus_HealthStatus_HealthStatusID",
                        column: x => x.HealthStatusID,
                        principalTable: "HealthStatus",
                        principalColumn: "HealthStatusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MouseHealthStatus_Mouse_MouseID",
                        column: x => x.MouseID,
                        principalTable: "Mouse",
                        principalColumn: "MouseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MouseTask",
                columns: table => new
                {
                    MouseTaskID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MouseID = table.Column<int>(type: "int", nullable: false),
                    TaskTypeID = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MouseTask", x => x.MouseTaskID);
                    table.ForeignKey(
                        name: "FK_MouseTask_Mouse_MouseID",
                        column: x => x.MouseID,
                        principalTable: "Mouse",
                        principalColumn: "MouseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MouseTask_TaskType_TaskTypeID",
                        column: x => x.TaskTypeID,
                        principalTable: "TaskType",
                        principalColumn: "TaskTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MouseTask_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CageCondition_CageID",
                table: "CageCondition",
                column: "CageID");

            migrationBuilder.CreateIndex(
                name: "IX_CageCondition_ConditionID",
                table: "CageCondition",
                column: "ConditionID");

            migrationBuilder.CreateIndex(
                name: "IX_CageCondition_UserId",
                table: "CageCondition",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LineGenoType_GenoTypeID",
                table: "LineGenoType",
                column: "GenoTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_LineGenoType_LineID",
                table: "LineGenoType",
                column: "LineID");

            migrationBuilder.CreateIndex(
                name: "IX_Mouse_GenoTypeID",
                table: "Mouse",
                column: "GenoTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Mouse_LineID",
                table: "Mouse",
                column: "LineID");

            migrationBuilder.CreateIndex(
                name: "IX_MouseCage_CageID",
                table: "MouseCage",
                column: "CageID");

            migrationBuilder.CreateIndex(
                name: "IX_MouseCage_MouseID",
                table: "MouseCage",
                column: "MouseID");

            migrationBuilder.CreateIndex(
                name: "IX_MouseHealthStatus_ApplicationUserId",
                table: "MouseHealthStatus",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MouseHealthStatus_HealthStatusID",
                table: "MouseHealthStatus",
                column: "HealthStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_MouseHealthStatus_MouseID",
                table: "MouseHealthStatus",
                column: "MouseID");

            migrationBuilder.CreateIndex(
                name: "IX_MouseTask_MouseID",
                table: "MouseTask",
                column: "MouseID");

            migrationBuilder.CreateIndex(
                name: "IX_MouseTask_TaskTypeID",
                table: "MouseTask",
                column: "TaskTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_MouseTask_UserId",
                table: "MouseTask",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CageCondition");

            migrationBuilder.DropTable(
                name: "LineGenoType");

            migrationBuilder.DropTable(
                name: "MouseCage");

            migrationBuilder.DropTable(
                name: "MouseHealthStatus");

            migrationBuilder.DropTable(
                name: "MouseTask");

            migrationBuilder.DropTable(
                name: "Condition");

            migrationBuilder.DropTable(
                name: "Cage");

            migrationBuilder.DropTable(
                name: "HealthStatus");

            migrationBuilder.DropTable(
                name: "Mouse");

            migrationBuilder.DropTable(
                name: "TaskType");

            migrationBuilder.DropTable(
                name: "GenoType");

            migrationBuilder.DropTable(
                name: "Line");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "Initials",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }
    }
}
