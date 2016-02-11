using UnityEngine;
using System.Collections;
using System.Text;

public class ContestListRequest : BaseRequest {

	public ContestListRequest()
	{
		Add ("memSeq", UserMgr.UserInfo.memSeq);
	

//		mParams = JsonFx.Json.JsonWriter.Serialize (this);
		mDic = this;
	}

	public override string GetType ()
	{
		return "apps";
	}

	public override string GetQueryId()
	{
		return "getContestList";
	}

}
