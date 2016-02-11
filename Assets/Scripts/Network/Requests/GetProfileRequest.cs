using UnityEngine;
using System.Collections;
using System.Text;

public class GetProfileRequest : BaseRequest {

	public GetProfileRequest(int memSeq)
	{
		Add ("memSeq", memSeq);

//		mParams = JsonFx.Json.JsonWriter.Serialize (this);
		mDic = this;

	}

	public override string GetType ()
	{
		return "apps";
	}

	public override string GetQueryId()
	{
		return "tubyGetProfileInfo";
	}

}
