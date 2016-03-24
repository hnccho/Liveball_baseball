using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerSeasonInfoResponse : BaseResponse {
	PlayerSeasonInfo _data;

	public PlayerSeasonInfo data {
		get {
			return _data;
		}
		set {
			_data = value;
		}
	}
}
