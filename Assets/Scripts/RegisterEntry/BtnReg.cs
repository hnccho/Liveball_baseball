using UnityEngine;
using System.Collections;

public class BtnReg : MonoBehaviour {

	RegEntryEvent mRegEvent;
	ContestListEvent mContestEvent;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){
		if(transform.parent.GetComponent<BtmInfo>().CheckSalary()){
			if(transform.parent.GetComponent<BtmInfo>().CheckFull()){
				mRegEvent = new RegEntryEvent(ReceivedEntry);
				string lineupName = transform.root.FindChild("RegisterEntry").GetComponent<RegisterEntry>().GetLineupName();
				RegisterEntry re = transform.root.FindChild("RegisterEntry").GetComponent<RegisterEntry>();


				if(transform.root.FindChild("RegisterEntry").GetComponent<RegisterEntry>().mContestInfo.myEntry < 1){
					NetMgr.RegEntry(lineupName,
					                transform.root.FindChild("RegisterEntry").GetComponent<RegisterEntry>().mLineup == null ? 0 : 
					                transform.root.FindChild("RegisterEntry").GetComponent<RegisterEntry>().mLineup.lineupSeq
					                , re.GetContestSeq(), re.GetSlots(), mRegEvent);
				} else{
					NetMgr.UpdateEntry(lineupName,
					                transform.root.FindChild("RegisterEntry").GetComponent<RegisterEntry>().mLineup == null ? 0 : 
					                transform.root.FindChild("RegisterEntry").GetComponent<RegisterEntry>().mLineup.lineupSeq
					                   ,transform.root.FindChild("RegisterEntry").GetComponent<RegisterEntry>().mContestInfo.myEntry
					                   , re.GetContestSeq(), re.GetSlots(), mRegEvent);
				}
			} else{
				DialogueMgr.ShowDialogue(UtilMgr.GetLocalText("StrError"),
				                         UtilMgr.GetLocalText("StrEntryNotEnough"), DialogueMgr.DIALOGUE_TYPE.Alert, null);
			}
		} else{
			DialogueMgr.ShowDialogue(UtilMgr.GetLocalText("StrSalaryLimit"),
			                         UtilMgr.GetLocalText("StrSalaryLimit2"), DialogueMgr.DIALOGUE_TYPE.Alert, null);
		}
	}

	void ReceivedEntry(){
		if(mRegEvent.Response.code == 0){
			DialogueMgr.ShowDialogue(UtilMgr.GetLocalText("StrRegSucceed"),
                                  	UtilMgr.GetLocalText("StrRegSucceed2"),DialogueMgr.DIALOGUE_TYPE.Alert, RegComplete);

			UserMgr.UserInfo.ticket -= transform.root.FindChild("RegisterEntry").GetComponent<RegisterEntry>().mContestInfo.entryTicket;
		} else{
			DialogueMgr.ShowDialogue(UtilMgr.GetLocalText("StrError"),
			                         mRegEvent.Response.message, DialogueMgr.DIALOGUE_TYPE.Alert, RegComplete);
		}


	}

	void RegComplete(DialogueMgr.BTNS btn){
		mContestEvent = new ContestListEvent(new EventDelegate(ReceivedContest));
		string title = transform.root.FindChild("Contests").FindChild("Top")
			.FindChild("LblRanking").GetComponent<UILabel>().text;
		int featured = 0;
		int type = 0;
		if(title.Equals(UtilMgr.GetLocalText("StrSpecialLeague"))){
			featured = ContestListInfo.FEATURED_SPECIAL;
			type = ContestListInfo.TYPE_ALL;
		} else if(title.Equals(UtilMgr.GetLocalText("Str50vs50"))){
			featured = ContestListInfo.TYPE_ALL;
			type = ContestListInfo.TYPE_FIFTY;
		} else if(title.Equals(UtilMgr.GetLocalText("StrRanking"))){
			featured = ContestListInfo.TYPE_ALL;
			type = ContestListInfo.TYPE_RANK;
		}		
		NetMgr.GetContestList(featured, type, mContestEvent);

	}

	void ReceivedContest(){
		UtilMgr.OnBackPressed();

		transform.root.FindChild("Contests").GetComponent<Contests>()
			.InitContests(transform.root.FindChild("Contests").FindChild("Top")
			              .FindChild("LblRanking").GetComponent<UILabel>().text,
			              mContestEvent.Response.data);
	}
}
