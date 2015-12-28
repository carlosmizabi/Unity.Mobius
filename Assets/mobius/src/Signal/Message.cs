namespace Tautalos.Unity.Mobius.Signals
{
	public class Message: IMessage
	{
		string _header = "";
		object _body = EmptyMessage.EmptyBody;
		object _footer = EmptyMessage.EmptyFooter;
		
		public Message (string header = "", object body = default(object), object footer = default(object))
		{
			_header = header ?? "";
			_body = body ?? EmptyMessage.EmptyBody;
			_footer = footer ?? EmptyMessage.EmptyFooter;
		}

		public string Header {
			get {
				return _header;
			}
		}

		public object Body {
			get {
				return _body;
			}
		}

		public object Footer {
			get {
				return _footer;
			}
		}

		public bool IsEmpty {
			get {
				var isEmpty = false;
				if (Header == "" && Body == EmptyMessage.EmptyBody && Footer == EmptyMessage.EmptyFooter) {
					isEmpty = true;
				}
				return isEmpty;
			}
		}
	}
}

