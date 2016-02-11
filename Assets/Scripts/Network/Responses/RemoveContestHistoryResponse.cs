using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RemoveContestHistoryResponse : BaseResponse {
	RemoveContestPresetInfo _data;

	public RemoveContestPresetInfo data
	{
		get{ return _data;}
		set{ _data = value;}
	}
}
