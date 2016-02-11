using UnityEngine;
using System.Collections;
using System.Text;

public class procStoreGachaRequest : BaseRequest {

	public procStoreGachaRequest(long product)
	{
		Add ("memSeq", UserMgr.UserInfo.memSeq);
	
		Add ("product", product);
//		mParams = JsonFx.Json.JsonWriter.Serialize (this);
		mDic = this;
	}

	public override string GetType ()
	{
		return "apps";
	}

	public override string GetQueryId()
	{
		return "procStoreGacha";
	}

}
