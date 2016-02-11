using UnityEngine;
using System.Collections;
using System.Text;

public class GetMailboxRequest : BaseRequest {

	public GetMailboxRequest(int memSeq)
	{
		Add ("memSeq", memSeq);

//		mParams = JsonFx.Json.JsonWriter.Serialize (this);
		mDic = this;

	}

	public override string GetType ()
	{
		return "apps";
	}

	public override string GetQueryId()
	{
		return "getMailbox";
	}

}
