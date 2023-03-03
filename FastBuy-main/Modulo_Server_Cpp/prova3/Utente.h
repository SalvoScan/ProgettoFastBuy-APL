#pragma once

#include <iostream>
#include <string.h>
#include <string>
#include <ostream>

using namespace std;

class Utente
{
private:
	string username;
	string pass;
	string nome;
	string cognome;
	string email;
	bool flag;

public:
	Utente(string username, string pass, string nome, string cognome, bool flag, string email);
	string getUsername();
	string getPass();
	string getNome();
	string getCognome();
	string getEmail();
	bool getFlag();
	friend ostream& operator << (ostream& os, const Utente& u);
};
