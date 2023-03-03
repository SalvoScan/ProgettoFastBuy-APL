#include "Utenti.h"

Utenti::Utenti() {}

// Caricamento dei dati dal database
void Utenti::caricaDati(MYSQL* conn) {
    MYSQL_ROW row;
    MYSQL_RES* res;
    int qstate;

    string query = "SELECT * FROM utenti";

    const char* q = query.c_str();
    qstate = mysql_query(conn, q);

    if (!qstate)
        cout << "Query accepted" << endl;
    else
        cout << "Query failed: " << mysql_error(conn) << endl;

    res = mysql_store_result(conn);

    while (row = mysql_fetch_row(res)) {
        bool x;
        if (string(row[4]).compare("0") == 0) {
            x = 0;
        }
        else {
            x = 1;
        }
        Utente* u = new Utente(row[0], row[1], row[2], row[3], x, row[5]);

        lista_utenti.push_back(*u);
    }

    cout << "Dati caricati" << endl;
}

void Utenti::stampaDati() {
    list<Utente> ::iterator it;
    for (it = lista_utenti.begin(); it != lista_utenti.end(); it++) {
        cout << *it << endl;
    }
}

list<Utente> Utenti::getListaUtenti() {
    return lista_utenti;
}