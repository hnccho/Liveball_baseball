using UnityEngine;
using System.Collections;

public class BtnPlayerName : MonoBehaviour {

	public PlayerInfo mPlayerInfo;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){
		transform.root.FindChild("PlayerCard").GetComponent<PlayerCard>().Init(mPlayerInfo, null);
	}
}
