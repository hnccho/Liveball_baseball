using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.IO;

public class PowerMaxRequest : BaseRequest {

	public PowerMaxRequest(int gameId, int bingoId)
	{	
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		Add ("gameId", gameId);
		Add ("bingoId", bingoId);

		mDic = this;
	}
	public override string GetType ()
	{
		return "apps.rtime";
	}

	public override string GetQueryId()
	{
		return "powerTime";
	}

}
