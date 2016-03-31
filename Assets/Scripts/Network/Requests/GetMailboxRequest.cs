using UnityEngine;
using System.Collections;
using System.Text;

public class GetMailboxRequest : BaseRequest {

	public GetMailboxRequest()
	{
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		Add ("mainType", 0);

//		mParams = JsonFx.Json.JsonWriter.Serialize (this);
		mDic = this;

	}

	public override string GetType ()
	{
		return "apps.member";
	}

	public override string GetQueryId()
	{
		return "getMemberMail";
	}

}
