using UnityEngine;
using System.Collections;
using System.Text;

public class ContestRankingeRequest : BaseRequest {

	public ContestRankingeRequest(int GameSeq)
	{		
		Add("memSeq", UserMgr.UserInfo.memSeq);
		if (GameSeq == 0) {
			Add ("gameSeq", UserMgr.Schedule.gameSeq);
		} else {
			Add ("gameSeq", GameSeq);
		}
		Add("contestSeq", UserMgr.CurrentContestSeq);

		mDic = this;
	}

	public override string GetType ()
	{
		return "spos";
	}

	public override string GetQueryId()
	{
		return "getContestRanking";
	}

}
