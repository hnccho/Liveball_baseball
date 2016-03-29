using UnityEngine;
using System.Collections;

public class ItemLineup : MonoBehaviour {

	public LineupInfo mLineupInfo;
	DeleteLineupEvent mDeleteEvent;
	GetMyLineupEvent mMyLineupEvent;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.root.FindChild("Lineup").GetComponent<MyLineup>().IsDeletable){
			transform.FindChild("Normal").gameObject.SetActive(false);
			transform.FindChild("Delete").gameObject.SetActive(true);
		} else{
			transform.FindChild("Normal").gameObject.SetActive(true);
			transform.FindChild("Delete").gameObject.SetActive(false);
		}
	}

	public void BtnEditClick(){
		transform.root.FindChild("Lineup").GetComponent<MyLineup>().ShowEditBox(mLineupInfo);
	}

	public void BtnSelectClick(){
		mMyLineupEvent = new GetMyLineupEvent(ReceivedMyLineup);
		NetMgr.GetMyLineupData(mLineupInfo.lineupSeq, mMyLineupEvent);
	}

	void ReceivedMyLineup(){
		transform.root.FindChild("RegisterEntry").GetComponent<RegisterEntry>().InitRegisterEntry(
			transform.root.FindChild("RegisterEntry").GetComponent<RegisterEntry>().mContestInfo
				, mMyLineupEvent.Response.data);
		UtilMgr.OnBackPressed();
	}

	public void BtnDeleteClick(){
		mDeleteEvent = new DeleteLineupEvent(ReceivedDelete);
		NetMgr.DeleteLineup(mLineupInfo.lineupSeq, mDeleteEvent);
	}

	void ReceivedDelete(){
		for(int i = 0; i <
		    transform.root.FindChild("Lineup").GetComponent<MyLineup>().mLineupEvent.Response.data.Count; i++){
			if(mLineupInfo.lineupSeq ==
			   transform.root.FindChild("Lineup").GetComponent<MyLineup>().mLineupEvent.Response.data[i].lineupSeq){
				transform.root.FindChild("Lineup").GetComponent<MyLineup>().mLineupEvent.Response.data.RemoveAt(i);
				transform.root.FindChild("Lineup").GetComponent<MyLineup>().Reload();
				break;
			}
		}
	}
}
