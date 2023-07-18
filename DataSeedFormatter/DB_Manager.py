from DataSeedFormatter import aspect_data as aspects 
import sqlite3 

# connect to our testing database
connection = sqlite3.connect("V:\MAUI_db_testing\d4aspect_TESTING.db")

# establish a cursor
cursor = connection.cursor()


# insert formatted seed data into test db
cursor.executemany("""INSERT INTO d4aspect (AspectName , AspectType , AspectCategory, MinRangeValue, MaxRangeValue , StaticValue) 
                VALUES(? , ? , ? , ? , ? , ?)""" , aspects)


connection.commit()
