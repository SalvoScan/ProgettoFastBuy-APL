#include "Utente.h"

Utente::Utente(string username, string pass, string nome, string cognome, bool flag, string email) {
	this->username = username;
	this->pass = pass;
	this->nome = nome;
	this->cognome = cognome;
	this->flag = flag;
	this->email = email;
}

string Utente::getUsername() {
	return this->username;
}

string Utente::getPass() {
	return this->pass;
}

string Utente::getNome() {
	return this->nome;
}

string Utente::getCognome() {
	return this->cognome;
}

string Utente::getEmail() {
	return this->email;
}

bool Utente::getFlag(){
	return this->flag;
}

ostream& operator << (ostream& os, const Utente& u) {
	os << u.username + " " + u.pass + " " + u.nome + " " + u.cognome + " " << u.flag << " " + u.email;
	return os;
}