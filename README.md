# Övning 4 — Arv och Polymorfism

Smart hem-system i C# / .NET. Övningen tränar arv, `virtual`/`override`/`new`/`sealed`, polymorfa listor och interface (`ISchedulable`).

Del av Lexicon .NET VT-2026.

## Mål

- Bygga ett system **utan** polymorfism och känna smärtan (`List<object>`, typkontroll, casting).
- Refaktorera till en basklass `Appliance` + child classes.
- Lägga till funktion utan att röra befintlig kod (Open/Closed).
- Använda interface för funktion som bara vissa klasser har.

## Köra

```bash
dotnet run
```

## Struktur

| Fil | Innehåll |
|---|---|
| `Program.cs` | `Main` + controller-anrop |
| `Appliance.cs` | basklass |
| `Washer.cs`, `Oven.cs`, ... | child classes |
| `ISchedulable.cs` | interface för schemaläggning |
| `SmartHomeController.cs` | hanterar listan av apparater |

> **Tips:** Bygg först allt i `Program.cs` (Del 1–2), refaktorera sedan till egna filer (Del 3+). Samma mönster som NETGame.

## Git-arbetsflöde (branch per moment)

Varje refaktoreringssteg ligger i en egen branch så läraren ser ett moment per PR-diff. Varje branch utgår från den **föregående** — inte master.

| Branch | Delar | Diffen visar |
|---|---|---|
| `ovning4/01-fulkod` | 1–2 | `List<object>`, `is`, casting |
| `ovning4/02-polymorfism` | 3–5 | refaktor → `Appliance` + child classes |
| `ovning4/03-controller` | 6–7 | logik flyttas till `SmartHomeController` |
| `ovning4/04-interface` | 8–9 | `ISchedulable` + casting till interface |
| `ovning4/05-labbar` | 10–12 | `virtual` / `new` / `sealed` |
| `ovning4/06-slututmaning` | 13–15 | extra + `AirConditioner` |

Viktigaste diffen: **01 → 02** (fulkod → polymorfism).

### Starta

```bash
git checkout master && git pull
git checkout -b ovning4/01-fulkod
# ... skriv Del 1–2 i Ovning_4-ArvOchPolymorfism/
git add Ovning_4-ArvOchPolymorfism/
git commit -m "feat(ovning4): smart home with List<object> and casting"
git push -u origin ovning4/01-fulkod
```

### Nästa steg (branchar FRÅN föregående)

```bash
git checkout -b ovning4/02-polymorfism
# ... refaktorera till Appliance + child classes
git commit -am "refactor(ovning4): introduce Appliance base class and polymorphic list"
git push -u origin ovning4/02-polymorfism
```

Upprepa för 03–06. Commit-typer: `feat` (01, 04, 06), `refactor` (02, 03), `docs` (reflektionssvar i kommentarer).

### PR-regel

På GitHub: sätt **base = föregående branch**, inte master. Då visar varje PR bara sitt eget steg.

- PR 1: base `master` ← `ovning4/01-fulkod`
- PR 2: base `ovning4/01-fulkod` ← `ovning4/02-polymorfism`
- ...osv

**Radera inte branchar efter merge** — läraren ska kunna `git checkout` varje steg och köra det. När allt är klart: merga `06` in i master.

## Status

- [ ] Del 1 — bygg problemet (`List<object>`)
- [ ] Del 2 — `CoffeeMachine`, känn smärtan
- [ ] Del 3 — basklass `Appliance`
- [ ] Del 4 — fem child classes
- [ ] Del 5 — `List<Appliance>`
- [ ] Del 6 — `SmartHomeController`
- [ ] Del 7 — ny apparat utan att ändra controllern
- [ ] Del 8 — `ISchedulable`
- [ ] Del 9 — casting till interface
- [ ] Del 10 — labb `virtual` / `override`
- [ ] Del 11 — labb `new`
- [ ] Del 12 — labb `sealed`
- [ ] Del 13 — `List<ISchedulable>` (extra)
- [ ] Del 14 — `FindDeviceByBrand` (extra)
- [ ] Del 15 — `AirConditioner` (slututmaning)

## Begrepp att minnas

| Engelska | Svenska | Kort |
|---|---|---|
| inheritance | arv | child class ärver från basklass |
| `virtual` | virtuell | metod som *får* override:as |
| `override` | åsidosätta | ersätter basens metod polymorfiskt |
| `new` (method hiding) | dölja | gömmer basens metod — **inte** polymorft |
| `sealed override` | förseglad | stoppar vidare override |
| polymorphism | polymorfism | samma anrop, olika beteende per typ |
| interface | gränssnitt | kontrakt utan implementation |
| upcasting | uppcastning | `Appliance a = new Washer()` |

Full uppgiftstext: [`Ovning_4-ArvOchPolymorfism.md`](./Ovning_4-ArvOchPolymorfism.md)
