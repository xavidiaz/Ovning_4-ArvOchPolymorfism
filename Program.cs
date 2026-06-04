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
        Console.WriteLine("Start Washer.");
    }

    public void StopWash()
    {
        Console.WriteLine("Stop Washer.");
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
        Console.WriteLine("Start Cooling.");
    }

    public void StopCooling()
    {
        Console.WriteLine("Stop Cooling.");
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

    public void StartCooling()
    {
        Console.WriteLine("Start Cleaning.");
    }

    public void StopCleaning()
    {
        Console.WriteLine("Stop Cleaning.");
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
        Console.WriteLine("Start RobotVacuum.");
    }

    public void StopRobotVacuum()
    {
        Console.WriteLine("Stop RobotVacuum.");
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
        new Washer("Electrolux", 5000),
        new Refrigerator("Bosh", 3000),
        new Oven("Franke", 6000),
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
            // 2. Casta till rätt typ.
            // 3. Anropa rätt startmetod.
            // 4. Anropa rätt stoppmetod.
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
