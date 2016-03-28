using UnityEngine;
using System.Collections;
using System.Text;

public class DeleteLineupRequest : BaseRequest {

	public DeleteLineupRequest(int lineupSeq)
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
		return "contestRemoveLineup";
	}

}
