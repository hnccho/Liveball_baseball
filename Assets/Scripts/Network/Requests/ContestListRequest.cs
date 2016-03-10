using UnityEngine;
using System.Collections;
using System.Text;

public class ContestListRequest : BaseRequest {

	public ContestListRequest(int featured, int type)
	{
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		Add ("organ", 1);
		Add ("featured", featured);
		Add ("type", type);

//		mParams = JsonFx.Json.JsonWriter.Serialize (this);
		mDic = this;
	}

	public override string GetType ()
	{
		return "apps.contest";
	}

	public override string GetQueryId()
	{
		return "contestGetList";
	}

}
