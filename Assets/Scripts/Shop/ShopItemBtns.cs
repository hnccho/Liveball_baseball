using UnityEngine;
using System.Collections;

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
			DialogueMgr.ShowDialogue(UtilMgr.GetLocalText("StrPurchaseSuccess"),
			                         string.Format(UtilMgr.GetLocalText("StrPurchaseSuccess2"), mItemInfo.productName)
			                         , DialogueMgr.DIALOGUE_TYPE.Alert, CardPurchasedHandler);
		} else if(mItemInfo.category == Shop.TICKET){
			DialogueMgr.ShowDialogue(UtilMgr.GetLocalText("StrPurchaseSuccess"),
			                         string.Format(UtilMgr.GetLocalText("StrPurchaseSuccess2"), mItemInfo.productName)
			                         , DialogueMgr.DIALOGUE_TYPE.Alert, null);
		}
		UserMgr.UserInfo.gold -= mItemInfo.price;
	}

	void CardPurchasedHandler(DialogueMgr.BTNS btn){
		mCardEvent = new GetCardInvenEvent(ReceivedCards);
		NetMgr.GetCardInven(mCardEvent);
	}

	void ReceivedCards(){
		UserMgr.CardList = mCardEvent.Response.data;
		transform.root.FindChild("MyCards").GetComponent<MyCards>().Init(mCardEvent,
     		transform.root.FindChild("MyCards").GetComponent<MyCards>().GetMailEvent());
	}
}
