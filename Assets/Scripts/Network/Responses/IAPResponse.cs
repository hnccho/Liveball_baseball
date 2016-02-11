using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IAPResponse : BaseResponse {
	IAPInfo _data;

	public IAPInfo data
	{
		get{ return _data;}
		set{ _data = value;}
	}
}
