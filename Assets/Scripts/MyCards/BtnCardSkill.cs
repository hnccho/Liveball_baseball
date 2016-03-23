using UnityEngine;
using System.Collections;

public class BtnCardSkill : MonoBehaviour {

	GetItemShopGoldEvent mGoldEvent;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnClick(){
		if(name.Equals("BtnCardShop")){
			mGoldEvent = new GetItemShopGoldEvent(ReceivedCardShop);
			NetMgr.GetItemShopList(Shop.CARD, mGoldEvent);
		} else{

		}
	}

	void ReceivedCardShop(){
		UtilMgr.AddBackState(UtilMgr.STATE.Shop);
		UtilMgr.AnimatePageToLeft("MyCards", "Shop");

		transform.root.FindChild("Shop").GetComponent<Shop>().InitGoldShop(
			UtilMgr.GetLocalText("LblCardShop"), Shop.CARD, mGoldEvent);
	}
}
