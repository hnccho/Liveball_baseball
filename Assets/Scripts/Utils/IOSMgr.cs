using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class IOSMgr : MonoBehaviour
{
	EventDelegate mEventDelegate;
	static IOSMgr _instance;
	string mMsg;
	bool gotToken = false;

	[DllImport("__Internal")]
	private static extern void OpenGallery(string str);
	[DllImport("__Internal")]
	private static extern void iOSInAppInit(string strProductIds);
	[DllImport("__Internal")]
	private static extern void iOSBuyItem(string strProductId);
	[DllImport("__Internal")]
	private static extern void iOSRestoreCompletedTransactions();
	[DllImport("__Internal")]
	private static extern void GetUID(string str);

	public delegate void purchaseSucceeded(string receipt);
	public delegate void purchaseFailed(string receipt);
	public static event purchaseSucceeded PurchaseSucceededEvent;
	public static event purchaseFailed PurchaseFailedEvent;




	#if(UNITY_EDITOR)
	public static void CallIOSFunc( string strFuncName, string str){}
	#elif(UNITY_ANDROID)
	public static void CallIOSFunc( string strFuncName, string str)
	{
	}
	#else
	public void NotiReceived()
	{
		Debug.Log("AlertBody : "+UnityEngine.iOS.NotificationServices.remoteNotifications[0].alertBody);
		ICollection col = UnityEngine.iOS.NotificationServices.remoteNotifications[0].userInfo.Keys;
		IEnumerator enu = col.GetEnumerator();
		while(enu.MoveNext()){
			Debug.Log ("key : "+enu.Current);
		}
		//		for(int i = 0; i < col.Count; i++){
		//			Debug.Log("key("+i+") : "+col.);
		//			Debug.Log("value("+i+") : "+UnityEngine.iOS.NotificationServices.remoteNotifications[0].userInfo.Values[i]);
		//		}
		string type = UnityEngine.iOS.NotificationServices.remoteNotifications[0].userInfo["type"].ToString();
		string info = UnityEngine.iOS.NotificationServices.remoteNotifications[0].userInfo["info"].ToString();
		
		//		Dictionary<string, object> dic = new Dictionary<string, object>();
		NotiMsgInfo notiInfo = new NotiMsgInfo();
		notiInfo.type = type;
		notiInfo.info = Newtonsoft.Json.JsonConvert.DeserializeObject<NotiQuizInfo>(info);
		//		dic.Add("type", type);
		//		dic.Add("info", quizInfo);
		
//		Debug.Log("NotiReceived : "+UtilMgr.OnPause);
//		if(!UtilMgr.OnPause)
//			QuizMgr.NotiReceived (notiInfo);
		
		UnityEngine.iOS.NotificationServices.ClearRemoteNotifications();
	}

	public static void CallIOSFunc( string strFuncName, string str){
		switch(strFuncName){
		case "OpenGallery":
			OpenGallery(str);
			break;
		}
	}

	void Update(){
		if(UnityEngine.iOS.NotificationServices.remoteNotifications.Length > 0){
			Debug.Log("noti received");
			NotiReceived();
		} else{
//			Debug.Log("none");
		}

		if(gotToken)
			return;

		if(UnityEngine.iOS.NotificationServices.registrationError != null){
			mMsg = "";
			Debug.Log("token is "+mMsg);
			gotToken = true;
			mEventDelegate.Execute();
		}
		
		if(UnityEngine.iOS.NotificationServices.deviceToken != null){
//			string token = System.Text.Encoding.UTF8.GetString(UnityEngine.iOS.NotificationServices.deviceToken);
			mMsg = System.BitConverter.ToString(UnityEngine.iOS.NotificationServices.deviceToken)
				.Replace("-", "").ToLower();
			Debug.Log("token is "+mMsg);
			gotToken = true;
			mEventDelegate.Execute();
		}
//		else
//			Debug.Log("token is null");
	}

	#endif
	private static IOSMgr Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = FindObjectOfType(typeof(IOSMgr)) as IOSMgr;
				Debug.Log("IOSMgr is null");
				if (_instance == null)
				{
					GameObject container = new GameObject();  
					container.name = "IOSMgr";  
					_instance = container.AddComponent(typeof(IOSMgr)) as IOSMgr;
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

	public static string GetMsg()
	{
		return Instance.mMsg;
	}

	public void MsgReceived(string msg)
	{
		Debug.Log ("Android Msg Received : " + msg);
		mMsg = msg;
		mEventDelegate.Execute ();
	}

	public void ErrorReceived(string msg)
	{
		Debug.Log (msg);
	}

	public static void OpenCamera(EventDelegate eventDelegate){
		Instance.mEventDelegate = eventDelegate;
		string timeStr = UtilMgr.GetDateTime ("yyyy-MM-dd HH:mm:ss");
		timeStr += " by lb.jpg";
		IOSMgr.CallIOSFunc("OpenCamera", timeStr);
	}

	public static void OpenGallery(EventDelegate eventDelegate){
		Instance.mEventDelegate = eventDelegate;
		IOSMgr.CallIOSFunc("OpenGallery", "");
	}

	public static void GetGalleryImages(EventDelegate eventDelegate){
		Instance.mEventDelegate = eventDelegate;
		IOSMgr.CallIOSFunc("GetGalleryImages", "");
	}

	public static void RegistGCM(EventDelegate eventDelegate){
		Instance.mEventDelegate = eventDelegate;
		IOSMgr.CallIOSFunc("RegisterGCM", "");
	}

	public static void ViberateDevice(long millSec){
		IOSMgr.CallIOSFunc("ViberateDevice", string.Format("{0}", millSec));
	}

	public static void OpenFB(EventDelegate eventDelegate){
		Instance.mEventDelegate = eventDelegate;
		IOSMgr.CallIOSFunc("OpenFB", "");
	}

	public static void GetHeightStatusBar(){
		IOSMgr.CallIOSFunc("GetHeightStatusBar", "");
	}
	public void GotHeightStatusBar(string height){
		Constants.HEIGHT_STATUS_BAR = int.Parse(height);
		Debug.Log("Size of StatusBar is "+Constants.HEIGHT_STATUS_BAR);
	}


	/////////////////////////


	public static void RegistAPNS(EventDelegate eventDelegate){
		Instance.gotToken = false;
		Instance.mEventDelegate = eventDelegate;
		#if(UNITY_ANDROID)
		#else
		UnityEngine.iOS.NotificationServices.RegisterForNotifications(
			UnityEngine.iOS.NotificationType.Alert |
			UnityEngine.iOS.NotificationType.Badge |
			UnityEngine.iOS.NotificationType.Sound
			);
		#endif

	}

	public static void SkipToken(){
		Instance.mMsg = "";
		Instance.gotToken = true;
		Instance.mEventDelegate.Execute();
	}

	public static void InAppInit(string prodList, EventDelegate eventDelegate){
		Instance.mEventDelegate = eventDelegate;
		iOSInAppInit(prodList);
	}

	public static void InAppInit(){
		iOSInAppInit("");
	}

	public static void BuyItem(string strProductId){
		iOSBuyItem(strProductId);
	}

	public void ResultBuyItem(string strResult){
		DialogueMgr.ShowDialogue("result", strResult, DialogueMgr.DIALOGUE_TYPE.Alert, null);
	}

	public void RestorecompletedTransactions(){
		iOSRestoreCompletedTransactions();
	}

	public void PurchaseSucceeded(string receipt){
		Debug.Log("purchaseSucceeded : "+receipt);
		PurchaseSucceededEvent(receipt);
	}

	public void PurchaseFailed(string receipt){
		Debug.Log("purchaseFailed : "+receipt);
		PurchaseFailedEvent(receipt);
	}

	public static void GetUID(string msg, EventDelegate eventDelegate){
		Instance.mEventDelegate = eventDelegate;
		GetUID(msg);
	}

//	public void DisagreePush(string str){
//		DialogueMgr.ShowDialogue("disagree", "disagree", DialogueMgr.DIALOGUE_TYPE.Alert, null);
//	}



}