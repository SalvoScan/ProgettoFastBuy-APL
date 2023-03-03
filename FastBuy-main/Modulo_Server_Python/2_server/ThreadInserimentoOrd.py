import threading
import time
import random
from Server import *
from ConnDB import *
from Punto import *

class ThreadInserimentoOrd (threading.Thread):
   def __init__(self):
      threading.Thread.__init__(self)      

   def run(self):
      print ("Starting ThreadInserimentoOrd")

      while True:
          print("Ciclo while ThreadInserimentoOrd")

          # Apertura Connessione Database
          database = ConnDB()
          db = database.db
          cursor = database.cursor
        
          # Apertura Socket con Client C++
          server = Server(9000)
          print("ThreadInserimentoOrd in attesa di connessione")
          server.acceptConn()
          print("ThreadInserimentoOrd connesso")

          # Ricezione dati dal Client C++
          response = server.connectionSocket.recv(1024)
          resp = str(response)
          risposta = server.formattaDati(resp)
          
          risposta = risposta[1:]
          risposta = risposta.split("$")

          dim_lista = risposta[0]
          user = risposta[1]
          cod_ordine = risposta[2]
          prezzo_ordine = risposta[3]

          # print("Dimensione lista: " + dim_lista + ", User: " + user + ", Codice ordine: " + cod_ordine + ", Prezzo ordine: " + prezzo_ordine)

          for x in range(0,int(dim_lista)):
              response = server.connectionSocket.recv(1024)
              resp = str(response)
              risposta = server.formattaDati(resp)
              # print("RISPOSTA:  " + risposta)
              risposta = risposta.split("$")

              cod_prodotto = risposta[0]
              categoria = risposta[1]
              nome = risposta[2]
              prezzo = risposta[3]
              quantita = risposta[4]

              insert_prod = "INSERT INTO info_ordini (user, cod_ordine, cod_prodotto, categoria, nome, prezzo, quantita, prezzo_finale) VALUES ('" + user + "', " + cod_ordine + ", '" + cod_prodotto + "', '" + categoria + "', '" + nome + "', " + prezzo + ", " + quantita + ", " + prezzo_ordine + ")"
              # print("QUERY:  " + insert_prod)

              cursor.execute(insert_prod)
              db.commit()

          # Chiusura Socket con Client C++
          server.serverSocket.close()
          server.connectionSocket.close()

          # Generazione dei Punti random per il Tracciamento
          lista_tracciamento = list()
          for i in range(0,5):
              x = random.randint(0,50)
              y = random.randint(0,50)
              p = Punto(x,y)
              lista_tracciamento.append(p)
              # print(p)

          # Ordinamento lista Punti rispetto a X
          lista_tracciamento.sort(key=lambda p: p.x) 

          lis = list()
          for p in lista_tracciamento:
              x = p.x
              y = p.y
              pt = str(x) + "-" + str(y)
              lis.append(pt)

          pt1 = lis[0]
          pt2 = lis[1]
          pt3 = lis[2]
          pt4 = lis[3]
          pt5 = lis[4]

          insert_track = "INSERT INTO tracciamento_ordini (user, cod_ordine, pt1, pt2, pt3, pt4, pt5) VALUES ('" + user + "', " + cod_ordine + ", '" + pt1 + "', '" + pt2 + "', '" + pt3 + "', '" + pt4 + "', '" + pt5 + "')"
          # print("QUERY:  " + insert_track)

          cursor.execute(insert_track)
          db.commit()

          # Chiusura Connessione Database
          cursor.close()
          db.close()