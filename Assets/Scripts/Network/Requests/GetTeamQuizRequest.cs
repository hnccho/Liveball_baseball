using UnityEngine;
using System.Collections;
using System.Text;

public class GetTeamQuizRequest : BaseRequest {

	public GetTeamQuizRequest(string teamCode)
	{
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		Add ("gameSeq", 0);
		Add ("teamCode", teamCode);
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
		return "gameSposProgressQuiz";
	}

}
