using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectFeeding : MonoBehaviour {

	GetCardInvenEvent mCardEvent;
	Texture2D mDefaultTxt;
	List<CardInfo> mSortedList;
	CardInfo mTargetCard;
	// Use this for initialization
	void Start () {
		mDefaultTxt = Resources.Load<Texture2D>("images/man_default_b");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Init(CardInfo targetCard){
		mTargetCard = targetCard;
		transform.gameObject.SetActive(true);
		transform.localPosition = new Vector3(2000f, 2000f);
		mCardEvent = new GetCardInvenEvent(ReceivedCard);
		NetMgr.GetCardInven(mCardEvent);
	}

	void ReceivedCard(){
		UtilMgr.ClearList(transform.FindChild("Body").FindChild("Draggable"));

		if(mSortedList != null) mSortedList.Clear();
		mSortedList = new List<CardInfo>();

		if(transform.root.FindChild("CardPowerUp").GetComponent<CardPowerUp>().mType == CardPowerUp.TYPE.LEVELUP){
			foreach(CardInfo info in mCardEvent.Response.data){
				if(info.itemSeq == mTargetCard.itemSeq){
					continue;
				} else if(info.useYn > 0){
					continue;
				}
				mSortedList.Add(info);
			}
		} else{
			foreach(CardInfo info in mCardEvent.Response.data){
				if(info.itemSeq == mTargetCard.itemSeq){
					continue;
				} else if(info.useYn > 0){
					continue;
				} else if(info.cardClass < mTargetCard.cardClass){
					continue;
				} else if(info.cardLevel < 5){
					continue;
				}
				mSortedList.Add(info);
			}
		}


		transform.FindChild("Body").FindChild("Draggable").GetComponent<UIDraggablePanel2>()
			.Init(mSortedList.Count, delegate (UIListItem item, int index){
				InitInvenItem(item, index);
			});
		transform.FindChild("Body").FindChild("Draggable").GetComponent<UIDraggablePanel2>().ResetPosition();

		if(transform.root.FindChild("CardPowerUp").GetComponent<CardPowerUp>().mType == CardPowerUp.TYPE.LEVELUP){
			transform.FindChild("Top").FindChild("LblSelected").FindChild("Label")
				.GetComponent<UILabel>().text = 
					transform.root.FindChild("CardPowerUp").GetComponent<CardPowerUp>().mCardFeedList.Count+"/4";
		} else{
			transform.FindChild("Top").FindChild("LblSelected").FindChild("Label")
				.GetComponent<UILabel>().text = 
					transform.root.FindChild("CardPowerUp").GetComponent<CardPowerUp>().mCardFeedList.Count+"/1";
		}


		UtilMgr.AddBackState(UtilMgr.STATE.SelectFeeding);
		UtilMgr.AnimatePageToLeft("CardPowerUp", "SelectFeeding");
	}

	void InitInvenItem(UIListItem item, int index){
		CardInfo info = mSortedList[index];
		item.Target.transform.FindChild("ItemCard").FindChild("BtnRight").GetComponent<BtnSelectFeeding>().mCardInfo = info;

		item.Target.transform.FindChild("ItemCard").FindChild("BtnRight").GetComponent<BtnSelectFeeding>().IsSelected = false;

		if(transform.root.FindChild("CardPowerUp").GetComponent<CardPowerUp>().mCardFeedList != null)
		foreach(CardInfo feedInfo in transform.root.FindChild("CardPowerUp").GetComponent<CardPowerUp>().mCardFeedList){
				if(feedInfo.itemSeq == info.itemSeq){
					item.Target.transform.FindChild("ItemCard").FindChild("BtnRight").GetComponent<BtnSelectFeeding>().IsSelected = true;
					break;
				}
			}

		Transform tf = item.Target.transform.FindChild("ItemCard");

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
		if(info.useYn > 0){
			tf.FindChild("BtnPhoto").FindChild("Panel").FindChild("Inuse").gameObject.SetActive(true);
			tf.FindChild("BtnPhoto").FindChild("Panel").GetComponent<UIPanel>().baseClipRegion
				= new Vector4(0, 0, 156f, 130f);
		} else{
			tf.FindChild("BtnPhoto").FindChild("Panel").FindChild("Inuse").gameObject.SetActive(false);
			tf.FindChild("BtnPhoto").FindChild("Panel").GetComponent<UIPanel>().baseClipRegion
				= new Vector4(0, 0, 152f, 108f);
		}
		if((info.injuryYN != null) && (info.injuryYN.Equals("Y"))){
			tf.FindChild("BtnPhoto").FindChild("SprInjury").gameObject.SetActive(true);
		} else
			tf.FindChild("BtnPhoto").FindChild("SprInjury").gameObject.SetActive(false);
		
		tf.FindChild("BtnPhoto").FindChild("Panel").FindChild("Texture").GetComponent<UITexture>().mainTexture = mDefaultTxt;
		
		tf.FindChild("BtnPhoto").FindChild("Panel").FindChild("Texture").GetComponent<UITexture>().color
			= new Color(1f, 1f, 1f, 50f/255f);
		
		UtilMgr.LoadImage(info.photoUrl,
		                  tf.FindChild("BtnPhoto").FindChild("Panel").FindChild("Texture").GetComponent<UITexture>());
	
	}
}
