import mysql.connector

class ConnDB:
    config = {
        'host': 'localhost',
        'port': 3306,
        'database': 'db_python',
        'user': 'root',
        'password': 'root',
        'charset': 'utf8',
        'use_unicode': True,
        'get_warnings': True,
    }
    db = 0
    cursor = 0

    def __init__(self):
        self.db = mysql.connector.Connect(**self.config)
        self.cursor = self.db.cursor()




