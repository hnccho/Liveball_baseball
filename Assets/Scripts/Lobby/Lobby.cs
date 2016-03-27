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

	public void FirstInit(){
//		string freeGold = UtilMgr.AddsThousandsSeparator(UserMgr.AttendInfo.freeGold);
//		string freeTicket = UtilMgr.AddsThousandsSeparator(UserMgr.AttendInfo.freeTicket);
//		DialogueMgr.ShowDialogue("Attendance", "Attendance Day is "+UserMgr.AttendInfo.attendDay +
//		                         "\n"+ freeGold +" Gold and " + 
//		                         freeTicket +" Tickets", DialogueMgr.DIALOGUE_TYPE.Alert, null);
		if(UserMgr.AttendInfo.joinFreeGold > 0){
			DialogueMgr.ShowAttendanceDialogue(DialogueMgr.DIALOGUE_TYPE.Welcome,
			                                   UserMgr.AttendInfo, CloseAttendance);
		} else{
			DialogueMgr.ShowAttendanceDialogue(DialogueMgr.DIALOGUE_TYPE.Attendance,
			                                   UserMgr.AttendInfo, CloseAttendance);
		}


		Init ();
	}

	void CloseAttendance(DialogueMgr.BTNS btn){
		DialogueMgr.DismissDialogue();
		Destroy(DialogueMgr.Instance.mAttendanceBox);
	}

	public void Init(){
		UtilMgr.AddBackState(UtilMgr.STATE.Lobby);

		mLobbyEvent = new GetLobbyInfoEvent(ReceivedLobbyInfo);
		NetMgr.GetLobbyInfo(UserMgr.UserInfo.memSeq, mLobbyEvent);
	}

	void ReceivedLobbyInfo(){
		transform.FindChild("Body").FindChild("ScrollBody").FindChild("RT").GetComponent<RTLobby>().Init();

		transform.FindChild("Top").FindChild("TopMenu").FindChild("BtnMyCards").FindChild("LblValue")
				.GetComponent<UILabel>().text = mLobbyEvent.Response.data.myCardCount+"";
		transform.FindChild("Top").FindChild("TopMenu").FindChild("BtnUpcoming").FindChild("LblValue")
				.GetComponent<UILabel>().text = mLobbyEvent.Response.data.upContestCount+"";
		transform.FindChild("Top").FindChild("TopMenu").FindChild("BtnLive").FindChild("LblValue")
			.GetComponent<UILabel>().text = mLobbyEvent.Response.data.myContestCount+"";
		
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
