using System;
using System.Collections.Generic;

public class Appliance
{
    public string Brand { get; }
    public string Room { get; }
    public bool IsOn { get; protected set; }

    public Appliance(string brand, string room)
    {
        Brand = brand;
        Room = room;
    }

    public virtual string GetInfo()
    {
        return $"{Brand} in {Room} room";
    }

    public virtual void TurnOn()
    {
        IsOn = true;
    }

    public virtual void TurnOff()
    {
        IsOn = false;
        Console.WriteLine($"{Brand} has stopped.");
    }

    public virtual double GetDailyEnergyUsage()
    {
        // Returnera 0 som standardvärde.
        return 0;
    }
}

public class Washer : Appliance
{
    public double CapacityKg { get; }

    public Washer(string brand, string room = "No assigned.", double capacityKg = 0) : base(brand, room)
    {
        CapacityKg = capacityKg;
    }

    public override string GetInfo()
    {
        return $"{Brand} washer ({CapacityKg} kg) in {Room})";
    }

    public override void TurnOn()
    {
        base.TurnOn();
        Console.WriteLine($"{Brand} washer starts washing program.");
    }

    public override void TurnOff()
    {
        base.TurnOff();
        Console.WriteLine($"{Brand} washer finished washing program.");
    }
    public override double GetDailyEnergyUsage()
    {
        return 1.2;
    }
}

public class Refrigerator : Appliance
{
    public double Temperature { get; }

    public Refrigerator(string brand, string room = "No assigned.", double temperature = 0) : base(brand, room)
    {
        Temperature = temperature;
    }

    public override string GetInfo()
    {
        return $"{Brand} refrigerator ({Temperature} C) in room {Room}";
    }

    public override void TurnOn()
    {
        base.TurnOn();
        Console.WriteLine($"{Brand} refrigerator starts cooling.");
    }

    public override void TurnOff()
    {
        base.TurnOff();
        Console.WriteLine($"{Brand} refrigerator stops cooling.");
    }

    public override double GetDailyEnergyUsage()
    {
        return 3.6;
    }
}

public class Oven : Appliance
{
    public double MaxTemperature { get; }

    public Oven(string brand, string room = "No assigned.", double maxtemperature = 0) : base(brand, room)
    {
        MaxTemperature = maxtemperature;
    }

    public override string GetInfo()
    {
        return $"{Brand} oven (Max temperature {MaxTemperature} C) in room {Room}";
    }
    public override void TurnOn()
    {
        base.TurnOn();
        Console.WriteLine($"{Brand} oven starts heating");
    }

    public override void TurnOff()
    {
        base.TurnOff();
        Console.WriteLine($"{Brand} oven is stops heating");
    }

    public override double GetDailyEnergyUsage()
    {
        return 2.5;
    }
}

public class RobotVacuum : Appliance
{
    public double BatteryLevel { get; }

    public RobotVacuum(string brand, string room = "No assigned.", double batteryLevel = 0) : base(brand, room)
    {
        BatteryLevel = batteryLevel;
    }

    public override string GetInfo()
    {
        return $"{Brand} robot vacuum (batteryLevel = {BatteryLevel}) is in room {Room}";
    }

    public override void TurnOn()
    {
        base.TurnOn();
        Console.WriteLine($"{Brand} robot vacuum is starting.");
    }

    public override void TurnOff()
    {
        base.TurnOff();
        Console.WriteLine($"{Brand} robot vacuum is stopping.");
    }

    public override double GetDailyEnergyUsage()
    {
        return 0.4;
    }
}


public class CoffeeMachine : Appliance
{
    public double CupsPerBrew { get; }

    public CoffeeMachine(string brand, string room = "No assigned.", int cups = 0) : base(brand, room)
    {
        CupsPerBrew = cups;
    }

    public override string GetInfo()
    {
        return $"{Brand} coffe machine ({CupsPerBrew} per brew) in room {Room}";
    }

    public override void TurnOn()
    {
        base.TurnOn();
        Console.WriteLine($"{Brand} coffe machine is brewing coffe.");
    }

    public override void TurnOff()
    {
        base.TurnOff();
        Console.WriteLine($"{Brand} coffe machine finished brewing coffe.");
    }

    public override double GetDailyEnergyUsage()
    {
        return 0.3;
    }
}

class Program
{
    static void Main()
    {
        List<object> devices = new List<object>()
        {
        new Washer("LG"),
        new Refrigerator("Samsung"),
        new Oven("Elextrolux"),
        new RobotVacuum("Xiamomi"),
        new CoffeeMachine("Nespresso")
        };

        RunMorningRoutine(devices);
        Console.WriteLine();
        ReportAllEnergy(devices);
    }

    static void RunMorningRoutine(List<object> devices)
    {
        foreach (object device in devices)
        {
            object deviceType = device.GetType().Name;
            switch (deviceType)
            {
                case "Washer":
                    if (device is Washer washer)
                    {
                        washer.TurnOn();
                        washer.TurnOff();
                    }
                    break;
                case "Refrigerator":
                    if (device is Refrigerator refrigerator)
                    {
                        refrigerator.TurnOn();
                        refrigerator.TurnOff();
                    }
                    break;
                case "Oven":
                    if (device is Oven oven)
                    {
                        oven.TurnOn();
                        oven.TurnOff();
                    }
                    break;
                case "RobotVacuum":
                    if (device is RobotVacuum robotVacuum)
                    {
                        robotVacuum.TurnOn();
                        robotVacuum.TurnOff();
                    }
                    break;
                case "CoffeeMachine":
                    if (device is CoffeeMachine coffeeMachine)
                    {
                        coffeeMachine.TurnOn();
                        coffeeMachine.TurnOff();
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
            object deviceType = device.GetType().Name;
            switch (deviceType)

            {
                case "Washer":
                    if (device is Washer washer)
                    {
                        Console.WriteLine(washer.GetDailyEnergyUsage());
                    }
                    break;
                case "Refrigerator":
                    if (device is Refrigerator refrigerator)
                    {
                        Console.WriteLine(refrigerator.GetDailyEnergyUsage());
                    }
                    break;
                case "Oven":
                    if (device is Oven oven)
                    {
                        Console.WriteLine(oven.GetDailyEnergyUsage());
                    }
                    break;
                case "RobotVacuum":
                    if (device is RobotVacuum robotVacuum)
                    {
                        Console.WriteLine(robotVacuum.GetDailyEnergyUsage());
                    }
                    break;
                case "CoffeeMachine":
                    if (device is CoffeeMachine coffeeMachine)
                    {
                        Console.WriteLine();
                    }
                    break;
                default:
                    Console.WriteLine("Unkknown deviceType!");
                    break;
            }
        }
    }
}
// FRÅGÅ
// 1. Varför behövde du kontrollera vilken typ varje objekt hade?
// För att Anropa rött metod
//
// 2. Vad händer om du lägger till en ny klass CoffeeMachine?
// Inget om vi inte addera ny 'device' i listan och ny 'case' i 'RunMorningRoutine()'.
// 
// 3. Vilka metoder måste du ändra om du lägger till CoffeeMachine?
// Det ska ändras 'RunMorningRoutine()' och 'ReportAllEnergy()'.
//
// 4. Vad är problemet med att listan är List<object>?
// Att vi vet inte vad är för var är för typ object, LSP/kompilator kan inte hjälpa till att anropa rätt metoder. Det är Generic, skulle vara mer uidiomatisk me 'List<Washer>' för exempel.
//
// 5. Vad händer om du råkar glömma en apparattyp i ReportAllEnergy()?
// Det kommer inte att printas ut. Etersom decice typer är liksom hardkoddad.
//
// 6. Hur många ställen i koden behövde du ändra för att systemet skulle fungera med CoffeeMachine?
// - addera ny coffe object till listan.
// - 'RunMorningRoutine()'
// - 'ReportAllEnergy()'
// Jag  hade att lägga till på 3 olika ställen.
//
// 
