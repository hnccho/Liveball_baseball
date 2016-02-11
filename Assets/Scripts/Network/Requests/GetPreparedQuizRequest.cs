using UnityEngine;
using System.Collections;
using System.Text;

public class GetPreparedQuizRequest : BaseRequest {

	public GetPreparedQuizRequest()
	{
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		Add ("gameSeq", UserMgr.Schedule.gameSeq);
		Add ("quizListSeq", 0);

//		mParams = JsonFx.Json.JsonWriter.Serialize (this);
		mDic = this;

	}

	public override string GetType ()
	{
		return "spos";
	}

	public override string GetQueryId()
	{
		return "gameSposPreparedQuiz";
	}

}
