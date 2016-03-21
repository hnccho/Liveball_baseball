using UnityEngine;
using System.Collections;
using System.Text;

public class GetItemShopGoldRequest : BaseRequest {

	public GetItemShopGoldRequest(int category)
	{
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		Add ("category", category);
		Add ("itemType", 0);

//		mParams = JsonFx.Json.JsonWriter.Serialize (this);
		mDic = this;
	}

	public override string GetType ()
	{
		return "apps.product";
	}

	public override string GetQueryId()
	{
		return "getStoreProductList";
	}

}
