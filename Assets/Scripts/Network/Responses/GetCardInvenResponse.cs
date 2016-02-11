using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GetCardInvenResponse : BaseResponse {
	CardInvenInfo _data;

	public CardInvenInfo data
	{
		get{ return _data;}
		set{ _data = value;}
	}
}
