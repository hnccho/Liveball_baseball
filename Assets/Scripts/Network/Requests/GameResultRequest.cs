using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.IO;

public class GameResultRequest : BaseRequest {

	public GameResultRequest()
	{	
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		Add ("gameId", UserMgr.eventJoined.gameId);

		mDic = this;
	}
	public override string GetType ()
	{
		return "apps.rtime";
	}

	public override string GetQueryId()
	{
		return "getGameStatistics";
	}

}
