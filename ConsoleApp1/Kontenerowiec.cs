using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{


    public class Kontenerowiec
    {
        public List<Kontener> Containers { get; private set; }
        public int MaxSpeed { get; private set; }
        public int MaxContainers { get; private set; }
        public double MaxTotalWeight { get; private set; }

        public Kontenerowiec(int maxSpeed, int maxContainers, double maxTotalWeight)
        {
            Containers = new List<Kontener>();
            MaxSpeed = maxSpeed;
            MaxContainers = maxContainers;
            MaxTotalWeight = maxTotalWeight;
        }

        public void AddContainer(Kontener container)
        {
            if (Containers.Count < MaxContainers)
            {
                Containers.Add(container);
            }
            else
            {
                Console.WriteLine("Maksymalna liczba kontenerów.");
            }
        }

        public double CalculateTotalWeight()
        {
            double totalWeight = 0;
            foreach (Kontener container in Containers)
            {
                totalWeight += container.GetLoadWeight();
            }
            return totalWeight;
        }

    
        public bool IsReadyForVoyage()
        {
            if (CalculateTotalWeight() <= MaxTotalWeight)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void DropContener()
        {
            Console.WriteLine("Podaj numer seryjny kontenera do usunięcia (w formacie KON-X-Numer):");
            string id = Console.ReadLine(); 

            foreach (var container in Containers.ToList())  
            {
                if (id.Equals(container.SerialNumber))
                {
                    Containers.Remove(container); 
                    Console.WriteLine($"Kontener {id} został usunięty ze statku.");
                    return; 
                }
            }

            Console.WriteLine("Nie znaleziono kontenera o podanym numerze seryjnym na statku.");
        }
        public void ReplaceContainer(Kontener newContainer)
        {
            Console.WriteLine("Podaj numer seryjny kontenera, który chcesz zastąpić (w formacie KON-X-Numer):");
            string oldContainerId = Console.ReadLine();

            foreach (var container in Containers.ToList()) 
            {
                if (oldContainerId.Equals(container.SerialNumber))
                {
                    Containers.Remove(container); 
                    Containers.Add(newContainer); 
                    Console.WriteLine($"Kontener {oldContainerId} został zastąpiony nowym kontenerem.");
                    return; 
                }
            }

            Console.WriteLine("Nie znaleziono kontenera o podanym numerze seryjnym na statku.");
        }

        public void MoveContainer(Kontener container, Kontenerowiec targetShip)
        {
            if (Containers.Contains(container)) 
            {
                if (targetShip.Containers.Count < targetShip.MaxContainers) 
                {
                    Containers.Remove(container); 
                    targetShip.Containers.Add(container); 
                    Console.WriteLine($"Kontener {container.SerialNumber} został przeniesiony na inny statek.");
                }
                else
                {
                    Console.WriteLine("Docelowy statek ma już maksymalną liczbę kontenerów. Nie można przenieść kontenera.");
                }
            }
            else
            {
                Console.WriteLine("Podany kontener nie znajduje się na bieżącym statku. Nie można go przenieść.");
            }
        }


        public void PrintShipInfo()
        {
            Console.WriteLine($"Informacje o statku:");
            Console.WriteLine($"Maksymalna prędkość: {MaxSpeed} węzłów");
            Console.WriteLine($"Maksymalna liczba kontenerów: {MaxContainers}");
            Console.WriteLine($"Maksymalna waga ładunku: {MaxTotalWeight} ton\n");

            Console.WriteLine($"Ładunek na statku:");
            if (Containers.Count > 0)
            {
                foreach (Kontener container in Containers)
                {
                    Console.WriteLine($"Numer seryjny: {container.SerialNumber}");
                    Console.WriteLine($"Masa ładunku: {container.GetLoadWeight()} kg");
                    Console.WriteLine($"Wysokość: {container.Height} cm");
                    Console.WriteLine($"Waga własna: {container.OwnWeight} kg");
                    Console.WriteLine($"Głębokość: {container.Depth} cm");
                }
            }
            else
            {
                Console.WriteLine("Brak kontenerów na statku.");
            }
        }
    }
}