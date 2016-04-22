using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuizMgr : MonoBehaviour {
	static QuizMgr _instance;

	static QuizMgr Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = FindObjectOfType(typeof(QuizMgr)) as QuizMgr;
				Debug.Log("QuizMgr is null");
				if (_instance == null)
				{
					GameObject container = new GameObject();  
					container.name = "QuizMgr";  
					_instance = container.AddComponent(typeof(QuizMgr)) as QuizMgr;
					Debug.Log("and makes new one");
					
				}
			}
			
			return _instance;
		}
	}

	void Awake()
	{
		DontDestroyOnLoad (this);
	}

	public static void SocketReceived(SocketMsgInfo msgInfo){
		if(UserMgr.eventJoined == null) return;

		LiveBingo bingo = UtilMgr.Instance.mRoot.FindChild("LiveBingo").GetComponent<LiveBingo>();

		switch(msgInfo.type){
		case ConstantsSocketType.RES.TYPE_ALIVE:
			NetMgr.Alive();
			break;
		case ConstantsSocketType.RES.RESULT_HIT :
			bingo.ReceivedResult(msgInfo);
			break;
		case ConstantsSocketType.RES.CHANGE_INNING:
			bingo.ChangeInning(msgInfo);
			break;

		}
	}
}
