#pragma once

#include <iostream>
#include <mysql.h>
#include <string.h>
#include <string>

using namespace std;

class ConnDB
{
private:
    MYSQL* conn;
public:
    ConnDB();
    MYSQL* getConn();
};
