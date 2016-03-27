using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardUpResponse : BaseResponse {
	List<CardUpInfo> _data;

	public List<CardUpInfo> data
	{
		get{ return _data;}
		set{ _data = value;}
	}
}
