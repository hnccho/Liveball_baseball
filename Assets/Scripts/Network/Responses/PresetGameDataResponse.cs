using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PresetGameDataResponse : BaseResponse {
	List<PresetGameDataInfo> _data;

	public List<PresetGameDataInfo> data {
		get {
			return _data;
		}
		set {
			_data = value;
		}
	}
}
