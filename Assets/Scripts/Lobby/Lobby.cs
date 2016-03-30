using UnityEngine;
using System.Collections;

public class Lobby : MonoBehaviour {

	GetLobbyInfoEvent mLobbyEvent;
	public UtilMgr.STATE mState;
	public GameObject mBodyItem;

	// Use this for initialization
	void Start () {
		mState = UtilMgr.STATE.Lobby;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void FirstInit(){
		if(UserMgr.LoginInfo.joinFreeGold > 0){
			DialogueMgr.ShowAttendanceDialogue(DialogueMgr.DIALOGUE_TYPE.Welcome, CloseAttendance);
		} else if(UserMgr.LoginInfo.freeGold > 0){
			DialogueMgr.ShowAttendanceDialogue(DialogueMgr.DIALOGUE_TYPE.Attendance, CloseAttendance);
		}

		Init ();
	}

	void CloseAttendance(DialogueMgr.BTNS btn){
		DialogueMgr.DismissDialogue();
		Destroy(DialogueMgr.Instance.mAttendanceBox);
	}

	public void Init(UtilMgr.STATE state){
		mState = state;
		Init ();
	}

	public void Init(){
		UtilMgr.AddBackState(UtilMgr.STATE.Lobby);

		mLobbyEvent = new GetLobbyInfoEvent(ReceivedLobbyInfo);
		NetMgr.GetLobbyInfo(UserMgr.UserInfo.memSeq, mLobbyEvent);
	}

	void ReceivedLobbyInfo(){
//		UtilMgr.ClearList(transform.FindChild("Body").FindChild("ScrollBody"));
//		GameObject bodyItem = Instantiate(mBodyItem);
//		bodyItem.transform.parent = transform.FindChild("Body").FindChild("ScrollBody");
//		bodyItem.transform.localScale = new Vector3(1f, 1f, 1f);
//		bodyItem.transform.localPosition = Vector3.zero;
		GameObject bodyItem = transform.FindChild("Body").FindChild("ScrollBody").GetChild(0).gameObject;

		bodyItem.transform.FindChild("RT").GetComponent<RTLobby>().Init();

		transform.FindChild("Top").FindChild("TopMenu").FindChild("BtnMyCards").FindChild("LblValue")
				.GetComponent<UILabel>().text = mLobbyEvent.Response.data.myCardCount+"";
		transform.FindChild("Top").FindChild("TopMenu").FindChild("BtnUpcoming").FindChild("LblValue")
				.GetComponent<UILabel>().text = mLobbyEvent.Response.data.upContestCount+"";
		transform.FindChild("Top").FindChild("TopMenu").FindChild("BtnLive").FindChild("LblValue")
			.GetComponent<UILabel>().text = mLobbyEvent.Response.data.myContestCount+"";
		
		bodyItem.transform.FindChild("DFS").FindChild("BtnSpecial").FindChild("LblValue")
				.GetComponent<UILabel>().text = mLobbyEvent.Response.data.contestCountS+"";
		bodyItem.transform.FindChild("DFS").FindChild("Btn50").FindChild("LblValue")
				.GetComponent<UILabel>().text = mLobbyEvent.Response.data.contestCount50+"";
		bodyItem.transform.FindChild("DFS").FindChild("BtnRanking").FindChild("LblValue")
				.GetComponent<UILabel>().text = mLobbyEvent.Response.data.contestCountR+"";

//		transform.FindChild("Body").FindChild("ScrollBody").GetComponent<UIScrollView>().ResetPosition();
	}
}
