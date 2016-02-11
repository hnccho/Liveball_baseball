using UnityEngine;
using System.Collections;

public class GetSposTeamInfoResponse : BaseResponse {
	SposTeamInfo _data;

	public SposTeamInfo data
	{
		get{ return _data;}
		set{ _data = value;}
	}
}
