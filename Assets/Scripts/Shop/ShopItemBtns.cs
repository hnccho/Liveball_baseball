using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShopItemBtns : MonoBehaviour {

	public ShopGoldInfo mGoldInfo;
	public ItemShopGoldInfo mItemInfo;
	PurchaseGoldEvent mGoldEvent;
	GetCardInvenEvent mCardEvent;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){
		if(transform.root.FindChild("Shop").GetComponent<Shop>().mCategory == Shop.GOLD){
			transform.root.FindChild("Shop").GetComponent<Shop>().RequestIAP(mGoldInfo.productCode,
			                                                                mGoldInfo.productName);
		} else{
			if(UserMgr.UserInfo.gold < mItemInfo.price){
				UtilMgr.NotEnoughGold();
				return;
			}
			
			mGoldEvent = new PurchaseGoldEvent(ReceivedPurchase);
			NetMgr.PurchaseGold(mItemInfo.productCode, mGoldEvent);
		}


	}

	void ReceivedPurchase(){
		if(mItemInfo.category == Shop.CARD){
//			DialogueMgr.ShowDialogue(UtilMgr.GetLocalText("StrPurchaseSuccess"),
//			                         string.Format(UtilMgr.GetLocalText("StrPurchaseSuccess2"), mItemInfo.productName)
//			                         , DialogueMgr.DIALOGUE_TYPE.Alert, CardPurchasedHandler);
			mCardEvent = new GetCardInvenEvent(ReceivedCards);
			NetMgr.GetCardInven(mCardEvent);
		} else if(mItemInfo.category == Shop.TICKET){
			DialogueMgr.ShowDialogue(UtilMgr.GetLocalText("StrPurchaseSuccess"),
			                         string.Format(UtilMgr.GetLocalText("StrPurchaseSuccess2"), mItemInfo.productName)
			                         , DialogueMgr.DIALOGUE_TYPE.Alert, null);
		} else if(mItemInfo.category == Shop.SKILL){
			DialogueMgr.ShowDialogue(UtilMgr.GetLocalText("StrPurchaseSuccess"),
			                         string.Format(UtilMgr.GetLocalText("StrPurchaseSuccess2"), mItemInfo.productName)
			                         , DialogueMgr.DIALOGUE_TYPE.Alert, DiagSkill);
		}
		UserMgr.UserInfo.gold -= mItemInfo.price;
	}

	void DiagSkill(DialogueMgr.BTNS btn){
		UtilMgr.OnBackPressed();
		transform.root.FindChild("SkillList").GetComponent<SkillList>().Init();
	}

//	void CardPurchasedHandler(DialogueMgr.BTNS btn){
//		mCardEvent = new GetCardInvenEvent(ReceivedCards);
//		NetMgr.GetCardInven(mCardEvent);
//	}

	void ReceivedCards(){
		UtilMgr.ShowLoading();
		StartCoroutine(WaitingForAnimation());

	}

	IEnumerator WaitingForAnimation(){
		yield return new WaitForSeconds(0.5f);

		UserMgr.CardList = mCardEvent.Response.data;
		transform.root.FindChild("MyCards").localPosition = new Vector3(2000f, 0, 0);
		transform.root.FindChild("MyCards").GetComponent<MyCards>().Init(mCardEvent,
		                                                                 transform.root.FindChild("MyCards").GetComponent<MyCards>().GetMailEvent());
		List<CardInfo> cardList = new List<CardInfo>();
		foreach(CardInfo info in mGoldEvent.Response.data.item){
			foreach(CardInfo tmp in UserMgr.CardList){
				if(info.itemSeq == tmp.itemSeq){
					cardList.Add(tmp);
					break;
				}
			}
		}
		transform.root.FindChild("PlayerCard").GetComponent<PlayerCard>().Init (cardList, mItemInfo.productCode);
		UtilMgr.DismissLoading();
	}
}
