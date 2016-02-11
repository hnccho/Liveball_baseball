using UnityEngine;
using System.Collections;
using System.Text;

public class InAppPurchaseRequest : BaseRequest {

	public InAppPurchaseRequest(string productCode, string token, string purchaseKey)
	{
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		Add ("productCode", productCode);
		Add ("token", token);
		Add ("purchaseKey", purchaseKey);

		mDic = this;
		
	}
	
	public override string GetType ()
	{
		return "apps";
	}
	
	public override string GetQueryId()
	{
		return "tubyInAppPurchase";
	}
	
}
