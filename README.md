# Unity.Mobius
An event system for unity.

I'm implementing, on top of Reactive Extensions (Rx), a version of the flux/flow architecture for Unity game engine.

Gist:

A Channel:
  - has a Registry of pairs of EventTypes and Broadcaster, with no repeating EventTypes.
  - Signals are emitted on to the Channel by Signallers.
  - Signals have an EventType and a Message Object.
  - A Broadcaster uniquely filters a Signals with specific EventTypes.
  - Broadcaster's accept subscriptions from Watchers to watch all Signals or specific EventTypes.
  - Communication is one way: Signaller --> Channel --> Broadcaster ---> Watcher.
  
  
 And that's pretty much it. 
 I have already implemented the same thing for Javascript on another repository called Flow.
 
 Why? Well Rx offers a functional way to compose events from events and alot other features for working with events. 
 Most of all, in terms of architecture, I like the idea of events following a perdictable path that can easily be mocked and monitored. I think not all events might be suitable for this communication channel but rather when there are events which severals components of a domain care about. I think, a kind of a rule would be that, whenever two completely
 separate parts need to react to an event, then the event ought to be thrown into a channel where the
 parts that want to observe it, can do so, without these parts becoming coupled. This makes the system
 more dynamic, allowing it to shapeshift more easily. 
 Though, one should be wary of breaking encapsulation.
