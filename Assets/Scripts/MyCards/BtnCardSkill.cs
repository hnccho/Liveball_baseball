using UnityEngine;
using System.Collections;

public class BtnCardSkill : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){
		if(name.Equals("BtnCardShop")){
			UtilMgr.AddBackState(UtilMgr.STATE.Shop);
			UtilMgr.AnimatePageToLeft("MyCards", "Shop");
			transform.root.FindChild("Shop").GetComponent<Shop>().InitShop(
				UtilMgr.GetLocalText("LblCardShop"), Shop.CARD);
		} else{

		}
	}
}
