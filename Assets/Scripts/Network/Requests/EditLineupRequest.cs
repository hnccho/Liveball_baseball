using UnityEngine;
using System.Collections;
using System.Text;

public class EditLineupRequest : BaseRequest {

	public EditLineupRequest(string name, int lineupSeq)
	{
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		Add ("lineupSeq", lineupSeq);
		Add ("name", name);

		mDic = this;
	}

	public override string GetType ()
	{
		return "apps.contest";
	}

	public override string GetQueryId()
	{
		return "contestUpdateLineup";
	}

}
