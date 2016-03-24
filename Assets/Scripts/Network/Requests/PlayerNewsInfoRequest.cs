using UnityEngine;
using System.Collections;
using System.Text;

public class PlayerNewsInfoRequest : BaseRequest {

	public PlayerNewsInfoRequest(long playerId)
	{
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		Add ("status", playerId);

//		mParams = JsonFx.Json.JsonWriter.Serialize (this);
		mDic = this;
	}

	public override string GetType ()
	{
		return "apps.contest";
	}

	public override string GetQueryId()
	{
		return "contestMyEntryList";
	}

}
