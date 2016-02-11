using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GetTeamRankingResponse : BaseResponse {
	List<TeamInfo> _data;

	public List<TeamInfo> data
	{
		get{ return _data;}
		set{ _data = value;}
	}
}
