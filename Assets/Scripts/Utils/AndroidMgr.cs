using UnityEngine;
using System.Collections;

public class AndroidMgr : MonoBehaviour
{
	EventDelegate mEventDelegate;
	static AndroidMgr _instance;
	string mMsg;

	#if(UNITY_EDITOR)
	public static void CallJavaFunc( string strFuncName, string str){}
	#elif(UNITY_ANDROID)
	private AndroidJavaObject curActivity;

	void Awake()
	{
		AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		curActivity = jc.GetStatic<AndroidJavaObject>("currentActivity");
		DontDestroyOnLoad (this);
	}

	public static void CallJavaFunc( string strFuncName, string str)
	{
		if( Instance.curActivity == null )
			return;

		Instance.curActivity.Call( strFuncName, str);
	}

//	public void SetGalleryImage(string image)
//	{
//		ScriptItemPhoto sip = mReceiver as ScriptItemPhoto;
//		sip.SetImgData (image);
//	}

	public void SetGalleryImages(string images)
	{
//		if(images.Length < 1)
//		{
//			AndroidMgr.Instance.strLog = "no Images";
//		}
//
//		JSONObject json = new JSONObject (images);
//
//		ScriptUpload su = mReceiver as ScriptUpload;
//
//		su.setImageDictionary (json);

	}

#else
	public static void CallJavaFunc( string strFuncName, string str){}

#endif
	private static AndroidMgr Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = FindObjectOfType(typeof(AndroidMgr)) as AndroidMgr;
				Debug.Log("AndroidMgr is null");
				if (_instance == null)
				{
					GameObject container = new GameObject();  
					container.name = "AndroidMgr";  
					_instance = container.AddComponent(typeof(AndroidMgr)) as AndroidMgr;
					Debug.Log("and makes new one");
					
				}
			}
			
			return _instance;
		}
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

	public void NotiReceived(string msg)
	{
		Debug.Log("NotiReceived : "+UtilMgr.OnPause);
		if(!UtilMgr.OnPause)
			QuizMgr.NotiReceived (msg);
	}

	public static void OpenCamera(EventDelegate eventDelegate){
		Instance.mEventDelegate = eventDelegate;
		string timeStr = UtilMgr.GetDateTime ("yyyy-MM-dd HH:mm:ss");
		timeStr += " by lb.jpg";
		AndroidMgr.CallJavaFunc("OpenCamera", timeStr);
	}

	public static void OpenGallery(EventDelegate eventDelegate){
		Instance.mEventDelegate = eventDelegate;
		AndroidMgr.CallJavaFunc("OpenGallery", "");
	}

	public static void GetGalleryImages(EventDelegate eventDelegate){
		Instance.mEventDelegate = eventDelegate;
		AndroidMgr.CallJavaFunc("GetGalleryImages", "");
	}

	public static void RegistGCM(EventDelegate eventDelegate){
		Instance.mEventDelegate = eventDelegate;
		AndroidMgr.CallJavaFunc("RegisterGCM", "");
	}

	public static void ViberateDevice(long millSec){
		AndroidMgr.CallJavaFunc("ViberateDevice", string.Format("{0}", millSec));
	}

	public static void OpenFB(EventDelegate eventDelegate){
		Instance.mEventDelegate = eventDelegate;
		AndroidMgr.CallJavaFunc("OpenFB", "");
	}

	public static void GetHeightStatusBar(){
		AndroidMgr.CallJavaFunc("GetHeightStatusBar", "");
	}
	public void GotHeightStatusBar(string height){
		Constants.HEIGHT_STATUS_BAR = int.Parse(height);
		Debug.Log("Size of StatusBar is "+Constants.HEIGHT_STATUS_BAR);
	}


}