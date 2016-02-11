using UnityEngine;
using System.Collections;
using System.Text;

public class CheckMemberDeviceRequest : BaseRequest {

	public CheckMemberDeviceRequest(string deviceId)
	{		
		Add("deviceID", deviceId);

		mDic = this;
	}

	public override string GetType ()
	{
		return "apps";
	}

	public override string GetQueryId()
	{
		return "checkMemberDevice";
	}

}
