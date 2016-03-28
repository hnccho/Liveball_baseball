using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ContestDetailsResponse : BaseResponse {
	ContestListInfo _data;

	public ContestListInfo data {
		get {
			return _data;
		}
		set {
			_data = value;
		}
	}
}
