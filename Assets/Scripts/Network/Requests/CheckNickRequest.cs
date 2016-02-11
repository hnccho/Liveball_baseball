using UnityEngine;
using System.Collections;
using System.Text;

public class CheckNickRequest : BaseRequest {

	public CheckNickRequest(string name)
	{		
		Add ("search", name);

		mDic = this;
	}

	public override string GetType ()
	{
		return "apps";
	}

	public override string GetQueryId()
	{
		return "tubyFindUserCount";
	}

}
