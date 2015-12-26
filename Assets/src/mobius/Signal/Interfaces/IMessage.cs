namespace Tautalos.Unity.Mobius.Signals
{
	public interface IMessage
	{
		string Header { get; }
		object Body { get; }
		object Footer { get; }
		bool IsEmpty { get; }
	}
}

