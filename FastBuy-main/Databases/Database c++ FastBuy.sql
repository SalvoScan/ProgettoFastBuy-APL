CREATE DATABASE db_cpp;
USE db_cpp;

CREATE TABLE utenti (
    username VARCHAR(20) PRIMARY KEY,
    pass VARCHAR(20) NOT NULL,
    nome VARCHAR(20),
    cognome VARCHAR(20),
    flag BOOLEAN,
    email VARCHAR(25));

INSERT INTO utenti (username, pass, nome, cognome, flag, email) VALUES ("Rosario97", "root", "Rosario", "Saglimbene", 1, "rosario_s97@live.it");
INSERT INTO utenti (username, pass, nome, cognome, flag, email) VALUES ("Salvo", "root", "Salvo", "Scandura", 0, "salvoscandura@gmail.com");
INSERT INTO utenti (username, pass, nome, cognome, flag, email) VALUES ("Mario27", "root", "Mario", "Rossi", 0, "mariorossi@hotmail.it");

CREATE TABLE prodotti (
    cod VARCHAR(10) PRIMARY KEY,
    categoria VARCHAR(20),
    nome VARCHAR(20),
    prezzo FLOAT,
    quantita INT);

INSERT INTO prodotti (cod, categoria, nome, prezzo, quantita) VALUES ("gfsdjhfgsj", "sport", "bicicletta", 70.00, 34);
INSERT INTO prodotti (cod, categoria, nome, prezzo, quantita) VALUES ("ljdshfknhg", "sport", "canna da pesca", 90.00, 22);
INSERT INTO prodotti (cod, categoria, nome, prezzo, quantita) VALUES ("ushnggvnnh", "sport", "racchetta", 50.00, 53);
INSERT INTO prodotti (cod, categoria, nome, prezzo, quantita) VALUES ("34y8wynsnh", "sport", "tavola da surf", 69.00, 26);
INSERT INTO prodotti (cod, categoria, nome, prezzo, quantita) VALUES ("nhsejgsvng", "elettronica", "cuffie", 30.50, 50);
INSERT INTO prodotti (cod, categoria, nome, prezzo, quantita) VALUES ("hihqndsknn", "elettronica", "tablet", 170.00, 38);
INSERT INTO prodotti (cod, categoria, nome, prezzo, quantita) VALUES ("ahnhshgdnh", "elettronica", "smart tv", 270.00, 39);
INSERT INTO prodotti (cod, categoria, nome, prezzo, quantita) VALUES ("aiohihngvj", "elettrodomestici", "lavatrice", 250.00, 95);
INSERT INTO prodotti (cod, categoria, nome, prezzo, quantita) VALUES ("ajvhgtnhhh", "elettrodomestici", "forno microonde", 110.00, 41);
INSERT INTO prodotti (cod, categoria, nome, prezzo, quantita) VALUES ("qsdnflenjh", "domotica", "robot aspirapolvere", 250.00, 23);
INSERT INTO prodotti (cod, categoria, nome, prezzo, quantita) VALUES ("3iykwybsnf", "giardinaggio", "motosega", 169.00, 26);
INSERT INTO prodotti (cod, categoria, nome, prezzo, quantita) VALUES ("ysjnmgdnah", "giardinaggio", "cesoie", 30.00, 40);
INSERT INTO prodotti (cod, categoria, nome, prezzo, quantita) VALUES ("v4m8oybsna", "giardinaggio", "soffia foglie", 19.00, 25);
INSERT INTO prodotti (cod, categoria, nome, prezzo, quantita) VALUES ("q1mdpqucga", "scarpe", "nike", 69.00, 15);