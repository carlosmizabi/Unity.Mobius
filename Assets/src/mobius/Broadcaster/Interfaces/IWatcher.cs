using Tautalos.Unity.Mobius.Channels;

namespace Tautalos.Unity.Mobius.Broadcasters
{
	public interface IWatcher
	{
		void Stop (IEventTag eventTag);
		
		void StopAll ();
		
		void IsWatching (IEventTag eventTag);
		
		void Watch (IEventTag eventTag);
		
		bool IsEmpty ();
		
	} 
}

