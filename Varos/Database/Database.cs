using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Varos.Models;

namespace Varos.Database
{
    public class Database
    {

        public static MySqlConnection GetConnection()
        {
            string connectionString = "Server=localhost;Database=Tomegkozlekedes;User ID=root;Password=;";


            MySqlConnection conn = new MySqlConnection(connectionString);

          

            return conn;
        }

        public static void CreateDatabase() {

            MySqlConnection conn = GetConnection();
            conn.Open();
            Console.WriteLine("jó");

            string command = "CREATE TABLE IF NOT EXISTS GyorsVasut (\r\n    km INT\r\n);\r\n\r\nCREATE TABLE IF NOT EXISTS Roller (\r\n    km INT\r\n);\r\n\r\nCREATE TABLE IF NOT EXISTS VonalBusz (\r\n    km INT\r\n);\r\n";
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = command;
            cmd.ExecuteNonQuery();
            conn.Close();
            
        }


        public static void AddData()
        {
            MySqlConnection conn = GetConnection();
            conn.Open();
            Console.WriteLine("adja meg a busz kilométert");
            int busz=int.Parse(Console.ReadLine());
            Console.WriteLine("adja meg a vonat km-t");
            int vasut=int.Parse((Console.ReadLine()));
            Console.WriteLine("adja meg a roller km-t");
            int roller = int.Parse(Console.ReadLine());

            string command = $"INSERT INTO `gyorsvasut`(`km`) VALUES ('{vasut}');" +
                $"INSERT INTO `roller`(`km`) VALUES ('{roller}');" +
                $"INSERT INTO `vonalbusz`(`km`) VALUES ('{busz}');";
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = command;
            cmd.ExecuteNonQuery();
            Console.WriteLine("sikeresen hozzáadva");


            conn.Close();
        }



        public static void SelectData()
        {
            MySqlConnection conn = GetConnection();
            conn.Open();

            string selectvasut = "SELECT `km` FROM `gyorsvasut`";

            MySqlCommand cmd= new MySqlCommand(selectvasut, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            List<int> vasutkms=new List<int>();
            List<Utazas> utazasok=new List<Utazas>();
            while (reader.Read())
            {
                int vasutkm=reader.GetInt32(0);
                vasutkms.Add(vasutkm);  
            }
            foreach (int i in vasutkms)
            {
                utazasok.Add(new GyorsVasut() { Km = i });
            }


            Console.WriteLine("Vasúti utazások száma!");

            foreach(Utazas utazas in utazasok)
            {
                Console.WriteLine(utazas.arSzamitas());
            }





            conn.Close();
        }

        

    }
}
