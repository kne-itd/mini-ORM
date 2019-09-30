using System;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;

namespace ORM.Model
{
    public class Patient
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

        public Patient(SqlConnection c)
        {
            myConn = c;
        }

        public void Save()
        {
            string tableName = "patient";

            // create lists
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
            
            string fieldnames = string.Join(",", keys);
            string parameters = "@" + string.Join(",@", keys);

            string query = "INSERT INTO " + tableName + " (" + fieldnames + ") " +
                "VALUES " +
                "(" + parameters + ")";

            SqlCommand cmd = new SqlCommand(query, myConn);
            for (int i = 0; i < keys.Count; i++)
            {
                Console.WriteLine(keys[i]);
                Console.WriteLine(Values[i]);
                cmd.Parameters.AddWithValue("@" + keys[i], Values[i]);
            }

            Console.WriteLine(query);
            myConn.Open();
            cmd.ExecuteNonQuery();
            myConn.Close();

        }


    }
}
