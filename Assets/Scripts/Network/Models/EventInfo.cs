using UnityEngine;
using System.Collections;

public class EventInfo {
	string _url;
//	string _language;
	string _title;

	public string title {
		get {
			return _title;
		}
		set {
			_title = value;
		}
	}

//	string _content;
//	string _date;

	public string url {
		get {
			return _url;
		}
		set {
			_url = value;
		}
	}
}
