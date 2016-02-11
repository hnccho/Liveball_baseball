using UnityEngine;
using System.Collections;
using System.Text;

public class GetSposTeamInfoRequest : BaseRequest {
	
	public GetSposTeamInfoRequest(string teamCode)
	{
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		Add ("teamCode", teamCode);
		//		mParams = JsonFx.Json.JsonWriter.Serialize (this);
		mDic = this;
		
	}
	
	public override string GetType ()
	{
		return "apps";
	}
	
	public override string GetQueryId()
	{
		return "getSposTeamInfo";
	}
	
}
