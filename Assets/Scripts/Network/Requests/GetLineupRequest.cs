using UnityEngine;
using System.Collections;
using System.Text;

public class GetLineupRequest : BaseRequest {

	public GetLineupRequest()
	{
		Add ("memSeq", UserMgr.UserInfo.memSeq);

		mDic = this;
	}

	public override string GetType ()
	{
		return "apps.contest";
	}

	public override string GetQueryId()
	{
		return "contestMyLineupList";
	}

}
