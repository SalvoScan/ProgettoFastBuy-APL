#include "Prodotto.h"
#include <list>
#include <iterator>
#include "ConnDB.h"

class Prodotti
{
private:
	list<Prodotto> lista_prodotti;

public:
	Prodotti();
	void caricaDati(MYSQL* conn);
	void stampaDati();
	list<Prodotto> getListaProdotti();
};
