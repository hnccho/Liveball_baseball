using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.IO;

public class CardRankUpRequest : BaseRequest {

	public CardRankUpRequest(CardInfo targetCard, CardInfo feedingCard)
	{	
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		Add ("itemMain", targetCard.itemSeq);
		Add ("itemSub", feedingCard.itemSeq);

		mDic = this;
	}
	public override string GetType ()
	{
		return "apps.member";
	}

	public override string GetQueryId()
	{
		return "procItemCompose";
	}

}
