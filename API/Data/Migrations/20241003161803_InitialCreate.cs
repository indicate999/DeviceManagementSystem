using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
	/// <inheritdoc />
	public partial class InitialCreate : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Devices",
				columns: table => new
				{
					Id = table.Column<int>(type: "INTEGER", nullable: false)
						.Annotation("Sqlite:Autoincrement", true),
					Brand = table.Column<string>(type: "TEXT", nullable: true),
					Manufacturer = table.Column<string>(type: "TEXT", nullable: true),
					ModelName = table.Column<string>(type: "TEXT", nullable: true),
					OperatingSystem = table.Column<string>(type: "TEXT", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Devices", x => x.Id);
				});

			migrationBuilder.InsertData(
				table: "Devices",
				columns: new[] { "Id", "Brand", "Manufacturer", "ModelName", "OperatingSystem" },
				values: new object[,]
				{
				{ 1, "Apple", "Apple Inc.", "iPhone 13", "iOS" },
				{ 2, "Samsung", "Samsung Electronics", "Galaxy S21", "Android" },
				{ 3, "Google", "Google LLC", "Pixel 6", "Android" },
				{ 4, "OnePlus", "OnePlus Technology", "OnePlus 9 Pro", "Android" },
				{ 5, "Xiaomi", "Xiaomi Corporation", "Mi 11", "Android" },
				{ 6, "Sony", "Sony Corporation", "Xperia 1 III", "Android" },
				{ 7, "Microsoft", "Microsoft", "Surface Duo 2", "Android" },
				{ 8, "Huawei", "Huawei Technologies", "P40 Pro", "Android" },
				{ 9, "Nokia", "HMD Global", "Nokia 8.3 5G", "Android" },
				{ 10, "LG", "LG Electronics", "Wing 5G", "Android" }
				});
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Devices");
		}
	}
}
