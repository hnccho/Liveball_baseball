using UnityEngine;
using System.Collections;
using System.Text;

public class PresetGameDataRequest : BaseRequest {

	public PresetGameDataRequest()
	{
		Add ("memSeq", UserMgr.UserInfo.memSeq);
	

//		mParams = JsonFx.Json.JsonWriter.Serialize (this);
		mDic = this;
	}

	public override string GetType ()
	{
		return "apps";
	}

	public override string GetQueryId()
	{
		return "getContestPresetData";
	}

}
