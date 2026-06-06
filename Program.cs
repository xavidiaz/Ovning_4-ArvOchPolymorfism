using System;
using System.Collections.Generic;

public interface ISchedulable
{
    DateTime NextRun { get; set; }
    void Schedule(DateTime time);
}

public class SmartHomeController
{
    private List<Appliance> _devices = new List<Appliance>();

    public void AddDevice(Appliance device)
    {
        // TODO:
        // Lägg till device i listan.
        _devices.Add(device);
    }

    public void TurnOnAll()
    {
        // TODO:
        // Loopa igenom alla devices och starta dem.
        // Du får inte använda if/switch på specifika klasser.
        foreach (Appliance device in _devices)
        {
            device.TurnOn();
        }
    }

    public void TurnOffAll()
    {
        // TODO:
        // Loopa igenom alla devices och stäng av dem.
        foreach (Appliance device in _devices)
        {
            device.TurnOff();
        }
    }

    public void PrintStatusReport()
    {
        // TODO:
        // Loopa igenom alla devices.
        // Skriv ut GetInfo() och om apparaten är på eller av.
        foreach (Appliance device in _devices)
        {
            Console.WriteLine(device.GetInfo());
        }
    }

    public double GetTotalDailyEnergyUsage()
    {
        // TODO:
        // Räkna ihop GetDailyEnergyUsage() för alla devices.
        // Returnera totalsumman.
        double totalsumman = 0;
        foreach (Appliance device in _devices)
        {
            totalsumman += device.GetDailyEnergyUsage();
        }
        return totalsumman;
    }

    // public void ScheduleAllDevicesWrong(DateTime time)
    // {
    //     foreach (Appliance device in _devices)
    //     {
    //         device.Schedule(time);
    //     }
    // }
    //
    // FRÅGÅR
    // Varför kompilerar inte detta? Svara som kommentar.
    // - Rättas 'devices' till '_devices'.
    // - Eftersom inte alla devices has metod 'Schedule()', endast har det 'Washer', 'RobotVacuum', 'CoffeeMachine'.

    public void ScheduleAllSchedulableDevices(DateTime time)
    {
        foreach (Appliance device in _devices)
        {
            if (device is ISchedulable schedulable)
            {
                schedulable.Schedule(time);
                Console.WriteLine($"{device} Scheduled for {time}");
            }
        }
    }
}

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
        Console.WriteLine($"[Appliance] {Brand} turned On.");
    }

    // public void TurnOn()
    // {
    //     IsOn = true;
    // }
    // FRÅGÅR
    // TEST A: Försök köra programmet utan 'virtual'. 
    // Vad säger kompilatorn i dina child classes där du använder override? 
    // '''error CS0506: '<child-class>.TurnOn()': cannot override inherited member 'Appliance.TurnOn()' because it is not marked virtual, abstract, or override'''

    public virtual void TurnOff()
    {
        IsOn = false;
    }

    public virtual double GetDailyEnergyUsage()
    {
        // Returnera 0 som standardvärde.
        return 0;
    }
}

public class Washer : Appliance, ISchedulable
{
    public double CapacityKg { get; }
    public DateTime NextRun { get; set; }

    public Washer(string brand, string room = "No assigned.", double capacityKg = 0) : base(brand, room)
    {
        CapacityKg = capacityKg;
    }

    public override string GetInfo()
    {
        return $"{Brand} washer ({CapacityKg} kg) in {Room} room - {(IsOn ? "ON" : "OFF")}";
    }

    public override void TurnOn()
    {
        base.TurnOn();
        Console.WriteLine($"{Brand} washer starts washing program.");
    }

    //  public void TurnOn()
    // {
    //     base.TurnOn();
    //     Console.WriteLine($"{Brand} washer starts washing program.");
    // }
    //
    // FRÅGÅR
    // TesT B: Vad händer? Får du en varning? Vad föreslår C# att du ska använda? 
    // ''warning CS0114: 'Washer.TurnOn()' hides inherited member 'Appliance.TurnOn()'. 
    // To make the current member override that implementation, add the override keyword. Otherwise add the new keyword.''
    // Kompilator beskriver att ändring i parent-klass ska inte genomföras tills skrivs 'override' i child-metoden.

    public override void TurnOff()
    {
        base.TurnOff();
        Console.WriteLine($"{Brand} washer finished washing program.");
    }
    public override double GetDailyEnergyUsage()
    {
        return 1.2;
    }

    public void Schedule(DateTime time)
    {
        NextRun = time;
        Console.WriteLine($"{Brand} washer scheduled for {NextRun}.");
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
        return $"{Brand} refrigerator ({Temperature} C) in {Room} room - {(IsOn ? "ON" : "OFF")}";
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
        return $"{Brand} oven (Max temperature {MaxTemperature} C) in {Room} room - {(IsOn ? "ON" : "OFF")}";
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

public class RobotVacuum : Appliance, ISchedulable
{
    public double BatteryLevel { get; }
    public DateTime NextRun { get; set; }

    public RobotVacuum(string brand, string room = "No assigned.", double batteryLevel = 0) : base(brand, room)
    {
        BatteryLevel = batteryLevel;
    }

    public override string GetInfo()
    {
        return $"{Brand} robot vacuum (batteryLevel = {BatteryLevel}) is in {Room} room - {(IsOn ? "ON" : "OFF")}";
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

    public void Schedule(DateTime time)
    {
        NextRun = time;
        Console.WriteLine($"{Brand} robot vacuum is scheduled for {NextRun}.");
    }
}


public class CoffeeMachine : Appliance, ISchedulable
{
    public double CupsPerBrew { get; }
    public DateTime NextRun { get; set; }

    public CoffeeMachine(string brand, string room = "No assigned.", int cups = 0) : base(brand, room)
    {
        CupsPerBrew = cups;
    }

    public override string GetInfo()
    {
        return $"{Brand} coffe machine ({CupsPerBrew} per brew) in {Room} room - {(IsOn ? "ON" : "OFF")}";
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

    public void Schedule(DateTime time)
    {
        NextRun = time;
        Console.WriteLine($"{Brand} coffe machine is scheduled for {NextRun}.");
    }
}

public class AirConditioner : Appliance
{
    public double TargetTemperature { get; }
    public AirConditioner(string brand, string room = "No assigned", int targetTemperature = 0) : base(brand, room)
    {
        TargetTemperature = targetTemperature;
    }
    public override string GetInfo()
    {
        return $"{Brand} air conditioner (Target: {TargetTemperature} C) in {Room} - {(IsOn ? "ON" : "OFF")}";
    }
    public override void TurnOn()
    {
        base.TurnOn();
        Console.WriteLine($"{Brand} air conditioner starts cooling to {TargetTemperature} C.");
    }
    public override void TurnOff()
    {
        base.TurnOff();
        Console.WriteLine($"{Brand} air conditioner stops cooling.");
    }
    public override double GetDailyEnergyUsage()
    {
        return 4.5;
    }
}

public class SmartLamp : Appliance
{
    public int Brightness { get; set; }

    public SmartLamp(string brand, string room, int brightness)
        : base(brand, room)
    {
        Brightness = brightness;
    }

    public new void TurnOn()
    {
        // TODO:
        // Skriv ut att lampan tänds.
        Console.WriteLine($"[SmartLamp] {Brand} SmartLamp turned On.");
    }
}

public class PizzaOven : Oven
{
    public PizzaOven(string brand, string room, int maxTemperature)
        : base(brand, room, maxTemperature)
    {
    }

    public override void TurnOn()
    {
        Console.WriteLine("Pizza oven starts at extra high temperature.");
    }
}

class Program
{
    static void Main()
    {
        // Del 6
        SmartHomeController controller = new SmartHomeController();

        controller.AddDevice(new Washer("LG", "Laundry", 7));
        controller.AddDevice(new Refrigerator("Samsung", "Kitchen", 4));
        controller.AddDevice(new Oven("Electrolux", "Kitchen", 250));
        controller.AddDevice(new RobotVacuum("Xiaomi", "Living", 100));
        controller.AddDevice(new CoffeeMachine("Nespresso", "Kitchen", 6));
        controller.AddDevice(new AirConditioner("Daikin", "Bedroom", 22));

        controller.PrintStatusReport();
        Console.WriteLine();
        controller.TurnOnAll();
        Console.WriteLine();

        double totalEnergy = controller.GetTotalDailyEnergyUsage();
        Console.WriteLine($"Total daily energy usage: {totalEnergy} kWh");
        Console.WriteLine();

        controller.TurnOffAll();

        // Del 9
        Console.WriteLine();
        controller.ScheduleAllSchedulableDevices(DateTime.Now.AddHours(2));

        // Del 11
        Console.WriteLine();
        SmartLamp lamp1 = new SmartLamp("IKEA", "Hallway", 80);
        Appliance lamp2 = lamp1;

        lamp1.TurnOn();
        lamp2.TurnOn();
    }


}
// FRÅGÅR
//
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

// FRÅGÅR
// DEL 5
//
// 1. Varför fungerar device.TurnOn() trots att device har typen Appliance?
// Etersom 'Appliance' klass har metoden 'TurnOn()'.
// 
// 2.Vilken metod körs om objektet egentligen är en RobotVacuum?
// Den anpadase metoden av 'RobotVacuum' från basklassen 'Appliance'.
//
// 3. Vad blev bättre jämfört med List<object>?
// Det behövs inte längre declarers metoder 'RunMorningRoutine()' och 'ReportAllEnergy()'.
//
// Frågor efter Del 9
// 1. Varför kan vi inte anropa Schedule() direkt på en variabel av typen Appliance?
// Etersom inte alla class implementerar metod 'Schedule()'.
//
// 2. Varför fungerar det efter att vi castar till ISchedulable?
// Etersom vi anropar metod 'Schedule()' endast för 'devides' som har metoden.
//
// 3. Vad betyder det att RobotVacuum både är en Appliance och en ISchedulable?
// Att 'RobotVacuum' ärv från 'Appliance' och måste implementera kontrakt av interface 'ISchedulable'.
//
// 4. Varför ska inte Schedule() ligga direkt i Appliance?
// Etersom devides som inte ska ha kontrakt med property och metod av interface 'ISchedulable' skulle ha det.
//
// 5. Vad är skillnaden mellan arv och interface i det här exemplet?
// - arv_ subklassen få properties och metoder från parent klass.
// - interface_ är en kontrakt som garanteras att klasser med det ska ha properties och metoder som ör definieras i interfacen.

// FRÅGÅR
// DEL 11
//
// 1. Blir utskriften samma?
// Nej! I 'SmartLamp' fall printas 'Console.WriteLine()' från child-klassen. Utan i 'Appliance' fall printas ut 'Console.WriteLine()' från parent-klass.
//
// 2. Vilken metod körs när variabeln har typen SmartLamp?
// Metoden i child-klass 'SmartLamp'
//
// 3. Vilken metod körs när variabeln har typen Appliance?
// Metoden i parent-klass 'Appliance'.
//
// 4. Varför är detta farligt eller förvirrande?
// Det förliga är att samma objekt beter sig olika beroende på vilken modifier använder man. Det kan vara svårt att felsöka.
// 'override' enable polimorfism medan 'new' enable shadowing.
//
// 5. Vad händer om du byter new till override?
// Med 'New' printas ut pakent-klass metod medan med 'override' printas ut child-klass.

// FRÅGÅR
// DEL 12
//
// 1. Vad säger kompilatorn?
// ''error CS0239: 'PizzaOven.TurnOn()': cannot override inherited member 'Oven.TurnOn()' because it is sealed'''
//
// 2. Varför får PizzaOven inte override:a TurnOn()?
// Eftersom 'sealed' modifier skydas parent-klass mot ändringar.
//
// 3. När kan det vara rimligt att använda sealed override?
// När man vill att vissa metoder skall ändras inte för subklassen, försäkra att behåla grurnd-metod.
//
// 4. Vad kan PizzaOven fortfarande göra i stället? Kan den override:a någon annan metod?
// Det kan overskriva allt utan menoder med 'sealed'
//
