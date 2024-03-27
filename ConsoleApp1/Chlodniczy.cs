using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Chlodniczy : Kontener
    {
        public string Rodzaj { get; private set; }
        public int Temp { get; private set; }

        public Chlodniczy(double loadWeight, double height, double ownWeight, double depth, double maxPayload, string rodzaj, int temp)
            : base(loadWeight, height, ownWeight, depth, maxPayload)
        {
            Rodzaj = rodzaj;
            Temp = temp;

        }

        protected override string GenerateContainerType()
        {
            return "B";
        }
        public void PrintContainerInfo()
        {
            Console.WriteLine($"Informacje o kontenerze chłodniczym:");
            Console.WriteLine($"Numer seryjny: {SerialNumber}");
            Console.WriteLine($"Masa ładunku: {LoadWeight} kg");
            Console.WriteLine($"Wysokość: {Height} cm");
            Console.WriteLine($"Waga własna: {OwnWeight} kg");
            Console.WriteLine($"Głębokość: {Depth} cm");
            Console.WriteLine($"Przewożony towar: {Rodzaj}");
            Console.WriteLine($"Temperatura: {Temp}°C");
            Console.WriteLine();
        }
    }
}