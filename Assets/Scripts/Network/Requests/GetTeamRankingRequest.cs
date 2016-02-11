using UnityEngine;
using System.Collections;
using System.Text;

public class GetTeamRankingRequest : BaseRequest {

	public GetTeamRankingRequest()
	{
		Add ("memSeq", UserMgr.UserInfo.memSeq);

//		mParams = JsonFx.Json.JsonWriter.Serialize (this);
		mDic = this;
	}

	public override string GetType ()
	{
		return "spos";
	}

	public override string GetQueryId()
	{
		return "gameSposTeamRanking";
	}

}
