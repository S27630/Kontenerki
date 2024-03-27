namespace ConsoleApp1
{
    public class Gaz : Kontener
    {

        public Gaz(double loadWeight, double height, double ownWeight, double depth, double maxPayload)
            : base(loadWeight, height, ownWeight, depth, maxPayload)
        {
        }

        protected override string GenerateContainerType()
        {
            return "G";
        }

        public override void Load(double cargoWeight)
        {
            base.Load(cargoWeight);
            if (LoadWeight > (MaxPayload * 0.5))
                NotifyDanger(SerialNumber);
        }

        public override void Unload()
        {
            base.Unload();
        }
        public void PrintContainerInfo()
        {
            Console.WriteLine($"Informacje o kontenerze:");
            Console.WriteLine($"Numer seryjny: {SerialNumber}");
            Console.WriteLine($"Masa ładunku: {LoadWeight} kg");
            Console.WriteLine($"Wysokość: {Height} cm");
            Console.WriteLine($"Waga własna: {OwnWeight} kg");
            Console.WriteLine($"Głębokość: {Depth} cm");
            Console.WriteLine();
        }
    }
}