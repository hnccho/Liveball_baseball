using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheckMemberPincodeResponse : BaseResponse {
	UserInfo _data;

	public UserInfo data
	{
		get{ return _data;}
		set{ _data = value;}
	}
}
