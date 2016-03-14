using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GetEventsResponse : BaseResponse {
	List<EventInfo> _data;

	public List<EventInfo> data {
		get {
			return _data;
		}
		set {
			_data = value;
		}
	}
}
