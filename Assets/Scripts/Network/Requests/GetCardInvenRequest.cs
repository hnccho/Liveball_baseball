using UnityEngine;
using System.Collections;
using System.Text;

public class GetCardInvenRequest : BaseRequest {

	public GetCardInvenRequest()
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
		return "tubyGetCardInven";
	}

}
