using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MyCards : MonoBehaviour {

	GetCardInvenEvent mCardEvent;
	GetMailEvent mMailEvent;

	List<CardInfo> mList;
	Texture2D mDefaultTxt;
	
	// Use this for initialization
	void Start () {
		mDefaultTxt = Resources.Load<Texture2D>("images/man_default_b");		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public GetMailEvent GetMailEvent(){
		return mMailEvent;
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

			tf.GetComponent<ItemCard>().mCardInfo = info;
			tf.FindChild("LblName").GetComponent<UILabel>().text = info.firstName + " " + info.lastName;
			if(tf.FindChild("LblName").GetComponent<UILabel>().width > 232)
				tf.FindChild("LblName").GetComponent<UILabel>().text = info.firstName.Substring(0, 1) + ". " + info.lastName;
			tf.FindChild("LblPosition").GetComponent<UILabel>().text = info.position;
			tf.FindChild("LblTeam").GetComponent<UILabel>().text = info.city + " " + info.teamName;
			tf.FindChild("LblSalary").GetComponent<UILabel>().text = "$"+info.salary;
			tf.FindChild("Star").FindChild("SprStar").FindChild("StarV").GetComponent<UILabel>().text = info.cardClass+"";
			tf.FindChild("Level").FindChild("LblLevel").FindChild("LevelV").GetComponent<UILabel>().text = info.cardLevel+"";
			tf.FindChild("LblFPPG").FindChild("LblFPPGV").GetComponent<UILabel>().text = info.fppg;
			tf.FindChild("LblSkill").FindChild("LblSkillV").GetComponent<UILabel>().text = "1";
			if(UtilMgr.IsMLB()){
				tf.FindChild("MLB").gameObject.SetActive(true);
				tf.FindChild("KBO").gameObject.SetActive(false);

				tf = item.Target.transform.FindChild("ItemCard").FindChild("MLB");
				
				if((info.injuryYN != null) && (info.injuryYN.Equals("Y"))){
					tf.FindChild("BtnPhoto").FindChild("SprInjury").gameObject.SetActive(true);
				} else
					tf.FindChild("BtnPhoto").FindChild("SprInjury").gameObject.SetActive(false);

				if(info.useYn > 0){
					tf.FindChild("BtnPhoto").FindChild("Panel").FindChild("Inuse").gameObject.SetActive(true);
					tf.FindChild("BtnPhoto").FindChild("Panel").GetComponent<UIPanel>().baseClipRegion
						= new Vector4(0, 0, 156f, 130f);
				} else{
					tf.FindChild("BtnPhoto").FindChild("Panel").FindChild("Inuse").gameObject.SetActive(false);
					tf.FindChild("BtnPhoto").FindChild("Panel").GetComponent<UIPanel>().baseClipRegion
						= new Vector4(0, 0, 152f, 108f);
				}
			} else{
				tf.FindChild("MLB").gameObject.SetActive(false);
				tf.FindChild("KBO").gameObject.SetActive(true);

				tf = item.Target.transform.FindChild("ItemCard").FindChild("KBO");

				tf.FindChild("BtnPhoto").FindChild("Panel").FindChild("Inuse").gameObject.SetActive(false);
				tf.FindChild("BtnPhoto").FindChild("Panel").GetComponent<UIPanel>().baseClipRegion
					= new Vector4(0, 0, 152f, 186f);

				if(info.useYn > 0){
					tf.FindChild("BtnPhoto").FindChild("Panel").FindChild("Inuse").gameObject.SetActive(true);
					tf.FindChild("BtnPhoto").FindChild("Panel").GetComponent<UIPanel>().baseClipRegion
					= new Vector4(0, 0, 156f, 130f);
				} else{
					tf.FindChild("BtnPhoto").FindChild("Panel").FindChild("Inuse").gameObject.SetActive(false);
					tf.FindChild("BtnPhoto").FindChild("Panel").GetComponent<UIPanel>().baseClipRegion
					= new Vector4(0, 0, 152f, 108f);
				}
			}



			tf.FindChild("BtnPhoto").FindChild("Panel").FindChild("Texture").GetComponent<UITexture>().mainTexture = mDefaultTxt;
			
			tf.FindChild("BtnPhoto").FindChild("Panel").FindChild("Texture").GetComponent<UITexture>().color
				= new Color(1f, 1f, 1f, 50f/255f);
			
			UtilMgr.LoadImage(info.photoUrl,
			                  tf.FindChild("BtnPhoto").FindChild("Panel").FindChild("Texture").GetComponent<UITexture>());


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
