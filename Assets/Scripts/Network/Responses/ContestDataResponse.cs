using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ContestDataResponse : BaseResponse {
	List<ContestDataInfo> _data;

	public List<ContestDataInfo> data {
		get {
			return _data;
		}
		set {
			_data = value;
		}
	}
}
