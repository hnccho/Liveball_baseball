using UnityEngine;
using System.Collections;
using System.Text;

public class GetPlayerStatisticsRequest : BaseRequest {

	public GetPlayerStatisticsRequest()
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
		return "gameSposPlayerRanking";
	}

}
