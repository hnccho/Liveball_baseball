using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerNewsInfoResponse : BaseResponse {
	List<PlayerNewsInfo> _data;

	public List<PlayerNewsInfo> data {
		get {
			return _data;
		}
		set {
			_data = value;
		}
	}
}
