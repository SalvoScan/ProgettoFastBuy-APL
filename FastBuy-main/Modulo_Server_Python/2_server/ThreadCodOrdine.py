import threading
import time
from Server import *
from ConnDB import *

class ThreadCodOrdine (threading.Thread):
    def __init__(self):
        threading.Thread.__init__(self)      

    def run(self):
        print ("Starting ThreadCodOrdine")
       
        while True:
            print("Ciclo while ThreadCodOrdine")
            # Apertura Connessione Database
            database = ConnDB()
            db = database.db
            cursor = database.cursor

            # Apertura Socket con Client C#
            server = Server(8002)
            print("ThreadCodOrdine in attesa di connessione")
            server.acceptConn()
            print("ThreadCodOrdine connesso")

            # Ricezione dati dal Client C#
            response = server.connectionSocket.recv(1024)
            resp = str(response)
            risposta = server.formattaDati(resp)

            risposta = risposta[0:len(risposta) - 1]
            # print("USER:  " + risposta)

            q1 = "SELECT MAX(cod_ordine) FROM info_ordini WHERE user = '" + risposta + "'";

            cursor.execute(q1)
            results = cursor.fetchall()
            result = results[0]
            res = result[0]
            # print("RESULT:  " + str(res))

            if str(res) == "None":
                res = 0
                server.connectionSocket.send(str.encode(str(res)))
                # print("IF:  " + str(res))
            else:
                server.connectionSocket.send(str.encode(str(res)))
                # print("ELSE:  " + str(res))
    
            # Chiusura Socket con Client C#
            server.serverSocket.close()
            server.connectionSocket.close()

            # Chiusura Connessione Database
            cursor.close()
            db.close()


