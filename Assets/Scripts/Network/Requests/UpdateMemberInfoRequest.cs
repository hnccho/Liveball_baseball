using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.IO;

public class UpdateMemberInfoRequest : BaseUploadRequest {

	public UpdateMemberInfoRequest(JoinMemberInfo memInfo)
	{		
		Dictionary<string, object> dic = new Dictionary<string, object> ();

		#if(UNITY_EDITOR)
		dic.Add("osType", 1);
		dic.Add("version", UnityEditor.PlayerSettings.bundleVersion);
		#elif(UNITY_ANDROID)
		dic.Add("osType", 1);
		dic.Add("version", Application.version);
		#else
		dic.Add("osType", 2);
		dic.Add("version", Application.version);
		#endif

//		Debug.Log("memInfo.MemberName is "+memInfo.MemberName);
		dic.Add ("memSeq", UserMgr.UserInfo.memSeq);
		if(memInfo.MemberName != null && memInfo.MemberName.Length > 0)
			dic.Add ("nick", memInfo.MemberName);
		if (memInfo.Photo != null && memInfo.Photo.Length > 0)
			dic.Add("file", "profile.png");

		AddField("param", Newtonsoft.Json.JsonConvert.SerializeObject(dic));
		
		if (memInfo.Photo != null && memInfo.Photo.Length > 0) {
			if(File.Exists(memInfo.Photo)){
				Debug.Log("a file exists : "+memInfo.Photo);
				byte[] bytes = File.ReadAllBytes(memInfo.Photo);

				AddBinaryData("file", bytes, "profile.png", "image/png");
			} else{
				Debug.Log("a file not found : "+memInfo.Photo);
			}
			
		}

//		if (memInfo.PhotoBytes != null && memInfo.PhotoBytes.Length > 0) {
//			Debug.Log("a file exists : "+memInfo.PhotoBytes);
//			byte[] bytes = memInfo.PhotoBytes;
//			AddBinaryData("file", bytes, "profile.png", "image/png");
//		} else{
//			Debug.Log("a file not found : "+memInfo.PhotoBytes);
//		}
			
	}

	public override string GetType ()
	{
		return "apps.member";
	}

	public override string GetQueryId()
	{
		return "updateMemberInfo";
	}

}
