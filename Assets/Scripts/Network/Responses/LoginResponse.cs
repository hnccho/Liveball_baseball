using UnityEngine;
using System.Collections;

public class LoginResponse : BaseResponse {
	LoginInfo _data;

	public LoginInfo data
	{
		get{ return _data;}
		set{ _data = value;}
	}
}
