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
        Console.WriteLine("Wash energi xxx.");
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
        Console.WriteLine("Cooling energi xxx.");
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
        Console.WriteLine("Cleaning energi xxx.");
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
        Console.WriteLine("RobotVacuum energi xxx");
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
        new Washer("LG", 5000),
        new Refrigerator("Samsung", 3000),
        new Oven("Elextrolux", 6000),
        new RobotVacuum("Xiamomi", 500),
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
            // 2. Casta till rätt typ.
            // 3. Anropa rätt energimetod.
        }
    }
}
