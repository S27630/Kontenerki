
using ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        //Przykładowe kontenery i ich opis
        Plyny plyny1 = new Plyny(1000, 200, 50, 150, 2000, 500, false);
        Plyny plyny2 = new Plyny(1500, 180, 60, 140, 2500, 700, true);
        Plyny plyny3 = new Plyny(1200, 190, 55, 160, 2200, 600, false);

        //Do zamiany
        Plyny plyny4 = new Plyny(1100, 210, 55, 170, 2300, 650, false);


        plyny1.PrintContainerInfo();
        plyny2.PrintContainerInfo();
        plyny3.PrintContainerInfo();

        //Stworzenie kontenera oraz dodanie załadowanie go 
        Kontenerowiec kontenerowiec = new Kontenerowiec(100, 100, 100000);

        Kontenerowiec kontenerowiec1 = new Kontenerowiec(100, 100, 10000);

        kontenerowiec.AddContainer(plyny1);
        kontenerowiec.AddContainer(plyny2);
        kontenerowiec.AddContainer(plyny3);


    
        //info
        kontenerowiec.PrintShipInfo();

        //usuniecie kontenera
        kontenerowiec.DropContener();

        //info po usnięciu 
        kontenerowiec.PrintShipInfo();

        //zastąpienie kontenera innym
        kontenerowiec.ReplaceContainer(plyny4);

        //into po zastąpieniu
        kontenerowiec.PrintShipInfo();

        //przesuniecie konterenra
        kontenerowiec.MoveContainer(plyny1, kontenerowiec1);

        kontenerowiec1.PrintShipInfo();


    }
}