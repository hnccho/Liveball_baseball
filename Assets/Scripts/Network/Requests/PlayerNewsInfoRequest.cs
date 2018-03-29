using UnityEngine;
using System.Collections;
using System.Text;

public class PlayerNewsInfoRequest : BaseRequest {

	public PlayerNewsInfoRequest(long playerId)
	{
//		Add ("memSeq", UserMgr.UserInfo.memSeq);
		Add ("playerId", playerId);

//		mParams = JsonFx.Json.JsonWriter.Serialize (this);
		mDic = this;
	}

	public override string GetType ()
	{
		return "apps.ginfo";
	}

	public override string GetQueryId()
	{
		return "getPlayerNews";
	}

}
