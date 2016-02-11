using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;

public class GetQuizResultRequest : BaseRequest {

	public GetQuizResultRequest(int quizListSeq)
	{
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		Add ("gameSeq", UserMgr.Schedule.gameSeq);
		Add ("quizListSeq", quizListSeq);

//		mParams = JsonFx.Json.JsonWriter.Serialize (this);
		mDic = this;
	}

	public override string GetType ()
	{
		return "spos";
	}

	public override string GetQueryId()
	{
		return "gameSposQuizResult";
	}

}
