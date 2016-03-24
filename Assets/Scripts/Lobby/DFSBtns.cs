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

		if(name.Equals("BtnSpecial")){
			featured = ContestListInfo.FEATURED_SPECIAL;
			type = ContestListInfo.TYPE_ALL;
			mTitle = UtilMgr.GetLocalText("StrSpecialLeague");
		} else if(name.Equals("Btn50")){
			featured = ContestListInfo.TYPE_ALL;
			type = ContestListInfo.TYPE_FIFTY;
			mTitle = UtilMgr.GetLocalText("Str50vs50");
		} else if(name.Equals("BtnRanking")){
			featured = ContestListInfo.TYPE_ALL;
			type = ContestListInfo.TYPE_RANK;
			mTitle = UtilMgr.GetLocalText("StrRanking");
		}

		NetMgr.GetContestList(featured, type, mContestEvent);
	}

	void ReceivedContest(){
		UtilMgr.AddBackState(UtilMgr.STATE.Contests);
		UtilMgr.AnimatePage(UtilMgr.DIRECTION.ToLeft,
		                    transform.root.FindChild("Lobby").gameObject,
		                    transform.root.FindChild("Contests").gameObject);

		transform.root.FindChild("Contests").GetComponent<Contests>()
			.InitContests(mTitle, mContestEvent.Response.data);
	}
}
