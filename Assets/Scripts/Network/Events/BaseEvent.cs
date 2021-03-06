﻿using UnityEngine;
using System.Collections;

public class BaseEvent {

	BaseResponse _response;
	EventDelegate _eventDelegate = null;

	protected delegate void InitDelegate (string data);
	protected event InitDelegate InitEvent;

	protected bool checkError()
	{
		if (response.code > 0) {
			if(response.code == 100){
//				AutoFade.LoadLevel("SceneLogin");
				DialogueMgr.ShowDialogue(UtilMgr.GetLocalText("StrServerMaintenance"),
				                     response.message, DialogueMgr.DIALOGUE_TYPE.Alert, DialogueHandler);
				return true;
			}

			Debug.Log("Response Error : " + response.message);
			DialogueMgr.ShowDialogue(UtilMgr.GetLocalText("StrServerError"),
			                         response.message, DialogueMgr.DIALOGUE_TYPE.Alert, null);
			return true;
		} 
		return false;
	}

	void DialogueHandler(DialogueMgr.BTNS btn){
		Application.Quit();		
	}


	protected EventDelegate eventDelegate
	{
		get{return _eventDelegate;}
		set{_eventDelegate = value;}
	}

	protected BaseResponse response
	{
		get{return _response;}
		set{_response = value;}
	}

	public void Init(string data)
	{
		Debug.Log("InitEvent (data)");
		InitEvent (data);
	}

}
