using UnityEngine;
using System.Collections;

public class LandingRoot : SuperRoot {

	GetLobbyInfoEvent mLobbyEvent;

	// Use this for initialization
	new void Start () {
		base.Start();

		InitLobby();
	}
	
	new void Awake(){
		base.Awake();
	}
	
	// Update is called once per frame
	new void Update () {
		base.Update();
	}

	public void InitLobby(){
		mLobbyEvent = new GetLobbyInfoEvent(ReceivedLobby);
		NetMgr.GetLobbyInfo(UserMgr.UserInfo.memSeq, mLobbyEvent);
	}

	void ReceivedLobby(){
		transform.FindChild("Lobby").FindChild("Body").FindChild("ScrollBody").FindChild("DFS")
			.FindChild("BtnSpecial").FindChild("LblValue")
				.GetComponent<UILabel>().text = mLobbyEvent.Response.data.contestCountS+"";
		transform.FindChild("Lobby").FindChild("Body").FindChild("ScrollBody").FindChild("DFS")
			.FindChild("Btn50").FindChild("LblValue")
				.GetComponent<UILabel>().text = mLobbyEvent.Response.data.contestCount50+"";
		transform.FindChild("Lobby").FindChild("Body").FindChild("ScrollBody").FindChild("DFS")
			.FindChild("BtnRanking").FindChild("LblValue")
				.GetComponent<UILabel>().text = mLobbyEvent.Response.data.contestCountR+"";
	}
}
