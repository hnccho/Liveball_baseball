using UnityEngine;
using System.Collections;
using System.Text;

public class UpdateEntryRequest : BaseRequest {

	public UpdateEntryRequest(string lineupName, int lineupSeq, int entrySeq, int contestSeq, long[][] slots)
	{
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		Add ("lineupName", lineupName);
		Add ("lineupSeq", lineupSeq);
		Add ("entrySeq", entrySeq);
		Add ("contestSeq", contestSeq);
		for(int i = 0; i < slots.Length; i++){
			Add ("slot"+(i+1), slots[i][0]); //playerId
			Add ("item"+(i+1), slots[i][1]); //a card given id
		}
		mDic = this;
	}

	public override string GetType ()
	{
		return "apps.contest";
	}

	public override string GetQueryId()
	{
		return "contestUpdateEntry";
	}

}
