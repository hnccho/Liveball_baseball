using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PresetUpdateResponse : BaseResponse {
	PresetUpdateInfo _data;

	public PresetUpdateInfo data {
		get {
			return _data;
		}
		set {
			_data = value;
		}
	}
}
