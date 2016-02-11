using UnityEngine;
using System.Collections;
using System.Text;

public class GetDoneInvenItemRequest : BaseRequest {
	
	public GetDoneInvenItemRequest(long itemNo, long itemId)
	{
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		Add ("itemNo", itemNo);
		Add ("itemId", itemId);
		//		mParams = JsonFx.Json.JsonWriter.Serialize (this);
		mDic = this;
		
	}
	
	public override string GetType ()
	{
		return "apps";
	}
	
	public override string GetQueryId()
	{
		return "tubyDoneInvenItem";
	}
	
}
