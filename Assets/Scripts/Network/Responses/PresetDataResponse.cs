using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PresetDataResponse : BaseResponse {
	List<PresetDataInfo> _data;

	public List<PresetDataInfo> data {
		get {
			return _data;
		}
		set {
			_data = value;
		}
	}
}
