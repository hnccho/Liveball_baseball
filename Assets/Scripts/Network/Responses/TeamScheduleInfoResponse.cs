using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TeamScheduleInfoResponse : BaseResponse {
	List<TeamScheduleInfo> _data;

	public List<TeamScheduleInfo> data
	{
		get{ return _data;}
		set{ _data = value;}
	}
}
