using UnityEngine;
using System.Collections;
using System.Text;

public class MergeMembershipRequest : BaseRequest {

	public MergeMembershipRequest(string pincode)
	{		
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		Add ("memPIN", pincode);

		mDic = this;

	}

	public override string GetType ()
	{
		return "apps";
	}

	public override string GetQueryId()
	{
		return "tubyMergeMembership";
	}

}
