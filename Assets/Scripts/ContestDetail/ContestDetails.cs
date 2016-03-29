using UnityEngine;
using System.Collections;
using System;

public class ContestDetails : MonoBehaviour {

	ContestDetailsEvent mContestEvent;
	EntryListEvent mEntryEvent;
	ContestMyTeamEvent mTeamEvent;

	ContestListInfo mContest;
	DateTime mContestTime;

	public GameObject mItemRulesHeader;
	public GameObject mItemRulesDetail;

	public class RuleInfo {
		public string mName;
		public float mPoint;

		public RuleInfo(string name, float pt){
			mName = name;
			mPoint = pt;
		}
	}

	RuleInfo[][] RulesInfo;
	// Use this for initialization
	void Start () {
		RulesInfo = new RuleInfo[2][]{
			new RuleInfo[]{
				new RuleInfo(UtilMgr.GetLocalText("StrSingle"), 3f),
				new RuleInfo(UtilMgr.GetLocalText("StrDouble"), 6f),
				new RuleInfo(UtilMgr.GetLocalText("StrTriple"), 9f),
				new RuleInfo(UtilMgr.GetLocalText("StrHomeRun"), 12f),
				new RuleInfo(UtilMgr.GetLocalText("StrRBI"), 3f),
				new RuleInfo(UtilMgr.GetLocalText("StrRunScored"), 3f),
				new RuleInfo(UtilMgr.GetLocalText("StrBaseOnBalls"), 3f),
				new RuleInfo(UtilMgr.GetLocalText("StrStolenBase"), 6f),
				new RuleInfo(UtilMgr.GetLocalText("StrHitByPitch"), 3f),
				new RuleInfo(UtilMgr.GetLocalText("StrOut"), 0)
			},
			new RuleInfo[]{
				new RuleInfo(UtilMgr.GetLocalText("StrWin"), 12f),
				new RuleInfo(UtilMgr.GetLocalText("StrEarnedRun"), -3f),
				new RuleInfo(UtilMgr.GetLocalText("StrStrikeout"), 3f),
				new RuleInfo(UtilMgr.GetLocalText("StrInningPitched"), 3f),
				new RuleInfo(UtilMgr.GetLocalText("StrHitAgainst"), 0)
			}
			
		};
	}
	
	// Update is called once per frame
	void Update () {
		if(mContest == null) return;

		if(mContest.contestStatus == ContestListInfo.STATUS_UP){
			if(mContestTime.Year < 2016)
				return;
			
			TimeSpan ts = mContestTime.AddHours(13d) - DateTime.Now.AddTicks(UserMgr.DiffTicks);
			
			transform.FindChild("InfoTop").FindChild("Time").FindChild("LblRight").GetComponent<UILabel>().text
				= UtilMgr.GetDateTime(ts);
		}
	}

	public void Init(ContestListInfo contest){
		int year = int.Parse(contest.startTime.Substring(0, 4));
		int mon = int.Parse(contest.startTime.Substring(4, 2));
		int day = int.Parse(contest.startTime.Substring(6, 2));
		int hour = int.Parse(contest.startTime.Substring(8, 2));
		int min = int.Parse(contest.startTime.Substring(10, 2));
		int sec = int.Parse(contest.startTime.Substring(12, 2));
		mContestTime = new DateTime(year, mon, day, hour, min, sec);
		mContest = contest;

		transform.localPosition = new Vector3(2000f, 2000f, 0);
		transform.gameObject.SetActive(true);
		mEntryEvent = new EntryListEvent(ReceivedEntry);
		NetMgr.EntryList(mContest.contestSeq, mEntryEvent);
	}

	void ReceivedTeam(){
		mContestEvent = new ContestDetailsEvent(ReceivedDetails);
		NetMgr.ContestDetails(mContest.entrySeq, mContestEvent);
	}

	void ReceivedEntry(){
		mTeamEvent = new ContestMyTeamEvent(ReceivedTeam);
		NetMgr.ContestMyTeamList(mContest.contestSeq, mTeamEvent);
	}

	void ReceivedDetails(){
		transform.FindChild("InfoTop").FindChild("LblTitle").GetComponent<UILabel>().text = mContest.contestName;

		string strMin = ""+mContestTime.Minute;
		if(mContestTime.Minute < 10)
			strMin = "0"+mContestTime.Minute;
		transform.FindChild("InfoTop").FindChild("Time").FindChild("LblLeft").GetComponent<UILabel>().text
			= "ET " + UtilMgr.GetAMPM(mContestTime.Hour)[0] + ":" + strMin + " " + UtilMgr.GetAMPM(mContestTime.Hour)[1] + " Start";
		transform.FindChild("InfoTop").FindChild("Time").FindChild("LblRight").GetComponent<UILabel>().text = "";
		if(mContest.contestStatus == ContestListInfo.STATUS_UP){
			transform.FindChild("InfoTop").FindChild("Labels").FindChild("LblEntries").FindChild("Label").
				GetComponent<UILabel>().text = "[b]" + UtilMgr.AddsThousandsSeparator(mContestEvent.Response.data.totalJoin) + "[/b][cccccc] / "
					+ UtilMgr.AddsThousandsSeparator(mContestEvent.Response.data.totalEntry);
		} else{
			transform.FindChild("InfoTop").FindChild("Labels").FindChild("LblEntries").GetComponent<UILabel>().text
				= UtilMgr.GetLocalText("StrPosition");
			transform.FindChild("InfoTop").FindChild("Labels").FindChild("LblEntries").FindChild("Label").
				GetComponent<UILabel>().text = "[b]" + UtilMgr.AddsThousandsSeparator(mContestEvent.Response.data.myRank) + "[/b][cccccc] / "
					+ UtilMgr.AddsThousandsSeparator(mContestEvent.Response.data.totalJoin);
		}

		transform.FindChild("InfoTop").FindChild("Labels").FindChild("LblTickets").FindChild("Label").GetComponent<UILabel>().
			text = mContestEvent.Response.data.entryTicket+"";
		transform.FindChild("InfoTop").FindChild("Labels").FindChild("LblPrize").FindChild("Label").GetComponent<UILabel>().
			text = mContestEvent.Response.data.totalReward+"G";

		InitEntries();

		InitGames();

		InitPrizes();

		InitRules();

		transform.FindChild("Selection").FindChild("BtnEntries").GetComponent<ContestDetailBtns>().OnClick();

		UtilMgr.AddBackState(UtilMgr.STATE.ContestDetails);
		UtilMgr.AnimatePageToLeft("MyContests", "ContestDetails");
	}

	void InitEntries(){
		Transform tf = transform.FindChild("Changeables").FindChild("Entries");
		tf.gameObject.SetActive(true);
		UtilMgr.ClearList(tf.FindChild("Draggable"));
		tf.FindChild("Draggable").GetComponent<UIDraggablePanel2>().Init(mEntryEvent.Response.data.Count,
			delegate(UIListItem item, int index) {
			item.Target.transform.FindChild("SprRankbox").FindChild("Label").GetComponent<UILabel>()
				.text = mEntryEvent.Response.data[index].rank+"";
			item.Target.transform.FindChild("LblName").GetComponent<UILabel>().text
				= mEntryEvent.Response.data[index].name;
			item.Target.transform.FindChild("LblPtLeft").GetComponent<UILabel>().text
				= mEntryEvent.Response.data[index].fantasyPoint+"";

			float ratio = mEntryEvent.Response.data[index].gameOverPlayers / 9f;
			int width = (int)(152 * ratio);
			item.Target.transform.FindChild("Panel").FindChild("SprGaugeFront").GetComponent<UISprite>()
				.width = width;
			item.Target.transform.FindChild("Panel").FindChild("SprGaugeFront").localPosition
				= new Vector3(-((152 - width)/2), 0);
		});
		tf.FindChild("Draggable").GetComponent<UIDraggablePanel2>().ResetPosition();
	}

	void InitGames(){
		Transform tf = transform.FindChild("Changeables").FindChild("Games");
		tf.gameObject.SetActive(true);
		UtilMgr.ClearList(tf.FindChild("Draggable"));
		tf.FindChild("Draggable").GetComponent<UIDraggablePanel2>().Init(mTeamEvent.Response.data.Count,
		                                                                 delegate(UIListItem item, int index) {
			item.Target.transform.FindChild("SprLeft").FindChild("Label").GetComponent<UILabel>()
				.text = mTeamEvent.Response.data[index].awayTeamRuns+"";
			item.Target.transform.FindChild("SprLeft").FindChild("SprEmblem").GetComponent<UISprite>()
				.spriteName = mTeamEvent.Response.data[index].awayTeamId+"";
			item.Target.transform.FindChild("SprRight").FindChild("SprEmblem").GetComponent<UISprite>()
				.spriteName = mTeamEvent.Response.data[index].homeTeamId+"";
			item.Target.transform.FindChild("SprRight").FindChild("Label").GetComponent<UILabel>()
				.text = mTeamEvent.Response.data[index].homeTeamRuns+"";

			item.Target.transform.FindChild("LblCenter").GetComponent<UILabel>()
				.text = mTeamEvent.Response.data[index].awayTeam + "         " + mTeamEvent.Response.data[index].homeTeam;
			int hour = int.Parse(mTeamEvent.Response.data[index].dateTime.Substring(8, 2));
			string min = mTeamEvent.Response.data[index].dateTime.Substring(10, 2);//20160326220500
			item.Target.transform.FindChild("LblCenter").FindChild("LblUnder").GetComponent<UILabel>()
				.text = mTeamEvent.Response.data[index].day + " ET " + UtilMgr.GetAMPM(hour)[0] + ":" + min
					+ UtilMgr.GetAMPM(hour)[1];
		});
		tf.FindChild("Draggable").GetComponent<UIDraggablePanel2>().ResetPosition();
	}

	void InitPrizes(){

	}

	void InitRules(){
		Transform tf = transform.FindChild("Changeables").FindChild("Rules");
		tf.gameObject.SetActive(true);
		UtilMgr.ClearList(tf.FindChild("Scroll View"));

		float stackedHeight = 0f;

		GameObject go = Instantiate(mItemRulesHeader);
		go.transform.parent = tf.FindChild("Scroll View");
		stackedHeight -= 30f;
		go.transform.localPosition = new Vector3(0, stackedHeight);
		stackedHeight -= 30f;
		go.transform.localScale = new Vector3(1f, 1f, 1f);
		go.transform.FindChild("LblLeft").GetComponent<UILabel>().text = UtilMgr.GetLocalText("StrHitter");
		for(int i = 0; i < RulesInfo[0].Length; i++){
			go = Instantiate(mItemRulesDetail);
			go.transform.parent = tf.FindChild("Scroll View");
			stackedHeight -= 68f;
			go.transform.localPosition = new Vector3(0, stackedHeight);
			stackedHeight -= 68f;
			go.transform.localScale = new Vector3(1f, 1f, 1f);
			go.transform.FindChild("LblLeft").GetComponent<UILabel>().text = RulesInfo[0][i].mName;
			go.transform.FindChild("LblRight").GetComponent<UILabel>().text
				= RulesInfo[0][i].mPoint > 0 ? "+" + RulesInfo[0][i].mPoint : RulesInfo[0][i].mPoint+"";
		}
		go = Instantiate(mItemRulesHeader);
		go.transform.parent = tf.FindChild("Scroll View");
		stackedHeight -= 30f;
		go.transform.localPosition = new Vector3(0, stackedHeight);
		stackedHeight -= 30f;
		go.transform.localScale = new Vector3(1f, 1f, 1f);
		go.transform.FindChild("LblLeft").GetComponent<UILabel>().text = UtilMgr.GetLocalText("StrPitcher");
		for(int i = 0; i < RulesInfo[1].Length; i++){
			go = Instantiate(mItemRulesDetail);
			go.transform.parent = tf.FindChild("Scroll View");
			stackedHeight -= 68f;
			go.transform.localPosition = new Vector3(0, stackedHeight);
			stackedHeight -= 68f;
			go.transform.localScale = new Vector3(1f, 1f, 1f);
			go.transform.FindChild("LblLeft").GetComponent<UILabel>().text = RulesInfo[1][i].mName;
			go.transform.FindChild("LblRight").GetComponent<UILabel>().text
				= RulesInfo[0][i].mPoint > 0 ? "+" + RulesInfo[1][i].mPoint : RulesInfo[1][i].mPoint+"";
		}

		tf.FindChild("Scroll View").GetComponent<UIScrollView>().ResetPosition();
	}
}
