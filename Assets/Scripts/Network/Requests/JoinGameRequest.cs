using UnityEngine;
using System.Collections;
using System.Text;

public class JoinGameRequest : BaseRequest {

	public JoinGameRequest()
	{
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		Add ("gameSeq", UserMgr.Schedule.gameSeq);


//		mParams = JsonFx.Json.JsonWriter.Serialize (this);
		mDic = this;

	}

	public override string GetType ()
	{
		return "spos";
	}

	public override string GetQueryId()
	{
		return "gameJoinUser";
	}

}
