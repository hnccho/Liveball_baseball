using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;
public class PresetUpdateRequest : BaseRequest {

	public PresetUpdateRequest(int ContestSeq,int presetSeq,List<int> List)
	{
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		Add ("contestSeq", ContestSeq);
		Add ("presetSeq", presetSeq);
		if (List.Count >= 17) {
			for (int i = 0; i<List.Count; i++) {
				if (i < 9) {
					Add ("a" + (i + 1).ToString (), List [i]);
				} else {
					Add ("h" + (i -9 + 1).ToString (), List [i]);
				}
			}
		}

//		mParams = JsonFx.Json.JsonWriter.Serialize (this);
		mDic = this;
	}

	public override string GetType ()
	{
		return "apps";
	}

	public override string GetQueryId()
	{
		return "updateContestPreset";
	}

}
