using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Praksa.Models;
using DataLibrary;
using DataLibrary.Worker;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Praksa.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            int a = UgovorWorker.LoadAktivni();
            int n = UgovorWorker.LoadNeaktivni();
            Aktivni akt = new Aktivni { aktivni = a, neaktivni=n };

            var data = UgovorWorker.LoadFiveUgovor();
            List<UgovorIspis> ugovori = new List<UgovorIspis>();
            foreach (var row in data) ugovori.Add(new UgovorIspis { Id = row.Id, KIme = row.KIme, Trajanje = row.Trajanje, Kreirano=row.Kreirano });

            var data1 = PaketWorker.LoadAllPaket();

            var data2 = UgovorWorker.LoadUgovor();
            List<Prihod> prihodi= new List<Prihod>();
            foreach (var row in data2)
            {
                if (row.Stat == 0) continue;
                if (row.Net == null) row.Net = -1;
                if (row.Iptv == null) row.Iptv = -1;
                if (row.Voip == null) row.Voip = -1;
                int pr = 0;
                foreach (DataLibrary.Models.Paket p in data1)
                {
                    if (row.Net == p.Id || row.Iptv == p.Id || row.Voip == p.Id) pr += p.Cena;
                }
                pr = pr * (row.Trajanje - row.Gratis);
                pr = pr * (100 - row.Popust);
                prihodi.Add(new Prihod { id = ""+row.Id, prihod=pr/100});
            }
            Prihod suma = new Prihod { id = "Suma", prihod = 0 };
            foreach (Prihod item in prihodi)
            {
                suma.prihod += item.prihod;
            }
            prihodi.Add(suma);
            ViewData["Prihodi"] = prihodi;
            ViewData["UgovoriFive"] = ugovori;
            ViewData["Aktivni"] = akt;
            return View();
        }

        public IActionResult Paket()
        {
            var data = PaketWorker.LoadPaket();
            List<Paket> paketi = new List<Paket>();
            foreach (var row in data) paketi.Add(new Paket { id = row.Id, Naziv = row.Naziv, Opis = row.Opis, Cena = row.Cena, Kategorija = row.Kategorija });
            ViewData["Paketi"] = paketi;
            return View();
        }
        
        [HttpPost]
        public IActionResult Paket(Paket p)
        {
            if(ModelState.IsValid)
            {
                PaketWorker.CreatePaket(p.Naziv, p.Opis, p.Cena, p.Kategorija, 0);
            }
            var data = PaketWorker.LoadPaket();
            List<Paket> paketi = new List<Paket>();
            foreach (var row in data) paketi.Add(new Paket { id = row.Id, Naziv = row.Naziv, Opis = row.Opis, Cena = row.Cena, Kategorija = row.Kategorija });
            ViewData["Paketi"] = paketi;
            return View();
        }

        public IActionResult PaketBrisanje(int id)
        {
            PaketWorker.DeletePaket(id);
            return RedirectToAction("Paket");
        }

        public IActionResult PaketEdit(int id)
        {
            ViewData["Message"] = "Paket "+id;
            var data = PaketWorker.LoadPaket();
            List<Paket> paketi = new List<Paket>();
            Paket edit=null;
            foreach (var row in data)
            {
                paketi.Add(new Paket { id = row.Id, Naziv = row.Naziv, Opis = row.Opis, Cena = row.Cena, Kategorija = row.Kategorija });
                if (row.Id == id)
                {
                    edit=new Paket { id = row.Id, Naziv = row.Naziv, Opis = row.Opis, Cena = row.Cena, Kategorija = row.Kategorija };
                }
            }
            ViewData["Paketi"] = paketi;
            return View(edit);
        }


        [HttpPost]
        public IActionResult PaketEdit(Paket p)
        {

            PaketWorker.UpdatePaket(p.id,p.Naziv, p.Opis, p.Cena, p.Kategorija, 0);
            return RedirectToAction("Paket");
        }

        public IActionResult UgovorBrisanje(int id)
        {
            UgovorWorker.DeleteUgovor(id);
            return RedirectToAction("Index");
        }
        
        public IActionResult Ugovor()
        {
            ViewData["Message"] = "";
            var data = PaketWorker.LoadPaket();
            List<Paket> net = new List<Paket>();
            net.Add(new Paket() { id = -1, Naziv = "Nijedan" });
            List<Paket> iptv = new List<Paket>();
            iptv.Add(new Paket() { id = -1, Naziv = "Nijedan" });
            List<Paket> voip = new List<Paket>();
            voip.Add(new Paket() { id = -1, Naziv = "Nijedan" });

            foreach (var row in data)
            {
                if(row.Kategorija==1) net.Add(new Paket { id = row.Id, Naziv = row.Naziv, Opis = row.Opis, Cena = row.Cena, Kategorija = row.Kategorija });
                else if (row.Kategorija == 2) iptv.Add(new Paket { id = row.Id, Naziv = row.Naziv, Opis = row.Opis, Cena = row.Cena, Kategorija = row.Kategorija });
                else voip.Add(new Paket { id = row.Id, Naziv = row.Naziv, Opis = row.Opis, Cena = row.Cena, Kategorija = row.Kategorija });
            }
            
            ViewData["Net"] = new SelectList(net, "id", "Naziv");
            ViewData["Iptv"] = new SelectList(iptv, "id", "Naziv");
            ViewData["Voip"] = new SelectList(voip, "id", "Naziv");
            return View();
        }

        [HttpPost]
        public IActionResult Ugovor(Ugovor u)
        {
            ViewData["Message"] = "";
            var data = PaketWorker.LoadPaket();
            List<Paket> net = new List<Paket>();
            net.Add(new Paket() { id = -1, Naziv = "Nijedan" });
            List<Paket> iptv = new List<Paket>();
            iptv.Add(new Paket() { id = -1, Naziv = "Nijedan" });
            List<Paket> voip = new List<Paket>();
            voip.Add(new Paket() { id = -1, Naziv = "Nijedan" });

            foreach (var row in data)
            {
                if (row.Kategorija == 1) net.Add(new Paket { id = row.Id, Naziv = row.Naziv, Opis = row.Opis, Cena = row.Cena, Kategorija = row.Kategorija });
                else if (row.Kategorija == 2) iptv.Add(new Paket { id = row.Id, Naziv = row.Naziv, Opis = row.Opis, Cena = row.Cena, Kategorija = row.Kategorija });
                else voip.Add(new Paket { id = row.Id, Naziv = row.Naziv, Opis = row.Opis, Cena = row.Cena, Kategorija = row.Kategorija });
            }

            ViewData["Net"] = new SelectList(net, "id", "Naziv");
            ViewData["Iptv"] = new SelectList(iptv, "id", "Naziv");
            ViewData["Voip"] = new SelectList(voip, "id", "Naziv");
            if (ModelState.IsValid)
            {
                if (u.Net == -1 && u.Iptv == -1 && u.Voip == -1)
                {
                    ViewData["Message"] = "Morate izabrati barem jedan paket";
                    return View();
                }
                if (UgovorWorker.LoadAktivniKIme(u.KIme) == 1)
                {
                    ViewData["Message"] = "Ovaj korisnik vec ima aktivan ugovor.";
                    return View();
                }
                UgovorWorker.CreateUgovor(u.KIme, u.Trajanje, u.Popust, u.Gratis, 1, u.Net, u.Iptv, u.Voip);
            }
            return RedirectToAction("Index");
        }

        public IActionResult UgovorEdit(int id)
        {
            ViewData["Message"] = "";
            var data1 = PaketWorker.LoadPaket();
            List<Paket> net = new List<Paket>();
            net.Add(new Paket() { id = -1, Naziv = "Nijedan" });
            List<Paket> iptv = new List<Paket>();
            iptv.Add(new Paket() { id = -1, Naziv = "Nijedan" });
            List<Paket> voip = new List<Paket>();
            voip.Add(new Paket() { id = -1, Naziv = "Nijedan" });

            foreach (var row in data1)
            {
                if (row.Kategorija == 1) net.Add(new Paket { id = row.Id, Naziv = row.Naziv, Opis = row.Opis, Cena = row.Cena, Kategorija = row.Kategorija });
                else if (row.Kategorija == 2) iptv.Add(new Paket { id = row.Id, Naziv = row.Naziv, Opis = row.Opis, Cena = row.Cena, Kategorija = row.Kategorija });
                else voip.Add(new Paket { id = row.Id, Naziv = row.Naziv, Opis = row.Opis, Cena = row.Cena, Kategorija = row.Kategorija });
            }
            var data = UgovorWorker.LoadUgovor();
            List<Ugovor> ugovori = new List<Ugovor>();
            Ugovor edit = null;
            foreach (var row in data)
            {
                if (row.Id == id)
                {
                    edit = new Ugovor() { Id=row.Id, Gratis=row.Gratis, Iptv=row.Iptv, KIme=row.KIme, Net=row.Net,
                        Popust =row.Popust, Stat=row.Stat, Trajanje=row.Trajanje, Voip=row.Voip };
                }
            }

            SelectList n = new SelectList(net, "id", "Naziv");
            foreach (var item in n)
            {
                if (item.Value == ""+edit.Net) { item.Selected = true; break; }
            }
            ViewData["Net"] = n;

            SelectList i = new SelectList(iptv, "id", "Naziv");
            foreach (var item in i)
            {
                if (item.Value == "" + edit.Iptv) { item.Selected = true; break; }
            }
            ViewData["Iptv"] = i;

            SelectList v = new SelectList(voip, "id", "Naziv");
            foreach (var item in v)
            {
                if (item.Value == "" + edit.Voip) { item.Selected = true; break; }
            }
            ViewData["Voip"] = v;
            var data2 = UgovorWorker.LoadIzmene(id);
            List<Izmena> izmene = new List<Izmena>();
            foreach (var row in data2)
            {
                izmene.Add(new Izmena() { Id = row.Id, Datum = row.Datum, Stat = (row.Stat==1)?"Da":"Ne", IdUgovor = row.IdUgovor, Suma = row.Suma });
            }
            ViewData["Izmene"] = izmene;
            return View(edit);
        }

        [HttpPost]
        public IActionResult UgovorEdit(Ugovor u)
        {
            ViewData["Message"] = "";
            var data1 = PaketWorker.LoadPaket();
            List<Paket> net = new List<Paket>();
            net.Add(new Paket() { id = -1, Naziv = "Nijedan" });
            List<Paket> iptv = new List<Paket>();
            iptv.Add(new Paket() { id = -1, Naziv = "Nijedan" });
            List<Paket> voip = new List<Paket>();
            voip.Add(new Paket() { id = -1, Naziv = "Nijedan" });

            foreach (var row in data1)
            {
                if (row.Kategorija == 1) net.Add(new Paket { id = row.Id, Naziv = row.Naziv, Opis = row.Opis, Cena = row.Cena, Kategorija = row.Kategorija });
                else if (row.Kategorija == 2) iptv.Add(new Paket { id = row.Id, Naziv = row.Naziv, Opis = row.Opis, Cena = row.Cena, Kategorija = row.Kategorija });
                else voip.Add(new Paket { id = row.Id, Naziv = row.Naziv, Opis = row.Opis, Cena = row.Cena, Kategorija = row.Kategorija });
            }
            var data = UgovorWorker.LoadUgovor();
            List<Ugovor> ugovori = new List<Ugovor>();
            Ugovor edit = null;
            foreach (var row in data)
            {
                if (row.Id == u.Id)
                {
                    edit = new Ugovor()
                    {
                        Id = row.Id, Gratis = row.Gratis, Iptv = row.Iptv,
                        KIme = row.KIme, Net = row.Net, Popust = row.Popust,
                        Stat = row.Stat, Trajanje = row.Trajanje, Voip = row.Voip
                    };
                }
            }

            SelectList n = new SelectList(net, "id", "Naziv");
            foreach (var item in n)
            {
                if (item.Value == "" + edit.Net) { item.Selected = true; break; }
            }
            ViewData["Net"] = n;

            SelectList i = new SelectList(iptv, "id", "Naziv");
            foreach (var item in i)
            {
                if (item.Value == "" + edit.Iptv) { item.Selected = true; break; }
            }
            ViewData["Iptv"] = i;

            SelectList v = new SelectList(voip, "id", "Naziv");
            foreach (var item in v)
            {
                if (item.Value == "" + edit.Voip) { item.Selected = true; break; }
            }
            ViewData["Voip"] = v;
            var data2 = UgovorWorker.LoadIzmene(u.Id);
            List<Izmena> izmene = new List<Izmena>();
            foreach (var row in data2)
            {
                izmene.Add(new Izmena() { Id = row.Id, Datum = row.Datum, Stat = (row.Stat == 1) ? "Da" : "Ne", IdUgovor = row.IdUgovor, Suma = row.Suma });
            }
            ViewData["Izmene"] = izmene;

            if (u.Net == -1 && u.Iptv == -1 && u.Voip == -1)
            {
                ViewData["Message"] = "Morate izabrati barem jedan paket";
                return View();
            }
            if (UgovorWorker.LoadAktivniKIme(u.KIme) == 1 && u.Stat==1)
            {
                ViewData["Message"] = "Ovaj korisnik vec ima aktivan ugovor.";
                return View();
            }

            UgovorWorker.UpdateUgovor(u.Id, u.KIme, u.Trajanje, u.Popust, u.Gratis, u.Stat, u.Net, u.Iptv, u.Voip);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
