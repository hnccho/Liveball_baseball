using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.IO;

public class CallBingoRequest : BaseRequest {

	public CallBingoRequest(int gameId, int bingoId, int inningNumber)
	{	
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		Add ("gameId", gameId);
		Add ("bingoId", bingoId);
		Add ("inningNumber", inningNumber);

		mDic = this;
	}
	public override string GetType ()
	{
		return "apps.rtime";
	}

	public override string GetQueryId()
	{
		return "callBingo";
	}

}
