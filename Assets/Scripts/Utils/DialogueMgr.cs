using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogueMgr : MonoBehaviour {

	public enum DIALOGUE_TYPE
	{
		Alert,
		YesNo,
		YesNoSetValue,
		Choose,
		EventAlert_NonBg,
		EventAlert,
	}

	public enum BTNS
	{
		Btn1,
		Btn2,
		Cancel
	}

	bool mIsExit;
	static DialogueMgr _instance;
	GameObject mDialogueBox;
	GameObject mAccusationBox;
	AccusationInfo mAccuInfo;
	AccuseContentEvent mAccuEvent;
//	EventDelegate mEvent;
	public delegate void DialogClickHandler(BTNS BtnType);
	public event DialogClickHandler OnClickHandler;

	public void SetHandler(DialogClickHandler handler){
		Instance.OnClickHandler = handler;// as OnClicked;
	}

	public static bool IsShown;
	public static bool IsAccusing;

	public static DialogueMgr Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = FindObjectOfType(typeof(DialogueMgr)) as DialogueMgr;
				Debug.Log("DialogueMgr is null");
				if (_instance == null)
				{
					GameObject container = new GameObject();  
					container.name = "DialogueMgr";  
					_instance = container.AddComponent(typeof(DialogueMgr)) as DialogueMgr;
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

	public static void ShowExitDialogue(DialogClickHandler handler){
//		Debug.Log("ShowExitDialogue");
		if (Instance.mDialogueBox == null) {
			//if(Application.loadedLevelName.Equals("SceneLobby")){
				GameObject prefab = Resources.Load ("CommonDialogue2") as GameObject;
				Instance.mDialogueBox = Instantiate (prefab, new Vector3 (0f, 0f, 0f), Quaternion.identity) as GameObject;
//			}else{
//				GameObject prefab = Resources.Load ("CommonDialogue") as GameObject;
//				Instance.mDialogueBox = Instantiate (prefab, new Vector3 (0f, 0f, 0f), Quaternion.identity) as GameObject;
//			}
		
		}

		string strTitle = Instance.mDialogueBox.GetComponent<PlayMakerFSM> ().FsmVariables.FindFsmString ("exitTitle").Value;
		string strBody = Instance.mDialogueBox.GetComponent<PlayMakerFSM> ().FsmVariables.FindFsmString ("exitBody").Value;

		ShowDialogue (strTitle, strBody, DIALOGUE_TYPE.YesNo, null, null, null, handler);

//		Instance.mIsExit = true;
	}

	public static void ShowDialogue(string strTitle, string strBody, DIALOGUE_TYPE type,
	                                DialogClickHandler handler){
//		Debug.Log("ShowDialogue1");
		ShowDialogue(strTitle, strBody, type, null, null, null, handler);
	}

	public static void ShowDialogue(string strTitle, string strBody, DIALOGUE_TYPE type,
	                                string strBtn1, string strBtn2, string strCancel, DialogClickHandler handler)
	{
		Instance.SetHandler(handler);
//		Debug.Log("ShowDialogue2");
		if (Instance.mDialogueBox == null) {
			//if(Application.loadedLevelName.Equals("SceneLobby")){
				GameObject prefab = Resources.Load ("CommonDialogue2") as GameObject;
				Instance.mDialogueBox = Instantiate (prefab, new Vector3 (0f, 0f, 0f), Quaternion.identity) as GameObject;
//			}else{
//				GameObject prefab = Resources.Load ("CommonDialogue") as GameObject;
//				Instance.mDialogueBox = Instantiate (prefab, new Vector3 (0f, 0f, 0f), Quaternion.identity) as GameObject;
//			}
		}

		if (IsShown) {
			DialogueMgr.DismissDialogue();		
		}

		Instance.mDialogueBox.transform.parent = GameObject.Find ("Camera").transform;
		Instance.mDialogueBox.transform.localScale = new Vector3(1f, 1f, 1f);
		Instance.mDialogueBox.transform.localPosition = new Vector3(0, 0, 0);
		Instance.mDialogueBox.SetActive (true);

		Instance.mDialogueBox.transform.FindChild("Panel").FindChild("LblTitle")
			.GetComponent<UILabel> ().text = strTitle;
		Instance.mDialogueBox.transform.FindChild("Panel").FindChild("LblBody")
			.GetComponent<UILabel> ().text = "[565656]"+strBody+"[-]";

		Instance.SetTypeDialogue (type, strBtn1, strBtn2, strCancel);
//		Instance.mIsExit = false;
//		UtilMgr.SetBackEvent(new EventDelegate(Instance.GetComponent<DialogueMgr>(), "DismissDialogue"));
     	IsShown = true;
	}


	void SetTypeDialogue(DIALOGUE_TYPE type, string strBtn1, string strBtn2, string strCancel)
	{
		GameObject btn1 = Instance.mDialogueBox.transform.FindChild("Panel").FindChild("Btn1").gameObject;
		GameObject btn2 = Instance.mDialogueBox.transform.FindChild("Panel").FindChild("Btn2").gameObject;
		GameObject btnCancel = Instance.mDialogueBox.transform.FindChild("Panel").FindChild("BtnCancel").gameObject;
		GameObject SprBG = Instance.mDialogueBox.transform.FindChild("Panel").FindChild("SprBG").gameObject;
		SprBG.SetActive (true);
		HutongGames.PlayMaker.FsmVariables fsmVariables = Instance.mDialogueBox.GetComponent<PlayMakerFSM> ().FsmVariables;

		if (strBtn1 == null
						|| strBtn1.Length < 1)
			strBtn1 = fsmVariables.FindFsmString ("strBtn1").Value;

		if (strBtn2 == null
						|| strBtn2.Length < 1)
						strBtn2 = "";

		if (strCancel == null
		    || strCancel.Length < 1)
			strCancel = fsmVariables.FindFsmString ("strCancel").Value;

		if (type == DIALOGUE_TYPE.Alert) {
			btn1.SetActive (false);
			btn2.SetActive (false);
			btnCancel.SetActive (true);

			strCancel = fsmVariables.FindFsmString ("strAlert").Value;

			btnCancel.transform.FindChild ("Label").GetComponent<UILabel> ().text = strCancel;
			btnCancel.transform.localPosition = new Vector3 (0, -100f, 0);
		} else if (type == DIALOGUE_TYPE.YesNo) {
			btn1.SetActive (true);
			btn2.SetActive (false);
			btnCancel.SetActive (true);

			btn1.transform.FindChild ("Label").GetComponent<UILabel> ().text = strBtn1;
			btnCancel.transform.FindChild ("Label").GetComponent<UILabel> ().text = strCancel;

			btn1.transform.localPosition = new Vector3 (-145f, -100f, 0);
			btnCancel.transform.localPosition = new Vector3 (145f, -100f, 0);
		} else if (type == DIALOGUE_TYPE.Choose) {
			btn1.SetActive (true);
			btn2.SetActive (true);
			btnCancel.SetActive (true);

			btn1.transform.FindChild ("Label").GetComponent<UILabel> ().text = strBtn1;
			btn2.transform.FindChild ("Label").GetComponent<UILabel> ().text = strBtn2;
			btnCancel.transform.FindChild ("Label").GetComponent<UILabel> ().text = strCancel;

			btn2.transform.localPosition = new Vector3 (0, -100f, 0);
			btn1.transform.localPosition = new Vector3 (-190f, -100f, 0);
			btnCancel.transform.localPosition = new Vector3 (190f, -100f, 0);
		} else if (type == DIALOGUE_TYPE.EventAlert_NonBg) {
			SprBG.SetActive (false);
			btn1.SetActive (false);
			btn2.SetActive (false);
			btnCancel.SetActive (true);
			
			strCancel = fsmVariables.FindFsmString ("strAlert").Value;
			
			btnCancel.transform.FindChild ("Label").GetComponent<UILabel> ().text = strCancel;
			btnCancel.transform.localPosition = new Vector3 (0, -100f, 0);
		} else if (type == DIALOGUE_TYPE.EventAlert) {
			btn1.SetActive (false);
			btn2.SetActive (false);
			btnCancel.SetActive (true);
			
			strCancel = fsmVariables.FindFsmString ("strAlert").Value;
			
			btnCancel.transform.FindChild ("Label").GetComponent<UILabel> ().text = strCancel;
			btnCancel.transform.localPosition = new Vector3 (0, -100f, 0);
		}
	}

	public static void DismissDialogue()
	{
		Debug.Log("DismissDialogue");
		if(Instance.mDialogueBox != null)
			Instance.mDialogueBox.SetActive (false);
		IsShown = false;
	}

	public void Btn1Clicked()
	{
		DialogueMgr.DismissDialogue ();
		if(Instance.OnClickHandler != null)
			Instance.OnClickHandler(BTNS.Btn1);
	}

	public void Btn2Clicked()
	{
		DialogueMgr.DismissDialogue ();
		if(Instance.OnClickHandler != null)
			Instance.OnClickHandler(BTNS.Btn2);
	}

	public void BtnCancelClicked()
	{
		DialogueMgr.DismissDialogue ();
		if(Instance.OnClickHandler != null)
			Instance.OnClickHandler(BTNS.Cancel);
	}

	public static void ShowGuestDialogue()
	{
		GameObject prefab = Resources.Load ("GuestDialogue") as GameObject;
		GameObject dialogueBox = Instantiate (prefab, new Vector3 (0f, 0f, 0f), Quaternion.identity) as GameObject;
				
		dialogueBox.transform.parent = GameObject.Find ("UI Root").transform;
		dialogueBox.transform.localScale = new Vector3(1f, 1f, 1f);
		dialogueBox.transform.localPosition = new Vector3(0, 0, 0);
		dialogueBox.SetActive (true);
	}

	public void BtnJoinClicked()
	{
		if(Instance.OnClickHandler != null)
			Instance.OnClickHandler(BTNS.Cancel);
	}

	public void BtnContinueClicked()
	{
		if(Instance.OnClickHandler != null)
			Instance.OnClickHandler(BTNS.Cancel);
	}

	public static void ShowAccusationDialog(AccusationInfo accuInfo, AccuseContentEvent baseEvent)
	{
		IsAccusing = true;
		Instance.mAccuEvent = baseEvent;
		Instance.mAccuInfo = accuInfo;
		Instance.mAccuInfo.Type = "5";
		GameObject prefab = Resources.Load ("AccusationDialogue") as GameObject;
		Instance.mAccusationBox = Instantiate (prefab, new Vector3 (0f, 0f, 0f), Quaternion.identity) as GameObject;

		Instance.mAccusationBox.transform.FindChild("Panel").FindChild("LblBodyContent").
			GetComponent<UILabel>().text = accuInfo.ContentNum;
		Instance.mAccusationBox.transform.parent = GameObject.Find ("UI Root").transform;
		Instance.mAccusationBox.transform.localScale = new Vector3(1f, 1f, 1f);
		Instance.mAccusationBox.transform.localPosition = new Vector3(0, 0, 0);
		Instance.mAccusationBox.SetActive (true);
	}

	public static void DismissAccusationDialog(){
		Instance.BtnAccusationCancelClicked();
	}

	public void BtnAccuseClicked()
	{
		if(CheckReason()){
			ShowDialogue("신고 오류", "기타를 선택한 경우에는 사유가 입력되어야 합니다.", DIALOGUE_TYPE.Alert, null);
			return;
		}

		NetMgr.AccuseContent(Instance.mAccuInfo, Instance.mAccuEvent);
	}

	public void Test(Transform t){
//		string v = Instance.mAccusationBox.transform.FindChild("Panel").FindChild("Input").
//			GetComponent<UIInput>().value;
		string v = t.GetComponent<UIInput>().value;
		Debug.Log("value is "+v);
	}

	public void ResizeCollider(){
		int height = Instance.mAccusationBox.transform.FindChild("Panel")
			.FindChild("Scroll View").FindChild("Input").FindChild("Label")
				.GetComponent<UILabel>().height;
		Instance.mAccusationBox.transform.FindChild("Panel")
			.FindChild("Scroll View").FindChild("Input")
				.GetComponent<BoxCollider2D>().size = new Vector2(456f, (float)height);

	}

	bool CheckReason(){
		if(Instance.mAccuInfo == null)
			return false;

		Instance.mAccuInfo.Msg = Instance.mAccusationBox.transform.FindChild("Panel")
			.FindChild("Scroll View").FindChild("Input").
			GetComponent<UIInput>().value;
		if(Instance.mAccuInfo.Msg == null)
			Instance.mAccuInfo.Msg = "";

		if(Instance.mAccuInfo.Type.Equals("5")){
			if(Instance.mAccuInfo.Msg.Length < 1){
				return true;
			} else
				return false;

		}
		return false;
	}
	
	public void BtnAccusationCancelClicked()
	{
		IsAccusing = false;
		if(Instance.mAccusationBox == null)
			return;

		Instance.mAccusationBox.SetActive(false);
		Instance.mAccusationBox = null;
	}

	public void ToggleChanged(Transform target){
		if(Instance.mAccuInfo != null){
			Instance.mAccuInfo.Type = target.name;
		}
		Debug.Log("Type is "+target.name);
	}

}
