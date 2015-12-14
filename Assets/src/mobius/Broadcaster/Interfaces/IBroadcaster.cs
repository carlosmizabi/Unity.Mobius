
using Tautalos.Unity.Mobius.Channel;

namespace Tautalos.Unity.Mobius.Broadcaster
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

