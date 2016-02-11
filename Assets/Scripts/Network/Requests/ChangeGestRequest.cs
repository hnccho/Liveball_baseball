using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.IO;

public class ChangeGestRequest : BaseUploadRequest {

	public ChangeGestRequest(LoginInfo loginInfo)
	{		
		Dictionary<string, object> dic = new Dictionary<string, object> ();
		dic.Add ("memSeq", UserMgr.UserInfo.memSeq);
		dic.Add ("memberEmail", loginInfo.memberEmail);
		dic.Add ("memberPwd", loginInfo.memberPwd);
		dic.Add ("memUID", loginInfo.memUID);
		dic.Add ("deviceID", loginInfo.DeviceID);		

//		AddField ("param", JsonFx.Json.JsonWriter.Serialize (dic));
		AddField("param", Newtonsoft.Json.JsonConvert.SerializeObject(dic));



	}
	public override string GetType ()
	{
		return "apps";
	}

	public override string GetQueryId()
	{
		return "tubyChangeMembership";
	}

}
