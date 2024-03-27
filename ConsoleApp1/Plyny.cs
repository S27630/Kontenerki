using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Plyny : Kontener
    {
        public double LiquidCapacity { get; private set; }
        public bool IsDanger { get; private set; }

        public Plyny(double loadWeight, double height, double ownWeight, double depth, double maxPayload, double liquidCapacity, bool isDanger)
            : base(loadWeight, height, ownWeight, depth, maxPayload)
        {
            LiquidCapacity = liquidCapacity;
            IsDanger = isDanger;
        }



        protected override string GenerateContainerType()
        {
            return "L";
        }

        public override void Load(double cargoWeight)
        {
            base.Load(cargoWeight);
            if (IsDanger)
            {
                if (LoadWeight > MaxPayload * 0.5)
                {
                    NotifyDanger(SerialNumber);
                    return;
                }
            }
            else
            {
                if (LoadWeight > MaxPayload * 0.9)
                {
                    NotifyDanger(SerialNumber);
                    return;
                }
            }
        }
        public void PrintContainerInfo()
        {
            Console.WriteLine($"Informacje o kontenerze płynów:");
            Console.WriteLine($"Numer seryjny: {SerialNumber}");
            Console.WriteLine($"Masa ładunku: {LoadWeight} kg");
            Console.WriteLine($"Wysokość: {Height} cm");
            Console.WriteLine($"Waga własna: {OwnWeight} kg");
            Console.WriteLine($"Głębokość: {Depth} cm");
            Console.WriteLine($"Pojemność płynów: {LiquidCapacity} L");
            Console.WriteLine($"Czy ładunek jest niebezpieczny: {IsDanger}");
            Console.WriteLine();
        }
    }
}