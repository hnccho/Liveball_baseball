using UnityEngine;
using System.Collections;

public class BtnsShop : MonoBehaviour {

	GetItemShopGoldEvent mItemEvent;
	GetGoldShopEvent mGoldEvent;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){
		if(name.Equals("BtnGold")){
			OpenGold();
		} else if(name.Equals("BtnTicket")){
			OpenTickets();
		}
	}

	public void OpenGold(){
		mGoldEvent = new GetGoldShopEvent(ReceivedGold);
		NetMgr.GetGoldShop(mGoldEvent);
	}

	public void OpenTickets(){
		mItemEvent = new GetItemShopGoldEvent(ReceivedTicketShop);
		NetMgr.GetItemShopList(Shop.TICKET, mItemEvent);
	}

	void ReceivedGold(){
		UtilMgr.RemoveBackState(UtilMgr.STATE.Profile);

		if(UtilMgr.GetLastBackState() != UtilMgr.STATE.Shop){
			UtilMgr.AnimatePageToLeft(UtilMgr.GetLastBackState().ToString(), "Shop");
			UtilMgr.AddBackState(UtilMgr.STATE.Shop);
		}

		transform.root.FindChild("Shop").GetComponent<Shop>().InitGoldShop(
			UtilMgr.GetLocalText("StrGoldShop"), Shop.GOLD, mGoldEvent);
	}

	void ReceivedTicketShop(){
		UtilMgr.RemoveBackState(UtilMgr.STATE.Profile);
		UtilMgr.AnimatePageToLeft(UtilMgr.GetLastBackState().ToString(), "Shop");
		UtilMgr.AddBackState(UtilMgr.STATE.Shop);

		transform.root.FindChild("Shop").GetComponent<Shop>().InitItemShop(
			UtilMgr.GetLocalText("StrTicketShop"), Shop.TICKET, mItemEvent);
	}
}
