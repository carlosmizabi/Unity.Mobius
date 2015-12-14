using Tautalos.Unity.Mobius.Channel;

namespace Tautalos.Unity.Mobius.Broadcaster
{
	public interface IWatcher
	{
		void Stop (IEventType eventType);
		
		void StopAll ();
		
		void IsWatching (IEventType eventType);
		
		void Watch (IEventType eventType);
		
	} 
}

