#include "Utente.h"
#include <list>
#include <iterator>
#include "ConnDB.h"

class Utenti
{
private:
	list<Utente> lista_utenti;

public:
	Utenti();
	void caricaDati(MYSQL* conn);
	void stampaDati();
	list<Utente> getListaUtenti();
};
