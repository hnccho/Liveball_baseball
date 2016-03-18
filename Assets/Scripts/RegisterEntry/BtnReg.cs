using UnityEngine;
using System.Collections;

public class BtnReg : MonoBehaviour {

	RegEntryEvent mRegEvent;

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
				RegisterEntry re = transform.root.FindChild("RegisterEntry").GetComponent<RegisterEntry>();
				NetMgr.RegEntry(re.GetContestSeq(), re.GetSlots(), mRegEvent);
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
		} else{
			DialogueMgr.ShowDialogue(UtilMgr.GetLocalText("StrError"),
			                         mRegEvent.Response.message, DialogueMgr.DIALOGUE_TYPE.Alert, RegComplete);
		}
	}

	void RegComplete(DialogueMgr.BTNS btn){
		UtilMgr.OnBackPressed();
	}
}
