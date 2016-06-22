using UnityEngine;
using System.Collections;

public class BtnSkillShop : MonoBehaviour {
	GetItemShopGoldEvent mGoldEvent;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){
		mGoldEvent = new GetItemShopGoldEvent(ReceivedSkillShop);
		NetMgr.GetItemShopList(Shop.SKILL, mGoldEvent);
	}

	void ReceivedSkillShop(){
		UtilMgr.AddBackState(UtilMgr.STATE.Shop);
		UtilMgr.AnimatePageToLeft("SkillList", "Shop");
		
		transform.root.FindChild("Shop").GetComponent<Shop>().InitItemShop(
			UtilMgr.GetLocalText("LblSkillsetShop"), Shop.SKILL, mGoldEvent);
	}
}
