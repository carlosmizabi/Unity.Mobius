namespace Tautalos.Unity.Mobius.Signals
{
	public interface IMessage
	{
		string Header { get; }
		object Body { get; }
		string Footer { get; }
	}
}

