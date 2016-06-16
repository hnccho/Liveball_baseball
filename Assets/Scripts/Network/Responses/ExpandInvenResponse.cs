using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExpandInvenResponse : BaseResponse {
	ExpandInvenInfo _data;

	public ExpandInvenInfo data
	{
		get{ return _data;}
		set{ _data = value;}
	}
}
