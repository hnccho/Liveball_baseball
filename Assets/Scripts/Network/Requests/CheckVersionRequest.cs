using UnityEngine;
using System.Collections;
using System.Text;

public class CheckVersionRequest : BaseRequest {

	public CheckVersionRequest()
	{
//#if(UNITY_EDITOR)
//		Add ("osType", 1);
//#elif(UNITY_ANDROID)
//		Add ("osType", 1);
//#else
//		Add ("osType", 2);
//#endif

//		mParams = JsonFx.Json.JsonWriter.Serialize (this);
		mDic = this;

	}

	public override string GetType ()
	{
		return "apps";
	}

	public override string GetQueryId()
	{
		return "checkVersion";
	}

}
