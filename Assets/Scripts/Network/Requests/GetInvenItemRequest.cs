using UnityEngine;
using System.Collections;
using System.Text;

public class GetInvenItemRequest : BaseRequest {

	public GetInvenItemRequest()
	{
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		//Add ("memSeq", 210);

//		mParams = JsonFx.Json.JsonWriter.Serialize (this);
		mDic = this;

	}

	public override string GetType ()
	{
		return "apps";
	}

	public override string GetQueryId()
	{
		return "tubyGetInvenItem";
	}

}
