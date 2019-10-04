using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace ORM.Model
{
    public class AnimalTypes : Crud
    {
        private int animalTypeID;
        private string animalType;

        private string tableName = "animaltype";
        public int AnimalTypeID
        {
            get
            {
                return animalTypeID;
            }
            set
            {
                animalTypeID = value;
            }
        }
        public string AnimalType
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

        public AnimalTypes(SqlConnection c) : base(c)
        {
        }

        public void Save()
        {
            ArrayList Values = new ArrayList()
            {
                animalType,
            };

            List<string> keys = new List<string>
            {
                "animalType",
            };

            int newID = Insert(tableName, Values, keys, "animaltypeID");
            Console.WriteLine(newID);
        }
        public void Delete()
        {
            base.Delete(tableName, "animalTypeID", animalTypeID);
        }

        public void Update(List<string> keys)
        {
            ArrayList Values = new ArrayList();
            foreach (string item in keys)
            {
                Values.Add(this.GetType().GetProperty(item).GetValue(this, null));
            }

            base.Update(tableName, Values, keys, "animalTypeID", animalTypeID.ToString());
        }

        public void Get()
        {
            SqlDataReader reader = Read(tableName, "animaltypeID", AnimalTypeID.ToString());

            while (reader.Read())
            {
                AnimalTypeID = reader.GetInt32(0);
                animalType = reader.GetString(1);
            }

            reader.Close();
        }
    }
}
