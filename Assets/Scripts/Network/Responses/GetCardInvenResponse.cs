using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GetCardInvenResponse : BaseResponse {
	List<CardInfo> _data;

	public List<CardInfo> data
	{
		get{ return _data;}
		set{ _data = value;}
	}
}
