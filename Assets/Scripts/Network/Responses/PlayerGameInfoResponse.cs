using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerGameInfoResponse : BaseResponse {
	List<PlayerGameInfo> _data;

	public List<PlayerGameInfo> data {
		get {
			return _data;
		}
		set {
			_data = value;
		}
	}
}
