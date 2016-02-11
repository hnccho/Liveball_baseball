using UnityEngine;
using System.Collections;
using System.Text;

public class GetLineupRequest : BaseRequest {

	public GetLineupRequest(string teamCode)
	{
		Add ("memSeq", UserMgr.UserInfo.memSeq);
//		Add ("gameSeq", UserMgr.Schedule.gameSeq);
		Add ("teamCode", teamCode);

//		mParams = JsonFx.Json.JsonWriter.Serialize (this);
		mDic = this;
	}

	public override string GetType ()
	{
		return "spos";
	}

	public override string GetQueryId()
	{
		return "gameSposGameLineup";
	}

}
