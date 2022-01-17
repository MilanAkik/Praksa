--USE Posiljke

--DROP DATABASE IF EXISTS Ugovori_Orion;
--CREATE DATABASE Ugovori_Orion;
--GO

--USE Ugovori_Orion;

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