using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.IO;

public class RewardInfoRequest : BaseRequest {

	public RewardInfoRequest(int contestSeq)
	{	
		Add ("contestSeq", contestSeq);

		mDic = this;
	}
	public override string GetType ()
	{
		return "apps.contest";
	}

	public override string GetQueryId()
	{
		return "contestGetRewardList";
	}

}
