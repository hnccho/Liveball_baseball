using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.IO;

public class WithdrawRequest : BaseRequest {

	public WithdrawRequest()
	{		
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		Add ("text", "");

		mDic = this;

	}
	public override string GetType ()
	{
		return "apps";
	}

	public override string GetQueryId()
	{
		return "serviceWithdraw";
	}

}
