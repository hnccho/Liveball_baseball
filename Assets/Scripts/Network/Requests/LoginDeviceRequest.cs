using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;

public class LoginDeviceRequest : BaseUploadRequest {

	public LoginDeviceRequest(string deviceID)
	{
		Dictionary<string, object> dic = new Dictionary<string, object> ();

		#if(UNITY_EDITOR)
		dic.Add ("version", UnityEditor.PlayerSettings.bundleVersion);
		dic.Add ("osType", 1);
		#elif(UNITY_ANDROID)
		dic.Add("version", Application.version);
		dic.Add ("osType", 1);
		#else
		dic.Add("version", Application.version);
		dic.Add ("osType", 2);
		#endif
		dic.Add ("deviceID", deviceID);

		AddField("param", Newtonsoft.Json.JsonConvert.SerializeObject(dic));
	}

	public override string GetType ()
	{
		return "apps.member";
	}

	public override string GetQueryId()
	{
		return "checkMemberDevice";
	}

}
