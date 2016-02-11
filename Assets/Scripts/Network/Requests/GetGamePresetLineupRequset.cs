using UnityEngine;
using System.Collections;
using System.Text;

public class GetGamePresetLineupRequset : BaseRequest {

	public GetGamePresetLineupRequset(int gameSeq)
	{
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		Add ("gameSeq", gameSeq);
	

//		mParams = JsonFx.Json.JsonWriter.Serialize (this);
		mDic = this;

	}

	public override string GetType ()
	{
		return "spos";
	}

	public override string GetQueryId()
	{
		return "gamePresetLineup";
	}

}
