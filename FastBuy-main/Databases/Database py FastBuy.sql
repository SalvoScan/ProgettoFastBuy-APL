CREATE DATABASE db_python;
USE db_python;

CREATE TABLE info_ordini (
    user VARCHAR(20),
    cod_ordine INT,
    cod_prodotto VARCHAR(10),
    categoria VARCHAR(20),
    nome VARCHAR(20),
    prezzo FLOAT,
    quantita INT,
    prezzo_finale FLOAT,
    CONSTRAINT PRIMARY KEY (user, cod_ordine, cod_prodotto));

CREATE TABLE tracciamento_ordini (
    user VARCHAR(20),
    cod_ordine INT,
    pt1 VARCHAR(5),
    pt2 VARCHAR(5),
    pt3 VARCHAR(5),
    pt4 VARCHAR(5),
    pt5 VARCHAR(5),
    CONSTRAINT PRIMARY KEY (user, cod_ordine));