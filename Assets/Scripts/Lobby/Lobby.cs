using UnityEngine;
using System.Collections;
using System.Collections.Generic;


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
		

		Fold_FantasyContest();

		//--------------------
		draw_TopPlayer();
		draw_title();


		//ui_align();
		//Transform bottom = Com.FindTransform(transform, "Bottom"); Com.NUI_MoveBottom(cam, bottom, 142);
	}


	void ui_align()
	{
		{
			UISprite tar = Com.Find_UISprite(transform, "RtBG");
			UISprite tops = Com.Find_UISprite(transform, "Top_Players", "SprRT");
			Transform top = Com.FindTransform(transform, "Top_Players");
			Com.NUI_AttachBottom(tar, tops, top);
		}

		{		
			UISprite tar = Com.Find_UISprite(transform, "black");
			UISprite dess = Com.Find_UISprite(transform, "Fantasy_Contests", "left");
			Transform des = Com.FindTransform(transform, "Fantasy_Contests");
			Com.NUI_AttachTop(tar, dess, des);
		}
	}



	void draw_title()
	{
		Com.LOOG("draw_title", Localization.language);

		if(Localization.language.Equals("English"))
		{
			Com.FindTransform(transform, "tab1").gameObject.SetActive(true);
			Com.FindTransform(transform, "tab2").gameObject.SetActive(true);
			Com.FindTransform(transform, "tab3").gameObject.SetActive(true);
			Com.FindTransform(transform, "kbo").gameObject.SetActive(false);
		}
		else
		{
			Com.FindTransform(transform, "tab1").gameObject.SetActive(true);
			Com.FindTransform(transform, "tab2").gameObject.SetActive(true);
			Com.FindTransform(transform, "tab3").gameObject.SetActive(true);
			Com.FindTransform(transform, "kbo").gameObject.SetActive(false);
			Com.Find_UILabel(transform, "Top", "Label").text = "KBO";
		}
	}


	//-----------------------------------Ï
	GetCardInvenEvent mCardEvent;
	void draw_TopPlayer()
	{
		mCardEvent = new GetCardInvenEvent(ReceivedCards);
		NetMgr.GetCardInven(mCardEvent);
	}
	void ReceivedCards()
	{
		UserMgr.CardList = mCardEvent.Response.data;
		//for(int i=0;i<UserMgr.CardList.Count;i++) Com.LOOG("mycard", i, UserMgr.CardList[i].korName, UserMgr.CardList[i].itemId);	//debug
		
		draw_TopPlayer_post();
	}

	List<PlayerInfo> mSortedList;
	void draw_TopPlayer_post()
	{

		List<PlayerInfo> mSortedList0 = new List<PlayerInfo>();
		foreach(PlayerInfo info in UserMgr.PlayerList)
		{
			//if(info.positionNo == 1) mSortedList.Add(info);		//del
			mSortedList0.Add(info);									// all
		}
		mSortedList0.Sort(delegate(PlayerInfo x, PlayerInfo y) {		// sort
			return y.fppg.CompareTo(x.fppg);
		});

		mSortedList = new List<PlayerInfo>();
		for(int i =0;i<10;i++)
		{
			mSortedList.Add(mSortedList0[i]);
		}
		


		//for(int i=0;i<mSortedList.Count;i++) Com.LOOG(i, mSortedList[i].korName, mSortedList[i].fppg);	//debug
					
		UIDraggablePanel2 drag = Com.FindTransform(transform, "Top_Players", "ScrollBody").GetComponent<UIDraggablePanel2>();

		drag.SetDragAmount(0, 30f, false);
		drag.RemoveAll();
		drag.Init(
			mSortedList.Count, delegate(UIListItem item, int index) {
			
			UILabel name = Com.Find_UILabel(item.Target.transform, "MLB","name");
			name.text = Localization.language.Equals("English")
					? mSortedList[index].firstName.Substring(0, 1) + ". " + mSortedList[index].lastName
					: mSortedList[index].korName;

			UITexture tex = Com.FindTransform(item.Target.transform, "MLB", "BtnPhoto", "Texture").GetComponent<UITexture>();
			//tex.color = new Color(1f, 1f, 1f, 50f/255f);
			bool ispic = UtilMgr.LoadImage(mSortedList[index].playerId, tex);
			if(ispic == false)
			{
				tex.mainTexture	= UtilMgr.GetTextureDefault();
			}
			


			UILabel rank = Com.Find_UILabel(item.Target.transform, "ranking_num", "Label");
			if(index < 3)
			{
				rank.transform.parent.gameObject.SetActive(true);
				rank.text = (index + 1) + "";

				if(index == 0) rank.transform.parent.GetComponent<UISprite>().color = Com.GetColor(0xceab2a);
				else if(index == 1) rank.transform.parent.GetComponent<UISprite>().color = Com.GetColor(0x9c9d9f);
				else if(index == 2) rank.transform.parent.GetComponent<UISprite>().color = Com.GetColor(0x935e44);
			}
			else
			{
				rank.transform.parent.gameObject.SetActive(false);
			}

			UILabel fppg = Com.Find_UILabel(item.Target.transform, "FPPG_num");
			fppg.text = mSortedList[index].fppg.ToString("f1");

			UILabel position = Com.Find_UILabel(item.Target.transform, "position", "Label");
			position.text = mSortedList[index].position;



			// draw own
			{
				Transform own = Com.FindTransform(item.Target.transform, "own");
				own.gameObject.SetActive(false);
				for(int i=0;i<UserMgr.CardList.Count;i++)
	 				if(UserMgr.CardList[i].playerFK == mSortedList[index].playerId)
					{
						own.gameObject.SetActive(true);
						Com.LOOG("own", UserMgr.CardList[i].korName, UserMgr.CardList[i].fppg ,mSortedList[index].fppg);
						break;
					}
			}

			Com.FindTransform(item.Target.transform, "BtnPhoto").GetComponent<TopCard>().mPlayerInfo = mSortedList[index];


		});


		drag.ResetPosition();
		drag.GetComponent<SpringPanel>().target = new Vector3(0, -85, 0);
		drag.GetComponent<SpringPanel>().enabled = true;
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



	public bool isOpen_FantasyContest = false;
	public void OnPress_FantasyContest()
	{
		Com.LOOG("OnPress_FantasyContest");

		
		if(isOpen_FantasyContest)
		{
			isOpen_FantasyContest = false;
			Fold_FantasyContest();
		}
		else
		{
			isOpen_FantasyContest = true;
			Fold_FantasyContest();
		}
	}
	void Fold_FantasyContest()
	{
		Transform sub = Com.FindTransform(transform, "Fantasy_Contests", "sub");
		UISprite btn_sprite = Com.Find_UISprite(transform, "Fantasy_Contests", "btn fold");

		if(isOpen_FantasyContest)
		{
			//sub.localPosition = new Vector3(sub.localPosition.x,  -534f, sub.localPosition.z);
			btn_sprite.flip = UIBasicSprite.Flip.Horizontally;

			//Com.FindTransform(sub, "Special_League").gameObject.SetActive(true);
			//Com.FindTransform(sub, "50").gameObject.SetActive(true);
			//Com.FindTransform(sub, "Ranking").gameObject.SetActive(true);

			TweenPosition.Begin(sub.GetChild(0).gameObject, 0.2f, new Vector3(0, 276, 0), false);
		}
		else
		{
			//sub.localPosition = new Vector3(sub.localPosition.x,  -810f, sub.localPosition.z);
			btn_sprite.flip = UIBasicSprite.Flip.Nothing;

			//Com.FindTransform(sub, "Special_League").gameObject.SetActive(false);
			//Com.FindTransform(sub, "50").gameObject.SetActive(false);
			//Com.FindTransform(sub, "Ranking").gameObject.SetActive(false);

			TweenPosition.Begin(sub.GetChild(0).gameObject, 0.2f, new Vector3(0, -3, 0), false);
		}
	}




}
