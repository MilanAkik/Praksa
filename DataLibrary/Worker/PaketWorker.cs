using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Worker
{
    public static class PaketWorker
    {

        public static int CreatePaket(String naziv, string opis, int cena, int kategorija, int uklonjen)
        {
            Paket p = new Paket
            {
                Id = 0,
                Naziv = naziv,
                Opis = opis,
                Cena = cena,
                Kategorija = kategorija,
                Uklonjen = uklonjen
            };
            string sql = @"INSERT INTO Paket(Naziv, Opis, Cena, Kategorija, Uklonjen) 
                            VALUES (@Naziv, @Opis, @Cena, @Kategorija, @Uklonjen);";
            return SQLDataAccess.SaveData(sql, p);
        }

        public static List<Paket> LoadPaket()
        {
            String sql = @"SELECT Id, Naziv, Opis, Cena, Kategorija, Uklonjen FROM Paket WHERE Uklonjen=0;";
            return SQLDataAccess.LoadData<Paket>(sql);
        }

        public static List<Paket> LoadAllPaket()
        {
            String sql = @"SELECT Id, Naziv, Opis, Cena, Kategorija, Uklonjen FROM Paket;";
            return SQLDataAccess.LoadData<Paket>(sql);
        }

        public static void DeletePaket(int Id)
        {
            //String sql = @"DELETE FROM Paket WHERE Id="+Id+";";
            String sql = @"UPDATE Paket SET Uklonjen=1 WHERE Id=" + Id + ";";
            SQLDataAccess.DaleteData(sql);
        }

        public static void UpdatePaket(int Id, String naziv, string opis, int cena, int kategorija, int uklonjen)
        {
            Paket p = new Paket
            {
                Id = 0,
                Naziv = naziv,
                Opis = opis,
                Cena = cena,
                Kategorija = kategorija,
                Uklonjen = uklonjen
            };
            String sql = @"UPDATE Paket SET Naziv=@Naziv, Opis=@Opis, Cena=@Cena, Kategorija=@Kategorija WHERE Id=" + Id + ";";
            SQLDataAccess.UpdateData(sql,p);
        }
    }
}
