using UnityEngine;
using System.Collections;

public class BtnItemEntry : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){
		UtilMgr.AddBackState(UtilMgr.STATE.SelectPlayer);
		UtilMgr.AnimatePageToLeft("RegisterEntry", "SelectPlayer");
		transform.root.FindChild("SelectPlayer").GetComponent<SelectPlayer>()
			.Init(int.Parse(transform.parent.parent.FindChild("Label").GetComponent<UILabel>().text));
	}
}
