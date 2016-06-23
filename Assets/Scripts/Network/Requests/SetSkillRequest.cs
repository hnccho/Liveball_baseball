using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.IO;

public class SetSkillRequest : BaseRequest {

	public SetSkillRequest(CardInfo card, SkillsetInfo skillset, int slot)
	{	
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		Add ("cardId", card.itemSeq);
		Add ("skillId", skillset.itemSeq);
		Add ("slotNo", slot);

		mDic = this;
	}

	public override string GetType ()
	{
		return "apps.member";
	}

	public override string GetQueryId()
	{
		return "setSkillDockingOn";
	}

}
