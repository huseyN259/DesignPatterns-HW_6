public class Originator
{
	string? state;
	public string? State
	{
		get { return state; }
		set
		{
			state = value;
			Console.WriteLine("State = " + state);
		}
	}
	
	public Memento CreateMemento()
		=> (new Memento(state));
	
	public void SetMemento(Memento memento)
	{
		Console.WriteLine("Restoring state...");
		State = memento.State;
	}
}


public class Memento
{
	string state;
	
	public Memento(string state)
		=> this.state = state;
	
	public string State
	{
		get { return state; }
	}
}


public class Caretaker
{
	Memento? memento;
	public Memento? Memento
	{
		set { memento = value; }
		get { return memento; }
	}
}


/*class Program
{
	public static void Main()
	{
		Originator o = new Originator();

		o.State = "On";

		// Store internal state
		Caretaker c = new Caretaker();
		c.Memento = o.CreateMemento();
		// Continue changing originator
		o.State = "Off";
		// Restore saved state
		o.SetMemento(c.Memento);
	}
}*/