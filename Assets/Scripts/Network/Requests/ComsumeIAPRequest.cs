using UnityEngine;
using System.Collections;
using System.Text;

public class ComsumeIAPRequest : BaseRequest {

	public ComsumeIAPRequest(int orderNo, string token)
	{		
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		Add ("orderNo", orderNo);
		Add ("token", token);

//		mParams = JsonFx.Json.JsonWriter.Serialize (this);
		mDic = this;

	}

	public override string GetType ()
	{
		return "apps";
	}

	public override string GetQueryId()
	{
		return "tubyInAppPurchaseUpdate";
	}

}
