#include "Prodotto.h"

Prodotto::Prodotto(string cod, string categoria, string nome, float prezzo, int quantita) {
	this->cod = cod;
	this->categoria = categoria;
	this->nome = nome;
	this->prezzo = prezzo;
	this->quantita = quantita;
}

string Prodotto::getCod() {
	return cod;
}

string Prodotto::getCategoria() {
	return categoria;
}

string Prodotto::getNome() {
	return nome;
}

float Prodotto::getPrezzo() {
	return prezzo;
}

int Prodotto::getQuantita() {
	return quantita;
}

ostream& operator << (ostream& os, const Prodotto& p) {
	os << p.cod + " " + p.categoria + " " + p.nome + " " << p.prezzo << " " << p.quantita;
	return os;
}