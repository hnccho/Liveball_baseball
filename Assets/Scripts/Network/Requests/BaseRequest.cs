using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseRequest : Dictionary<string, object>{
	protected Dictionary<string, object> mDic;

	public string ToRequestString()
	{
		string str = "";

		#if(UNITY_EDITOR)
		mDic.Add("osType", 1);
//		mDic.Add("version", "3.1.1");
		mDic.Add("version", UnityEditor.PlayerSettings.bundleVersion);
		#elif(UNITY_ANDROID)
		mDic.Add("osType", 1);
		mDic.Add("version", Application.version);
		#else
		mDic.Add("osType", 2);
		mDic.Add("version", Application.version);
		#endif

//		string param = JsonFx.Json.JsonWriter.Serialize (mDic);
		string param = Newtonsoft.Json.JsonConvert.SerializeObject(mDic);
		str += "param=" + param;
		str += "&type="+GetType();
		str += "&id=" + GetQueryId ();

		return str;
	}

	public virtual string GetType(){return null;}
	public virtual string GetQueryId(){return null;}

}
