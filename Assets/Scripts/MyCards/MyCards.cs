using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MyCards : MonoBehaviour {

	GetCardInvenEvent mCardEvent;
	GetMailEvent mMailEvent;

	List<CardInfo> mList;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Init(GetCardInvenEvent cardEvent, GetMailEvent mailEvent){
		transform.FindChild("Top").FindChild("Cards").FindChild("LblCardsV").GetComponent<UILabel>().text
			= cardEvent.Response.data.Count+"";
		//need total inven
		
		transform.FindChild("Top").FindChild("Skills").FindChild("LblSkillsV").GetComponent<UILabel>().text
			= 0+"";

		mCardEvent = cardEvent;
		mMailEvent = mailEvent;

		mList = cardEvent.Response.data;
		foreach(CardInfo cardInfo in mList)
			cardInfo.mType = CardInfo.INVEN_TYPE.CARD;

		foreach(Mailinfo mailInfo in mailEvent.Response.data){
			if(mailInfo.mailTitle.Equals("star pack")){
				CardInfo item = new CardInfo();
				item.mType = CardInfo.INVEN_TYPE.PACK;
				mList.Insert(0, item);
			}
		}

		//if not max expand
		CardInfo expand = new CardInfo();
		expand.mType = CardInfo.INVEN_TYPE.EXPAND;
		mList.Add(expand);

		transform.FindChild("Body").FindChild("Draggable").GetComponent<UIDraggablePanel2>()
			.Init(mList.Count, delegate (UIListItem item, int index){
				InitInvenItem(item, index);
		});
		transform.FindChild("Body").FindChild("Draggable").GetComponent<UIDraggablePanel2>().ResetPosition();
	}

	void InitInvenItem(UIListItem item, int index){
		CardInfo info = mList[index];
		item.Target.GetComponent<ItemInvenCard>().mCardInfo = info;

		if(info.mType == CardInfo.INVEN_TYPE.CARD){
			item.Target.transform.FindChild("ItemCardPack").gameObject.SetActive(false);
			item.Target.transform.FindChild("ItemCard").gameObject.SetActive(true);
			item.Target.transform.FindChild("ItemExpand").gameObject.SetActive(false);

			Transform tf = item.Target.transform.FindChild("ItemCard");
			tf.FindChild("LblName").GetComponent<UILabel>().text = info.playerName;
			tf.FindChild("LblPosition").GetComponent<UILabel>().text = info.position;
			tf.FindChild("LblTeam").GetComponent<UILabel>().text = info.teamName;
			tf.FindChild("LblSalary").GetComponent<UILabel>().text = "$"+info.salary;
			tf.FindChild("Star").FindChild("SprStar").FindChild("StarV").GetComponent<UILabel>().text = info.cardClass+"";
			tf.FindChild("Level").FindChild("LblLevel").FindChild("LevelV").GetComponent<UILabel>().text = info.cardLevel+"";
			tf.FindChild("LblFPPG").FindChild("LblFPPGV").GetComponent<UILabel>().text = info.fppg;
			tf.FindChild("LblSkill").FindChild("LblSkillV").GetComponent<UILabel>().text = "1";
		} else if(info.mType == CardInfo.INVEN_TYPE.PACK){
			item.Target.transform.FindChild("ItemCardPack").gameObject.SetActive(true);
			item.Target.transform.FindChild("ItemCard").gameObject.SetActive(false);
			item.Target.transform.FindChild("ItemExpand").gameObject.SetActive(false);
		} else if(info.mType == CardInfo.INVEN_TYPE.EXPAND){
			item.Target.transform.FindChild("ItemCardPack").gameObject.SetActive(false);
			item.Target.transform.FindChild("ItemCard").gameObject.SetActive(false);
			item.Target.transform.FindChild("ItemExpand").gameObject.SetActive(true);
		}
	}
}
