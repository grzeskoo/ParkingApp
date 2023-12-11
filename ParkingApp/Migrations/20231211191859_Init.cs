using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingApp.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parking",
                columns: table => new
                {
                    idparkingu = table.Column<int>(name: "id_parkingu", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    liczbamiejsc = table.Column<int>(name: "liczba_miejsc", type: "int", nullable: false),
                    liczbapięter = table.Column<int>(name: "liczba_pięter", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parking", x => x.idparkingu);
                });

            migrationBuilder.CreateTable(
                name: "Uzytkownicy",
                columns: table => new
                {
                    iduzytkownika = table.Column<int>(name: "id_uzytkownika", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    haslo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nrtelefonu = table.Column<string>(name: "nr_telefonu", type: "nvarchar(max)", nullable: false),
                    adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    czygosc = table.Column<bool>(name: "czy_gosc", type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uzytkownicy", x => x.iduzytkownika);
                });

            migrationBuilder.CreateTable(
                name: "MiejsceParkingowe",
                columns: table => new
                {
                    idmiejsca = table.Column<int>(name: "id_miejsca", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idparkingu = table.Column<int>(name: "id_parkingu", type: "int", nullable: false),
                    stan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Parkingidparkingu = table.Column<int>(name: "Parkingid_parkingu", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiejsceParkingowe", x => x.idmiejsca);
                    table.ForeignKey(
                        name: "FK_MiejsceParkingowe_Parking_Parkingid_parkingu",
                        column: x => x.Parkingidparkingu,
                        principalTable: "Parking",
                        principalColumn: "id_parkingu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pojazd",
                columns: table => new
                {
                    idpojazdu = table.Column<int>(name: "id_pojazdu", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numerrejestracyjny = table.Column<string>(name: "numer_rejestracyjny", type: "nvarchar(max)", nullable: false),
                    marka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    waga = table.Column<int>(type: "int", nullable: false),
                    idużytkownika = table.Column<int>(name: "id_użytkownika", type: "int", nullable: false),
                    Uzytkownikiduzytkownika = table.Column<int>(name: "Uzytkownikid_uzytkownika", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pojazd", x => x.idpojazdu);
                    table.ForeignKey(
                        name: "FK_Pojazd_Uzytkownicy_Uzytkownikid_uzytkownika",
                        column: x => x.Uzytkownikiduzytkownika,
                        principalTable: "Uzytkownicy",
                        principalColumn: "id_uzytkownika",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Postoj",
                columns: table => new
                {
                    idpostoju = table.Column<int>(name: "id_postoju", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idmiejscaparkingowego = table.Column<int>(name: "id_miejsca_parkingowego", type: "int", nullable: false),
                    datazakonczenia = table.Column<DateTime>(name: "data_zakonczenia", type: "datetime2", nullable: false),
                    datarozpoczecia = table.Column<DateTime>(name: "data_rozpoczecia", type: "datetime2", nullable: false),
                    iduzytkownika = table.Column<int>(name: "id_uzytkownika", type: "int", nullable: false),
                    Uzytkownikiduzytkownika = table.Column<int>(name: "Uzytkownikid_uzytkownika", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postoj", x => x.idpostoju);
                    table.ForeignKey(
                        name: "FK_Postoj_Uzytkownicy_Uzytkownikid_uzytkownika",
                        column: x => x.Uzytkownikiduzytkownika,
                        principalTable: "Uzytkownicy",
                        principalColumn: "id_uzytkownika",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rezerwacja",
                columns: table => new
                {
                    idrezerwacji = table.Column<int>(name: "id_rezerwacji", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idpojazdu = table.Column<int>(name: "id_pojazdu", type: "int", nullable: false),
                    idmiejsca = table.Column<int>(name: "id_miejsca", type: "int", nullable: false),
                    datarozpoczęcia = table.Column<DateTime>(name: "data_rozpoczęcia", type: "datetime2", nullable: false),
                    datazakończenia = table.Column<DateTime>(name: "data_zakończenia", type: "datetime2", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    iduzytkownika = table.Column<int>(name: "id_uzytkownika", type: "int", nullable: false),
                    Uzytkownikiduzytkownika = table.Column<int>(name: "Uzytkownikid_uzytkownika", type: "int", nullable: false),
                    MiejsceParkingoweidmiejsca = table.Column<int>(name: "MiejsceParkingoweid_miejsca", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezerwacja", x => x.idrezerwacji);
                    table.ForeignKey(
                        name: "FK_Rezerwacja_MiejsceParkingowe_MiejsceParkingoweid_miejsca",
                        column: x => x.MiejsceParkingoweidmiejsca,
                        principalTable: "MiejsceParkingowe",
                        principalColumn: "id_miejsca",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rezerwacja_Uzytkownicy_Uzytkownikid_uzytkownika",
                        column: x => x.Uzytkownikiduzytkownika,
                        principalTable: "Uzytkownicy",
                        principalColumn: "id_uzytkownika",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MiejsceParkingowe_Parkingid_parkingu",
                table: "MiejsceParkingowe",
                column: "Parkingid_parkingu");

            migrationBuilder.CreateIndex(
                name: "IX_Pojazd_Uzytkownikid_uzytkownika",
                table: "Pojazd",
                column: "Uzytkownikid_uzytkownika");

            migrationBuilder.CreateIndex(
                name: "IX_Postoj_Uzytkownikid_uzytkownika",
                table: "Postoj",
                column: "Uzytkownikid_uzytkownika");

            migrationBuilder.CreateIndex(
                name: "IX_Rezerwacja_MiejsceParkingoweid_miejsca",
                table: "Rezerwacja",
                column: "MiejsceParkingoweid_miejsca");

            migrationBuilder.CreateIndex(
                name: "IX_Rezerwacja_Uzytkownikid_uzytkownika",
                table: "Rezerwacja",
                column: "Uzytkownikid_uzytkownika");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pojazd");

            migrationBuilder.DropTable(
                name: "Postoj");

            migrationBuilder.DropTable(
                name: "Rezerwacja");

            migrationBuilder.DropTable(
                name: "MiejsceParkingowe");

            migrationBuilder.DropTable(
                name: "Uzytkownicy");

            migrationBuilder.DropTable(
                name: "Parking");
        }
    }
}
