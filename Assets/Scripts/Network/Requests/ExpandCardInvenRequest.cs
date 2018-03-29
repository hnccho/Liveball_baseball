using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.IO;

public class ExpandCardInvenRequest : BaseRequest {

	public ExpandCardInvenRequest()
	{	
		Add ("memSeq", UserMgr.UserInfo.memSeq);

		mDic = this;
	}
	public override string GetType ()
	{
		return "apps.member";
	}

	public override string GetQueryId()
	{
		return "increaseCardInven";
	}

}
