using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.IO;

public class UsePowerRequest : BaseRequest {

	public UsePowerRequest(int gameId, int bingoId, int tailId)
	{	
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		Add ("gameId", gameId);
		Add ("bingoId", bingoId);
		Add ("tailId", tailId);

		mDic = this;
	}
	public override string GetType ()
	{
		return "apps.rtime";
	}

	public override string GetQueryId()
	{
		return "powerGauge";
	}

}
