using UnityEngine;
using System.Collections;

public class BtnFeedingCard : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){
		transform.root.FindChild("SelectFeeding").GetComponent<SelectFeeding>().Init(
			transform.root.FindChild("CardPowerUp").GetComponent<CardPowerUp>().mTargetCard);
	}
}
