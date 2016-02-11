using UnityEngine;
using System.Collections;
using System.Text;

public class CheckMemberPincodeRequest : BaseRequest {

	public CheckMemberPincodeRequest(string pincode)
	{		
		Add ("pinCode", pincode);

		mDic = this;

	}

	public override string GetType ()
	{
		return "apps";
	}

	public override string GetQueryId()
	{
		return "checkMemberPincode";
	}

}
