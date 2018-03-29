using UnityEngine;
using System.Collections;


public class GetCurrentLineupResponse : BaseResponse {
	CurrentLineupInfo _data;

	public CurrentLineupInfo data
	{
		get{ return _data;}
		set{ _data = value;}
	}
}
