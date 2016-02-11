using UnityEngine;
using System.Collections;
using System.Text;

public class GetGameParticipantRankingRequest : BaseRequest {

	public GetGameParticipantRankingRequest()
	{
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		Add ("gameSeq", UserMgr.Schedule.gameSeq);
	//	Add ("gameSeq", 1622);


//		mParams = JsonFx.Json.JsonWriter.Serialize (this);
		mDic = this;
	}

	public override string GetType ()
	{
		return "spos";
	}

	public override string GetQueryId()
	{
		return "getGameParticipantRanking";
	}

}
