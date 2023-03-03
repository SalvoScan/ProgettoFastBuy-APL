#include "Ordine.h"

Ordine::Ordine(string user, int cod_ordine, list<Prodotto> lista_prodotti, float prezzo_finale) {
	this->user = user;
	this->cod_ordine = cod_ordine;
	this->lista_prodotti = lista_prodotti;
	this->prezzo_finale = prezzo_finale;
}

string Ordine::getUser() {
	return user;
}

int Ordine::getCodOrdine() {
	return cod_ordine;
}

list<Prodotto> Ordine::getListaProdotti() {
	return lista_prodotti;
}

float Ordine::getPrezzoFinale() {
	return prezzo_finale;
}