using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.IO;

public class ContestMyTeamRequest : BaseRequest {

	public ContestMyTeamRequest(int contestSeq)
	{	
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		Add ("contestSeq", contestSeq);

		mDic = this;
	}
	public override string GetType ()
	{
		return "apps.contest";
	}

	public override string GetQueryId()
	{
		return "contestMyEntryTeam";
	}

}
