using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GetMyLineupResponse : BaseResponse {
	LineupInfo _data;

	public LineupInfo data
	{
		get{ return _data;}
		set{ _data = value;}
	}
}
