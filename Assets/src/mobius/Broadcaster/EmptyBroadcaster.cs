
using Tautalos.Unity.Mobius.Channels;
using System;
using UniRx;
using Tautalos.Unity.Mobius.Signals;

namespace Tautalos.Unity.Mobius.Broadcasters
{
	public class EmptyBroadcaster: IBroadcaster
	{

		static EmptyBroadcaster _instance = new EmptyBroadcaster ();
		static IEventTag[] _eventTags = new IEventTag[0];
		
		string _name = "EMPTY";
		
		public IChannel Channel {
			get {
				return EmptyChannel.Instance;
			}
		}
		
		public bool IsEmpty {
			get { return true; }
		}
				
		public static EmptyBroadcaster Instance {
			get { return _instance; }
		}
		
		public string Name {
			get { return _name; }
		}
		
		public IEventTag[] GetEventTags ()
		{
			return _eventTags;
		}
		
		public bool HasEventTag (IEventTag eventTag)
		{
			return false;
		}
		
		public void Silence ()
		{			
		}
		
		public IDisposable Subscribe (IObserver<ISignal> observer)
		{
			return null;
		}

		public IDisposable SubscribeWhere (IObserver<ISignal> observer, Func<ISignal, bool> perdicate)
		{
			return null;
		}

		public void OnCompleted ()
		{
		}
		public void OnError (Exception error)
		{
		}
		public void OnNext (ISignal value)
		{
		}
	}
}

