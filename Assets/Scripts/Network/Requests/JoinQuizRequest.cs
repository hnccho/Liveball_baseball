using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;

public class JoinQuizRequest : BaseRequest {

	public JoinQuizRequest(JoinQuizInfo joinInfo)
	{
		Add ("memSeq", joinInfo.MemSeq);
		Add ("gameSeq", joinInfo.GameSeq);
		Add ("quizListSeq", joinInfo.QuizListSeq);
		Add ("qzType", joinInfo.QzType);
		Add ("useCardNo", joinInfo.UseCardNo);
		Add ("betPoint", joinInfo.BetPoint);
		Add ("item", joinInfo.Item);
		Add ("selectValue", joinInfo.SelectValue);
		Add ("extendValue", joinInfo.ExtendValue);

//		mParams = JsonFx.Json.JsonWriter.Serialize (this);
		mDic = this;
	}

	public override string GetType ()
	{
		return "spos";
	}

	public override string GetQueryId()
	{
		return "gameSposQuizJoin";
	}

}
