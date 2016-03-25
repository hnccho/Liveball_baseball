using UnityEngine;
using System.Collections;

public class BtnSelectCompletion : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){
		UtilMgr.OnBackPressed();
		transform.root.FindChild("CardPowerUp").GetComponent<CardPowerUp>().LoadFeedsInfo();
	}
}
