using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PresetAddResponse : BaseResponse {
	PresetAddInfo _data;

	public PresetAddInfo data {
		get {
			return _data;
		}
		set {
			_data = value;
		}
	}
}
