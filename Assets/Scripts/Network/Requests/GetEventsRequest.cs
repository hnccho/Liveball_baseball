using UnityEngine;
using System.Collections;
using System.Text;

public class GetEventsRequest : BaseRequest {
	
	public GetEventsRequest()
	{
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		
		//		mParams = JsonFx.Json.JsonWriter.Serialize (this);
		mDic = this;
		
	}
	
	public override string GetType ()
	{
		return "apps.ginfo";
	}
	
	public override string GetQueryId()
	{
		return "getEventListMLB";
	}

}
