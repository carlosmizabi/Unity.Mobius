using Tautalos.Unity.Mobius.Channels;

namespace Tautalos.Unity.Mobius.Broadcasters
{
	public interface IWatcher
	{
		void Stop (IEventType eventType);
		
		void StopAll ();
		
		void IsWatching (IEventType eventType);
		
		void Watch (IEventType eventType);
		
		bool IsEmpty ();
		
	} 
}

