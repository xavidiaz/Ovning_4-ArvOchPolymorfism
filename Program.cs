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
        List<Appliance> devices = new()
        {
          new Washer("LG"),
          new Refrigerator("Samsung"),
          new Oven("Elextrolux"),
          new RobotVacuum("Xiamomi"),
          new CoffeeMachine("Nespresso")
        };

        foreach (Appliance device in devices)
        {
            device.GetInfo();
            device.TurnOn();
            device.GetDailyEnergyUsage();
            device.TurnOff();
        }

        Console.WriteLine();
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
// Frågor efter Del 5
// 1. Varför fungerar device.TurnOn() trots att device har typen Appliance?
// Etersom 'Appliance' klass har metoden 'TurnOn()'.
// 
// 2.Vilken metod körs om objektet egentligen är en RobotVacuum?
// Den anpadase metoden av 'RobotVacuum' från basklassen 'Appliance'.
//
// 3. Vad blev bättre jämfört med List<object>?
// Det behövs inte längre declarers metoder 'RunMorningRoutine()' och 'ReportAllEnergy()'.
