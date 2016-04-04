using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RewardInfoResponse : BaseResponse {
	List<RewardInfo> _data;

	public List<RewardInfo> data
	{
		get{ return _data;}
		set{ _data = value;}
	}
}
