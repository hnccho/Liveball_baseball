using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheckVersionResponse : BaseResponse {
	VersionInfo _data;

	public VersionInfo data
	{
		get{ return _data;}
		set{ _data = value;}
	}
}
