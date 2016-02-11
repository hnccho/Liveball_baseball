using UnityEngine;
using System.Collections;

public class GetDoneInvenItemResponse : BaseResponse {
	DoneInvenItemInfo _data;

	public DoneInvenItemInfo data
	{
		get{ return _data;}
		set{ _data = value;}
	}
}
