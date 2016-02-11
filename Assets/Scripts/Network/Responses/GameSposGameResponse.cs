using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameSposGameResponse : BaseResponse {
	GameSposGameInfo _data;

	public GameSposGameInfo data {
		get {
			return _data;
		}
		set {
			_data = value;
		}
	}
}
