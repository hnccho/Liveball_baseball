using UnityEngine;
using System.Collections;

public class BtnPlayerSelected : MonoBehaviour {

	public PlayerInfo mPlayerInfo;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){
		transform.root.FindChild("RegisterEntry").GetComponent<RegisterEntry>().SetDesignated(mPlayerInfo);
		UtilMgr.OnBackPressed();
	}
}
