using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;

namespace NormCase_OOP.Classes
{
    class DbConnect
    {
        private MySqlConnection _connection;
        private string _server;
        private string _database;
        private string _uid;
        private string _password;

        //Constructor
        public DbConnect()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            _server = "localhost";
            _database = "normcase_oop";
            _uid = "root";
            _password = "";
            string connectionString;
            connectionString = "SERVER=" + _server + ";" + "DATABASE=" + 
                               _database + ";" + "UID=" + _uid + ";" + "PASSWORD=" + _password + ";";

            _connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                _connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                _connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //Insert statement
        public void InsertKunde(string tmpUsername, string tmpPassword, string tmpCredit)
        {
            try
            {
            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = _connection.CreateCommand();
                
                cmd.CommandText = "INSERT INTO kunden(username, passwd, Creditcard) VALUES(?username,?passwd,?creditcard)";
                cmd.Parameters.Add("?username", MySqlDbType.VarChar).Value = tmpUsername;
                cmd.Parameters.Add("?passwd", MySqlDbType.VarChar).Value = tmpPassword;
                cmd.Parameters.Add("?creditcard", MySqlDbType.VarChar).Value = tmpCredit;
                
                //Execute command
                cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.CloseConnection();
            }
            
        }
        public void InsertArtikel(string tmpArtikel)
        {
            string query = "INSERT INTO artikel (Artikel_name) VALUES(tmpArtikel)";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, _connection);
        
                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Select statement
        public List <string> [] Select()
        {
            string query = "SELECT * FROM artikel";

            //Create a list to store the result
            List< string >[] list = new List< string >[3];
            list[0] = new List< string >();
            list[1] = new List< string >();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, _connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
        
                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["artikel_id"] + "");
                    list[1].Add(dataReader["Artikel_name"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }
    }
}