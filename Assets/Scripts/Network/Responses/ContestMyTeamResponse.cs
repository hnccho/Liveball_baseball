using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ContestMyTeamResponse : BaseResponse {
	List<ContestMyTeamListInfo> _data;

	public List<ContestMyTeamListInfo> data
	{
		get{ return _data;}
		set{ _data = value;}
	}
}
