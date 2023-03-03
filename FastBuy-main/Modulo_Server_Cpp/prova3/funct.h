#include <iostream>
#include "Utente.h"
#include "Prodotto.h"
#include <tuple>

using namespace std;

// Funzione per quando si tenta l'accesso
string connAccedi(string s, list<Utente> lista) {
    string buff = s;
    buff.erase(0, 1);
 
    list<string> array_buff;
    int j = 0;
    for (int i = 0; i < buff.length(); i++) {
        if (buff[i] == '$') {
            array_buff.push_back(buff.substr(j, i));
            j = i + 1;
        }
    }
    array_buff.push_back(buff.substr(j, buff.length()));

    list<string>::iterator ite = array_buff.begin();

    string user = *ite;
    advance(ite, 1);
    string pass = *ite;

    list<Utente> ::iterator it;
    int count = 0;
    string lettura;

    // Ricerca dell'utente nella lista utenti
    for (it = lista.begin(); it != lista.end(); it++) {
        if (user.compare(it->getUsername()) == 0 && pass.compare(it->getPass()) == 0) {
            int fl = int(it->getFlag());
            if (fl == 1) {
                lettura = "Benvenuto amministratore";
                return lettura;
            }
            else {
                lettura = "Benvenuto cliente";
                return lettura;
            }
        }
    }
    lettura = "Username o password non corretti";
    return lettura;
}

// Funzione per quando si tenta la registrazione
string connRegistrati(string s, list<Utente> lista, MYSQL* conn) {
    string buff = s;
    buff.erase(0, 1);

    list<string> array_buff;
    int j = 0;
    for (int i = 0; i < buff.length(); i++) {
        if (buff[i] == '$') {
            array_buff.push_back(buff.substr(j, i-j));
            j = i + 1;
        }
    }
    array_buff.push_back(buff.substr(j, buff.length()));

    list<string>::iterator ite = array_buff.begin();

    string user = *ite;
    advance(ite, 1);
    string pass = *ite;
    advance(ite, 1);
    string nome = *ite;
    advance(ite, 1);
    string cognome = *ite;
    advance(ite, 1);
    string email = *ite;

    // cout << "Username: " << user << " Password: " << pass << " Nome: " << nome << " Cognome: " << cognome << " Email: " << email << endl;

    list<Utente>::iterator it;
    
    string lettura;

    for (it = lista.begin(); it != lista.end(); it++) {
        if (user.compare(it->getUsername()) == 0) {
            lettura = "Username già esistente";
            return lettura;
        }
    }

    string query = "INSERT INTO utenti (username, pass, nome, cognome, flag, email) VALUES ('" + user + "', '" + pass + "', '" + nome + "', '" + cognome + "', 0, '" + email + "')";

    const char* r = query.c_str();
    int qstate = mysql_query(conn, r);

    if (!qstate)
        cout << "Query accepted" << endl;
    else
        cout << "Query failed: " << mysql_error(conn) << endl;

    lettura = "Utente registrato!";
    return lettura;
}

// Funzione per quando si tenta l'inserimento di un prodotto
string connInserisci(string s, list<Prodotto> lista, MYSQL* conn) {
    string buff = s;
    buff.erase(0, 1);

    list<string> array_buff;
    int j = 0;
    for (int i = 0; i < buff.length(); i++) {
        if (buff[i] == '$') {
            array_buff.push_back(buff.substr(j, i - j));
            j = i + 1;
        }
    }
    array_buff.push_back(buff.substr(j, buff.length()));

    list<string>::iterator ite = array_buff.begin();

    string codice = *ite;
    advance(ite, 1);
    string categoria = *ite;
    advance(ite, 1);
    string nome = *ite;
    advance(ite, 1);
    string prezzo = *ite;
    advance(ite, 1);
    string quantita = *ite;

    // cout << "Codice: " << codice << " Categoria: " << categoria << " Nome: " << nome << " Prezzo: " << prezzo << " Quantita: " << quantita << endl;

    list<Prodotto>::iterator it;

    string lettura;

    for (it = lista.begin(); it != lista.end(); it++) {
        if (codice.compare(it->getCod()) == 0) {
            lettura = "Codice già esistente";
            return lettura;
        }
    }

    for (int i = 0; i < prezzo.length(); i++) {
        string c1;
        c1.push_back(prezzo[i]);
        if (c1.compare(",") == 0) {
            prezzo[i] = '.';
        }
    }

    string query = "INSERT INTO prodotti (cod, categoria, nome, prezzo, quantita) VALUES ('" + codice + "', '" + categoria + "', '" + nome + "', " + prezzo + ", " + quantita + ")";
    
    const char* r = query.c_str();
    int qstate = mysql_query(conn, r);

    if (!qstate)
        cout << "Query accepted" << endl;
    else
        cout << "Query failed: " << mysql_error(conn) << endl;

    lettura = "Prodotto inserito!";
    return lettura;
}

// Funzione per Categorie prodotti
string connCategorie(MYSQL* conn) {
    MYSQL_ROW row;
    MYSQL_RES* res;
    int qstate;

    string query = "SELECT categoria FROM prodotti GROUP BY categoria";

    const char* q = query.c_str();
    qstate = mysql_query(conn, q);

    if (!qstate)
        cout << "Query accepted" << endl;
    else
        cout << "Query failed: " << mysql_error(conn) << endl;

    res = mysql_store_result(conn);

    string s = "";
    while (row = mysql_fetch_row(res)) {
        s = s + row[0] + '$';
    }
    s.erase(s.length() -1, 1);

    // cout << "Categorie: " << s << endl;
    
    return s;
}

// Funzione per elenco prodotti
list<Prodotto> connProdotti(string s, list<Prodotto> lista) {
    string buff = s;
    buff.erase(0, 1);

    list<Prodotto>::iterator it;
    list<Prodotto> lista_prodotti;
    for (it = lista.begin(); it != lista.end(); it++) {
        if (buff.compare(it->getCategoria()) == 0) {
            lista_prodotti.push_back(*it);
        }
    }

    return lista_prodotti;
}

// Funziona per concatenare le info di un prodotto
list<string> concatProdotti(list<Prodotto> lista) {
    list<string> concatprod;

    string s1 = "";
    list<Prodotto>::iterator it;

    for (it = lista.begin(); it != lista.end(); it++) {
        int f = to_string(it->getPrezzo()).find(".");
        string prezzo = to_string(it->getPrezzo()).substr(0, f + 3);
        s1 = it->getCod() + '$' + it->getCategoria() + '$' + it->getNome() + '$' + prezzo + '$' + to_string(it->getQuantita());
        concatprod.push_back(s1);
    }

    return concatprod;
}

// Funzione per le Info generali di un Ordine
list<string> connInfoOrdine(string s) {
    string buff = s;
    buff.erase(0, 1);

    list<string> lista_info;

    int j = 0;
    for (int i = 0; i < buff.length(); i++) {
        if (buff[i] == '$') {
            lista_info.push_back(buff.substr(j, i - j));
            j = i + 1;
        }
    }
    lista_info.push_back(buff.substr(j, buff.length()));

    return lista_info;
}

// Funzione per le Info di un Prodotto di un Ordine
tuple<string, string, string, float, int> connInfoProdotto(string s) {
    string buff = s;

    list<string> lista_info;

    int j = 0;
    for (int i = 0; i < buff.length(); i++) {
        if (buff[i] == '$') {
            lista_info.push_back(buff.substr(j, i - j));
            j = i + 1;
        }
    }
    lista_info.push_back(buff.substr(j, buff.length()));

    list<string>::iterator it;

    it = lista_info.begin();
    string cod = *it;
    advance(it, 1);
    string categoria = *it;
    advance(it, 1);
    string nome = *it;
    advance(it, 1);
    string prz = *it;

    for (int i = 0; i < prz.length(); i++) {
        string c1;
        c1.push_back(prz[i]);
        if (c1.compare(",") == 0) {
            prz[i] = '.';
        }
    }

    float prezzo = stof(prz);
    advance(it, 1);
    int quantita = stoi(*it);

    tuple<string, string, string, float, int> t = make_tuple(cod, categoria, nome, prezzo, quantita);

    return t;
}

// Funzione per le Info dell'Ordine
tuple<int, string, int, float> connInfo(string s) {
    // Ricevo DIM dal Client
    list<string> info_ordine = connInfoOrdine(s);
    list<string>::iterator it;

    it = info_ordine.begin();
    int dim_ordine = stoi(*it);
    advance(it, 1);
    string user = *it;
    advance(it, 1);
    int cod_ordine = stoi(*it);
    advance(it, 1);
    string prz = *it;

    for (int i = 0; i < prz.length(); i++) {
        string c1;
        c1.push_back(prz[i]);

        if (c1.compare(",") == 0) {
            prz[i] = '.';
        }
    }

    float prezzo_finale = stof(prz);

    tuple<int, string, int, float> t = make_tuple(dim_ordine, user, cod_ordine, prezzo_finale);

    return t;
}

// Funzione per l'Aggiornamento dei Prodotti
void aggiornaProdotti(MYSQL* conn, Ordine o) {
    list<Prodotto> lista_prodotti = o.getListaProdotti();
    list<Prodotto>::iterator it;

    for (it = lista_prodotti.begin(); it != lista_prodotti.end(); it++) {
        int qnt = it->getQuantita();

        // cout << "QUANTITA CONSIDERATA: " << qnt << endl;

        string query = "UPDATE prodotti SET quantita=quantita-" + to_string(qnt) + " WHERE cod='" + it->getCod() + "'";

        // cout << "QUERY: " << query << endl;

        const char* r = query.c_str();
        int qstate = mysql_query(conn, r);

        if (!qstate)
            cout << "Query accepted" << endl;
        else
            cout << "Query failed: " << mysql_error(conn) << endl;
        
    }

    cout << "Aggiornamento completato" << endl;
}

// Funzione per la Trasmissione di un Ordine
void trasmettiOrdine(Ordine o) {
    // Apertuta Socket con Server Python
    ClientSide* client = new ClientSide();
    client->connessione();
    int sockfdcl = client->getSockfd();

    string prz = to_string(o.getPrezzoFinale());
    int pos = prz.find(".");
    prz = prz.substr(0, pos + 3);

    int dim_lista = o.getListaProdotti().size();

    string info_ordine = "0" + to_string(dim_lista) + "$" + o.getUser() + "$" + to_string(o.getCodOrdine()) + "$" + prz;

    // cout << "INFO ORDINE: " << info_ordine << endl;

    char* msg = client->formattaDati(info_ordine);
    int result = send(sockfdcl, msg, 1024, 0);

    list<Prodotto>::iterator it;
    list<Prodotto> lista_prodotti = o.getListaProdotti();

    for (it = lista_prodotti.begin(); it != lista_prodotti.end(); it++) {
        string prz = to_string(it->getPrezzo());
        int pos = prz.find(".");
        prz = prz.substr(0, pos + 3);
        
        string info_prodotto = it->getCod() + "$" + it->getCategoria() + "$" + it->getNome() + "$" + prz + "$" + to_string(it->getQuantita());

        // cout << "INFO PRODOTTO: " << info_prodotto << endl;

        char* msg = client->formattaDati(info_prodotto);
        int result = send(sockfdcl, msg, 1024, 0);
    }

    // Chiusura Socket con Server Python
    closesocket(sockfdcl);
}