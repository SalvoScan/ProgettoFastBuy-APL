#include "ConnDB.h"

ConnDB::ConnDB() {
	conn = mysql_init(0);
	conn = mysql_real_connect(conn, "localhost", "root", "root", "db_cpp", 3306, NULL, 0);
	if (!conn) {
		cout << "Connessione Database Fallita" << endl;
		ExitProcess(EXIT_FAILURE);
	}
	cout << "Connessione Database Riuscita" << endl;
}

MYSQL* ConnDB::getConn() {
	return conn;
}