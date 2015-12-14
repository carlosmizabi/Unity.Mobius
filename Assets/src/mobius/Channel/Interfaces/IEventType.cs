namespace Tautalos.Unity.Mobius.Channel
{
	public interface IEventType
	{
		string Name { get; }
		string Description  { get; }
		string[] Tags { get; }
	}
}

