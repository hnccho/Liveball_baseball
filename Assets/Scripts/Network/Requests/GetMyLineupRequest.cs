using UnityEngine;
using System.Collections;
using System.Text;

public class GetMyLineupRequest : BaseRequest {

	public GetMyLineupRequest(int entrySeq)
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
