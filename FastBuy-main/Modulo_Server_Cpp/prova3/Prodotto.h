#pragma once

#include <iostream>
#include <string.h>
#include <string>
#include <ostream>

using namespace std;

class Prodotto
{
private:
	string cod;
	string categoria;
	string nome;
	float prezzo;
	int quantita;

public:
	Prodotto(string cod, string categoria, string nome, float prezzo, int quantita);
	string getCod();
	string getCategoria();
	string getNome();
	float getPrezzo();
	int getQuantita();
	friend ostream& operator << (ostream& os, const Prodotto& p);
};
