using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace iQurban.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hewans",
                columns: table => new
                {
                    HewanID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Jenis_Hewan = table.Column<string>(nullable: true),
                    Grade = table.Column<string>(nullable: true),
                    Berat = table.Column<decimal>(nullable: false),
                    Harga = table.Column<decimal>(nullable: false),
                    Additional_Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hewans", x => x.HewanID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HewanID = table.Column<int>(nullable: false),
                    Order_Number = table.Column<int>(nullable: false),
                    Tanggal_Order = table.Column<DateTime>(nullable: false),
                    Jumlah = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    Keterangan = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                });

            migrationBuilder.CreateTable(
                name: "Peoples",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Kartu_Keluarga = table.Column<string>(nullable: true),
                    NIK = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Tanggal_Lahir = table.Column<DateTime>(nullable: false),
                    Tempat_Lahir = table.Column<string>(nullable: true),
                    Alamat = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Handphone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peoples", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    USERID = table.Column<string>(nullable: false),
                    PASSWORD = table.Column<string>(nullable: true),
                    FIRST_NAME = table.Column<string>(nullable: true),
                    LAST_NAME = table.Column<string>(nullable: true),
                    EMAILID = table.Column<string>(nullable: true),
                    PHONE = table.Column<string>(nullable: true),
                    ACCESS_LEVEL = table.Column<string>(nullable: true),
                    READ_ONLY = table.Column<string>(nullable: true),
                    WRITE_ACCESS = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.USERID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hewans");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Peoples");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
