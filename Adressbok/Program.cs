using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.ExceptionServices;

namespace Progmetövning1
{
    class Program
    {

        static void Main(string[] args)
        {
            string filePath = @"C:\Users\Savio\Desktop\adressbok.txt";
            string namn;
            string adress;
            string telefon;
            string email;
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
                    Console.Write("Namn: ");
                    namn = Console.ReadLine();
                    Console.Write("Adress: ");
                    adress = Console.ReadLine();
                    Console.Write("Telefon: ");
                    telefon = Console.ReadLine();
                    Console.Write("Email: ");
                    email = Console.ReadLine();

                    lines.Add($"{namn} {adress} {telefon} {email}");
                    File.WriteAllLines(filePath, lines);

                    Console.ReadLine();
                }
                else if (command == "lista")
                {
                    Console.WriteLine("Listan: ");
                    for (int i = 0; i < lines.Count; i++)    
                    {
                        Console.WriteLine($"{i+1}: {lines [i]}");
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



//C:\Users\Savio\Desktop\adressbok.txt