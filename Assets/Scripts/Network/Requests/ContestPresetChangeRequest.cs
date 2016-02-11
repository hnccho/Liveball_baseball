using UnityEngine;
using System.Collections;
using System.Text;

public class ContestPresetChangeRequest : BaseRequest {

	public ContestPresetChangeRequest(string gameQuziSeq,string presetValue)
	{		
		Add("memSeq", UserMgr.UserInfo.memSeq);
		Add("gameSeq", UserMgr.Schedule.gameSeq);
		Add("gameQuizSeq", gameQuziSeq);
		Add("presetSeq", UserMgr.CurrentPresetSeq);
		Add("presetValue", presetValue);


		mDic = this;
	}

	public override string GetType ()
	{
		return "spos";
	}

	public override string GetQueryId()
	{
		return "gameContestPresetChange";
	}

}
