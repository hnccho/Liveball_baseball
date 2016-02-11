using UnityEngine;
using System.Collections;

public class BaseCSEvent {

//	BaseResponse _response;
	EventDelegate _eventDelegate = null;
//
	protected delegate void InitDelegate (string data);
	protected event InitDelegate InitEvent;
//
//	protected bool checkError()
//	{
//		if (response.code > 0) {
//			if(response.code == 100){
////				AutoFade.LoadLevel("SceneLogin");
//				DialogueMgr.ShowDialogue("서버점검", response.message, DialogueMgr.DIALOGUE_TYPE.Alert, DialogueHandler);
//				return true;
//			}
//
//			Debug.Log("Response Error : " + response.message);
//			DialogueMgr.ShowDialogue("서버에러", response.message, DialogueMgr.DIALOGUE_TYPE.Alert, null);
//			return true;
//		} 
//		return false;
//	}
//
//	void DialogueHandler(DialogueMgr.BTNS btn){
//		Application.Quit();		
//	}
//
//
	protected EventDelegate eventDelegate
	{
		get{return _eventDelegate;}
		set{_eventDelegate = value;}
	}
//
//	protected BaseResponse response
//	{
//		get{return _response;}
//		set{_response = value;}
//	}

	public void Init(string data)
	{
		InitEvent (data);
	}

}
