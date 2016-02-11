using UnityEngine;
using System.Collections;
using System.Text;

public class GetScheduleMoreRequest : BaseRequest {

	public GetScheduleMoreRequest(string teamCode, int teamSeq)
	{
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		Add ("date", UtilMgr.GetDateTime ("yyyyMMdd"));
		if (teamCode != null && teamCode.Length > 0) {
			Add ("teamCode", teamCode);
			Add ("teamSeq", teamSeq);
		}

//		mParams = JsonFx.Json.JsonWriter.Serialize (this);
		mDic = this;
	}

	public override string GetType ()
	{
		return "apps";
	}

	public override string GetQueryId()
	{
		return "bcastGetScheduleMore";
	}

}
