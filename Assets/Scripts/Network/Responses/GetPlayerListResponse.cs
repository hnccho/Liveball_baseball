using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GetPlayerListResponse : BaseResponse {
	List<PlayerInfo> _data;

	public List<PlayerInfo> data {
		get {
			return _data;
		}
		set {
			_data = value;
		}
	}
}
