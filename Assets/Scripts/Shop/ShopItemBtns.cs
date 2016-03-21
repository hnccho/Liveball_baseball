using UnityEngine;
using System.Collections;

public class ShopItemBtns : MonoBehaviour {

	public ItemShopGoldInfo mInfo;
	PurchaseGoldEvent mGoldEvent;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){
		if(UserMgr.UserInfo.gold < mInfo.price){
			DialogueMgr.ShowDialogue("", "", DialogueMgr.DIALOGUE_TYPE.YesNo, "", "", "", BuyGold);
			return;
		}

		mGoldEvent = new PurchaseGoldEvent(ReceivedPurchase);
		NetMgr.PurchaseGold(mInfo.productCode, mGoldEvent);
	}

	void BuyGold(DialogueMgr.BTNS btn){
		if(btn == DialogueMgr.BTNS.Btn1){
			//buy gold
		}
	}

	void ReceivedPurchase(){
		if(mInfo.category == Shop.CARD){
			DialogueMgr.ShowDialogue("Card!", "Good!", DialogueMgr.DIALOGUE_TYPE.Alert, null);
		}
	}
}
