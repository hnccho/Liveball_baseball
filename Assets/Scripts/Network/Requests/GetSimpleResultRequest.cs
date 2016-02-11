using UnityEngine;
using System.Collections;
using System.Text;

public class GetSimpleResultRequest : BaseRequest {

	public GetSimpleResultRequest(int quizListSeq)
	{
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		Add ("gameSeq", UserMgr.Schedule.gameSeq);
		Add ("contestSeq", UserMgr.CurrentContestSeq);
		Add ("presetSeq", UserMgr.CurrentPresetSeq);
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
		return "gameSposSimpleQuizResult";
	}

}
