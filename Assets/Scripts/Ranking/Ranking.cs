using UnityEngine;
using System.Collections;

public class Ranking : MonoBehaviour {

	EntryListEvent mUserEvent;

	public enum TYPE{
		USER_DAILY,
		USER_WEEKLY,
		USER_MONTHLY
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
		} 
	}

	public void Init(){
		transform.FindChild("Top").FindChild("SprTri").gameObject.SetActive(false);
		NeedAnimation = true;
		transform.localPosition = new Vector3(2000f, 0);
		transform.gameObject.SetActive(true);

//		for(int i = 0; i < 3; i++){
//			transform.FindChild("Top").FindChild("Selection").GetChild(i).FindChild("Sprite").gameObject.SetActive(false);
//			transform.FindChild("Top").FindChild("Selection").GetChild(i).GetComponent<UIButton>().defaultColor = new Color(51f/255f, 51f/255f, 51f/255f);
//			transform.FindChild("Top").FindChild("Selection").GetChild(i).GetComponent<UIButton>().hover = new Color(51f/255f, 51f/255f, 51f/255f);
//		}
		for(int i = 0; i < 3; i++){
			transform.FindChild("Top").FindChild("Selection").GetChild(i).GetComponent<BtnRankingSort>().IsSelected = false;
		}
		transform.FindChild("Top").FindChild("Selection").GetChild(0).GetComponent<BtnRankingSort>().IsSelected = true;

//		transform.FindChild("Top").FindChild("Selection").FindChild("1").FindChild("Sprite").gameObject.SetActive(true);
//		transform.FindChild("Top").FindChild("Selection").FindChild("1").GetComponent<UIButton>().defaultColor = new Color(0, 160f/255f, 233f/255f);
//		transform.FindChild("Top").FindChild("Selection").FindChild("1").GetComponent<UIButton>().hover = new Color(0, 160f/255f, 233f/255f);

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
