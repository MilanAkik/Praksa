using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Worker
{
    public static class UgovorWorker
    {
        public static int LoadAktivni()
        {
            String sql = @"SELECT COUNT(*) FROM Ugovor WHERE Stat=1;";
            return SQLDataAccess.LoadInt(sql);
        }

        public static int LoadNeaktivni()
        {
            String sql = @"SELECT COUNT(*) FROM Ugovor WHERE Stat=0;";
            return SQLDataAccess.LoadInt(sql);
        }
        
        public static int LoadAktivniKIme(String KIme)
        {
            String sql = @"SELECT COUNT(*) FROM Ugovor WHERE Stat=1 AND KIme='"+KIme+"';";
            return SQLDataAccess.LoadInt(sql);
        }

        public static List<Ugovor> LoadUgovor()
        {
            String sql = @"SELECT Id, KIme, Trajanje, Popust, Gratis, Stat, Kreirano, Net, Iptv, Voip FROM Ugovor ORDER BY Id ASC;";
            return SQLDataAccess.LoadData<Ugovor>(sql);
        }

        public static List<Ugovor> LoadFiveUgovor()
        {
            String sql = @"SELECT Id, KIme, Trajanje, Popust, Gratis, Stat, Kreirano, Net, Iptv, Voip FROM Ugovor ORDER BY Kreirano DESC;";
            List<Ugovor> src = SQLDataAccess.LoadData<Ugovor>(sql);
            List<Ugovor> res = new List<Ugovor>();
            int lim = 0;
            foreach (Ugovor u in src)
            {
                res.Add(u);
                if (++lim == 5) break;
            }
            return res;
        }

        public static void DeleteUgovor(int Id)
        {
            String sql = @"DELETE FROM Izmena WHERE IdUgovor=" + Id + ";";
            SQLDataAccess.DaleteData(sql);
            sql = @"DELETE FROM Ugovor WHERE Id=" + Id + ";";
            SQLDataAccess.DaleteData(sql);
        }
        
        public static List<Izmena> LoadIzmene(int Id)
        {
            String sql = @"SELECT Id, Datum, Stat, Suma, IdUgovor FROM Izmena WHERE IdUgovor="+Id+" ORDER BY Datum ASC;";
            return SQLDataAccess.LoadData<Izmena>(sql);
        }

        public static void CreateUgovor(String kIme, int trajanje, int popust, int gratis, int stat, int? net, int?iptv, int? voip)
        {
            Ugovor u = new Ugovor()
            {
                Id = 0,
                KIme = kIme,
                Trajanje = trajanje,
                Popust = popust,
                Gratis = gratis,
                Stat = stat,
                Kreirano = DateTime.Now,
                Net = (net==-1)?null:net,
                Iptv = (iptv == -1) ? null : iptv,
                Voip = (voip == -1) ? null : voip
            };
            string sql = @"INSERT INTO Ugovor(KIme, Trajanje, Popust, Gratis, Stat, Kreirano, Net, Iptv, Voip) VALUES (@KIme, @Trajanje, @Popust, @Gratis, @Stat, @Kreirano, @Net, @Iptv, @Voip);";
            SQLDataAccess.SaveData(sql, u);

            //-----------------------------------------------

            sql = @"SELECT Id, KIme, Trajanje, Popust, Gratis, Stat, Kreirano, Net, Iptv, Voip FROM Ugovor ORDER BY Kreirano ASC;";
            Ugovor last = SQLDataAccess.LoadLast<Ugovor>(sql);

            var data1 = PaketWorker.LoadAllPaket();

            //-----------------------------------------------

            if (net == null) net = -1;
            if (iptv == null) iptv = -1;
            if (voip == null) voip = -1;
            int pr = 0;
            foreach (DataLibrary.Models.Paket p in data1)
            {
                if (net == p.Id || iptv == p.Id || voip == p.Id) pr += p.Cena;
            }
            pr = pr * (trajanje - gratis);
            pr = pr * (100 - popust);
            pr = pr / 100;

            //-----------------------------------------------

            Izmena i = new Izmena()
            {
                Id = 0,
                Datum = u.Kreirano,
                Stat = stat,
                Suma = pr,
                IdUgovor = last.Id
            };
            sql = @"INSERT INTO Izmena(Datum, Stat, Suma, IdUgovor) VALUES (@Datum, @Stat, @Suma, @IdUgovor);";
            SQLDataAccess.SaveData(sql, i);
        }

        public static void UpdateUgovor(int id, String kIme, int trajanje, int popust, int gratis, int stat, int? net, int? iptv, int? voip)
        {
            Ugovor u = new Ugovor()
            {
                Id = id,
                KIme = kIme,
                Trajanje = trajanje,
                Popust = popust,
                Gratis = gratis,
                Stat = stat,
                Kreirano = DateTime.Now,
                Net = (net == -1) ? null : net,
                Iptv = (iptv == -1) ? null : iptv,
                Voip = (voip == -1) ? null : voip
            };
            String sql = @"UPDATE Ugovor SET KIme=@KIme, Trajanje=@Trajanje, Popust=@Popust, Gratis=@Gratis,
                            Stat=@Stat, Iptv=@Iptv, Net=@Net, Voip=@Voip WHERE Id=" + u.Id + ";";
            SQLDataAccess.UpdateData(sql, u);


            var data1 = PaketWorker.LoadAllPaket();

            if (net == null) net = -1;
            if (iptv == null) iptv = -1;
            if (voip == null) voip = -1;
            int pr = 0;
            foreach (DataLibrary.Models.Paket p in data1)
            {
                if (net == p.Id || iptv == p.Id || voip == p.Id) pr += p.Cena;
            }
            pr = pr * (trajanje - gratis);
            pr = pr * (100 - popust);
            pr = pr / 100;

            //-----------------------------------------------

            Izmena i = new Izmena()
            {
                Id = 0,
                Datum = u.Kreirano,
                Stat = stat,
                Suma = pr,
                IdUgovor = u.Id
            };
            sql = @"INSERT INTO Izmena(Datum, Stat, Suma, IdUgovor) VALUES (@Datum, @Stat, @Suma, @IdUgovor);";
            SQLDataAccess.SaveData(sql, i);

        }

    }
}
