using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace NormCase_OOP.Classes
{
    class Artikel : Database
    {
        public List <string> [] listAll()
        {
            string query = "SELECT * FROM artikel";

            //Create a list to store the result
            List< string >[] list = new List< string >[1];
            list[0] = new List< string >();

            //Open connection
            if (OpenConnection())
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, _connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
        
                //Read the data and store them in the list
                var i = 0;
                while (dataReader.Read())
                {
                    
                    list[i].Add(dataReader["artikel_id"] + "");
                    list[i].Add(dataReader["artikel_name"] + "");
                    i++;
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
        
        public List <string> [] searchArtikelName(string tmpSearchTerm)
        {
            //Create a list to store the result
            List< string >[] list = new List< string >[1];
            list[0] = new List< string >();


            //Open connection
            if (OpenConnection())
            {
                //Create Command
                MySqlCommand cmd = _connection.CreateCommand();
                
                cmd.CommandText = "SELECT * FROM artikel WHERE artikel_name LIKE @artikel_name";
                cmd.Parameters.Add("@artikel_name", MySqlDbType.VarChar).Value = "%"+tmpSearchTerm+"%";
                MySqlDataReader dataReader = cmd.ExecuteReader();
        
                //Read the data and store them in the list
                var i = 0;
                while (dataReader.Read())
                {
                    
                    list[i].Add(dataReader["artikel_id"] + "");
                    list[i].Add(dataReader["artikel_name"] + "");
                    i++;
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
        
        public List <string> [] searchArtikelID(int tmpSearchTerm)
        {
            //Create a list to store the result
            List< string >[] list = new List< string >[1];
            list[0] = new List< string >();


            //Open connection
            if (OpenConnection())
            {
                //Create Command
                MySqlCommand cmd = _connection.CreateCommand();
                
                cmd.CommandText = "SELECT * FROM artikel WHERE artikel_id LIKE @artikel_id";
                cmd.Parameters.Add("@artikel_id", MySqlDbType.VarChar).Value = "%"+tmpSearchTerm+"%";
                MySqlDataReader dataReader = cmd.ExecuteReader();
        
                //Read the data and store them in the list
                var i = 0;
                while (dataReader.Read())
                {
                    
                    list[i].Add(dataReader["artikel_id"] + "");
                    list[i].Add(dataReader["artikel_name"] + "");
                    i++;
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
        
        public bool InsertArtikel(string tmpArtikel)
        {
            try
            {
                if (this.OpenConnection())
                {
                    MySqlCommand cmd = _connection.CreateCommand();
            
                    cmd.CommandText = "INSERT INTO artikel(artikel_name) VALUES(@artikel_name)";
                    cmd.Parameters.Add("@artikel_name", MySqlDbType.VarChar).Value = tmpArtikel;
            
            
                    //Execute command
                    cmd.ExecuteNonQuery();
                    return true;
                }
                return false;
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
    }
}