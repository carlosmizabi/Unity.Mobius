namespace Tautalos.Unity.Mobius.Signal
{
	public interface IMessage
	{
		string Header { get; }
		object Body { get; }
		string Footer { get; }
	}
}

