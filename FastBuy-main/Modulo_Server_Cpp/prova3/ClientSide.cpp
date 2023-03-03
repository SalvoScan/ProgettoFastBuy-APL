#include "ClientSide.h"

ClientSide::ClientSide() {
	// Init WINSOCK
	WSAData wsaData;
	WORD DllVersion = MAKEWORD(2, 1);
	if (WSAStartup(DllVersion, &wsaData) != 0) {
		ExitProcess(EXIT_FAILURE);
	}

	// Create Socket
	sockfd = socket(AF_INET, SOCK_STREAM, 0);
	if (sockfd < 0) {
		cout << "Fallimento Creazione SOCKET" << endl;
		ExitProcess(EXIT_FAILURE);
	}

	server_addr.sin_family = AF_INET;
	server_addr.sin_addr.s_addr = inet_addr("127.0.0.1");
	server_addr.sin_port = htons(9000);

	cout << "-- Client in attesa di connettersi --" << endl;
}

int ClientSide::getSockfd() {
	return (int)sockfd;
}

void ClientSide::connessione() {
	int retcode = connect(sockfd, (struct sockaddr*)&server_addr, server_addr_len);

	if (retcode < 0) {
		cout << "Errore durante la connessione" << endl;
		ExitProcess(EXIT_FAILURE);
	}
	cout << "Connessione al server stabilita" << endl;
}

char* ClientSide::formattaDati(string lettura) {
	char msg[1024 + 1];

	for (int i = 0; i < lettura.length(); i++) {
		msg[i] = lettura[i];
	}
	
	msg[lettura.length()] = '@';
	return msg;
}