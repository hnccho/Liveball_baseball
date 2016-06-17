using UnityEngine;
using System.Collections;

public class Lobby : MonoBehaviour {

	GetLobbyInfoEvent mLobbyEvent;

	public UtilMgr.STATE mState;
	public GameObject mBodyItem;

	// Use this for initialization
	void Start () {
		mState = UtilMgr.STATE.Lobby;
		StartCoroutine(init_GUI());
	}


	IEnumerator init_GUI()
	{
		Camera cam = null;
		while(cam == null)
		{
			cam = Com.NUI_Camera();
			yield return null;
		}
		
		Transform bottom = Com.FindTransform(transform, "Bottom");
		Com.NUI_MoveBottom(cam, bottom, 142);
		//Com.NUI_MoveRate(cam, bottom, 0.5f, 1, 0, 142);
	}


	
	// Update is called once per frame
	void Update () {

	}

	public void FirstInit(){
		transform.gameObject.SetActive(true);

		transform.root.FindChild("Notice").GetComponent<Notice>().Init();

		Init ();
	}

	public void CheckAttendance(){
		if(UserMgr.LoginInfo.joinFreeGold > 0){
			DialogueMgr.ShowAttendanceDialogue(DialogueMgr.DIALOGUE_TYPE.Welcome, CloseAttendance);
		} else if(UserMgr.LoginInfo.freeGold > 0
		          || UserMgr.LoginInfo.freeTicket > 0){
			DialogueMgr.ShowAttendanceDialogue(DialogueMgr.DIALOGUE_TYPE.Attendance, CloseAttendance);
		}
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
		UserMgr.eventJoined = null;
		UtilMgr.AddBackState(UtilMgr.STATE.Lobby);

		mLobbyEvent = new GetLobbyInfoEvent(ReceivedLobbyInfo);
		NetMgr.GetLobbyInfo(UserMgr.UserInfo.memSeq, mLobbyEvent);
	}

	void ReceivedLobbyInfo(){
		GameObject bodyItem = Com.FindTransform(transform, "Body", "BodyItem").gameObject;
		bodyItem.transform.FindChild("RT").GetComponent<RTLobby>().Init();

		Com.Find_UILabel(transform, "Bottom", "Menu", "BtnMyCards", "LblValue").text = mLobbyEvent.Response.data.myCardCount+"";
		Com.Find_UILabel(transform, "Bottom", "Menu", "BtnUpcoming", "LblValue").text = mLobbyEvent.Response.data.upContestCount+"";
		Com.Find_UILabel(transform, "Bottom", "Menu", "BtnLive", "LblValue").text = mLobbyEvent.Response.data.myContestCount+"";


		
//		Com.Find_UILabel(bodyItem.transform, "DFS", "BtnSpecial", "LblValue").text = mLobbyEvent.Response.data.contestCountS+"";
//		Com.Find_UILabel(bodyItem.transform, "Btn50", "LblValue").text = mLobbyEvent.Response.data.contestCount50+"";
//Ï		Com.Find_UILabel(bodyItem.transform, "DFS", "BtnRanking", "LblValue").text = mLobbyEvent.Response.data.contestCountR+"";

//		transform.FindChild("Body").FindChild("ScrollBody").GetComponent<UIScrollView>().ResetPosition();
	}

	int mTimerClickCnt = 0;
	bool mTimerShow = false;
	public void TimerTestClick(){
		if(++mTimerClickCnt % 10 == 0){
			mTimerShow = (!mTimerShow);
			if(!mTimerShow)
				transform.FindChild("Top").FindChild("Label").GetComponent<UILabel>().color = new Color(51f/ 255f, 51f/ 255f, 51f/ 255f);
			else
				transform.FindChild("Top").FindChild("Label").GetComponent<UILabel>().color = Color.white;

		}
	}
}
