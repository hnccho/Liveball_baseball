using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.IO;

public class OpenCardPackRequest : BaseRequest {

	public OpenCardPackRequest(int mailSeq, long itemFK)
	{	
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		Add ("mailSeq", mailSeq);
		Add ("itemFK", itemFK);

		mDic = this;
	}
	public override string GetType ()
	{
		return "apps.member";
	}

	public override string GetQueryId()
	{
		return "openMailbox";
	}

}
