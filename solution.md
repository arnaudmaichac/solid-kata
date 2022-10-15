## SOLID Kata

### SRP

* Extract Printer logic in a dedicated class

### OCP

* Create Employee inheritance
* Use private field

BONUS: add a new type of employee -> `BigBoss`

What do you have to do?

### LSP

* Code smell: `is` check

```csharp
public void Refuel(Vehicle vehicle)
{
	if (vehicle is PetrolCar)
	{
		vehicle.FillUpWithFuel();
	}
}

public void Charge(Vehicle vehicle)
{
	if (vehicle is ElectricCar)
	{
		vehicle.ChargeBattery();
	}
}
```

* Review inheritance

```csharp
public abstract class Vehicle {
  	//Common to each vehicles
    private bool engineStarted = false;

	public void StartEngine()
	{
		engineStarted = true;
	}

	public bool EngineIsStarted()
	{
		return engineStarted;
	}

	public void StopEngine()
	{
		engineStarted = false;
	}

  	//Force implementation -> should be isolated in interfaces
	public abstract void FillUpWithFuel();

	public abstract void ChargeBattery();
}
```

* Create interfaces: `IElectricityPowered`, `IPetrolPowered`

```csharp
public class ElectricCar : Vehicle, IElectricityPowered
public class PetrolCar : Vehicle, IPetrolPowered
```

* Now we can refactor `FillingStation`

```csharp
public class FillingStation
{
	public void Refuel(PetrolCar petrolCar)
	{
		petrolCar.FillUpWithFuel();
	}

	public void Charge(ElectricCar electricCar)
	{
		electricCar.ChargeBattery();
	}
}   
```

* Create subtype of cars : `VWDieselCar`, `TeslaCar` for example
  * Use them in your tests
  * No more `is` anywhere
  * Cleaner Inheritance

### ISP

```java
public class Bird : IAnimal
{
	// exactly what we want to avoid
	public void Bark() { }

	public void Run()
	{
		Console.Write("Bird is running");
	}

	public void Fly()
	{
		Console.Write("Bird is flying");
	}
}
```

* Split the `Animal` interface: `IBarking`, `IRunning`, `IFlying`

```csharp
public interface Animal 
{
  void Fly();
  void Run();
  void Bark();
}
```

* Change the interface implementation of `Bird` and `Dog`

### DIP

* Find the code smell

```csharp
public class BirthdayGreeter
{
	private readonly IEmployeeRepository employeeRepository;
	private readonly Clock clock;

	public BirthdayGreeter(IEmployeeRepository employeeRepository, Clock clock)
	{
		this.employeeRepository = employeeRepository;
		this.clock = clock;
	}

	public void SendGreetings()
	{
		DateTime today = clock.MonthDay();

		employeeRepository.FindEmployeesBornOn(today)
			.Select(EmailFor)
			.ToList()
			// Ask questions about this line
			// Impact on testing
			.ForEach(e => new EmailSender().Send(e));
	}

	private Email EmailFor(Employee employee)
	{
		string message = $"Happy birthday, dear {employee.FirstName}!";
		return new Email(employee.Email, "Happy birthday!", message);
	}
}
```

* Inject `EmailSender`
  * Ask question about how to do it: method, constructor, property
* Impact on the tests?
    * No more need to check stdout
    * Check call to `EmailSender` only