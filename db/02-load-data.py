# -*- coding: utf-8 -*-

import sys
import psycopg2

DB_NAME = "usda_sr28_test"
DB_USERNAME = sys.argv[1]
DB_PASSWORD = sys.argv[2]

try:
  DB_CONNECTION = psycopg2.connect(dbname=DB_NAME, user=DB_USERNAME, password=DB_PASSWORD)
except:
    print "I am unable to connect to the database."

def clean(record):
    """
    Removes ~ characters and replaces any missing data
    with NULL.

    Returns: single string containing comma separated values
    """
    values = record.rstrip().replace("'", r"''").replace("~", "").split("^")
    for i in range(len(values)):
        if not values[i]:
            values[i] = r'NULL'
        else:
            values[i] = r"'"+values[i]+"'"
    return ','.join(values)

def execute(sql):
    """Executes provided sql statement"""
    try:
        with DB_CONNECTION.cursor() as curs:
            curs.execute('SET client_encoding=latin1')
            curs.execute(sql)
        DB_CONNECTION.commit()
    except psycopg2.Error as error:
        print("")
        print("There was a problem with the following sql")
        print(sql)
        print(error)
        print("")
        raise

def insert_record(table, record):
    """
    Inserts data into provided table

    It is assumed that the data provided matches the columns in the table.
    """
    execute("INSERT INTO {} VALUES ({});".format(table, clean(record)))

def load_data_from_file(filepath, tablename):
    """
    Loads data from a file into a table
    """
    with open(filepath) as datafile:
        for line in datafile:
            insert_record(tablename, line)

print("loading FD_GROUP...")
load_data_from_file("./data/FD_GROUP.txt", "Fd_Group")

print("loading FOOD_DES...")
load_data_from_file("./data/FOOD_DES.txt", "Food_Des")

print("loading DATA_SRC...")
load_data_from_file("./data/DATA_SRC.txt", "Data_Src")

print("loading DERIV_CD...")
load_data_from_file("./data/DERIV_CD.txt", "Deriv_Cd")

print("loading FOOTNOTE...")
load_data_from_file("./data/FOOTNOTE.txt", "Footnote")

print("loading LANGDESC...")
load_data_from_file("./data/LANGDESC.txt", "Langdesc")

print("loading WEIGHT...")
load_data_from_file("./data/WEIGHT.txt", "Weight")

print("loading NUTR_DEF...")
load_data_from_file("./data/NUTR_DEF.txt", "Nutr_Def")

print("loading LANGUAL...")
load_data_from_file("./data/LANGUAL.txt", "Langual")

print("loading SRC_CD...")
load_data_from_file("./data/SRC_CD.txt", "Src_Cd")

print("loading DATSRCLN...(this one is a little bigger, so it takes a moment)...")
load_data_from_file("./data/DATSRCLN.txt", "Dat_Src_Lnk")

print("loading NUT_DATA...(this is the largest file, so it takes a moment too)...")
load_data_from_file("./data/NUT_DATA.txt", "Nut_Data")

DB_CONNECTION.close()
