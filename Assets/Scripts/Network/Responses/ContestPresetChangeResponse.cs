using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ContestPresetChangeResponse : BaseResponse {
	ContestPresetChangeInfo _data;

	public ContestPresetChangeInfo data {
		get {
			return _data;
		}
		set {
			_data = value;
		}
	}
}
