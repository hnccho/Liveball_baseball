using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.IO;

public class GetBingoRequest : BaseRequest {

	public GetBingoRequest(int gameId)
	{	
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		Add ("gameId", gameId);

		mDic = this;
	}

	public override string GetType ()
	{
		return "apps.rtime";
	}

	public override string GetQueryId()
	{
		return "getRealtimeBingo";
	}

}
