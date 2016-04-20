using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;

public class JoinQuizRequest : BaseRequest {

	public JoinQuizRequest(JoinQuizInfo joinInfo)
	{
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		Add ("gameId", joinInfo.gameId);
		Add ("bingoId", joinInfo.bingoId);
		Add ("inningNumber", joinInfo.inningNumber);
		Add ("inningHalf", joinInfo.inningHalf);
		Add ("battingOrder", joinInfo.battingOrder);
		Add ("playerId", joinInfo.playerId);
		Add ("checkValue", joinInfo.checkValue);

//		mParams = JsonFx.Json.JsonWriter.Serialize (this);
		mDic = this;
	}

	public override string GetType ()
	{
		return "apps.rtime";
	}

	public override string GetQueryId()
	{
		return "answerIncidentForecast";
	}

}
