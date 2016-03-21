using UnityEngine;
using System.Collections;

public class BtnWhat : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

//	GetItemShopGoldEvent mShopEvent;
	public void OnClick(){
//		mShopEvent = new GetItemShopGoldEvent(ReceivedShop);
//		NetMgr.GetItemShopList(Shop.TYPE.TICKET, mShopEvent);
	}

//	void ReceivedShop(){
//		transform.root.FindChild("Shop").GetComponent<Shop>().InitShop(
//			UtilMgr.GetLocalText("StrTicketShop"), Shop.TYPE.TICKET);
//		UtilMgr.AddBackState(UtilMgr.STATE.Shop);
//		UtilMgr.AnimatePageToLeft("Lobby", "Shop");
//	}
}
