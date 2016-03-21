using UnityEngine;
using System.Collections;
using System.Text;

public class PurchaseGoldRequest : BaseRequest {

	public PurchaseGoldRequest(string productCode)
	{		
		Add ("productCode", productCode);
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		Add ("bundle", "0");
		Add ("token", "0");

//		mParams = JsonFx.Json.JsonWriter.Serialize (this);
		mDic = this;
	}

	public override string GetType ()
	{
		return "apps.product";
	}

	public override string GetQueryId()
	{
		return "payStorePurchase";
	}

}
