using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.IO;

public class ExpandSkillInvenRequest : BaseRequest {

	public ExpandSkillInvenRequest()
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
		return "increaseSkillInven";
	}

}
