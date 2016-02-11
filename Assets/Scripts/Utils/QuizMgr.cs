using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuizMgr : MonoBehaviour {

//	ScriptMainTop mMainTop;
//	ScriptMatchPlaying mMatchPlaying;
	//public static int QuizCount = 0;
	public static int QuizValue = 0;
	int sequenceQuiz;
	public static int SequenceQuiz {
		get {	return Instance.sequenceQuiz;}
		set {	Instance.sequenceQuiz = value;}
	}

	bool isBettingOpended;
	public static bool IsBettingOpended{
		get{return Instance.isBettingOpended;}
		set{Instance.isBettingOpended = value;}
	}
	bool needsDetailInfo;
	public static bool NeedsDetailInfo{
		get{return Instance.needsDetailInfo;}
		set{Instance.needsDetailInfo = value;}
	}
	bool hasQuiz;
	public static bool HasQuiz{
		get{return Instance.hasQuiz;}
		set{Instance.hasQuiz = value;}
	}
	bool moreQuiz;
	public static bool MoreQuiz{
		get{return Instance.moreQuiz;}
		set{Instance.moreQuiz = value;}
	}
	int joinCount;
	public static int JoinCount{
		get{return Instance.joinCount;}
		set{Instance.joinCount = value;}
	}

	List<QuizInfo> quizList;
	public static List<QuizInfo> QuizList{
		get{return Instance.quizList;}
		set{Instance.quizList = value;}
	}
	QuizInfo quizInfo;
	public static QuizInfo QuizInfo
	{
		get{return Instance.quizInfo;}
		set{Instance.quizInfo = value;}
	}
	QuizListInfo nextPlayerInfo;
	public static QuizListInfo NextPlayerInfo
	{
		get{return Instance.nextPlayerInfo;}
		set{Instance.nextPlayerInfo = value;}
	}
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

	public static void EnterMain
		(GameObject script)
//		(ScriptMainTop script)
	{
//		Instance.mMainTop = script;
//		Instance.mMatchPlaying = Instance.mMainTop.GetComponent<ScriptMainTop>()
//			.mHighlight.transform.FindChild("MatchPlaying").GetComponent<ScriptMatchPlaying>();
//
	}

	public static void LeaveMain()
	{
//		Instance.mMainTop = null;
//		Instance.mMatchPlaying = null;
	}

	public static void InitBetting()
	{
		Instance.joinCount = 0;
	}

	public static void SetQuizList(List<QuizInfo> quizList)
	{
		QuizList = quizList;
		foreach(QuizInfo quiz in quizList){
			if(SequenceQuiz < quiz.quizListSeq)
				SequenceQuiz = quiz.quizListSeq;
		}
	}

	public static void AddQuizList(QuizInfo quiz)
	{
		QuizList.Insert(0, quiz);
		if(SequenceQuiz < quiz.quizListSeq)
			SequenceQuiz = quiz.quizListSeq;
	}

	public static void InitSimpleResult(GetSimpleResultEvent simpleEvent,
	                                    GameObject scriptBetting, GameObject scriptQuizResult){
//	                                    , ScriptBetting scriptBetting, ScriptQuizResult scriptQuizResult){
		Debug.Log ("InitSimpleResult");
		if (simpleEvent.Response.data == null
			|| simpleEvent.Response.data.Count < 1) {
			Debug.Log("return");
			return;
		}
		
		QuizInfo quiz = null;
		foreach (QuizInfo quizInfo in QuizMgr.QuizList) {
			if(quizInfo.quizListSeq == simpleEvent.Response.data [0].quizListSeq){
				quiz = quizInfo;
				break;
			}
		}
		if (quiz == null) {
			Debug.Log("return re");
			return;
		}

		quiz.quizValue = simpleEvent.Response.data [0].quizValue;

		if(simpleEvent.Response.data[0].isCancel > 0){
			quiz.resultMsg = simpleEvent.Response.data[0].resultMsg;
			Debug.Log("simpleEvent.Response.data[0].respStatus : "+simpleEvent.Response.data[0].respStatus);

		}
		if (simpleEvent.Response.data [0].respStatus > 0
			|| simpleEvent.Response.data [0].isCancel > 0) {
			quiz.resp = new List<QuizRespInfo> ();
			QuizRespInfo tmpInfo;
			if (simpleEvent.Response.data.Count > 1) {
				//got 2 answers
				tmpInfo = new QuizRespInfo ();
				tmpInfo.respValue = simpleEvent.Response.data [1].respValue;
				tmpInfo.expectRewardPoint = int.Parse (simpleEvent.Response.data [1].rewardPoint);
				quiz.resp.Add (tmpInfo);
			} 
			
			tmpInfo = new QuizRespInfo ();
			tmpInfo.respValue = simpleEvent.Response.data [0].respValue;
			tmpInfo.expectRewardPoint = int.Parse (simpleEvent.Response.data [0].rewardPoint);
			quiz.resp.Insert (0, tmpInfo);
			Debug.Log ("simpleEvent.Response.data[0].isCancel : " + simpleEvent.Response.data [0].isCancel);
//			if (ScriptMainTop.OpenBettingCheck) {
//				if (simpleEvent.Response.data [0].isCancel > 0) {
//					ShowQuizResult (quiz, simpleEvent, scriptQuizResult);
//				} else {
//					if (ShowQuizResult (quiz, simpleEvent, scriptQuizResult)) {
//						scriptQuizResult.InitParticle ();
//					}
//				}
//			}
		}
		
//		scriptBetting.UpdateHitterItem(quiz);
	}

	static bool ShowQuizResult(QuizInfo quiz, GetSimpleResultEvent simpleEvent,
	                           GameObject scriptQuizResult)
//	                           ScriptQuizResult scriptQuizResult)
	{
		Debug.Log ("");
		scriptQuizResult.GetComponent<PlayMakerFSM>().SendEvent("OpenResultEvent");


//		return scriptQuizResult.GetComponent<ScriptQuizResult> ().Init (simpleEvent.Response.data);
		return true;
	}

	public static void SocketReceived(SocketMsgInfo msgInfo){
//		if(Instance.mMatchPlaying != null){
//			Instance.mMatchPlaying.mCntAlive = 0;
//			Instance.mMatchPlaying.mNeedResponse = false;
//		}
//		Debug.Log("msgInfo.type" + msgInfo.type);
//		if(msgInfo.type == ConstantsSocketType.RES.TYPE_JOIN){
//			if(Instance.mMatchPlaying != null){
//				Instance.mMatchPlaying.CompleteJoin();
//			}
//		} else if(msgInfo.type.Equals(ConstantsSocketType.RES.TYPE_START)){
//
//			Instance.mMainTop.StartGame();
//
//		} else if(msgInfo.type.Equals(ConstantsSocketType.RES.TYPE_CLOSE)){
////			Instance.mMainTop.GameReslut();
////			Debug.Log("Game Close");
//			if(UserMgr.Schedule.myEntryFee!="0"){
//			if(UserMgr.Schedule.doneGame!=null){
//				if(UserMgr.Schedule.doneGame=="0"){
//
//						Instance.mMainTop.ResetData();
//					
//				}else{
//					Instance.mMainTop.GameReslut();
//				}
//			}
//			}
//			Instance.mMainTop.GameEnd();
//
//
//			//Reset Contest,Preset,History List;
//
//
//		} else if(msgInfo.type == ConstantsSocketType.RES.TYPE_STATUS){
//			if(Instance.mMainTop != null){
////				bool hasQuiz = false;
//				if(msgInfo.data.quiz != null
//				   && msgInfo.data.quiz.Equals("1")){
//					if(QuizMgr.IsBettingOpended){
//						MoreQuiz = true;
//												Debug.Log ("MoreQuiz");
//					} else{
//						HasQuiz = true;
//												Debug.Log ("HasQuiz");
//					}
//				}
//				
//				if(msgInfo.data.inning != null
//				   && msgInfo.data.inning.Equals("1")){
//					NeedsDetailInfo = true;
//				} else if(msgInfo.data.score != null
//				          && msgInfo.data.score.Equals("1")){
//					NeedsDetailInfo = true;
//				} else if(msgInfo.data.result != null
//				          && msgInfo.data.result.Equals("1")){
//					Debug.Log("result");
//					if(Instance.mMainTop != null){
//						Debug.Log("GetSimpleResult");
//						Instance.GetSimpleResult(msgInfo);
//					}
//				} else{
//					NeedsDetailInfo = false;
//				}
//				
//				//				Debug.Log ("RequestBoardInfo");
//				Instance.mMainTop.RequestBoardInfo();
//			}
//		} else if(msgInfo.type == ConstantsSocketType.RES.TYPE_ALIVE){
////			NetMgr.SendSocketMsg(new AliveRequest().ToRequestString());
//			if(Instance.mMatchPlaying != null)
//				Instance.mMatchPlaying.mCntAlive = ScriptMatchPlaying.TIME_MAX_ALIVE;
//		}
	}

	public static void NotiReceived(NotiMsgInfo msgInfo){
		Debug.Log ("push type : " + msgInfo.type);
//		Debug.Log ("msgInfo.info.gameSeq : " + msgInfo.info.gameSeq);
//		Debug.Log ("msgInfo.info.scheduleSeq : " + msgInfo.info.scheduleSeq);
//		Debug.Log ("msgInfo.info.quizListSeq : " + msgInfo.info.quizListSeq);
//		Debug.Log ("msgInfo.info.quiz : " + msgInfo.info.quiz);
//		Debug.Log ("msgInfo.info.inning : " + msgInfo.info.inning);
//		Debug.Log ("msgInfo.info.score : " + msgInfo.info.score);
		
//		if(msgInfo.type.Equals(Constants.POST_MSG)){
//			
//		} else if(msgInfo.type.Equals(Constants.POST_GAME_START)){
//			Debug.Log("UserMgr.Schedule.gameSeq is "+UserMgr.Schedule.gameSeq);
//			if(UserMgr.Schedule != null){
//				Debug.Log("msgInfo.info.gameSeq is "+msgInfo.info.gameSeq);
//				if(UserMgr.Schedule.gameSeq == int.Parse(msgInfo.info.gameSeq)){
//				//	AutoFade.LoadLevel("SceneMain");
//				}
//			}
//		} else if(msgInfo.type.Equals(Constants.POST_GAME_STATUS)){
//			if(Instance.mMainTop != null){
//				bool hasQuiz = false;
//				if(msgInfo.info.quiz != null
//				   && msgInfo.info.quiz.Equals("1")){
//					if(QuizMgr.IsBettingOpended){
//						MoreQuiz = true;
////						Debug.Log ("MoreQuiz");
//					} else{
//						HasQuiz = true;
////						Debug.Log ("HasQuiz");
//					}
//				}
//				
//				if(msgInfo.info.inning != null
//				   && msgInfo.info.inning.Equals("1")){
//					NeedsDetailInfo = true;
//				} else if(msgInfo.info.score != null
//				          && msgInfo.info.score.Equals("1")){
//					NeedsDetailInfo = true;
//				} else{
//					NeedsDetailInfo = false;
//				}
//
////				Debug.Log ("RequestBoardInfo");
//				Instance.mMainTop.RequestBoardInfo();
//			}
//		} else if(msgInfo.type.Equals(Constants.POST_QUIZ_RESULT)
//		          || msgInfo.type.Equals(Constants.POST_QUIZ_CANCEL)){
//			if(Instance.mMainTop != null){
//				Instance.mMainTop.GetComponent<ScriptMainTop>().GetSimpleResult(int.Parse(msgInfo.info.quizListSeq));
//			}
//		}
	}

	public static void NotiReceived(string msg)
	{
		Debug.Log ("ReceivedMsg : " + msg);
		NotiMsgInfo msgInfo = null;
//		msgInfo = JsonFx.Json.JsonReader.DeserializeObject<NotiMsgInfo> (msg);
		msgInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<NotiMsgInfo>(msg);
		NotiReceived(msgInfo);		 
	}

	void GetSimpleResult(SocketMsgInfo msgInfo){
		int quizListSeq = int.Parse(msgInfo.data.quizListSeq);
		StartCoroutine(RoutineSimpleResult(quizListSeq));

	}

	IEnumerator RoutineSimpleResult(int quizListSeq){
		float waitingSeconds = 0f;
		string watching = PlayerPrefs.GetString(Constants.PrefSetting_watching_method);
		if(watching != null
		   && watching.Equals("INTERNET"))
			waitingSeconds = 15f;

		yield return new WaitForSeconds(waitingSeconds);
//		mMainTop.GetComponent<ScriptMainTop>().GetSimpleResult(quizListSeq);
	}
}
