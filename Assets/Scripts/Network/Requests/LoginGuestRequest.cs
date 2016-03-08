using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.IO;

public class LoginGuestRequest : BaseUploadRequest {
		
	public LoginGuestRequest(LoginInfo loginInfo)
	{
		Dictionary<string, object> dic = new Dictionary<string, object> ();
		dic.Add ("name", loginInfo.nick == null ? "" : loginInfo.nick);
		dic.Add ("memUID", loginInfo.memUID == null ? "" : loginInfo.memUID);
//		Debug.Log("deviceID is "+loginInfo.DeviceID);
//		loginInfo.DeviceID = "test9";
		dic.Add ("osType", loginInfo.osType);
		#if(UNITY_EDITOR)
		dic.Add("version", UnityEditor.PlayerSettings.bundleVersion);
		#elif(UNITY_ANDROID)
		dic.Add("version", Application.version);
		#else
		dic.Add("version", Application.version);
		#endif
		dic.Add ("deviceID", loginInfo.DeviceID);
		
		
		//		AddField ("param", JsonFx.Json.JsonWriter.Serialize (dic));
		AddField("param", Newtonsoft.Json.JsonConvert.SerializeObject(dic));
		
		if (loginInfo.Photo != null && loginInfo.Photo.Length > 0) {
			if(File.Exists(loginInfo.Photo)){
				Debug.Log("a file exists : "+loginInfo.Photo);
				byte[] bytes = File.ReadAllBytes(loginInfo.Photo);
				AddBinaryData("file", bytes, "profile.png", "image/png");
			} else{
				Debug.Log("a file not found : "+loginInfo.Photo);
			}
			
		}
		
		if (loginInfo.PhotoBytes != null && loginInfo.PhotoBytes.Length > 0) {
			
			Debug.Log("a file exists : "+loginInfo.PhotoBytes);
			byte[] bytes = loginInfo.PhotoBytes;
			
			AddBinaryData("file", bytes, "profile.png", "image/png");
		} else{
			Debug.Log("a file not found : "+loginInfo.PhotoBytes);
		}
		
	}

	public override string GetType ()
	{
		return "apps.member";
	}

	public override string GetQueryId()
	{
		return "memberLoginDevice";
	}

}
