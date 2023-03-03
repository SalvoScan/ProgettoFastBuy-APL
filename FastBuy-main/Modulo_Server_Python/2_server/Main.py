from ThreadInserimentoOrd import *
from ThreadCodOrdine import *
from ThreadVisualizzaOrdini import *
from ThreadVisualizzaProdotti import *
from ThreadTracciamentoOrdine import *


def media(x, y):
    avg = int(mean([x, y]))
    if avg >= 15:
        return 15
    elif avg <= 5:
        return 5
    else:
        return avg

# Questa funzione prende una stringa e restituisce
# separatamente le due coordinate del punto
def slitterPunto(s):
        s = s.split("-")
        x = int(s[0])
        y = int(s[1])

        return x, y

# Gli sleep() sono stati inseriti per una corretta
# visualizzazione dei print() di ciascun thread
if __name__ == "__main__":
    print("Starting Server Python")

    thread1 = ThreadInserimentoOrd()
    thread2 = ThreadCodOrdine()
    thread3 = ThreadVisualizzaOrdini()
    thread4 = ThreadVisualizzaProdotti()
    thread5 = ThreadTracciamentoOrdine()
    thread1.start()
    time.sleep(1)
    thread2.start()
    time.sleep(1)
    thread3.start()
    time.sleep(1)
    thread4.start()
    time.sleep(1)
    thread5.start()
    time.sleep(1)

    while True:
        print("Thread notifica tracciamento")
        
        # Apertura Socket con Client C#
        server = Server(9006)
        print("Thread notifica tracciamento in attesa di connessione")
        server.acceptConn()
        print("Thread notifica tracciamento connesso")
        # Connessione al Database
        database = ConnDB()
        db = database.db
        cursor = database.cursor

        # Ricezione dati dal Client C#
        response = server.connectionSocket.recv(1024)
        resp = str(response)
        risposta = server.formattaDati(resp)
        risposta = risposta[0:len(risposta) - 1]

        # print("RICEVUTO: " + risposta)

        risposta = risposta.split("$")

        user = risposta[0]
        cod_ordine = risposta[1]


        q1 = "SELECT pt1, pt2, pt3, pt4, pt5 FROM tracciamento_ordini WHERE user = '" + risposta[0] + "' AND cod_ordine = '" + risposta[1] + "'";

        cursor.execute(q1)
        results = cursor.fetchall()
        result = results[0]

        for i in range(0, len(result)):
            x, y = slitterPunto(result[i])
            # Calcolo della media dei punti
            z = media(x, y)

            # Viene atteso un tempo pari a z, tra un punto e il successivo,
            # per simulare il tragitto compiuto dall'ordine
            time.sleep(z)
            # Trasmissione notifica raggiungimento di un punto
            server.connectionSocket.send(str.encode("Arrivato punto " + str(i + 1) + ", coordinate: " + str(x) + ", " + str(y)))
            response = server.connectionSocket.recv(1024)


        server.connectionSocket.send(str.encode("Ordine consegnato"))

        # Chiusura Socket con Client C#
        server.serverSocket.close()
        server.connectionSocket.close()

        # Chiusura connessione Database
        cursor.close()
        db.close()