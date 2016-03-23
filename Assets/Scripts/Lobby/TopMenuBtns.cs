using UnityEngine;
using System.Collections;

public class TopMenuBtns : MonoBehaviour {

	GetCardInvenEvent mCardEvent;
	GetMailEvent mMailEvent;
	ContestDataEvent mContestEvent;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){

		if(name.Equals("BtnMyCards")){
			mCardEvent = new GetCardInvenEvent(ReceivedCards);
			NetMgr.GetCardInven(mCardEvent);
		} else if(name.Equals("BtnUpcoming")){
			mContestEvent = new ContestDataEvent(ReceivedUpcoming);
			NetMgr.GetContestData(ContestListInfo.STATUS_UP, mContestEvent);
		} else if(name.Equals("BtnLive")){
			mContestEvent = new ContestDataEvent(ReceivedLive);
			NetMgr.GetContestData(ContestListInfo.STATUS_LIVE, mContestEvent);
		} else if(name.Equals("BtnRecent")){
			mContestEvent = new ContestDataEvent(ReceivedRecent);
			NetMgr.GetContestData(ContestListInfo.STATUS_RECENT, mContestEvent);
		}
	}

	void ReceivedCards(){
		mMailEvent = new GetMailEvent(ReceivedMail);
		NetMgr.GetUserMailBox(mMailEvent);
	}

	void ReceivedMail(){
		UtilMgr.AddBackState(UtilMgr.STATE.MyCards);
		UtilMgr.AnimatePage(UtilMgr.DIRECTION.ToLeft,
		                    transform.root.FindChild("Lobby").gameObject,
		                    transform.root.FindChild("MyCards").gameObject);
		transform.root.FindChild("MyCards").GetComponent<MyCards>().Init(mCardEvent, mMailEvent);
	}

	void ReceivedUpcoming(){
		UtilMgr.AddBackState(UtilMgr.STATE.MyContests);
		UtilMgr.AnimatePage(UtilMgr.DIRECTION.ToLeft,
		                    transform.root.FindChild("Lobby").gameObject,
		                    transform.root.FindChild("MyContests").gameObject);

		transform.root.FindChild("MyContests").GetComponent<MyContests>().Init(
			UtilMgr.GetLocalText("LblUpcomingContests"), mContestEvent);
	}

	void ReceivedLive(){
		UtilMgr.AddBackState(UtilMgr.STATE.MyContests);
		UtilMgr.AnimatePage(UtilMgr.DIRECTION.ToLeft,
		                    transform.root.FindChild("Lobby").gameObject,
		                    transform.root.FindChild("MyContests").gameObject);

		transform.root.FindChild("MyContests").GetComponent<MyContests>().Init(
			UtilMgr.GetLocalText("LblLive"), mContestEvent);
	}

	void ReceivedRecent(){
		UtilMgr.AddBackState(UtilMgr.STATE.MyContests);
		UtilMgr.AnimatePage(UtilMgr.DIRECTION.ToLeft,
		                    transform.root.FindChild("Lobby").gameObject,
		                    transform.root.FindChild("MyContests").gameObject);

		transform.root.FindChild("MyContests").GetComponent<MyContests>().Init(
			UtilMgr.GetLocalText("LblSettledEntries"), mContestEvent);
	}
}
