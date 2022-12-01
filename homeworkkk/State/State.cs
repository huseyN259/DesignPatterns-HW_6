using System.Diagnostics;

interface IState
{
	public void Toggle(Switch sw);
}


class OnState : IState
{
	public void Toggle(Switch sw)
	{
		Console.WriteLine("Switch is in ON State.. Turning it OFF");
		sw.setState(new OffState());
	}
}


class OffState : IState
{
	public void Toggle(Switch sw)
	{
		Console.WriteLine("Switch is in OFF State.. Turning it ON");
		sw.setState(new OnState());
	}
}


class Switch
{
	private IState state;

	public Switch(IState state)
		=> this.state = state;

	public void setState(IState state)
		=> this.state = state;

	public void toggleSwitch()
		=> state.Toggle(this);
}


class Program
{
	static void Main()
	{
		Switch sw = new Switch(new OnState());

		// Changing the state of switch
		sw.toggleSwitch();  
		sw.toggleSwitch();  
		sw.toggleSwitch();  
		sw.setState(new OnState());
		sw.toggleSwitch(); 
		sw.toggleSwitch();
	}
}