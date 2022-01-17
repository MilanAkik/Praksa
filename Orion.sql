--DROP DATABASE IF EXISTS Ugovori_Orion;
CREATE DATABASE Ugovori_Orion;
GO

USE Ugovori_Orion;

--Kategorije:
--NET = 0
--IPTV = 1
--VOICE = 2
CREATE TABLE Paket
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Naziv VARCHAR(128) NOT NULL,
	Opis TEXT NOT NULL,
	Cena INT NOT NULL,
	Kategorija INT NOT NULL,
	Uklonjen INT NOT NULL
);

CREATE TABLE Ugovor
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	KIme VARCHAR(128) NOT NULL,
	Trajanje INT NOT NULL,
	Popust INT NOT NULL,
	Gratis INT NOT NULL,
	Stat INT NOT NULL,
	Kreirano DATETIME NOT NULL,
	Net INT NULL,
	Iptv INT NULL,
	Voip INT NULL,
	FOREIGN KEY (Net) REFERENCES Paket(Id),
	FOREIGN KEY (Iptv) REFERENCES Paket(Id),
	FOREIGN KEY (Voip) REFERENCES Paket(Id)
);

CREATE TABLE Izmena
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Datum DATETIME NOT NULL,
	Stat INT NOT NULL,
	Suma INT NOT NULL,
	IdUgovor INT NOT NULL FOREIGN KEY REFERENCES Ugovor(Id)
);
GO

--INSERT INTO Paket(Id, Naziv, Opis, Cena, Kategorija, Uklonjen) VALUES
--(1,'NET 1' ,'0.5Gb/s'   ,1550,0,0),
--(2,'NET 2' ,'1Gb/s'     ,1750,0,0),
--(3,'NET 3' ,'2.5Gb/s'   ,3000,0,0),
--(4,'IPTV 1','150 kanala',1000,1,0),
--(5,'IPTV 2','160 kanala',1250,1,0),
--(6,'IPTV 3','190 kanala',1500,1,0),
--(7,'VOIP 1','150 minuta',750 ,2,0),
--(8,'VOIP 2','300 minuta',1300,2,0),
--(9,'VOIP 3','500 minuta',1700,2,0);

--INSERT INTO Ugovor(Id, KIme, Trajanje, Popust, Gratis, Stat, Kreirano, Net, Iptv, Voip) VALUES
--(1,'marko' ,12,5 ,4,1,'2021-08-22 06:07:39',1   ,4   ,9   ),
--(2,'anica' ,24,15,1,1,'2021-08-28 21:37:52',3   ,5   ,NULL),
--(3,'pera'  ,24,10,2,1,'2021-07-25 11:33:48',1   ,5   ,8   ),
--(4,'marija',12,0 ,3,1,'2021-03-21 22:32:46',1   ,NULL,7   ),
--(5,'mika'  ,12,8 ,5,1,'2021-08-08 17:56:56',2   ,6   ,9   ),
--(6,'jovana',12,12,4,1,'2021-07-17 02:01:09',NULL,4   ,8   ),
--(7,'zika'  ,24,3 ,6,1,'2021-08-16 00:43:00',1   ,5   ,7   ),
--(8,'andrea',24,25,3,1,'2021-12-03 03:43:34',3   ,NULL,NULL),
--(9,'vanja' ,12,20,2,1,'2021-07-08 12:47:50',2   ,4   ,9   );

--INSERT INTO Izmena(Id, Datum, Stat, Suma, IdUgovor) VALUES
--(1 ,'2021-08-22 06:07:39',1,4250,1),
--(2 ,'2021-08-28 21:37:52',1,4250,2),
--(3 ,'2021-07-25 11:33:48',1,4100,3),
--(4 ,'2021-03-21 22:32:46',1,2300,4),
--(5 ,'2021-08-08 17:56:56',1,4950,5),
--(6 ,'2021-07-17 02:01:09',1,2300,6),
--(7 ,'2021-08-16 00:43:00',1,3550,7),
--(8 ,'2021-12-03 03:43:34',1,3000,8),
--(9 ,'2021-07-08 12:47:50',1,4450,9),
--(10,'2021-12-15 08:00:58',0,4250,1);