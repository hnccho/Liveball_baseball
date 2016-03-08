﻿using UnityEngine;
using System.Collections;

public class LoginRoot : SuperRoot {

	CheckVersionEvent mVersionEvent;
	LoginEvent mCheckEvent;
	LoginEvent mLoginEvent;
	LoginInfo mLoginInfo;
	GetProfileEvent mProfileEvent;


	bool mMustUpdate;
	static string mNick = null;

	// Use this for initialization
	void Start () {
		base.Start();
		transform.FindChild("Terms").gameObject.SetActive(false);
		transform.FindChild("RegisterUsername").gameObject.SetActive(false);

		transform.FindChild("RegisterUsername").localPosition
			= new Vector3(0f, UtilMgr.GetScaledPositionY ());

		if(UtilMgr.IsMLB())
			transform.FindChild("SprTitle").GetComponent<UISprite>().spriteName = "logo_title1";

		if(mNick != null){
			Login ();
			return;
		}

		mVersionEvent = new CheckVersionEvent(new EventDelegate(ReceivedVersion));
		NetMgr.CheckVersion(mVersionEvent, false);

	}

	void Awake(){
		base.Awake();
	}
	
	// Update is called once per frame
	void Update () {
		base.Update();
	}

	void ReceivedVersion(){
		int aFirst = int.Parse(Application.version.Substring(0, 1));
		int aSecond = int.Parse(Application.version.Substring(2, 1));
		int aThird = int.Parse(Application.version.Substring(4, 1));
		
		#if(UNITY_EDITOR)
		Debug.Log("Application.version is "+UnityEditor.PlayerSettings.bundleVersion);
		aFirst = int.Parse(UnityEditor.PlayerSettings.bundleVersion.Substring(0, 1));
		aSecond = int.Parse(UnityEditor.PlayerSettings.bundleVersion.Substring(2, 1));
		aThird = int.Parse(UnityEditor.PlayerSettings.bundleVersion.Substring(4, 1));
		
		#else
		Debug.Log("Application.version is "+Application.version);
		#endif
		Debug.Log("Recent.version is "+mVersionEvent.Response.data.recentVer);
		Debug.Log("Support.version is "+mVersionEvent.Response.data.supportVer);
		
		
		
		int rFirst = int.Parse(mVersionEvent.Response.data.recentVer.Substring(0, 1));
		int rSecond = int.Parse(mVersionEvent.Response.data.recentVer.Substring(2, 1));
		int rThird = int.Parse(mVersionEvent.Response.data.recentVer.Substring(4, 1));
		
		int sFirst = int.Parse(mVersionEvent.Response.data.supportVer.Substring(0, 1));
		int sSecond = int.Parse(mVersionEvent.Response.data.supportVer.Substring(2, 1));
		int sThird = int.Parse(mVersionEvent.Response.data.supportVer.Substring(4, 1));
		
		if(aFirst < sFirst){
			MustUpdate(); return;
		} else if(aFirst == sFirst){
			if(aSecond < sSecond){
				MustUpdate(); return;
			} else if(aSecond == sSecond){
				if(aThird < sThird){
					MustUpdate(); return;
				}
			}
		}
		
		if(aFirst < rFirst){
			ReqUpdate(); return;
		} else if(aFirst == rFirst){
			if(aSecond < rSecond){
				ReqUpdate(); return;
			} else if(aSecond == rSecond){
				if(aThird < rThird){
					ReqUpdate(); return;
				}
			}
		}

		CheckPreference();
	}

	void CheckPreference(){

		InitConstants();

	}

	void InitConstants(){
		Debug.Log("ScreenSize.x : "+Screen.width+", y : "+Screen.height);
		
		Constants.SCREEN_HEIGHT_ORIGINAL = Screen.height;
		Debug.Log("SystemInfo.deviceModel is "+SystemInfo.deviceModel);
		if(Application.platform == RuntimePlatform.IPhonePlayer){
			if(SystemInfo.deviceModel.Contains("iPhone7,1")){
				Constants.WEBVIEW_GAB_TOP = 34f;
			} else if(SystemInfo.deviceModel.Contains("iPad2,1")){
				
			} else{
				Constants.WEBVIEW_GAB_TOP = 48f;
			}
		}

		Constants.AUTH_SERVER_HOST = mVersionEvent.Response.data.AUTH;
		Constants.APPS_SERVER_HOST = mVersionEvent.Response.data.APPS;
		Constants.FILE_SERVER_HOST = mVersionEvent.Response.data.FILE;
		Constants.FILE_PATH = mVersionEvent.Response.data.PATH;
		Constants.NOTE_SERVER_HOST = mVersionEvent.Response.data.NOTE;
		Constants.EXTR_SERVER_HOST = mVersionEvent.Response.data.EXTR;
		Constants.EXTR_SERVER_PORT = int.Parse(mVersionEvent.Response.data.PORT);

		CheckDevice();
	}

	void CheckDevice(){
		if(Application.platform == RuntimePlatform.IPhonePlayer){
			EventDelegate eventd = new EventDelegate(CheckUID);
			IOSMgr.GetUID("", eventd);
		} else{
			CheckUID();
		}
	}

	void CheckUID(){
		string deviceID;
		if(Application.platform == RuntimePlatform.IPhonePlayer){
			deviceID = IOSMgr.GetMsg();
		} else{
			deviceID = SystemInfo.deviceUniqueIdentifier;
		}

		mCheckEvent = new LoginEvent(new EventDelegate(ReceivedChecking));
		NetMgr.CheckDevice(deviceID, mCheckEvent);
	}

	void ReceivedChecking(){
		if(mCheckEvent.Response.code == 1){
			transform.FindChild("Terms").gameObject.SetActive(true);
			return;
		}

		Login();
	}

	void Login(){
		mLoginInfo = new LoginInfo();

		if(mNick == null)
			mLoginInfo.nick = mCheckEvent.Response.data.nick;
		else
			mLoginInfo.nick = mNick;

		if (Application.platform == RuntimePlatform.Android) {
			mLoginInfo.osType = 1;
			AndroidMgr.RegistGCM(new EventDelegate(this, "SetGCMId"));
		} else if (Application.platform == RuntimePlatform.IPhonePlayer) {
			mLoginInfo.osType = 2;
			//			if(CheckPushAgree()){
			//				mLoginInfo.memUID = "";
			//				//                NetMgr.DoLogin (mLoginInfo, mLoginEvent);
			//				SetGCMId();
			//			} else{
			IOSMgr.RegistAPNS(new EventDelegate(this, "SetGCMId"));
			//waiting 4 secs
			StartCoroutine(WaitingToken());
			//			}
		} else if(Application.platform == RuntimePlatform.OSXEditor){
			mLoginInfo.osType = 1;
			mLoginInfo.memUID = "";
			//            NetMgr.DoLogin (mLoginInfo, mLoginEvent);
			SetGCMId();
		}
	}

	public void SetGCMId()
	{
		UtilMgr.DismissLoading();
		#if(UNITY_EDITOR)
		mLoginInfo.memUID = AndroidMgr.GetMsg();
		mLoginInfo.DeviceID = SystemInfo.deviceUniqueIdentifier;
		DoLogin();
		#elif(UNITY_ANDROID)
		mLoginInfo.memUID = AndroidMgr.GetMsg();
		mLoginInfo.DeviceID = SystemInfo.deviceUniqueIdentifier;
		DoLogin();
		#else
		StopCoroutine(WaitingToken());
		mLoginInfo.memUID = IOSMgr.GetMsg();
		EventDelegate eventd = new EventDelegate(this, "DoLogin");
		IOSMgr.GetUID("", eventd);
		#endif
	}

	void DoLogin(){
		if(Application.platform == RuntimePlatform.IPhonePlayer)
			mLoginInfo.DeviceID = IOSMgr.GetMsg();

		Debug.Log("ID is "+mLoginInfo.DeviceID);
		//        NetMgr.DoLogin (mLoginInfo, mLoginEvent, UtilMgr.IsTestServer(), true);
		mLoginEvent = new LoginEvent(new EventDelegate(ReceivedLogin));
		NetMgr.LoginGuest(mLoginInfo, mLoginEvent, UtilMgr.IsTestServer(), true);
	}

	IEnumerator WaitingToken(){
		UtilMgr.ShowLoading(true);
		yield return new WaitForSeconds(3f);
		Debug.Log("Skip Token");
		IOSMgr.SkipToken();
		
	}

	void ReceivedLogin(){
		mProfileEvent = new GetProfileEvent(new EventDelegate(ReceivedProfile));
		NetMgr.GetProfile(mLoginEvent.Response.data.memSeq, mProfileEvent);
	}

	void ReceivedProfile(){
//		DialogueMgr.ShowDialogue("ok", mProfileEvent.Response.data.nick, DialogueMgr.DIALOGUE_TYPE.Alert, null);
		AutoFade.LoadLevel("Landing");
	}

	void MustUpdate(){
		mMustUpdate = true;
		DialogueMgr.ShowDialogue(UtilMgr.GetLocalText("StrCheckVersion"), UtilMgr.GetLocalText("StrMustUpdate"), DialogueMgr.DIALOGUE_TYPE.YesNo,
		                         UtilMgr.GetLocalText("StrUpdate"), "", UtilMgr.GetLocalText("StrExit"),
		                         DialogueClickHandler);
	}
	
	void ReqUpdate(){
		mMustUpdate = false;
		DialogueMgr.ShowDialogue(UtilMgr.GetLocalText("StrCheckVersion"), UtilMgr.GetLocalText("StrRecommendUpdate"), DialogueMgr.DIALOGUE_TYPE.YesNo,
		                         UtilMgr.GetLocalText("StrUpdate"), "", UtilMgr.GetLocalText("StrSkip"),
		                         DialogueClickHandler);
	}

	public void DialogueClickHandler(DialogueMgr.BTNS btn){
		if(mMustUpdate){
			if(btn == DialogueMgr.BTNS.Btn1){
				Debug.Log("Go to Store");
				#if(UNITY_ANDROID)
				Application.OpenURL(Constants.STORE_GOOGLE);
				#else
				Application.OpenURL(Constants.STORE_IPHONE);
				#endif
			} else{
				UtilMgr.Quit();
			}
		} else{
			if(btn == DialogueMgr.BTNS.Btn1){
				Debug.Log("Go to Store");
				#if(UNITY_ANDROID)
				Application.OpenURL(Constants.STORE_GOOGLE);
				#else
				Application.OpenURL(Constants.STORE_IPHONE);
				#endif
			} else{
				CheckPreference();
			}
		}
	}

	public void SetNick(string nick){
		mNick = nick;
	}
}