#include "Prodotti.h"

Prodotti::Prodotti() {}

// Caricamento dati dal database
void Prodotti::caricaDati(MYSQL* conn) {
    MYSQL_ROW row;
    MYSQL_RES* res;
    int qstate;

    string query = "SELECT * FROM prodotti";

    const char* q = query.c_str();
    qstate = mysql_query(conn, q);

    if (!qstate)
        cout << "Query accepted" << endl;
    else
        cout << "Query failed: " << mysql_error(conn) << endl;

    res = mysql_store_result(conn);

    list<Prodotto> lis;
    while (row = mysql_fetch_row(res)) {
        Prodotto* p = new Prodotto(row[0], row[1], row[2], stof(row[3]), stoi(row[4]));

        lis.push_back(*p);
    }

    cout << "Dati caricati" << endl;
    lista_prodotti = lis;
}

void Prodotti::stampaDati() {
    list<Prodotto> ::iterator it;
    for (it = lista_prodotti.begin(); it != lista_prodotti.end(); it++) {
        cout << *it << endl;
    }
}

list<Prodotto> Prodotti::getListaProdotti() {
    return lista_prodotti;
}