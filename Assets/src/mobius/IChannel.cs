using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Tautalos.Unity.Mobius.Broadcaster;

namespace Tautalos.Unity.Mobius
{
	public interface IChannel
	{
		List<IBroadcaster> GetRegistry ();
		
		void AddEventEntry (IEventEntry entry);
		
		bool HasEventType (IEventType eventType);
		
		bool HasEventType (string typeName);
		
		bool HasNamedBroadcaster (string name);
		
		IEventType GetEventType (string typeName);
		
		List<IEventType> GetEventEntries (IBroadcaster broadcaster);
		
		IBroadcaster GetBroadcaster (string eventType);
		
		IBroadcaster getBroadcaster (IEventType eventType);
		
		bool WhichEventTypesExist (EventType[] eventTypes);
		
		bool WhichEventTypesExist (string[] typeNames);
		
		bool IsEmittable (ISignal signal);
		
		void Emit (ISignal signal);
		
		ISignaller CreateSignaller ();
	}
	
	public interface IEventEntry
	{
		IEventType EventType { get; }
		IBroadcaster Broadcaster { get; }
	}
	
	public interface IEventType
	{
		string Name { get; }
		string Description  { get; }
		string[] Tags { get; }
	}
	
	public interface ISignal
	{
		IEventType EventType { get; }
		IMessage Message { get; }
		ISignaller Signaller { get; }
		
		bool HasMessage ();
		
	}
	
	public interface ISignaller
	{
		object Owner { get; }
		IChannel Channel { get; }
		
		bool IsEmptySignaller ();
		
		ISignal CreateSignal (EventType type, IMessage message);
		
		void emit (ISignal signal);
		
		void emit (ISignal[] signals);
	}
	
	public interface IMessage
	{
		string Header { get; }
		object Body { get; }
		string Footer { get; }
	}
	
	public interface IWatcher
	{
		void Stop (IEventType eventType);
		
		void StopAll ();
		
		void IsWatching (IEventType eventType);
		
		void Watch (EventType eventType);
		
	} 
}
