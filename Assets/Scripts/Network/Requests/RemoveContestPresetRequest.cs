using UnityEngine;
using System.Collections;
using System.Text;

public class RemoveContestPresetRequest : BaseRequest {
	
	public RemoveContestPresetRequest(int presetSeq)
	{
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		Add ("presetSeq", presetSeq);
		//		mParams = JsonFx.Json.JsonWriter.Serialize (this);
		mDic = this;
		
	}
	
	public override string GetType ()
	{
		return "apps";
	}
	
	public override string GetQueryId()
	{
		return "removeContestPreset";
	}
	
}
