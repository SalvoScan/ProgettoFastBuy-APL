#include "ServerSide.h"

ServerSide::ServerSide() {
	// Init WINSOCK
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
	server_addr.sin_addr.s_addr = htonl(INADDR_ANY);
	server_addr.sin_port = htons(8001);

	if (bind(sockfd, (struct sockaddr*)&server_addr, server_addr_len) != 0) {
		cout << "Fallimento BIND" << endl;
		ExitProcess(EXIT_FAILURE);
	}

	// Socket posta in modo passivo
	if (listen(sockfd, 1) != 0) {
		cout << "Fallimento LISTEN" << endl;
		ExitProcess(EXIT_FAILURE);
	}

	cout << "-- Server in attesa di connessioni --" << endl;
}

int ServerSide::acceptConn() {
	int connect_socket = accept(sockfd, (struct sockaddr*)&client_addr, &client_addr_len);
	if (connect_socket == -1) {
		cout << "Errore Chiamata ACCEPT" << endl;
		ExitProcess(EXIT_FAILURE);
	}

	cout << "Client connesso" << endl;
	return connect_socket;
}

char* ServerSide::formattaDati(string lettura) {
	char msg[1024 + 1];
	for (int i = 0; i < lettura.length(); i++) {
		msg[i] = lettura[i];
	}
	msg[lettura.length()] = '\0';
	return msg;
}

SOCKET ServerSide::getSockfd() {
	return sockfd;
}