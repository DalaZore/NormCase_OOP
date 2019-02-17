using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;

namespace NormCase_OOP.Classes
{
    class Database
    {
        protected MySqlConnection _connection;
        private string _server;
        private string _database;
        private string _uid;
        private string _password;

        //Constructor
        public Database()
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
            string connectionString = "SERVER=" + _server + ";" + "DATABASE=" + 
                               _database + ";" + "UID=" + _uid + ";" + "PASSWORD=" + _password + ";";

            _connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        protected bool OpenConnection()
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
        protected bool CloseConnection()
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

        //Login
        public bool LoginUser(string tmpUsername, string tmpPassword)
        {
            try
            {
                if (this.OpenConnection())
                {
                    MySqlCommand cmd = _connection.CreateCommand();
                
                    cmd.CommandText = "SELECT username,passwd FROM kunden WHERE username = @username AND passwd = @passwd";
                    cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = tmpUsername;
                    cmd.Parameters.Add("@passwd", MySqlDbType.VarChar).Value = tmpPassword;
                
                    //Execute command
                    MySqlDataReader dr = cmd.ExecuteReader();

                    return dr.HasRows;
                }
                else
                {
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                this.CloseConnection();
                
                
            }
        }
        
        //Insert statement
        public void InsertKunde(string tmpUsername, string tmpPassword, string tmpCredit)
        {
            try
            {
            //open connection
            if (this.OpenConnection())
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = _connection.CreateCommand();
                
                cmd.CommandText = "INSERT INTO kunden(username, passwd, Creditcard) VALUES(@username,@passwd,@creditcard)";
                cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = tmpUsername;
                cmd.Parameters.Add("@passwd", MySqlDbType.VarChar).Value = tmpPassword;
                cmd.Parameters.Add("@creditcard", MySqlDbType.VarChar).Value = tmpCredit;
                
                
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
    }
}