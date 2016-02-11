using UnityEngine;
using System.Collections;
using System.Text;

public class GetInAppHistoryRequest : BaseRequest {

	public GetInAppHistoryRequest()
	{
		Add ("memSeq", UserMgr.UserInfo.memSeq);

		mDic = this;
		
	}
	
	public override string GetType ()
	{
		return "apps";
	}
	
	public override string GetQueryId()
	{
		return "tubyGetInAppHistory";
	}
	
}
