using UnityEngine;
using System.Collections;

public class BtnsShop : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){
		if(name.Equals("BtnGold")){
			transform.root.FindChild("Shop").GetComponent<Shop>().InitShop(
				UtilMgr.GetLocalText("StrGoldShop"), Shop.GOLD);
		} else if(name.Equals("BtnTicket")){
			transform.root.FindChild("Shop").GetComponent<Shop>().InitShop(
				UtilMgr.GetLocalText("StrTicketShop"), Shop.TICKET);
		}
		UtilMgr.RemoveBackState(UtilMgr.STATE.Profile);
//		Debug.Log(UtilMgr.GetLastBackState().ToString());
		UtilMgr.AnimatePageToLeft(UtilMgr.GetLastBackState().ToString(), "Shop");
		UtilMgr.AddBackState(UtilMgr.STATE.Shop);

	}
}
