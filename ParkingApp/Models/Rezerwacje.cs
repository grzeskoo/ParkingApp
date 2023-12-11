﻿namespace ParkingApp.Models
{
    public class Rezerwacje
    {
        public int id_rezerwacji { get; set; }
        public int id_pojazdu { get; set; }
        public int id_miejsca  { get; set; }
        public DateTime data_rozpoczęcia { get; set; }
        public DateTime data_zakończenia { get; set; }
        public string status { get; set; } = "";
        public int id_uzytkownika { get; set; }

        public Uzytkownicy Uzytkownik { get; set; } = new();
        public MiejscaParkingowe MiejsceParkingowe  { get; set; } = new();
    }
}
    