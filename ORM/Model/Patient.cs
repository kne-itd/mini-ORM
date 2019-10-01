using System;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;

namespace ORM.Model
{
    public class Patient : Crud
    {
        private int patientID;
        private string patientName;
        private DateTime dateOfBirth;
        private DateTime deceased;
        private DateTime created;
        private AnimalType animalType;

        private SqlConnection myConn;

        public int PatientID
        {
            get;
            set;
        }
        public string PatientName
        {
            get
            {
                return patientName;
            }
            set
            {
                // tjek længden på navnet
                patientName = value;
            }
        }
        public DateTime DateOfBirth
        {
            get
            {
                return dateOfBirth;
            }
            set
            {
                dateOfBirth = value;
            }
        }
        public AnimalType AnimalsType
        {
            get
            {
                return animalType;
            }
            set
            {
                animalType = value;
            }
        }
        public DateTime Deceased
        {
            get;
            set;
        }
        public DateTime Created
        {
            get;
        }

        public Patient(SqlConnection c) : base(c)
        {
        //    myConn = c;
        }

        public void Save()
        {
            string tableName = "patient";

            ArrayList Values = new ArrayList()
            {
                patientName,
                dateOfBirth,
                animalType.AnimalTypeID
            };

            List<string> keys = new List<string>
            {
                "patientName",
                "dateOfBirth",
                "animaltype"
            };

            int newID = Insert(tableName, Values, keys);
            Console.WriteLine(newID);
        }

 /*       private int Zzz(string TableName, ArrayList values, List<string> keys)
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
        */
    }
}