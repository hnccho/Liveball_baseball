using UnityEngine;
using System.Collections;
using System.Text;

public class GetProgressQuizRequest : BaseRequest {

	public GetProgressQuizRequest(int quizListSeq)
	{
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		Add ("gameSeq", UserMgr.Schedule.gameSeq);
		Add ("teamCode", "");
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
		return "gameSposProgressQuiz";
	}

}
