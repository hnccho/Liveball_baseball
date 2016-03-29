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
//			if(UserMgr.UserInfo.gold < mItemInfo.price){
//				DialogueMgr.ShowDialogue("", "", DialogueMgr.DIALOGUE_TYPE.YesNo, "", "", "", BuyGold);
//				return;
//			}
			
			mGoldEvent = new PurchaseGoldEvent(ReceivedPurchase);
			NetMgr.PurchaseGold(mItemInfo.productCode, mGoldEvent);
		}


	}

	void BuyGold(DialogueMgr.BTNS btn){
		if(btn == DialogueMgr.BTNS.Btn1){
			//buy gold
		}
	}

	void ReceivedPurchase(){
		if(mItemInfo.category == Shop.CARD){
			DialogueMgr.ShowDialogue("Card!", "Purchased!", DialogueMgr.DIALOGUE_TYPE.Alert, CardPurchasedHandler);
		} else if(mItemInfo.category == Shop.TICKET){
			DialogueMgr.ShowDialogue("Ticket!", "Purchased!", DialogueMgr.DIALOGUE_TYPE.Alert, null);
		}
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
