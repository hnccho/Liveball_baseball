using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GetBingoResponse : BaseResponse {
	BingoInfo _data;

	public BingoInfo data {
		get {
			return _data;
		}
		set {
			_data = value;
		}
	}
}
