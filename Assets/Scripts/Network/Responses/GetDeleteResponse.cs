using UnityEngine;
using System.Collections;

public class GetDeleteResponse : BaseResponse {
	DeleteInfo _data;

	public DeleteInfo data
	{
		get{ return _data;}
		set{ _data = value;}
	}
}
