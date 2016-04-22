using UnityEngine;
using System.Collections;
using System.Text;

public class GetCurrentLineupRequest : BaseRequest {
	
	public GetCurrentLineupRequest(int gameId, int inning, int bingoId)
	{
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		Add ("gameId", gameId);
		Add ("inning", inning);
		Add ("bingoId", bingoId);
		//		mParams = JsonFx.Json.JsonWriter.Serialize (this);
		mDic = this;
		
	}
	
	public override string GetType ()
	{
		return "apps.rtime";
	}
	
	public override string GetQueryId()
	{
		return "getCurrentLineup";
	}
	
}
