using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddedYearAndOptionPart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BodyTypeId",
                table: "Items",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ColorId",
                table: "Items",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Cylinders",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Doors",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "FuelTypeId",
                table: "Items",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "HorsePower",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ItemCreatedYear",
                table: "Items",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Odometer",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "RegionalSpecsId",
                table: "Items",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "SteeringSide",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TransmissionTypeId",
                table: "Items",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "WarrantyId",
                table: "Items",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Badges",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Badges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BodyTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Extras",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FuelTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegionalSpecs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionalSpecs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SellerTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellerTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TechFeatures",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechFeatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransmissionTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransmissionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Warranties",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warranties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemBadges",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(nullable: false),
                    BadgesId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemBadges", x => new { x.BadgesId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_ItemBadges_Badges_BadgesId",
                        column: x => x.BadgesId,
                        principalTable: "Badges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemBadges_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemExtras",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(nullable: false),
                    ExtrasId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemExtras", x => new { x.ExtrasId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_ItemExtras_Extras_ExtrasId",
                        column: x => x.ExtrasId,
                        principalTable: "Extras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemExtras_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemTechFeatures",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(nullable: false),
                    TechFeaturesId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTechFeatures", x => new { x.TechFeaturesId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_ItemTechFeatures_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemTechFeatures_TechFeatures_TechFeaturesId",
                        column: x => x.TechFeaturesId,
                        principalTable: "TechFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_BodyTypeId",
                table: "Items",
                column: "BodyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ColorId",
                table: "Items",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_FuelTypeId",
                table: "Items",
                column: "FuelTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_RegionalSpecsId",
                table: "Items",
                column: "RegionalSpecsId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_TransmissionTypeId",
                table: "Items",
                column: "TransmissionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_WarrantyId",
                table: "Items",
                column: "WarrantyId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemBadges_ItemId",
                table: "ItemBadges",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemExtras_ItemId",
                table: "ItemExtras",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTechFeatures_ItemId",
                table: "ItemTechFeatures",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_BodyTypes_BodyTypeId",
                table: "Items",
                column: "BodyTypeId",
                principalTable: "BodyTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Colors_ColorId",
                table: "Items",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_FuelTypes_FuelTypeId",
                table: "Items",
                column: "FuelTypeId",
                principalTable: "FuelTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_RegionalSpecs_RegionalSpecsId",
                table: "Items",
                column: "RegionalSpecsId",
                principalTable: "RegionalSpecs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_TransmissionTypes_TransmissionTypeId",
                table: "Items",
                column: "TransmissionTypeId",
                principalTable: "TransmissionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Warranties_WarrantyId",
                table: "Items",
                column: "WarrantyId",
                principalTable: "Warranties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_BodyTypes_BodyTypeId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Colors_ColorId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_FuelTypes_FuelTypeId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_RegionalSpecs_RegionalSpecsId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_TransmissionTypes_TransmissionTypeId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Warranties_WarrantyId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "BodyTypes");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "FuelTypes");

            migrationBuilder.DropTable(
                name: "ItemBadges");

            migrationBuilder.DropTable(
                name: "ItemExtras");

            migrationBuilder.DropTable(
                name: "ItemTechFeatures");

            migrationBuilder.DropTable(
                name: "RegionalSpecs");

            migrationBuilder.DropTable(
                name: "SellerTypes");

            migrationBuilder.DropTable(
                name: "TransmissionTypes");

            migrationBuilder.DropTable(
                name: "Warranties");

            migrationBuilder.DropTable(
                name: "Badges");

            migrationBuilder.DropTable(
                name: "Extras");

            migrationBuilder.DropTable(
                name: "TechFeatures");

            migrationBuilder.DropIndex(
                name: "IX_Items_BodyTypeId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_ColorId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_FuelTypeId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_RegionalSpecsId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_TransmissionTypeId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_WarrantyId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "BodyTypeId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Cylinders",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Doors",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "FuelTypeId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "HorsePower",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemCreatedYear",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Odometer",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "RegionalSpecsId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "SteeringSide",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "TransmissionTypeId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "WarrantyId",
                table: "Items");
        }
    }
}
