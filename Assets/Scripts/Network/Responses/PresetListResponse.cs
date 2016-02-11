using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PresetListResponse : BaseResponse {
	List<PresetListInfo> _data;

	public List<PresetListInfo> data {
		get {
			return _data;
		}
		set {
			_data = value;
		}
	}
}
