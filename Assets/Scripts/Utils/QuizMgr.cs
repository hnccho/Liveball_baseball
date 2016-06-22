using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuizMgr : MonoBehaviour {
//	public static bool IsProcessing;

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

//	public static void EndProcess(){
//		Instance.StopCoroutine(Instance.IWaitProcess());
//		IsProcessing = false;
//	}
//
//	IEnumerator IWaitProcess(){
//		yield return new WaitForSeconds(10f);
//		IsProcessing = false;
//	}

	public static bool SocketReceived(SocketMsgInfo msgInfo){
//		if(IsProcessing) return true;
//
//		IsProcessing = true;

		if(UserMgr.eventJoined == null) return false;

		if(UtilMgr.GetLastBackState() != UtilMgr.STATE.LiveBingo) return false;

		LiveBingo bingo = UtilMgr.Instance.mRoot.FindChild("LiveBingo").GetComponent<LiveBingo>();
		bingo.mUpdateCnt = 0;
		bingo.transform.FindChild("Top").FindChild("BtnDebug").GetComponent<BtnDebugLiveBingo>().AddLog(msgInfo);

		if(msgInfo.type == ConstantsSocketType.RES.TYPE_ALIVE_OK
		   && bingo.mMsgCount < msgInfo.data.msgCount){
			string msg = "\n[ff0000]Socket msg count is wrong[-]";
			bingo.transform.FindChild("Top").FindChild("BtnDebug").GetComponent<BtnDebugLiveBingo>().AddLog(msg);
			bingo.ReloadAll();
			return false;
		}

		if(msgInfo.data.msgCount > 0)
			bingo.mMsgCount = msgInfo.data.msgCount;

		switch(msgInfo.type){
		case ConstantsSocketType.RES.TYPE_ALIVE:
//			IsProcessing = false;
			NetMgr.Alive();
			break;
		case ConstantsSocketType.RES.RESULT_HITTER :
//			Instance.StartCoroutine(Instance.IWaitProcess());
			bingo.ReceivedResult(msgInfo);
			break;
		case ConstantsSocketType.RES.CHANGE_INNING:
//			Instance.StartCoroutine(Instance.IWaitProcess());
//			bingo.ChangeInning(msgInfo);
			break;
		case ConstantsSocketType.RES.RELOAD_BINGO:
//			Instance.StartCoroutine(Instance.IWaitProcess());
			bingo.ReloadBoard();
			break;
		case ConstantsSocketType.RES.CHANGE_PLAYER:
//			Instance.StartCoroutine(Instance.IWaitProcess());
			bingo.ChangePlayer(msgInfo);
//			bingo.ReloadLineup(msgInfo);
			break;
		case ConstantsSocketType.RES.GAME_ENDED:
//			bingo.ShowGameEnded();
			bingo.GameEnded();
			break;
		}


		return false;
	}
}
