using UnityEngine;
using System.Collections;

public class DFSBtns : MonoBehaviour {

	ContestListEvent mContestEvent;
	string mTitle;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){
		int featured = 0;
		int type = 0;
		mContestEvent = new ContestListEvent(new EventDelegate(ReceivedContest));
		Com.LOOG("DFSBtns-OnClick" , name);

		if(transform.parent.name.Equals("Special_League")){
			featured = ContestListInfo.FEATURED_SPECIAL;
			type = ContestListInfo.TYPE_ALL;
			mTitle = UtilMgr.GetLocalText("StrSpecialLeague");
		} else if(transform.parent.name.Equals("50")){
			featured = ContestListInfo.TYPE_ALL;
			type = ContestListInfo.TYPE_FIFTY;
			mTitle = UtilMgr.GetLocalText("Str50vs50");
		} else if(transform.parent.name.Equals("Ranking")){
			featured = ContestListInfo.TYPE_ALL;
			type = ContestListInfo.TYPE_RANK;
			mTitle = UtilMgr.GetLocalText("StrRanking");
		}

		NetMgr.GetContestList(featured, type, mContestEvent);
	}

	void ReceivedContest(){
		UtilMgr.AddBackState(UtilMgr.STATE.Contests);
//		UtilMgr.AnimatePage(UtilMgr.DIRECTION.ToLeft,
//		                    transform.root.FindChild("Lobby").gameObject,
//		                    transform.root.FindChild("Contests").gameObject);
		UtilMgr.AnimatePageToLeft("Lobby", "Contests");

		transform.root.FindChild("Contests").GetComponent<Contests>()
			.InitContests(mTitle, mContestEvent.Response.data);
	}
}
