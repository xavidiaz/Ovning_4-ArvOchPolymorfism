# Övning 4: Smarta hemmet — varför behöver vi polymorfism?

> **Deadline:** tisdag 9/6 09.00

## Syfte

I den här övningen ska du bygga ett system för ett smart hem.

Du ska först skapa en lösning som fungerar, men som blir jobbig att bygga vidare på. Sedan ska du skriva om den med polymorfism.

Du ska träna på:

- arv
- basklass och child classes
- `virtual`
- `override`
- `new`
- `sealed`
- polymorfa listor
- `interface`
- casting till interface
- varför polymorfism gör kod lättare att bygga ut

## Regler för övningen

I början får du använda fulkod med `object`, `if`, `is` och casting.

Efter att du har infört polymorfism gäller en ny regel:

> Du får **inte** längre skriva `if (device is Washer)` eller `if (device is Oven)`.

**Undantag:** Du får använda `is` när du kontrollerar om något implementerar ett interface, till exempel `ISchedulable`.

---

## Del 1: Bygg problemet först

Du ska börja utan arv och utan polymorfism.

Skapa fyra separata klasser:

- `Washer`
- `Refrigerator`
- `Oven`
- `RobotVacuum`

De ska **inte** ärva från någon gemensam klass ännu. Varje klass ska ha olika metodnamn.

| Klass | Properties |
|---|---|
| Washer | Brand, CapacityKg |
| Refrigerator | Brand, Temperature |
| Oven | Brand, MaxTemperature |
| RobotVacuum | Brand, BatteryLevel |

Du ska själv skriva klasserna.

| Klass | Startmetod | Stoppmetod | Energimetod |
|---|---|---|---|
| Washer | `StartWash()` | `StopWash()` | `PrintWashEnergy()` |
| Refrigerator | `StartCooling()` | `StopCooling()` | `PrintCoolingEnergy()` |
| Oven | `StartHeating()` | `StopHeating()` | `PrintHeatingEnergy()` |
| RobotVacuum | `StartCleaning()` | `StopCleaning()` | `PrintCleaningEnergy()` |

### Startkod

Klistra in detta i `Program.cs` och fyll i alla TODO.

```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<object> devices = new List<object>();

        // TODO:
        // Skapa minst fyra objekt:
        // Washer, Refrigerator, Oven och RobotVacuum.
        // Lägg till dem i listan devices.

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
```

### Krav för Del 1

Du måste använda någon form av typkontroll och casting.

Exempel på idé, men inte en färdig lösning:

```csharp
if (device is Washer)
{
    // TODO:
    // Casta device till Washer
    // Anropa Washer-metoder
}
```

Du får också använda pattern matching:

```csharp
if (device is Washer washer)
{
    // TODO:
    // Anropa washer-metoder
}
```

### Test 1

När programmet körs ska alla apparater startas, stoppas och rapportera energiförbrukning. Det behöver inte se exakt likadant ut som nedan, men ungefär:

```text
LG washer starts washing.
LG washer stops washing.
Samsung refrigerator starts cooling.
Samsung refrigerator stops cooling.
Electrolux oven starts heating.
Electrolux oven stops heating.
Xiaomi robot vacuum starts cleaning.
Xiaomi robot vacuum stops cleaning.
LG washer uses 1.2 kWh per wash.
Samsung refrigerator uses 3.6 kWh per day.
Electrolux oven uses 2.5 kWh per hour.
Xiaomi robot vacuum uses 0.4 kWh per cleaning.
```

### Reflektionsfrågor efter Del 1

Svara som kommentarer längst ner i din kod.

1. Varför behövde du kontrollera vilken typ varje objekt hade?
2. Vad händer om du lägger till en ny klass `CoffeeMachine`?
3. Vilka metoder måste du ändra om du lägger till `CoffeeMachine`?
4. Vad är problemet med att listan är `List<object>`?
5. Vad händer om du råkar glömma en apparattyp i `ReportAllEnergy()`?

---

## Del 2: Lägg till en ny apparat och känn problemet

Skapa en femte klass: `CoffeeMachine` med properties för `Brand` och `CupsPerBrew`.

| Metod | Beskrivning |
|---|---|
| `StartBrewing()` | Startar kaffebryggning |
| `StopBrewing()` | Stoppar kaffebryggning |
| `PrintBrewingEnergy()` | Skriver ut energiförbrukning |

Lägg in ett `CoffeeMachine`-objekt i listan.

### Viktig fråga

Hur många ställen i koden behövde du ändra för att systemet skulle fungera med `CoffeeMachine`? Skriv svaret som kommentar.

```csharp
// När jag lade till CoffeeMachine behövde jag ändra...
```

---

## Del 3: Refaktorera till polymorfism

Nu ska du skriva om systemet. Målet är att alla apparater ska kunna behandlas som samma grundtyp.

Skapa en basklass:

```csharp
public class Appliance
{
    public string Brand { get; }
    public string Room { get; }
    public bool IsOn { get; protected set; }

    public Appliance(string brand, string room)
    {
        // TODO:
        // Sätt Brand, Room och IsOn.
    }

    public virtual string GetInfo()
    {
        // TODO:
        // Returnera en generell text om apparaten.
        // Exempel: "LG in Laundry room"
        throw new NotImplementedException();
    }

    public virtual void TurnOn()
    {
        // TODO:
        // Sätt IsOn till true.
        // Skriv ut ett generellt startmeddelande.
        throw new NotImplementedException();
    }

    public virtual void TurnOff()
    {
        // TODO:
        // Sätt IsOn till false.
        // Skriv ut ett generellt stoppmeddelande.
        throw new NotImplementedException();
    }

    public virtual double GetDailyEnergyUsage()
    {
        // TODO:
        // Returnera 0 som standardvärde.
        throw new NotImplementedException();
    }
}
```

### Viktigt

Du ska själv fylla i basklassen. När du är klar ska den:

- ha en fungerande konstruktor
- kunna spara `Brand`
- kunna spara `Room`
- kunna hålla koll på `IsOn`
- ha metoder som kan `override`:as i child classes

---

## Del 4: Skapa child classes

Skapa minst fem child classes som ärver från `Appliance`. (Okej att återanvända och skriva om de existerande klasserna, men kan vara en god idé att ta bort/döpa om dem istället för att få öva på skapandet från grunden.)

- `Washer`
- `Refrigerator`
- `Oven`
- `RobotVacuum`
- `CoffeeMachine`

Alla ska ärva från `Appliance`.

```csharp
public class Washer : Appliance
{
    // TODO
}
```

Varje child class ska:

- ha minst en egen property
- ha en konstruktor som använder `base(...)`
- `override`:a `GetInfo()`
- `override`:a `TurnOn()`
- `override`:a `TurnOff()`
- `override`:a `GetDailyEnergyUsage()`

### Kravtabell

| Klass | Egen property | Energiförbrukning per dag |
|---|---|---|
| Washer | CapacityKg | 1.2 |
| Refrigerator | Temperature | 3.6 |
| Oven | MaxTemperature | 2.5 |
| RobotVacuum | BatteryLevel | 0.4 |
| CoffeeMachine | CupsPerBrew | 0.3 |

Du får själv bestämma exakta utskrifter, men varje klass ska bete sig olika.

### Exempel på utskrift

För `Washer` ska `TurnOn()` till exempel kunna skriva något i stil med:

```text
LG washer starts a washing program.
```

För `Oven` ska `TurnOn()` kunna skriva något i stil med:

```text
Electrolux oven starts preheating.
```

---

## Del 5: Använd en polymorf lista

Byt ut den gamla listan:

```csharp
List<object> devices
```

mot:

```csharp
List<Appliance> devices = new List<Appliance>();
```

Lägg in minst fem olika apparater i listan.

```csharp
// TODO:
// Lägg till Washer, Refrigerator, Oven, RobotVacuum och CoffeeMachine.
```

Skriv sedan en loop:

```csharp
foreach (Appliance device in devices)
{
    // TODO:
    // Skriv ut info.
    // Starta apparaten.
    // Skriv ut energiförbrukning.
    // Stäng av apparaten.
}
```

### Viktig regel

I den här delen får du **inte** skriva `if (device is Washer)` eller `if (device is Oven)`. Poängen är att samma kod ska fungera för alla apparater.

### Frågor efter Del 5

1. Varför fungerar `device.TurnOn()` trots att device har typen `Appliance`?
2. Vilken metod körs om objektet egentligen är en `RobotVacuum`?
3. Vad blev bättre jämfört med `List<object>`?

---

## Del 6: Skapa en SmartHomeController

Nu ska du flytta logiken till en egen klass.

```csharp
public class SmartHomeController
{
    private List<Appliance> _devices = new List<Appliance>();

    public void AddDevice(Appliance device)
    {
        // TODO:
        // Lägg till device i listan.
    }

    public void TurnOnAll()
    {
        // TODO:
        // Loopa igenom alla devices och starta dem.
        // Du får inte använda if/switch på specifika klasser.
    }

    public void TurnOffAll()
    {
        // TODO:
        // Loopa igenom alla devices och stäng av dem.
    }

    public void PrintStatusReport()
    {
        // TODO:
        // Loopa igenom alla devices.
        // Skriv ut GetInfo() och om apparaten är på eller av.
    }

    public double GetTotalDailyEnergyUsage()
    {
        // TODO:
        // Räkna ihop GetDailyEnergyUsage() för alla devices.
        // Returnera totalsumman.
        throw new NotImplementedException();
    }
}
```

### Använd controllern i Main

```csharp
SmartHomeController controller = new SmartHomeController();

// TODO:
// Lägg till minst fem olika apparater.

controller.PrintStatusReport();
Console.WriteLine();
controller.TurnOnAll();
Console.WriteLine();

double totalEnergy = controller.GetTotalDailyEnergyUsage();
Console.WriteLine($"Total daily energy usage: {totalEnergy} kWh");
Console.WriteLine();

controller.TurnOffAll();
```

---

## Del 7: Lägg till en ny apparat utan att ändra controllern

Skapa en ny klass. Välj en:

- `Dishwasher`
- `AirConditioner`
- `Speaker`
- `GamingConsole`

Den ska ärva från `Appliance` och `override`:a samma metoder som de andra klasserna. Lägg till den i Main:

```csharp
controller.AddDevice(new AirConditioner(/* egna värden */));
```

### Viktig kontroll

Du får **inte** ändra `TurnOnAll()`, `TurnOffAll()`, `PrintStatusReport()` eller `GetTotalDailyEnergyUsage()`. Om du behöver ändra dessa metoder har du troligen inte använt polymorfism på rätt sätt.

---

## Del 8: Interface — alla apparater kan inte göra allt

Nu ska du lägga till schemaläggning. Alla apparater är `Appliance`. Men alla apparater kan inte schemaläggas.

- `RobotVacuum` kan schemaläggas.
- `Washer` kan schemaläggas.
- `CoffeeMachine` kan schemaläggas.
- `Refrigerator` kan **inte** schemaläggas.
- `Oven` kan **inte** schemaläggas.

Skapa ett interface:

```csharp
public interface ISchedulable
{
    DateTime NextRun { get; set; }
    void Schedule(DateTime time);
}
```

### Uppgift

Låt dessa klasser implementera `ISchedulable`:

- `Washer`
- `RobotVacuum`
- `CoffeeMachine`

```csharp
public class RobotVacuum : Appliance, ISchedulable
{
    // TODO
}
```

Varje schemaläggningsbar klass ska ha en property `NextRun`, implementera metoden `Schedule(DateTime time)` och skriva ut ett meddelande när den schemaläggs.

---

## Del 9: Varför måste vi casta till interfacet?

Lägg till denna metod i `SmartHomeController`. Skriv den först fel med flit.

```csharp
public void ScheduleAllDevicesWrong(DateTime time)
{
    foreach (Appliance device in devices)
    {
        device.Schedule(time);
    }
}
```

### Fråga

Varför kompilerar inte detta? Svara som kommentar.

### Rätt uppgift

```csharp
public void ScheduleAllSchedulableDevices(DateTime time)
{
    foreach (Appliance device in devices)
    {
        // TODO:
        // 1. Kontrollera om device implementerar ISchedulable.
        // 2. Casta device till ISchedulable.
        // 3. Anropa Schedule(time).
    }
}
```

Du ska skriva lösningen själv. Du måste använda antingen pattern matching:

```csharp
if (device is ISchedulable schedulable)
{
    // TODO
}
```

eller vanlig casting:

```csharp
if (device is ISchedulable)
{
    // TODO:
    // Casta device till ISchedulable.
}
```

**Krav:** Metoden ska schemalägga `Washer`, `RobotVacuum` och `CoffeeMachine`. Den ska hoppa över `Refrigerator` och `Oven` utan att programmet kraschar.

### Testkod i Main

```csharp
controller.ScheduleAllSchedulableDevices(DateTime.Now.AddHours(2));
```

### Frågor efter Del 9

1. Varför kan vi inte anropa `Schedule()` direkt på en variabel av typen `Appliance`?
2. Varför fungerar det efter att vi castar till `ISchedulable`?
3. Vad betyder det att `RobotVacuum` både är en `Appliance` och en `ISchedulable`?
4. Varför ska inte `Schedule()` ligga direkt i `Appliance`?
5. Vad är skillnaden mellan arv och interface i det här exemplet?

---

## Del 10: Labb med virtual och override

### Test A: Ta bort virtual

Gå till basklassen `Appliance`. Ändra:

```csharp
public virtual void TurnOn()
```

till:

```csharp
public void TurnOn()
```

Försök köra programmet. Vad säger kompilatorn i dina child classes där du använder `override`? Svara som kommentar. Ångra sedan ändringen så att metoden är `virtual` igen.

### Test B: Ta bort override

Gå till en child class, till exempel `Washer`. Ändra:

```csharp
public override void TurnOn()
```

till:

```csharp
public void TurnOn()
```

Vad händer? Får du en varning? Vad föreslår C# att du ska använda? Svara som kommentar. Ångra sedan ändringen.

---

## Del 11: Labb med new

Nu ska du skapa ett exempel där polymorfismen inte fungerar som du först tror.

```csharp
public class SmartLamp : Appliance
{
    public int Brightness { get; set; }

    public SmartLamp(string brand, string room, int brightness)
        : base(brand, room)
    {
        // TODO:
        // Spara brightness.
    }

    public new void TurnOn()
    {
        // TODO:
        // Skriv ut att lampan tänds.
    }
}
```

Lägg sedan detta i Main:

```csharp
SmartLamp lamp1 = new SmartLamp("IKEA", "Hallway", 80);
Appliance lamp2 = lamp1;

lamp1.TurnOn();
lamp2.TurnOn();
```

### Frågor

1. Blir utskriften samma?
2. Vilken metod körs när variabeln har typen `SmartLamp`?
3. Vilken metod körs när variabeln har typen `Appliance`?
4. Varför är detta farligt eller förvirrande?
5. Vad händer om du byter `new` till `override`?

Skriv en kommentar som förklarar detta med dina egna ord:

```csharp
// new gömmer basklassens metod.
// override ersätter basklassens metod polymorfiskt.
```

---

## Del 12: Labb med sealed

Nu ska du testa hur man kan stoppa vidare override. Gå till klassen `Oven` och ändra dess `TurnOn()` till:

```csharp
public sealed override void TurnOn()
{
    // TODO:
    // Skriv ugnens startmeddelande.
}
```

Skapa sedan en klass:

```csharp
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
```

### Frågor

1. Vad säger kompilatorn?
2. Varför får `PizzaOven` inte `override`:a `TurnOn()`?
3. När kan det vara rimligt att använda `sealed override`?
4. Vad kan `PizzaOven` fortfarande göra i stället? Kan den `override`:a någon annan metod?

---

## Del 13: Extra utmaning — filtrera med interface

Lägg till denna metod i `SmartHomeController`:

```csharp
internal List<ISchedulable> GetSchedulableDevices()
{
    List<ISchedulable> result = new List<ISchedulable>();

    foreach (Appliance device in devices)
    {
        // TODO:
        // Om device implementerar ISchedulable,
        // lägg till det i result.
    }

    return result;
}
```

I Main:

```csharp
List<ISchedulable> schedulableDevices = controller.GetSchedulableDevices();

foreach (ISchedulable schedulable in schedulableDevices)
{
    // TODO:
    // Skriv ut NextRun eller schemalägg apparaten.
}
```

**Fråga:** Varför kan listan vara `List<ISchedulable>` även om objekten egentligen är olika klasser?

---

## Del 14: Extra utmaning — sök efter apparat

Lägg till en metod i `SmartHomeController`:

```csharp
public Appliance FindDeviceByBrand(string brand)
{
    // TODO:
    // Returnera första apparaten med rätt brand.
    // Om ingen finns kan du returnera null,
    // eller kasta ett eget felmeddelande.
    throw new NotImplementedException();
}
```

Använd den så här:

```csharp
Appliance foundDevice = controller.FindDeviceByBrand("LG");

if (foundDevice != null)
{
    foundDevice.TurnOn();
}
```

### Svårare version

Om apparaten också är `ISchedulable`, schemalägg den. Du måste då kombinera `Appliance` med `ISchedulable`.

---

## Del 15: Slututmaning

Lägg till en helt ny apparat:

### `AirConditioner`

Den ska:

- ärva från `Appliance`
- ha en property `TargetTemperature`
- `override`:a alla relevanta metoder
- implementera `ISchedulable`
- kunna läggas till i `SmartHomeController`
- fungera i `TurnOnAll()`
- fungera i `TurnOffAll()`
- räknas med i total energiförbrukning
- kunna schemaläggas

### Viktigt krav

Du får bara ändra den nya klassen och koden i Main där du lägger till objektet. Du får **inte** ändra `TurnOnAll()`, `TurnOffAll()`, `PrintStatusReport()`, `GetTotalDailyEnergyUsage()` eller `ScheduleAllSchedulableDevices()`.

---

## Inlämning

Du ska lämna in:

1. hela din kod
2. svar på reflektionsfrågorna som kommentarer

### Checklista

Din kod ska innehålla:

- [ ] `Appliance`
- [ ] minst fem child classes
- [ ] minst en extra egen apparat
- [ ] `virtual`
- [ ] `override`
- [ ] `new`
- [ ] `sealed override`
- [ ] `ISchedulable`
- [ ] casting till interface
- [ ] `List<Appliance>`
- [ ] `List<ISchedulable>` i extrautmaningen
- [ ] `SmartHomeController`
