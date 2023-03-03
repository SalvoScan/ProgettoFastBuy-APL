import threading
from Server import *
from ConnDB import *

class ThreadVisualizzaProdotti(threading.Thread):
    def __init__(self):
      threading.Thread.__init__(self)

    def run(self):
        print ("Starting ThreadVisualizzaProdotti")

        while True:
          print("Ciclo while ThreadVisualizzaProdotti")


          # Apertura Socket con Client C#
          server = Server(8004)
          print("ThreadVisualizzaProdotti in attesa di connessione")
          server.acceptConn()
          print("ThreadVisualizzaProdotti connesso")

          # Apertura Connessione Database
          database = ConnDB()
          db = database.db
          cursor = database.cursor
        
          # Ricezione dati dal Client C#
          response = server.connectionSocket.recv(1024)
          resp = str(response)
          risposta = server.formattaDati(resp)
          risposta = risposta[0:len(risposta) - 1]

          # print("RICEZIONE: " + risposta)
          risposta = risposta.split("$")

          user = risposta[0]
          cod_ordine = risposta[1]

          q = "SELECT cod_prodotto, categoria, nome, prezzo, quantita, prezzo_finale FROM info_ordini WHERE user='" + user + "' AND cod_ordine =" + cod_ordine;
          
          cursor.execute(q)

          results = cursor.fetchall()

          lista_info_prodotti = list()
          dim_lista = 0
          prezzo_final = 0
          for result in results:
            # print("Cod prodotto: " + result[0] + " Categoria: ", result[1], " Nome: ", result[2], " Prezzo: ", result[3], " Quantita: ", result[4], " Prezzo finale: ", result[5])

            dim_lista += 1
            cod_prodotto = result[0]
            categoria = result[1]
            nome = result[2]
            prezzo = result[3]
            quantita = result[4]
            prezzo_final = result[5]
            info_prodotto = str(cod_prodotto) + "$" + str(categoria) + "$" + str(nome) + "$" + str(prezzo) + "$" + str(quantita)

            lista_info_prodotti.append(info_prodotto)


          lista_info_prodotti.insert(0, str(dim_lista) + "$" + str(prezzo_final))

          # Stampa per la corretta formattazione di ciò che deve essere ritornato al Client C#
          # for info_prodotto in lista_info_prodotti:
              # print(info_prodotto)

          # Invio del numero dei record che verranno trasmessi
          server.connectionSocket.send(str.encode(lista_info_prodotti.pop(0)))

          # Invio Info_Ordini al Client C#
          for i in range(0, dim_lista):
              # POP (con indice 0) permette di estrarre e rimuovere il primo elemento della lista
              server.connectionSocket.send(str.encode(lista_info_prodotti.pop(0)))

              response = server.connectionSocket.recv(1024)
              resp = str(response)
              risposta = server.formattaDati(resp)
              risposta = risposta[0:len(risposta) - 1]
              # print("RICEVUTO: " + risposta)

          # Chiusura Socket con Client C#
          server.serverSocket.close()
          server.connectionSocket.close()

          # Chiusura Connessione Database
          cursor.close()
          db.close()