using UnityEngine;
using System.Collections;

public class ItemContestsBtns : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){
		UtilMgr.AddBackState(UtilMgr.STATE.RegisterEntry);
		UtilMgr.AnimatePageToLeft("Contests", "RegisterEntry");
	}
}
