using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GetSimpleResultResponse : BaseResponse {
	List<SimpleResultInfo> _data;

	public List<SimpleResultInfo> data
	{
		get{ return _data;}
		set{ _data = value;}
	}
}
