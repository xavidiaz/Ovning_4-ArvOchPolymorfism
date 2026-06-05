using System;
using System.Collections.Generic;

public class Washer
{
    public string Brand { get; }
    public double CapacityKg { get; }

    public Washer(string brand, double capacityKg)
    {
        Brand = brand;
        CapacityKg = capacityKg;
    }
    public void StartWash()
    {
        Console.WriteLine($"{Brand} washer starts washing.");
    }

    public void StopWash()
    {
        Console.WriteLine($"{Brand} washer stops washing.");
    }

    public void PrintWashEnergy()
    {
        Console.WriteLine($"{Brand} Washer uses 1.2 kwh per wash.");
    }
}

public class Refrigerator
{
    public string Brand { get; }
    public double Temperature { get; }

    public Refrigerator(string brand, double temperature)
    {
        Brand = brand;
        Temperature = temperature;
    }

    public void StartCooling()
    {
        Console.WriteLine($"{Brand} refrigerator starts cooling.");
    }

    public void StopCooling()
    {
        Console.WriteLine($"{Brand} refrigerator stops cooling.");
    }

    public void PrintCoolingEnergy()
    {
        Console.WriteLine($"{Brand} refrigerator uses 3.6 kwh per day.");
    }
}

public class Oven
{
    public string Brand { get; }
    public double MaxTemperature { get; }

    public Oven(string brand, double maxtemperature)
    {
        Brand = brand;
        MaxTemperature = maxtemperature;
    }

    public void StartHeating()
    {
        Console.WriteLine($"{Brand} oven starts heating.");
    }

    public void StopHeating()
    {
        Console.WriteLine($"{Brand} oven stops heating.");
    }

    public void PrintCleaningEnergy()
    {
        Console.WriteLine($"{Brand} oven uses 2.5 kwh per hour.");
    }
}

public class RobotVacuum
{
    public string Brand { get; }
    public double BatteryLevel { get; }

    public RobotVacuum(string brand, double batteryLevel)
    {
        Brand = brand;
        BatteryLevel = batteryLevel;
    }

    public void StartRobotVacuum()
    {
        Console.WriteLine($"{Brand} robot vacuum starts cleaning.");
    }

    public void StopRobotVacuum()
    {
        Console.WriteLine($"{Brand} robot vacuum stops cleaning");
    }

    public void PrintRobotVacuumEnergy()
    {
        Console.WriteLine($"{Brand} robot vacuum uses 0.4 kwh per cleaning.");
    }
}

class Program
{
    static void Main()
    {
        // TODO:
        // Skapa minst fyra objekt:
        // Washer, Refrigerator, Oven och RobotVacuum.
        // Lägg till dem i listan devices.

        List<object> devices = new List<object>()
        {
        new Washer("LG", 1.2),
        new Refrigerator("Samsung", 3.6),
        new Oven("Elextrolux", 2.5),
        new RobotVacuum("Xiamomi", 0.4),
        };

        RunMorningRoutine(devices);
        Console.WriteLine();
        ReportAllEnergy(devices);
    }

    static void RunMorningRoutine(List<object> devices)
    {
        foreach (object device in devices)
        {
            // TODO:
            // 1. Kontrollera vilken typ device är.
            object deviceType = device.GetType().Name;
            // 2. Casta till rätt typ.
            // 3. Anropa rätt startmetod.
            // 4. Anropa rätt stoppmetod.
            switch (deviceType)
            {
                case "Washer":
                    if (device is Washer washer)
                    {
                        washer.StartWash();
                        washer.StopWash();
                    }
                    break;
                case "Refrigerator":
                    if (device is Refrigerator refrigerator)
                    {
                        refrigerator.StartCooling();
                        refrigerator.StartCooling();
                    }
                    break;
                case "Oven":
                    if (device is Oven oven)
                    {
                        oven.StartHeating();
                        oven.StartHeating();
                    }
                    break;
                case "RobotVacuum":
                    if (device is RobotVacuum robotVacuum)
                    {
                        robotVacuum.StartRobotVacuum();
                        robotVacuum.StopRobotVacuum();
                    }
                    break;
                default:
                    Console.WriteLine("Unkknown deviceType!");
                    break;
            }


        }
    }

    static void ReportAllEnergy(List<object> devices)
    {
        foreach (object device in devices)
        {
            // TODO:
            // 1. Kontrollera vilken typ device är.
            object deviceType = device.GetType().Name;

            // 2. Casta till rätt typ.
            // 3. Anropa rätt energimetod.
            switch (deviceType)
            {
                case "Washer":
                    if (device is Washer washer)
                    {
                        washer.PrintWashEnergy();
                    }
                    break;
                case "Refrigerator":
                    if (device is Refrigerator refrigerator)
                    {
                        refrigerator.PrintCoolingEnergy();
                    }
                    break;
                case "Oven":
                    if (device is Oven oven)
                    {
                        oven.PrintCleaningEnergy();
                    }
                    break;
                case "RobotVacuum":
                    if (device is RobotVacuum robotVacuum)
                    {
                        robotVacuum.PrintRobotVacuumEnergy();
                    }
                    break;
                default:
                    Console.WriteLine("Unkknown deviceType!");
                    break;
            }
        }
    }
}
// FRÅGÅR
// 1. Varför behövde du kontrollera vilken typ varje objekt hade?
// För att Anropa rött metod
//
// 2. Vad händer om du lägger till en ny klass CoffeeMachine?
// Inget om vi inte addera ny 'device' i listan och ny 'case' i 'RunMorningRoutine()'.
// 
// 3. Vilka metoder måste du ändra om du lägger till CoffeeMachine?
// Inget att ändra. Det ska skappas nya metoder och addera 'cases'. Vi inte återanvända kod ens.
//
// 4. Vad är problemet med att listan är List<object>?
// Att vi vet inte vad är för var är för typ object. Det är Generic, skulle vara mer uidiomatisk me 'List<Washer>' för exempel.
//
// 5. Vad händer om du råkar glömma en apparattyp i ReportAllEnergy()?
// Det kommer inte att printas ut. Etersom decice typer är liksom hardkoddad.
