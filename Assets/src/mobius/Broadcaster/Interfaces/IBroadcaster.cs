
using Tautalos.Unity.Mobius.Channels;

namespace Tautalos.Unity.Mobius.Broadcasters
{
	public interface IBroadcaster
	{
		string Name { get; }
		
		bool IsEmpty { get; }
		
		IEventTag[] GetEventTags ();
		
		bool HasEventTag ();
		
		void Silence ();
		
	}

}

