using UnityEngine;
using System.Collections;

public class SuperRoot : MonoBehaviour {
		
	void Start () {
		
		transform.FindChild ("Camera").transform.localPosition = new Vector3(0f, UtilMgr.GetScaledPositionY(), -2000f);
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}
	
	void Awake(){		
		if(GetComponent<AudioSource>() == null){
			gameObject.AddComponent<AudioSource>();
		}
		Debug.Log("frameRate is "+Application.targetFrameRate);		
		Debug.Log("vSyncCount is "+QualitySettings.vSyncCount);		
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 20;
	}
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
//			if(Application.loadedLevelName.Equals("SceneMain")){
//				if(!transform.FindChild("TF_Betting").gameObject.activeSelf){
//					OnBackPressed ();
//				}
//			}else{
//				OnBackPressed ();
//			}
		}
		
	}
	
	void OnApplicationFocus(bool focus){
//		UtilMgr.OnFocus = focus;
//		Debug.Log("Application focus : "+focus);
	}
	
	void OnApplicationPause(bool pause){
//		UtilMgr.OnPause = pause;
//		Debug.Log("Application pause : "+pause);
//		if(!pause)
//			UtilMgr.DismissLoading();
	}
	
	public void OnBackPressed()
	{
//		if (DialogueMgr.IsShown) {
//			DialogueMgr.Instance.BtnCancelClicked();
//		} else {
//			UtilMgr.OnBackPressed ();
//			if(Application.loadedLevelName.Equals("SceneMain")){
//				
//				if(transform.FindChild("TF_Livetalk").gameObject.activeSelf){
//					transform.FindChild("TF_Livetalk").FindChild("Panel").FindChild("Input").GetComponent<UIInput>().OpenKeboard();
//				}
//			}
//		}
	}
}
