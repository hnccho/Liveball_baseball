using UnityEngine;
using System.Collections;
using System.Text;

public class GetUserRankingWeeklyPoint : BaseRequest {

	public GetUserRankingWeeklyPoint(int memSeq)
	{
		Add ("memSeq", memSeq);
		Add ("nextRank",0);

//		mParams = JsonFx.Json.JsonWriter.Serialize (this);
		mDic = this;

	}

	public override string GetType ()
	{
		return "apps";
	}

	public override string GetQueryId()
	{
		return "getUserRankingWeeklyPoint";
	}

}
