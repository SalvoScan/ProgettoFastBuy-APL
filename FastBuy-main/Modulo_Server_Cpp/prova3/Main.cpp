#include "ServerSide.h"
#include "ClientSide.h"
#include "Utenti.h"
#include "Prodotti.h"
#include "Ordine.h"
#include "funct.h"
#include <tuple>

using namespace std;

int main() {
    cout << "Starting SERVER C++" << endl;

    // Connessione al Database
    ConnDB* conndb = new ConnDB();
    MYSQL* conn = conndb->getConn();

    // Caricamento lista Utenti
    Utenti* utenti = new Utenti();
    utenti->caricaDati(conn);
    // utenti->stampaDati();

    // Caricamento lista Prodotti
    Prodotti* prodotti = new Prodotti();
    prodotti->caricaDati(conn);
    // prodotti->stampaDati();

    while (true) {

        int x = 0;
        string esito;

        // Variabili Case 4
        list<Prodotto> lista_prodotti;
        list<string> concatprod;
        string dim;

        // Variabili Case 5
        int dim_ordine;
        string user;
        int cod_ordine;
        list<Prodotto> lista_prodotti_ordine;
        float prezzo_finale;
        Ordine* ord;

        list<string>::iterator it;

        // Apertura Socket con Client C#
        ServerSide* server = new ServerSide();
        int sockfd = server->acceptConn();

        char* msg;
        int msg_len;

        // Ricezione dati dal Client
        char buffer[1024 + 1];
        int result = recv(sockfd, buffer, 1024, 0);
        buffer[result] = '\0';
        // cout << "RICEVUTO: " << buffer << endl;

        // Tramite il primo valore si capisce l'operazione corretta da eseguire
        string var = buffer;
        var = var.substr(0, 1);
        x = stoi(var);

        switch (x)
        {
        case 0:
            // Caricamento dati utenti dal database
            utenti->caricaDati(conn);
            // Login
            esito = connAccedi(buffer, utenti->getListaUtenti());
            break;
        case 1:
            // Registrazione
            esito = connRegistrati(buffer, utenti->getListaUtenti(), conn);
            break;
        case 2:
            // Caricamento dati prodotti dal database
            prodotti->caricaDati(conn);
            // Inserimento nuovo prodotto da parte dell'amministratore
            esito = connInserisci(buffer, prodotti->getListaProdotti(), conn);
            break;
        case 3:
            // Visualizzazione delle categorie di prodotti
            esito = connCategorie(conn);
            break;
        case 4:
            // Caricamento dati prodotti dal database
            prodotti->caricaDati(conn);
            // Visualizzazione dei prodotti di una data categoria
            lista_prodotti = connProdotti(buffer, prodotti->getListaProdotti());
            concatprod = concatProdotti(lista_prodotti);

            // Invio al Client C# numero di prodotti
            dim = to_string(concatprod.size());
            msg = server->formattaDati(dim);
            msg_len = strlen(msg);

            result = send(sockfd, (const char*)msg, msg_len, 0);

            // Ricevo ACK dal Client C#
            result = recv(sockfd, buffer, 1024, 0);
            buffer[result] = '\0';
            // cout << "RIC dim: " << buffer << endl;

            for (it = concatprod.begin(); it != concatprod.end(); it++) {
                // Invio al Client C# del Prodotto
                msg = server->formattaDati(*it);
                msg_len = strlen(msg);

                result = send(sockfd, (const char*)msg, msg_len, 0);

                // Ricevo ACK dal Client C# sul Prodotto
                result = recv(sockfd, buffer, 1024, 0);
                buffer[result] = '\0';
                // cout << "RIC prod: " << buffer << endl;
            }
            esito = "Fine case 4";
            break;
        case 5:
        {
            // Visualizzazione Prodotti nel carrello
            tuple<int, string, int, float> t1 = connInfo(buffer);
            dim_ordine = get<0>(t1);
            user = get<1>(t1);
            cod_ordine = get<2>(t1);
            prezzo_finale = get<3>(t1);
            // Invio ACK al Client C#
            msg = server->formattaDati("OK Info Ordine");
            msg_len = strlen(msg);

            result = send(sockfd, (const char*)msg, msg_len, 0);

            // Ricezione Lista Prodotti dell' Ordine
            for (int i = 0; i < dim_ordine; i++) {
                // Ricevo un Prodotto dal Client C#
                result = recv(sockfd, buffer, 1024, 0);
                buffer[result] = '\0';

                tuple<string, string, string, float, int> t2 = connInfoProdotto(buffer);
                string cod = get<0>(t2);
                string categoria = get<1>(t2);
                string nome = get<2>(t2);
                float prezzo = get<3>(t2);
                int quantita = get<4>(t2);

                Prodotto* p = new Prodotto(cod, categoria, nome, prezzo, quantita);

                lista_prodotti_ordine.push_back(*p);

                // Invio ACK Prodotto al Client C#
                msg = server->formattaDati("OK Info Prodotto");
                msg_len = strlen(msg);

                result = send(sockfd, (const char*)msg, msg_len, 0);
            }

            ord = new Ordine(user, cod_ordine, lista_prodotti_ordine, prezzo_finale);
            
            aggiornaProdotti(conn, *ord);

            trasmettiOrdine(*ord);

            esito = "Ordine confermato!";
            break;
        }
        default:
            break;
        }

        msg = server->formattaDati(esito);
        msg_len = strlen(msg);

        result = send(sockfd, (const char*)msg, msg_len, 0);

        cout << "Connessione Server Chiusa" << endl;

        // Chiusura Socket con Client C#
        closesocket(sockfd);
        closesocket((int)server->getSockfd());
    }
    // Chiusura connessione Database
    mysql_close(conn);

    delete(conndb);
    delete(utenti);
    delete(prodotti);
}