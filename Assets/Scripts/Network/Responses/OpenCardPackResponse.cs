using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OpenCardPackResponse : BaseResponse {
	CardPackListInfo _data;

	public CardPackListInfo data
	{
		get{ return _data;}
		set{ _data = value;}
	}
}
