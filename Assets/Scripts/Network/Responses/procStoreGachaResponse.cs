using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class procStoreGachaResponse : BaseResponse {
	procStoreGachaInfo _data;

	public procStoreGachaInfo data {
		get {
			return _data;
		}
		set {
			_data = value;
		}
	}
}
