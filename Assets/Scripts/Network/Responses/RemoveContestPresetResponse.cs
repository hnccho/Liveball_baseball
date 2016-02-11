using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RemoveContestPresetResponse : BaseResponse {
	RemoveContestPresetInfo _data;

	public RemoveContestPresetInfo data
	{
		get{ return _data;}
		set{ _data = value;}
	}
}
