using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ORM.Model
{
    public class Crud
    {
        private SqlConnection myConn;

        public Crud( SqlConnection connection)
        {
            myConn = connection;
        }

        protected int Insert(string TableName, ArrayList values, List<string> keys)
        {
            string fieldnames = string.Join(",", keys);
            string parameters = "@" + string.Join(",@", keys);

            string query = "INSERT INTO " + TableName + " (" + fieldnames + ") output INSERTED.patientID " +
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

        protected void Delete(string TableName, string key, int value)
        {
            string query = "DELETE FROM " + TableName + " WHERE " + key + " = @value";
            SqlCommand cmd = new SqlCommand(query, myConn);
            cmd.Parameters.AddWithValue("@value", value);
            myConn.Open();
            cmd.ExecuteNonQuery();
            myConn.Close();

        }

        protected void Update(string TableName, ArrayList values, List<string> keys, string key, string value)
        {
            string query = "UPDATE " + TableName + " SET ";
            int l = values.Count;

            for (int i = 0; i < l; i++)
            {
                query += keys[i] + " = @" + keys[i] + ",";
            }
            char[] charToBeRemoved = { ',' };
            query = query.TrimEnd(charToBeRemoved);
            query += " WHERE " + key + "=" + value;

            SqlCommand cmd = new SqlCommand(query, myConn);
            for (int i = 0; i < l; i++)
            {
                cmd.Parameters.AddWithValue("@" + keys[i], values[i]);
            }
            myConn.Open();
            cmd.ExecuteNonQuery();
            myConn.Close();

        }
    }
}
