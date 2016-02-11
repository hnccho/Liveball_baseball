using UnityEngine;
using System.Collections;
using System.Text;

public class GetScheduleTodayRequest : BaseRequest {

	public GetScheduleTodayRequest()
	{
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		Add ("date", UtilMgr.GetDateTime ("yyyyMMdd"));

//		mParams = JsonFx.Json.JsonWriter.Serialize (this);
		mDic = this;
	}

	public override string GetType ()
	{
		return "apps";
	}

	public override string GetQueryId()
	{
		return "bcastGetScheduleToday";
	}

}
