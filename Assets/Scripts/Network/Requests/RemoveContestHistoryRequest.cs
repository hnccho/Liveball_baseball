using UnityEngine;
using System.Collections;
using System.Text;

public class RemoveContestHistoryRequest : BaseRequest {
	
	public RemoveContestHistoryRequest(int presetSeq)
	{
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		Add ("presetSeq", presetSeq);
		mDic = this;		
	}
	
	public override string GetType ()
	{
		return "apps";
	}
	
	public override string GetQueryId()
	{
		return "removeContestHistory";
	}
	
}
