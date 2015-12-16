namespace Tautalos.Unity.Mobius.Channels
{
	public interface IEventType
	{
		string Name { get; }
		string Description  { get; }
		string[] Tags { get; }
	}
}

