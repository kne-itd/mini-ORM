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
            string query = "INSERT INTO patient (patientName, dateOfBirth, animalType) " +
                "VALUES " +
                "(@patientName, @dateOfBirth, @animalType)";
            SqlCommand cmd = new SqlCommand(query, myConn);
            cmd.Parameters.AddWithValue("@patientName", patientName);
            cmd.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
            cmd.Parameters.AddWithValue("@animalType", animalType.AnimalTypeID);

            myConn.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine(query);
            myConn.Close();
        }
    }
}