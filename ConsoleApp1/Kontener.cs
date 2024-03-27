using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class Kontener
    {
        public double LoadWeight { get; private set; }
        public double Height { get; private set; }
        public double OwnWeight { get; private set; }
        public double Depth { get; private set; }
        public string SerialNumber { get; private set; }
        public double MaxPayload { get; private set; }

        private static int serialNumberCounter = 1;

        public Kontener(double loadWeight, double height, double ownWeight, double depth, double maxPayload)
        {
            LoadWeight = loadWeight;
            Height = height;
            OwnWeight = ownWeight;
            Depth = depth;
            MaxPayload = maxPayload;
            SerialNumber = GenerateSerialNumber();
        }


        private string GenerateSerialNumber()
        {
            string serial = "KON-";
            serial += GenerateContainerType();
            serial += "-";
            serial += serialNumberCounter.ToString();
            serialNumberCounter++;
            return serial;
        }

        protected abstract string GenerateContainerType();

        public virtual void Load(double cargoWeight)
        {
            if (cargoWeight > MaxPayload)
                throw new OverfillExeption("Masa ładunku przekracza maksymalną ładowność kontenera.");

            LoadWeight = cargoWeight;
        }

        public virtual void Unload()
        {
            LoadWeight = 0;
        }

        public virtual void NotifyDanger(string containerSerialNumber)
        {
            Console.WriteLine($"Niebezpieczna operacaja w konterzene nr: {containerSerialNumber}");
        }

        public double GetLoadWeight()
        {
            return LoadWeight;
        }


    }
}