using UnityEngine;
using System.Collections;

public class GetProfileResponse : BaseResponse {
	UserInfo _data;

	public UserInfo data
	{
		get{ return _data;}
		set{ _data = value;}
	}
}
