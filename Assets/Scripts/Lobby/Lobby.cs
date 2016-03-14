using UnityEngine;
using System.Collections;

public class Lobby : MonoBehaviour {

	GetLobbyInfoEvent mLobbyEvent;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Init(){
		mLobbyEvent = new GetLobbyInfoEvent(ReceivedLobbyInfo);
		NetMgr.GetLobbyInfo(UserMgr.UserInfo.memSeq, mLobbyEvent);
	}

	void ReceivedLobbyInfo(){
		transform.FindChild("Body").FindChild("ScrollBody").FindChild("RT").GetComponent<RTLobby>().Init();
			
		
		transform.FindChild("Body").FindChild("ScrollBody").FindChild("DFS")
			.FindChild("BtnSpecial").FindChild("LblValue")
				.GetComponent<UILabel>().text = mLobbyEvent.Response.data.contestCountS+"";
		transform.FindChild("Body").FindChild("ScrollBody").FindChild("DFS")
			.FindChild("Btn50").FindChild("LblValue")
				.GetComponent<UILabel>().text = mLobbyEvent.Response.data.contestCount50+"";
		transform.FindChild("Body").FindChild("ScrollBody").FindChild("DFS")
			.FindChild("BtnRanking").FindChild("LblValue")
				.GetComponent<UILabel>().text = mLobbyEvent.Response.data.contestCountR+"";
	}
}
