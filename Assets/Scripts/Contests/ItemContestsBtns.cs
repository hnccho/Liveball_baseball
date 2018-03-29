using UnityEngine;
using System.Collections;

public class ItemContestsBtns : MonoBehaviour {

//	int mContestSeq;
	ContestListInfo mContestInfo;
	GetMyLineupEvent mLineupEvent;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetContestSeq(ContestListInfo contestInfo){
//		mContestSeq = contestSeq;
		mContestInfo = contestInfo;
	}

	public void OnClick(){
		if(mContestInfo.entryTicket > UserMgr.UserInfo.ticket){
			UtilMgr.NotEnoughTicket();
			return;
		}

		if(mContestInfo.myEntry > 0){
			mLineupEvent = new GetMyLineupEvent(ReceivedEntry);
			NetMgr.GetMyEntryData(mContestInfo.myEntry, mLineupEvent);
			return;
		}

		UtilMgr.AddBackState(UtilMgr.STATE.RegisterEntry);
		UtilMgr.AnimatePageToLeft("Contests", "RegisterEntry");
		transform.root.FindChild("RegisterEntry").GetComponent<RegisterEntry>().InitRegisterEntry(mContestInfo);
	}

	void ReceivedEntry(){
		UtilMgr.AddBackState(UtilMgr.STATE.RegisterEntry);
		UtilMgr.AnimatePageToLeft("Contests", "RegisterEntry");
		transform.root.FindChild("RegisterEntry").GetComponent<RegisterEntry>().InitRegisterEntry(mContestInfo
			, mLineupEvent.Response.data);
	}
}
