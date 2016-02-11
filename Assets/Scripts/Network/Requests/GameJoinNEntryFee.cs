using UnityEngine;
using System.Collections;
using System.Text;

public class GameJoinNEntryFee : BaseRequest {

	public GameJoinNEntryFee()
	{
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		Add ("gameSeq", UserMgr.Schedule.gameSeq);
		Add ("entryFee", int.Parse(UserMgr.Schedule.entryFee));

//		mParams = JsonFx.Json.JsonWriter.Serialize (this);
		mDic = this;

	}

	public override string GetType ()
	{
		return "spos";
	}

	public override string GetQueryId()
	{
		return "gameJoinNEntryFee";
	}

}
