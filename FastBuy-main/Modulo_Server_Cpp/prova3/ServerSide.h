#define _WINSOCK_DEPRECATED_NO_WARNINGS
#define _CRT_SECURE_NO_WARNINGS

#pragma comment(lib,"ws2_32.lib")

#include <WinSock2.h>
#include <stdio.h>
#include <stdlib.h>
#include <Windows.h>
#include <string.h>
#include <string>
#include <iostream>

using namespace std;

class ServerSide
{
private:
	WSAData wsaData;
	WORD DllVersion = MAKEWORD(2, 1);
	SOCKET sockfd;
	struct sockaddr_in client_addr, server_addr;
	int server_addr_len = sizeof(server_addr);
	int client_addr_len = sizeof(client_addr);

public:
	ServerSide();
	int acceptConn();
	char* formattaDati(string lettura);
	SOCKET getSockfd();
};
