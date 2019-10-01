using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ORM.Model
{
    public class Crud
    {
        private SqlConnection myConn;

        public Crud( SqlConnection c)
        {
            myConn = connection;
        }

        protected int Insert(string TableName, ArrayList values, List<string> keys)
        {
            string fieldnames = string.Join(",", keys);
            string parameters = "@" + string.Join(",@", keys);

            string query = "INSERT INTO " + TableName + " (" + fieldnames + ")  " +
                "VALUES " +
                "(" + parameters + ")";

            SqlCommand cmd = new SqlCommand(query, myConn);
            for (int i = 0; i < keys.Count; i++)
            {
                cmd.Parameters.AddWithValue("@" + keys[i], values[i]);
            }

            Console.WriteLine(query);
            myConn.Open();
            int modified = (int)cmd.ExecuteScalar();

            myConn.Close();
            return modified;
        }

        protected void Delete()
        {

        }

        protected void Update()
        {

        }
    }
}
