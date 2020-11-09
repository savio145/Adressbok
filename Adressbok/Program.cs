using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Progmetövning1
{

    public class person
    {
        public string namn;
        public string adress;
        public string telefon;
        public string email;

    }
    class Program
    {

        static void Main(string[] args)
        {

            string filePath = @"C:\Users\Savio\Desktop\adressbok.txt"; //Skriv filePath här 
            string command;
            string sparad;
            int nummer;

            Console.WriteLine("Adressbok");
            Console.WriteLine("-----------------");
            Console.WriteLine("välj en av följande:");
            Console.WriteLine("ny");
            Console.WriteLine("lista");
            Console.WriteLine("ta bort");
            Console.WriteLine("sluta");
            Console.WriteLine("-----------------");
            List<String> lines = File.ReadAllLines(filePath).ToList();
            do
            {
                Console.Write("> ");
                command = Console.ReadLine();
                if (command == "ny")
                {
                    person person = new person();
                    Console.Write("Namn: ");
                    person.namn = Console.ReadLine();
                    Console.Write("Adress: ");
                    person.adress = Console.ReadLine();
                    Console.Write("Telefon: ");
                    person.telefon = Console.ReadLine();
                    Console.Write("Email: ");
                    person.email = Console.ReadLine();

                    lines.Add($"{person.namn} {person.adress} {person.telefon} {person.email}");
                    File.WriteAllLines(filePath, lines);
                    Console.ReadLine();
                }
                else if (command == "lista")
                {
                    Console.WriteLine("Listan: ");
                    for (int i = 0; i < lines.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}: {lines[i]}");
                    }
                }
                else if (command == "ta bort")
                {
                    Console.WriteLine("Vilket nummer vill du ta bort?: ");
                    nummer = int.Parse(Console.ReadLine());
                    sparad = lines[nummer - 1];
                    lines.RemoveAt(nummer - 1);
                    Console.WriteLine($"Du tog bort {sparad}");
                    File.WriteAllLines(filePath, lines);
                }
            } while (command != "sluta");

            Console.ReadKey();
        }
    }
}