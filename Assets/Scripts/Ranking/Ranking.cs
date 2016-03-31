using UnityEngine;
using System.Collections;

public class Ranking : MonoBehaviour {

	EntryListEvent mUserEvent;

	public enum TYPE{
		USER_DAILY,
		USER_WEEKLY,
		USER_MONTHLY,
		PLAYER_PITCHER,
		PLAYER_HITTER
	}

	public TYPE mType;
	bool NeedAnimation;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void InitNonTween(TYPE type){
		NeedAnimation = false;
		mType = type;

		if(mType == TYPE.USER_DAILY){
			InitUserDaily();
		} else if(mType == TYPE.USER_WEEKLY){
			InitUserWeekly();
		} else if(mType == TYPE.USER_MONTHLY){
			InitUserMonthly();
		} else if(mType == TYPE.PLAYER_PITCHER){
			InitPlayerPitcher();
		} else{
			InitPlayerHitter();
		}
	}

	public void InitPlayer(){

	}

	public void InitUser(){
		transform.FindChild("Top").FindChild("User").FindChild("SprTri").gameObject.SetActive(false);
		transform.FindChild("Top").FindChild("User").FindChild("Selection").localPosition = new Vector3(0, 400f);
		transform.FindChild("Top").FindChild("User").FindChild("BtnFilter").GetComponent<BtnFilter>().IsOpen = false;

		NeedAnimation = true;
		transform.localPosition = new Vector3(2000f, 0);
		transform.gameObject.SetActive(true);

		for(int i = 0; i < 3; i++){
			transform.FindChild("Top").FindChild("User").FindChild("Selection").GetChild(i).GetComponent<BtnRankingSort>().IsSelected = false;
		}
		transform.FindChild("Top").FindChild("User").FindChild("Selection").GetChild(0).GetComponent<BtnRankingSort>().IsSelected = true;

		mType = TYPE.USER_DAILY;
		InitUserDaily();
	}

	void InitUserDaily(){
		mUserEvent = new EntryListEvent(ReceivedUserRanking);
		NetMgr.UserDailyRanking(mUserEvent);
		transform.FindChild("Top").FindChild("LblTitle").GetComponent<UILabel>().
			text = UtilMgr.GetLocalText("StrDailyRanking");
	}

	void InitUserWeekly(){
		mUserEvent = new EntryListEvent(ReceivedUserRanking);
		NetMgr.UserWeeklyRanking(mUserEvent);
		transform.FindChild("Top").FindChild("LblTitle").GetComponent<UILabel>().
			text = UtilMgr.GetLocalText("StrWeeklyRanking");
	}

	void InitUserMonthly(){
		mUserEvent = new EntryListEvent(ReceivedUserRanking);
		NetMgr.UserMonthlyRanking(mUserEvent);
		transform.FindChild("Top").FindChild("LblTitle").GetComponent<UILabel>().
			text = UtilMgr.GetLocalText("StrMonthlyRanking");
	}

	void InitPlayerPitcher(){

	}

	void InitPlayerHitter(){

	}

	void ReceivedUserRanking(){
		transform.FindChild("Body").FindChild("ScrollUser").gameObject.SetActive(true);
		transform.FindChild("Body").FindChild("ScrollPlayer").gameObject.SetActive(false);

		UtilMgr.ClearList(transform.FindChild("Body").FindChild("ScrollUser"));
		transform.FindChild("Body").FindChild("ScrollUser").GetComponent<UIDraggablePanel2>().Init(
			mUserEvent.Response.data.Count, delegate(UIListItem item, int index) {
			item.Target.transform.FindChild("SprRankbox").FindChild("Label").GetComponent<UILabel>()
				.text = mUserEvent.Response.data[index].rank+"";
			item.Target.transform.FindChild("LblName").GetComponent<UILabel>()
				.text = mUserEvent.Response.data[index].name;
			item.Target.transform.FindChild("LblPtLeft").GetComponent<UILabel>()
				.text = mUserEvent.Response.data[index].rankPoint+"";
		});
		transform.FindChild("Body").FindChild("ScrollUser").GetComponent<UIDraggablePanel2>().ResetPosition();

		if(NeedAnimation){
			UtilMgr.AddBackState(UtilMgr.STATE.Ranking);
			UtilMgr.AnimatePageToLeft("Lobby", "Ranking");
		}
	}
}
