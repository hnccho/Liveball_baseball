using UnityEngine;
using System.Collections;
using System.Text;

public class ContestDetailsRequest : BaseRequest {

	public ContestDetailsRequest(int entrySeq)
	{
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		Add ("entrySeq", entrySeq);

		mDic = this;
	}

	public override string GetType ()
	{
		return "apps.contest";
	}

	public override string GetQueryId()
	{
		return "contestMyEntryData";
	}

}
