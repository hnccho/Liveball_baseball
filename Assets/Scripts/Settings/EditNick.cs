using UnityEngine;
using System.Collections;

public class EditNick : MonoBehaviour {

	CheckNickEvent mCheckEvent;
	UpdateMemberInfoEvent mUpdateEvent;
	string mNick = "";

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Cancel(){
		transform.gameObject.SetActive(false);
	}

	public void Submit(){
		transform.FindChild("Box").FindChild("Input").GetComponent<UIInput>().value
			= transform.FindChild("Box").FindChild("Input").GetComponent<UIInput>().value.Trim();
		mNick = transform.FindChild("Box").FindChild("Input").GetComponent<UIInput>().value;

		if(mNick.Equals(UserMgr.UserInfo.nick)){
			DialogueMgr.ShowDialogue(UtilMgr.GetLocalText("StrError"), UtilMgr.GetLocalText("StrSameNick"),
			                         DialogueMgr.DIALOGUE_TYPE.Alert, null);
			return;
		}
			

		mCheckEvent = new CheckNickEvent(new EventDelegate(ReceivedChecking));
		NetMgr.CheckNickname(mNick, mCheckEvent);
	}

	void ReceivedChecking(){
		if(mCheckEvent.Response.code == 0){
			DialogueMgr.ShowDialogue(UtilMgr.GetLocalText("StrCheckNick"), UtilMgr.GetLocalText("StrNickDuplicated"),
			                         DialogueMgr.DIALOGUE_TYPE.Alert, null);
			return;
		} 

		mUpdateEvent = new UpdateMemberInfoEvent(new EventDelegate(ReceivedUpdate));
		JoinMemberInfo memInfo = new JoinMemberInfo();
		memInfo.MemberName = mNick;
		NetMgr.UpdateMemberInfo(memInfo, mUpdateEvent, false, true);
		
	}

	void ReceivedUpdate(){
		mNick = mUpdateEvent.Response.data.nick;
		Cancel();
		UserMgr.UserInfo.nick = mNick;
		transform.FindChild("Box").FindChild("Input").GetComponent<UIInput>().value
			= UserMgr.UserInfo.nick;

		transform.root.FindChild("Settings").GetComponent<Settings>().Reset();

		DialogueMgr.ShowDialogue(UtilMgr.GetLocalText("StrRegSucceed"), UtilMgr.GetLocalText("StrSuccessNick"),
		                         DialogueMgr.DIALOGUE_TYPE.Alert, null);
	}
}
