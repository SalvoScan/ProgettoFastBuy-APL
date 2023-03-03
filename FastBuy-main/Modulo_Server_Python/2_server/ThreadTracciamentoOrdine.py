import threading
import time
from Server import *
from ConnDB import *
from Punto import *
from numpy import mean
import matplotlib.pyplot as plt

class ThreadTracciamentoOrdine (threading.Thread):
    def __init__(self):
        threading.Thread.__init__(self)      

    def slitterPunto(self, s):
        s = s.split("-")
        x = int(s[0])
        y = int(s[1])

        return x, y

    def media(self, x, y):
        avg = int(mean([x, y]))
        if avg >= 15:
            return 15
        elif avg <= 5:
            return 5
        else:
            return avg

    def run(self):
        print ("Starting ThreadTracciamentoOrdine")
       
        while True:
            print("Ciclo while ThreadTracciamentoOrdine")
            # Apertura Connessione Database
            database = ConnDB()
            db = database.db
            cursor = database.cursor

            # Apertura Socket con Client C#
            server = Server(9005)
            print("ThreadTracciamentoOrdine in attesa di connessione")
            server.acceptConn()
            print("ThreadTracciamentoOrdine connesso")

            # Ricezione dati dal Client C#
            response = server.connectionSocket.recv(1024)
            resp = str(response)
            risposta = server.formattaDati(resp)

            risposta = risposta[0:len(risposta) - 1]
            # print("USER:  " + risposta)
            risposta = risposta.split("$")

            user = risposta[0]
            cod_ordine = risposta[1]


            q1 = "SELECT pt1, pt2, pt3, pt4, pt5 FROM tracciamento_ordini WHERE user = '" + risposta[0] + "' AND cod_ordine = '" + risposta[1] + "'";

            cursor.execute(q1)
            results = cursor.fetchall()
            result = results[0]

            lista_x = list()
            lista_y = list()
            lista_media = list()

            for i in range(0, len(result)):
                x, y = self.slitterPunto(result[i])
                # Calcolo della media dei punti
                z = self.media(x, y)
                lista_x.append(x)
                lista_y.append(y)
                lista_media.append(z)

            # Tali plot() vengono usati per visualizzare rispettivamente
            # l'andamento dei punti e della media di essi (dove la media
            # rappresenta il tempo di attesa del raggiungimento del punto)
            plt.plot(lista_x, lista_y, color = 'blue', label = "Punti", marker = "o")
            plt.plot(lista_x, lista_media, color='red', label = "Media punti", marker = "o")
            plt.title("Tracciamento ordine")
            plt.legend();
            plt.savefig("Images/Tracciamento.png")

            plt.show()

            data2 = "Images/Tracciamento.png"

            # Apertuta File Immagine da inviare
            img = open(data2,'rb')
            image_data = img.read(2048)

            while image_data:
                server.connectionSocket.send(image_data)
                image_data = img.read(2048)

            print("Dati Inviati Correttamente")

            # Chiusura Socket con Client C#
            server.serverSocket.close()
            server.connectionSocket.close()

            # Chiusura Connessione Database
            cursor.close()
            db.close()