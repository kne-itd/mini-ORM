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
        private AnimalTypes animalType;

        private SqlConnection myConn;

        public int PatientID
        {
            get
            {
                return patientID;
            }
            set
            {
                patientID = value;
            }
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
        public AnimalTypes AnimalType
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
            myConn = c;
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

            int newID = Insert(tableName, Values, keys, "patientId");
            Console.WriteLine(newID);
        }

        public void Delete()
        {
            string tableName = "patient";
            base.Delete(tableName, "patientId", patientID);

        }

        public void Update(List<string> keys)
        {
            string tableName = "patient";
            ArrayList Values = new ArrayList();
            foreach(string item in keys)
            {   
                Values.Add( this.GetType().GetProperty(item).GetValue(this, null));
            }

            base.Update(tableName, Values, keys, "patientId", patientID.ToString());
        }

        public void Get()
        {
            string tableName = "patient";

            SqlDataReader reader = Read(tableName, "patientId", patientID.ToString());

            animalType = new AnimalTypes(myConn);
            while (reader.Read())
            {
                patientID = reader.GetInt32(0);
                patientName = reader.GetString(1);
                dateOfBirth = reader.GetDateTime(2);
                
                animalType.AnimalTypeID = reader.GetInt32(4);
            }
            reader.Close();
            animalType.Get();
        }
    }
}