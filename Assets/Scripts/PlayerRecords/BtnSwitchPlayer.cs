using UnityEngine;
using System.Collections;

public class BtnSwitchPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){
		transform.root.FindChild("PlayerRecords").GetComponent<PlayerRecords>().Switch();
	}
}
