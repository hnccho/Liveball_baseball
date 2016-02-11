using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.IO;

public class UpdateMemberInfoRequest : BaseUploadRequest {

	public UpdateMemberInfoRequest(JoinMemberInfo memInfo)
	{		
		Dictionary<string, object> dic = new Dictionary<string, object> ();
		dic.Add ("memSeq", UserMgr.UserInfo.memSeq);
		dic.Add ("memName", memInfo.MemberName);
		dic.Add ("memEmail", memInfo.MemberEmail);
		dic.Add ("memImage", memInfo.MemImage);
		dic.Add ("favoBB", memInfo.FavoBB);		

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



	public override string GetType ()
	{
		return "apps";
	}

	public override string GetQueryId()
	{
		return "tubyUpdateMemberInfo";
	}

}
