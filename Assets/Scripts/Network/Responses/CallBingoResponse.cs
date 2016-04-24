using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CallBingoResponse : BaseResponse {
	BingoRewardInfo _data;

	public BingoRewardInfo data {
		get {
			return _data;
		}
		set {
			_data = value;
		}
	}
}
