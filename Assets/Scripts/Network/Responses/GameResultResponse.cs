using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameResultResponse : BaseResponse {
	GameResultInfo _data;

	public GameResultInfo data {
		get {
			return _data;
		}
		set {
			_data = value;
		}
	}
}
