using UnityEngine;
using System.Collections;
using System.Text;

public class GetMyLineupDataRequest : BaseRequest {

	public GetMyLineupDataRequest(int lineupSeq)
	{
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		Add ("lineupSeq", lineupSeq);

		mDic = this;
	}

	public override string GetType ()
	{
		return "apps.contest";
	}

	public override string GetQueryId()
	{
		return "contestMyLineupData";
	}

}
