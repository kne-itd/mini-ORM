using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ORM.Model;


namespace ORM
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection conn = GetConnection();

            Patient patient = new Patient(conn);

            //           TestGet(patient);

            //            TestInsert(patient, conn);

            //            TestUpdate(patient);

            //            TestDelete(patient);
        }
        static void TestGet( Patient patient)
        {
            

            patient.PatientID = 36;
            patient.Get();
            Console.WriteLine(patient.PatientID);
            Console.WriteLine(patient.PatientName);
            Console.WriteLine(patient.DateOfBirth);
            Console.WriteLine(patient.AnimalType.AnimalTypeID);
            Console.WriteLine(patient.AnimalType.AnimalType);
        }

        static void TestInsert( Patient patient, SqlConnection conn)
        {
            patient.PatientName = "Fnuller";
            patient.DateOfBirth = new DateTime(2015, 12, 24);
            patient.AnimalType = new AnimalTypes(conn)
            {
                AnimalType = "Hund",
                AnimalTypeID = 1
            };
            patient.Save();
        }

        static void TestUpdate( Patient patient)
        {
            patient.PatientID = 37;
            patient.PatientName = "Bowwow";
            patient.DateOfBirth = new DateTime(2013, 5, 30);
            patient.Deceased = new DateTime(2018, 12, 31);

            List<string> propertiesToBeUpdate = new List<string>
            {
                "PatientName",
                "DateOfBirth",
                "Deceased"
            };

            patient.Update(propertiesToBeUpdate);
        }

        static void TestDelete (Patient patient)
        {
            patient.PatientID = 35;
            patient.Delete();
        }

        static SqlConnection GetConnection()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder()
            {
                InitialCatalog = "Vet",
                UserID = "Mac",
                Password = "1234",
                DataSource = "172.16.226.128"
            };

            SqlConnection conn = new SqlConnection(builder.ConnectionString);
            return conn;
        }
    }
}
