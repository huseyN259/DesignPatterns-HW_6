public abstract class Subject
{
	private List<Observer> observers = new List<Observer>();

	public void Attach(Observer observer)
		=> observers.Add(observer);
	
	public void Detach(Observer observer)
		=> observers.Remove(observer);

	public void Notify()
	{
		foreach (Observer o in observers)
			o.Update();
	}
}


public class ConcreteSubject : Subject
{
	private string? subjectState;
	
	// Gets or sets subject state
	public string? SubjectState
	{
		get { return subjectState; }
		set { subjectState = value; }
	}
}


public abstract class Observer
{
	public abstract void Update();
}


public class ConcreteObserver : Observer
{
	private string name;
	private string observerState;
	private ConcreteSubject subject;

	public ConcreteObserver(ConcreteSubject subject, string name)
	{
		this.subject = subject;
		this.name = name;
	}

	public override void Update()
	{
		observerState = subject.SubjectState;
		Console.WriteLine("Observer {0}'s new state is {1}", name, observerState);
	}

	// Gets or sets subject
	public ConcreteSubject Subject
	{
		get { return subject; }
		set { subject = value; }
	}
}


/*class Program
{
	public static void Main(string[] args)
	{
		ConcreteSubject s = new ConcreteSubject();

		s.Attach(new ConcreteObserver(s, "H"));
		s.Attach(new ConcreteObserver(s, "N"));

		s.SubjectState = "ABC";

		s.Notify();
	}
}*/