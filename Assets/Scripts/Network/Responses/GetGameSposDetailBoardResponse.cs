using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GetGameSposDetailBoardResponse : BaseResponse {
	SposDetailBoard _data;

	public SposDetailBoard data
	{
		get{ return _data;}
		set{ _data = value;}
	}
}
