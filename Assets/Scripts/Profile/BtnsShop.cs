using UnityEngine;
using System.Collections;

public class BtnsShop : MonoBehaviour {

	GetItemShopGoldEvent mGoldEvent;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){
		if(name.Equals("BtnGold")){
//			transform.root.FindChild("Shop").GetComponent<Shop>().InitShop(
//				UtilMgr.GetLocalText("StrGoldShop"), Shop.GOLD);
			return;
		} else if(name.Equals("BtnTicket")){
			mGoldEvent = new GetItemShopGoldEvent(ReceivedTicketShop);
			NetMgr.GetItemShopList(Shop.TICKET, mGoldEvent);


		}
	}

	void ReceivedTicketShop(){
		UtilMgr.RemoveBackState(UtilMgr.STATE.Profile);
		UtilMgr.AnimatePageToLeft(UtilMgr.GetLastBackState().ToString(), "Shop");
		UtilMgr.AddBackState(UtilMgr.STATE.Shop);

		transform.root.FindChild("Shop").GetComponent<Shop>().InitGoldShop(
			UtilMgr.GetLocalText("StrTicketShop"), Shop.TICKET, mGoldEvent);
	}
}
