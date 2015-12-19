namespace Tautalos.Unity.Mobius.Channels
{
	public class EventType: IEventType
	{
		
		public string Name { 
			get { return _name; }
		}
		
		public string Description { 
			get { return _description; } 
		}
		
		public string[] Tags { 
			get { 
				return _tags;
			} 
		}
		
		public EventType (string name = "NO-NAME", string description = "", string[] tags = _tags)
		{
			_name = name;
			_description = description;
			_tags = tags;
		}
		
		string _name;
		string _description;
		string[] _tags = new string[0];
	}
}



