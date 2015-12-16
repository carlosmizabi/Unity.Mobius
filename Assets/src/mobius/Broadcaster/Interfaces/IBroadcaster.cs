
using Tautalos.Unity.Mobius.Channels;

namespace Tautalos.Unity.Mobius.Broadcasters
{
	public interface IBroadcaster
	{
		string Name { get; }
		
		IEventType[] GetEventTypes ();
		
		bool HasEventType ();
		
		void Silence ();
		
		bool IsEmpty ();
	}

}

