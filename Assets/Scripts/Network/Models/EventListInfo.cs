using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventListInfo {	
	
	List<EventInfo> _data;
	
	public List<EventInfo> data
	{
		get{ return _data;}
		set{ _data = value;}
	}
	
	int _count;
	
	public int count {
		get {
			return _count;
		}
		set {
			_count = value;
		}
	}
}
