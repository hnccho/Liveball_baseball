using UnityEngine;
using System.Collections;
using System.Text;

public class AccuseContentRequest : BaseRequest {

	public AccuseContentRequest(AccusationInfo accuInfo)
	{
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		Add ("boardNo" , accuInfo.BoardNum);
		Add ("contentsSeq" , accuInfo.ContentNum);
		Add ("reportType" , accuInfo.Type);
		Add ("reportMsg" , accuInfo.Msg);

		mDic = this;
		
	}
	
	public override string GetType ()
	{
		return "apps";
	}
	
	public override string GetQueryId()
	{
		return "sendReport";
	}
	
}
