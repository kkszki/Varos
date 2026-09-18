using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Varos.Database;
using Varos.Models;


namespace Varos
{
    internal class Program
    {
        static List<Utazas> utazas = new List<Utazas>();
        static void Main(string[] args)
        {

            //2. feladat
            // Város Közösségi..
            utazas.Add(new VonalBusz() {Km=30});
            utazas.Add(new Roller() { Km=10});
            utazas.Add(new GyorsVasut() {Km=120});
            int ossz = 0;
            foreach (Utazas utazas in utazas) {
                int ut = utazas.arSzamitas();
                Console.WriteLine($"Teljes út: {ut}");
                ossz += ut;
            }
            Console.WriteLine($"Összbevétel: {ossz}");

            Database.Database.CreateDatabase();
            Console.WriteLine("adjunk az adatbázishoz adatot!");
            Database.Database.AddData();

        }

    }
}

