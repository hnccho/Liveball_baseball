using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AccuseContentResponse : BaseResponse {
	AccusationInfo _data;

	public AccusationInfo data
	{
		get{ return _data;}
		set{ _data = value;}
	}
}
