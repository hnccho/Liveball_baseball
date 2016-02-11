using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class JoinMemberRequest : BaseUploadRequest {

	public JoinMemberRequest(JoinMemberInfo memInfo)
	{
		Dictionary<string, object> dic = new Dictionary<string, object> ();
		dic.Add("memberEmail", memInfo.MemberEmail);
		//		dic.Add ("memberEmail", memInfo.MemberID);
		dic.Add ("memberName", memInfo.MemberName);
		dic.Add ("osType", memInfo.OsType);
		dic.Add ("registType", memInfo.RegistType);
		dic.Add ("memberPwd", memInfo.MemberPwd);
		dic.Add ("memUID", memInfo.MemUID);
		dic.Add ("memImage", memInfo.MemImage);
		dic.Add("favoBB", memInfo.FavoBB);
		dic.Add("deviceID", memInfo.DeviceID);


//		AddField ("param", JsonFx.Json.JsonWriter.Serialize (dic));
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

		if (memInfo.PhotoBytes != null && memInfo.PhotoBytes.Length > 0) {
			
			Debug.Log("a file exists : "+memInfo.PhotoBytes);
			byte[] bytes = memInfo.PhotoBytes;
			
			AddBinaryData("file", bytes, "profile.png", "image/png");
		} else{
			Debug.Log("a file not found : "+memInfo.PhotoBytes);
		}
		
	}
//		Debug.Log ("memberPwd : " + memInfo.MemberPwd);



	public override string GetType ()
	{
		return "apps";
	}

	public override string GetQueryId()
	{
		return "tubyJoinMember";
	}

}
