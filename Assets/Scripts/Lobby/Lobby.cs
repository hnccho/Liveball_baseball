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


		int total = mLobbyEvent.Response.data.contestCountS + mLobbyEvent.Response.data.contestCount50 + mLobbyEvent.Response.data.contestCountR;
		Com.Find_UILabel(transform, "Fantasy_Contests", "left", "point").text = total+"";
		Com.Find_UILabel(transform, "Fantasy_Contests", "Special_League", "point").text = mLobbyEvent.Response.data.contestCountS+"";
		Com.Find_UILabel(transform, "Fantasy_Contests", "50", "point").text = mLobbyEvent.Response.data.contestCount50+"";
		Com.Find_UILabel(transform, "Fantasy_Contests", "Ranking", "point").text = mLobbyEvent.Response.data.contestCountR+"";

//		transform.FindChild("Body").FindChild("ScrollBody").GetComponent<UIScrollView>().ResetPosition();
		UserMgr.LobbyInfo = mLobbyEvent.Response.data;
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



	public bool isFold_FantasyContest = true;
	public void OnPress_FantasyContest()
	{
		Com.LOOG("OnPress_FantasyContest");

		Transform fantasy = Com.FindTransform(transform, "Fantasy_Contests");
		UISprite btn_sprite = Com.Find_UISprite(transform, "Fantasy_Contests", "btn fold");
		
		if(isFold_FantasyContest)
		{
			fantasy.localPosition = new Vector3(fantasy.localPosition.x,  -534f, fantasy.localPosition.z);
			isFold_FantasyContest = false;
			btn_sprite.flip = UIBasicSprite.Flip.Horizontally;
		}
		else
		{
			fantasy.localPosition = new Vector3(fantasy.localPosition.x,  -810f, fantasy.localPosition.z);
			isFold_FantasyContest = true;
			btn_sprite.flip = UIBasicSprite.Flip.Nothing;
		}
	}




}
