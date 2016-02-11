using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GetPlayerStatisticsResponse : BaseResponse {
	PlayerStatistics _data;

	public PlayerStatistics data
	{
		get{ return _data;}
		set{ _data = value;}
	}
}
