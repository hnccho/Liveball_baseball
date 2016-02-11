using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GetGamePresetLineupResponse : BaseResponse {
	List<GamePresetLineupInfo> _data;

	public List<GamePresetLineupInfo> data
	{
		get{ return _data;}
		set{ _data = value;}
	}
}
