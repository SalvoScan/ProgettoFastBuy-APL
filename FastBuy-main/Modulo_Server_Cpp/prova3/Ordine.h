#include <iostream>
#include <string.h>
#include <string>
#include <ostream>
#include "Prodotto.h"
#include <list>

using namespace std;

class Ordine
{
private:
	string user;
	int cod_ordine;
	list<Prodotto> lista_prodotti;
	float prezzo_finale;

public:
	Ordine(string user, int cod_ordine, list<Prodotto> lista_prodotti, float prezzo_finale);
	string getUser();
	int getCodOrdine();
	list<Prodotto> getListaProdotti();
	float getPrezzoFinale();
};
