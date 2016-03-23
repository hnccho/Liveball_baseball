using UnityEngine;
using System.Collections;
using System.Text;

public class ContestDataRequest : BaseRequest {

	public ContestDataRequest(int status)
	{
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		Add ("status", status);

//		mParams = JsonFx.Json.JsonWriter.Serialize (this);
		mDic = this;
	}

	public override string GetType ()
	{
		return "apps.contest";
	}

	public override string GetQueryId()
	{
		return "contestMyEntryList";
	}

}
