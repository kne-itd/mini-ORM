using System;
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
            patient.PatientName = "Fnuller";
            patient.DateOfBirth = new DateTime(2015, 12, 24);
            patient.AnimalsType = new AnimalType {
                AnimalTypeName = "Hund",
                AnimalTypeID = 1
            };

            patient.Save();
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
