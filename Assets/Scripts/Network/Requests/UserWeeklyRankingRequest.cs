using UnityEngine;
using System.Collections;
using System.Text;

public class UserWeeklyRankingRequest : BaseRequest {

	public UserWeeklyRankingRequest()
	{
		Add ("lastId", 0);

		mDic = this;
	}

	public override string GetType ()
	{
		return "apps.contest";
	}

	public override string GetQueryId()
	{
		return "getWeeklyRank";
	}

}
