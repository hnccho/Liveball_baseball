using UnityEngine;
using System.Collections;
using System.Text;

public class GetGoldShopRequest : BaseRequest {

	public GetGoldShopRequest()
	{
		Add ("memSeq", UserMgr.UserInfo.memSeq);

//		mParams = JsonFx.Json.JsonWriter.Serialize (this);
		mDic = this;
	}

	public override string GetType ()
	{
		return "apps.product";
	}

	public override string GetQueryId()
	{
		return "paymentIAProductList";
	}

}
