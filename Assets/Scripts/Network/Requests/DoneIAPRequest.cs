using UnityEngine;
using System.Collections;
using System.Text;

public class DoneIAPRequest : BaseRequest {

	public DoneIAPRequest(int orderNo)
	{		
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		Add ("orderNo", orderNo);

//		mParams = JsonFx.Json.JsonWriter.Serialize (this);
		mDic = this;
	}

	public override string GetType ()
	{
		return "apps";
	}

	public override string GetQueryId()
	{
		return "tubyInAppPurchaseDone";
	}

}
