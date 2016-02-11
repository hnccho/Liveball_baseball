using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GetInAppHistoryResponse : BaseResponse {
	List<InAppHistoryInfo> _data;

	public List<InAppHistoryInfo> data
	{
		get{ return _data;}
		set{ _data = value;}
	}
}
