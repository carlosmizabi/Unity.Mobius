using Tautalos.Unity.Mobius.Channels;
using System;

namespace Tautalos.Unity.Mobius.Signals
{
	public class Signal: ISignal
	{
		IMessage _message = EmptyMessage.Instance;
		ISignaller _signaller = EmptySignaller.Instance;
		IEventTag _eventTag = EmptyEventTag.Instance;
		
		public Signal (ISignaller signaller, IEventTag eventTag, IMessage message = default(IMessage))
		{
			_eventTag = eventTag ?? EmptyEventTag.Instance;
			_message = message ?? EmptyMessage.Instance;
			_signaller = signaller ?? EmptySignaller.Instance;
		}
		
		public bool HasMessage ()
		{
			var hasMessage = false;
			if (Message != EmptyMessage.Instance || !Message.IsEmpty) {
				hasMessage = true;
			} 
			return hasMessage;
		}

		public IEventTag EventTag {
			get {
				return _eventTag;
			}
		}

		public IMessage Message {
			get { return _message; }
		}

		public ISignaller Signaller {
			get {
				return _signaller;
			}
		}

		public bool IsEmpty {
			get {
				return false;
			}
		}

	}
}
