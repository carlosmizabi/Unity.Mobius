namespace Tautalos.Unity.Mobius.Channels
{
	public class EventType: IEventType
	{	
		string _name;
		string _description;
		string[] _tags;
		static string[] _emptyTags = new string[0];
		
		public EventType (string[] tags, string name = "NO-NAME", string description = "")
		{
			_name = name;
			_description = description;
			_tags = tags;
		}
		
		public EventType (string name = "NO-NAME", string description = "") : this (_emptyTags, name, description)
		{
			
		}
		
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
		
		public bool IsEmpty ()
		{
			return false;
		}
			
	}
}



