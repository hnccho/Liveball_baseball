using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class checkRecentMessageResponse : BaseResponse {
	checkRecentMessageInfo _data;

	public checkRecentMessageInfo data
	{
		get{ return _data;}
		set{ _data = value;}
	}
}
