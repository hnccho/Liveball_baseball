using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheckMemberDeviceResponse : BaseResponse {
	CheckMemberDeviceInfo _data;

	public CheckMemberDeviceInfo data
	{
		get{ return _data;}
		set{ _data = value;}
	}
}
