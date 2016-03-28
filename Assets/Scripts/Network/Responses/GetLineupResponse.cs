using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GetLineupResponse : BaseResponse {
	List<LineupInfo> _data;

	public List<LineupInfo> data
	{
		get{ return _data;}
		set{ _data = value;}
	}
}
