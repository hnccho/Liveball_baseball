using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GetEventsResponse {
	EventListInfo _result;

	public EventListInfo result {
		get {
			return _result;
		}
		set {
			_result = value;
		}
	}
}
