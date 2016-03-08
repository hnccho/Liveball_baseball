using UnityEngine;
using System.Collections;

public class BtnRegisterUsername : MonoBehaviour {

	CheckNickEvent mNickEvent;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){
//		DialogueMgr.ShowDialogue("title", "body", DialogueMgr.DIALOGUE_TYPE.Alert, null);
		mNickEvent = new CheckNickEvent(new EventDelegate(ReceivedNick));
		string nick = transform.parent.FindChild("Input").FindChild("Label").GetComponent<UILabel>().text;
		//check text length n default text
		if(nick.Equals(transform.parent.FindChild("Input").GetComponent<UIInput>().defaultText)){
			DialogueMgr.ShowDialogue(UtilMgr.GetLocalText("StrCheckNick"), UtilMgr.GetLocalText("StrNickInput"),
			                         DialogueMgr.DIALOGUE_TYPE.Alert, null);
			return;
		} else if(nick.Length < 5){
			DialogueMgr.ShowDialogue(UtilMgr.GetLocalText("StrCheckNick"), UtilMgr.GetLocalText("StrNickShort"),
			                         DialogueMgr.DIALOGUE_TYPE.Alert, null);
			return;
		}
		NetMgr.CheckNickname(nick, mNickEvent);
	}

	void ReceivedNick(){
		if(mNickEvent.Response.code == 0){
			DialogueMgr.ShowDialogue(UtilMgr.GetLocalText("StrCheckNick"), UtilMgr.GetLocalText("StrNickDuplicated"),
			                         DialogueMgr.DIALOGUE_TYPE.Alert, null);
		} else{
			DialogueMgr.ShowDialogue(UtilMgr.GetLocalText("StrCheckNick"), UtilMgr.GetLocalText("StrNickConfirmed"),
			                         DialogueMgr.DIALOGUE_TYPE.Alert, JoinComplete);
			transform.root.GetComponent<LoginRoot>().SetNick(
				transform.parent.FindChild("Input").FindChild("Label").GetComponent<UILabel>().text);
		}
	}

	void JoinComplete(DialogueMgr.BTNS btn){
		AutoFade.LoadLevel("Login");
	}
}
