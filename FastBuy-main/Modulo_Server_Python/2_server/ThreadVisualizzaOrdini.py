import threading
from Server import *
from ConnDB import *

class ThreadVisualizzaOrdini(threading.Thread):
    def __init__(self):
      threading.Thread.__init__(self)

    def run(self):
        print ("Starting ThreadVisualizzaOrdini")

        while True:
          print("Ciclo while ThreadVisualizzaOrdini")


          # Apertura Socket con Client C#
          server = Server(8003)
          print("ThreadVisualizzaOrdini in attesa di connessione")
          server.acceptConn()
          print("ThreadVisualizzaOrdini connesso")

          # Apertura Connessione Database
          database = ConnDB()
          db = database.db
          cursor = database.cursor
        

          # Ricezione dati dal Client C#
          response = server.connectionSocket.recv(1024)
          resp = str(response)
          risposta = server.formattaDati(resp)

          risposta = risposta[0:len(risposta) - 1]
          # print("USER: " + risposta)

          q = "SELECT cod_ordine, prezzo_finale FROM info_ordini WHERE user='" + risposta + "' GROUP BY cod_ordine";
          
          cursor.execute(q)

          results = cursor.fetchall()

          lista_info_ordini = list()
          dim_lista = 0
          for result in results:
            print("Cod_Ordine: ", result[0], ", Prezzo_Finale: ", result[1])

            dim_lista += 1
            cod_ordine = result[0]
            prezzo_finale = result[1]
            info_ordine = str(cod_ordine) + "$" + str(prezzo_finale)

            lista_info_ordini.append(info_ordine)

          lista_info_ordini.insert(0, str(dim_lista))

          # Stampa per la corretta formattazione di ciò che deve essere ritornato al Client C#
          # for info_ordine in lista_info_ordini:
              # print(info_ordine)

          # Invio del numero dei record che verranno trasmessi
          server.connectionSocket.send(str.encode(lista_info_ordini.pop(0)))

          # Invio Info_Ordini al Client C#
          for i in range(0, dim_lista):
              # POP (con indice 0) permette di estrarre e rimuovere il primo elemento della lista
              server.connectionSocket.send(str.encode(lista_info_ordini.pop(0)))

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


