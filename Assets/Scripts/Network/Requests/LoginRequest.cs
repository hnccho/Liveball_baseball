using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;

public class LoginRequest : BaseRequest {

	public LoginRequest(LoginInfo loginInfo)
	{

		Add ("memberEmail", loginInfo.memberEmail);
		Add ("memberName", loginInfo.memberName);
		Add ("memUID", loginInfo.memUID);
		Add ("osType", loginInfo.osType);
		Add ("registType", loginInfo.registType);
		Add ("memberPwd", loginInfo.memberPwd);
		Add ("version", Application.version);
		Add ("deviceID", loginInfo.DeviceID);

//		mParams = JsonFx.Json.JsonWriter.Serialize (this);
		mDic = this;
	}

	public override string GetType ()
	{
		return "apps";
	}

	public override string GetQueryId()
	{
		return "tubyLogin";
	}

}
