#include <iostream>
#include <vector>
#include <string>
#include <thread>
#include <WinSock2.h>

#pragma comment(lib, "ws2_32")

#define PORT 1012
#define PACKET_SIZE 1024

using namespace std;

WSADATA wsadata;
SOCKET listener;
SOCKADDR_IN listenerAddr = {};

vector<pair<SOCKET, string>> clients;

void Set() {
	listener = socket(PF_INET, SOCK_STREAM, IPPROTO_TCP);

	listenerAddr.sin_family = AF_INET;
	listenerAddr.sin_port = htons(PORT);
	listenerAddr.sin_addr.s_addr = htonl(INADDR_ANY);

	bind(listener, (SOCKADDR*)&listenerAddr, sizeof(listenerAddr));
	listen(listener, SOMAXCONN);
}

void Chat(SOCKET target_client, string username) {
	while (true) {
		char buffer[PACKET_SIZE] = {};
		recv(target_client, buffer, PACKET_SIZE, 0);

		if (buffer[0] != NULL) {
			string buf(buffer);
			string temp = username + " : " + buf;
			char msg[PACKET_SIZE] = {};
			strcpy(msg, temp.c_str());
			cout << msg << '\n';
			for (int j = 0; j < clients.size(); j++) {
				send(clients[j].first, msg, strlen(msg), 0);
			}
		}
	}
}

void Accept() {
	while (true) {
		SOCKADDR_IN clientAddr = {};
		int clientSize = sizeof(clientAddr);
		SOCKET client = accept(listener, (SOCKADDR*)&clientAddr, &clientSize);

		char clientName[PACKET_SIZE] = {};
		recv(client, clientName, PACKET_SIZE, 0);
		clients.push_back(make_pair(client, clientName));
		cout << clientName << " Connected!\n";

		thread chat(Chat, client, clientName);
		chat.detach();
	}
}

int main() {
	WSAStartup(MAKEWORD(2, 2), &wsadata);

	Set();
	thread accept(Accept);
	accept.join();

	closesocket(listener);
	WSACleanup();
}