using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerNewsInfoResponse : BaseResponse {
	PlayerNewsInfo _data;

	public PlayerNewsInfo data {
		get {
			return _data;
		}
		set {
			_data = value;
		}
	}
}
