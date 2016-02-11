using UnityEngine;
using System.Collections;


public class GetGameParticipantRankingResponse : BaseResponse {
	GetGameParticipantRankingInfo _data;

	public GetGameParticipantRankingInfo data
	{
		get{ return _data;}
		set{ _data = value;}
	}
}
