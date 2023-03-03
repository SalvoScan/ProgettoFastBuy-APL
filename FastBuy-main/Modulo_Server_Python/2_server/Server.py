from socket import *

class Server:
  
    serverPort = 0
    serverSocket = 0
    connectionSocket = 0
    addr = 0

    def __init__(self, port):

        self.serverPort = port

        self.serverSocket = socket(AF_INET, SOCK_STREAM)

        self.serverSocket.bind(('', self.serverPort))

        self.serverSocket.listen(1)

        print("Server pronto a ricevere una connessione")

    def acceptConn(self):

        self.connectionSocket, self.addr = self.serverSocket.accept()

        print("Client connesso")

    def formattaDati(self, valore):
        val = valore[2:]
        risposta = ""

        for c in val:
            if str(c) != "@":
                 risposta = risposta + c
            if str(c) == "@":
                break

        return risposta
