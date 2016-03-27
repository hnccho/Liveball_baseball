using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.IO;

public class CardLevelUpRequest : BaseRequest {

	public CardLevelUpRequest(CardInfo targetCard, List<CardInfo> feedingCards)
	{	
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		Add ("itemMain", targetCard.itemSeq);
		string feeds = "";
		foreach(CardInfo info in feedingCards)
			feeds += info.itemSeq + ",";
		Add ("itemSub", feeds);

		mDic = this;
	}
	public override string GetType ()
	{
		return "apps.member";
	}

	public override string GetQueryId()
	{
		return "procItemStrengthen";
	}

}
