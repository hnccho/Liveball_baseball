using UnityEngine;
using System.Collections;

public class LandingRoot : SuperRoot {

	GetLobbyInfoEvent mLobbyEvent;

	// Use this for initialization
	void Start () {
		base.Start();

		mLobbyEvent = new GetLobbyInfoEvent(ReceivedLobby);
		NetMgr.GetLobbyInfo(UserMgr.UserInfo.memSeq, mLobbyEvent);
	}
	
	void Awake(){
		base.Awake();
	}
	
	// Update is called once per frame
	void Update () {
		base.Update();
	}

	void ReceivedLobby(){
//		DialogueMgr.ShowDialogue("myCardCount", mLobbyEvent.Response.data.myCardCount+"", DialogueMgr.DIALOGUE_TYPE.Alert, null);
	}
}
