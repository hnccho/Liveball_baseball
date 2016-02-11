using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ContestListResponse : BaseResponse {
	List<ContestListInfo> _data;

	public List<ContestListInfo> data {
		get {
			return _data;
		}
		set {
			_data = value;
		}
	}
}
