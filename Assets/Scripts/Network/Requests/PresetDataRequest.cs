using UnityEngine;
using System.Collections;
using System.Text;

public class PresetDataRequest : BaseRequest {

	public PresetDataRequest(int presetSeq)
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
		return "getContestPresetData";
	}

}
