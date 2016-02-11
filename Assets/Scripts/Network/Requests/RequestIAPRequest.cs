using UnityEngine;
using System.Collections;
using System.Text;

public class RequestIAPRequest : BaseRequest {

	public RequestIAPRequest(int productId, string productCode)
	{
		Add ("productId", productId);
		Add ("productCode", productCode);
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
		return "tubyInAppPurchaseReq";
	}

}
